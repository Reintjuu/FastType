using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour
{
	[SerializeField]
	private InputField inputField;
	[SerializeField]
	private Text textField;
	[SerializeField]
	private Countdown timer;
	[SerializeField]
	private int minutes;

	private RandomText generator;

	private string[] originalText;
	private string[] shownText;
	private int index;
	private int corrects;
	private int errors;
	private bool started;

	private string[] words = new string[] { "ik", "hallo", "je", "het", "een", "goed", "van", "en", "is", "voor",
											"dat", "met", "in", "zijn", "mooi", "jij", "de", "leuk", "niet", "mijn",
											"gaan", "lief", "nog", "ook", "veel", "groeten", "maar", "wat", "op",
											"naar", "hoe", "ben", "als", "Zweeds", "jou", "lekker", "dag", "hoi",
											"kus", "dan", "kunnen", "meisje", "Zweden", "wil", "eten", "heb", "liefde",
											"hebben", "mij", "doei", "huis", "meer", "groetjes", "jullie", "bedankt",
											"waar", "zien", "doen", "vakantie", "om", "willen", "aan", "alles", "ja",
											"ga", "vinden", "bij", "zeggen", "of", "te", "geen", "gefeliciteerd",
											"morgen", "kan", "weer", "leren", "zo", "Nederland", "gaat", "vriend",
											"snel", "omdat", "die", "nu", "heel", "maken", "tot", "slapen", "hou",
											"goedemorgen", "er", "was", "gek", "schat" };

	void Start ()
	{
		index = 0;
		started = false;
		timer.setText(minutes + ":00.00");

		generator = new RandomText(words);
		generator.AddContentParagraphs(1, 1, 1, 100, 1000);

		originalText = generator.Content.Split(' ');
		shownText = (string[])originalText.Clone();
		shownText[index] = "<color=black>" + shownText[index] + "</color>";
		textField.text = string.Join(" ", shownText);

		inputField.onValidateInput += delegate(string input, int charIndex, char addedChar) { return Validate(addedChar); };
	}

	char Validate(char c)
	{
		if(!started)
		{
			started = true;
			timer.StartCountdown(0, minutes, 0, OnCountdownEnd);
		}

		// Check if a space is entered...
		if (c == ' ')
		{
			// ... if it is, replace it with an empty char.
			c = '\0';
			Submit();
		}
		return c;
	}

	void Submit()
	{
		shownText = textField.text.Split(' ');

		// Check if the typed word is the same as the corresponding word.
		if (inputField.text == originalText[index])
		{
			shownText[index] = "<color=green>" + originalText[index] + "</color>";

			// We're including spaces, so add 1 to the amount of correct inputs.
			corrects += originalText[index].Length + 1;
		}
		else
		{
			shownText[index] = "<color=red>" + originalText[index] + "</color>";
			errors += originalText[index].Length + 1;
		}

		print("Corrects: " + corrects + ", Errors: " + errors + ", WPM: " + GrossWPM(corrects, minutes));

		// Highlight next word.
		shownText[index + 1] = "<color=black>" + originalText[index + 1] + "</color>";
		textField.text = string.Join(" ", shownText);

		index++;
		inputField.text = string.Empty;
	}

	void OnCountdownEnd()
	{
		inputField.DeactivateInputField();
		inputField.interactable = false;
		started = false;

		print("Corrects: " + corrects + ", Errors: " + errors + ", WPM: " + GrossWPM(corrects, minutes));
	}

	// Calculate WPM: http://www.speedtypingonline.com/typing-equations
	float NetWPM(int correctEntries, int incorrectEntries, int timeInMinutes)
	{
		return ((correctEntries / 5) - incorrectEntries) / timeInMinutes; 
	}

	float GrossWPM(int correctEntries, int timeInMinutes)
	{
		return (correctEntries / 5) / timeInMinutes;
	}
}
