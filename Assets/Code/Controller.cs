using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour
{
	[SerializeField]
	private InputField inputField;
	[SerializeField]
	private Text textField;

	private RandomText generator;

	private string[] originalText;
	private string[] shownText;
	private int index;

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
		inputField.onValidateInput += delegate(string input, int charIndex, char addedChar) { return Validate(addedChar); };

		generator = new RandomText(words);
		generator.AddContentParagraphs(1, 1, 1, 100, 1000);

		originalText = generator.Content.Split(' ');
		shownText = (string[])originalText.Clone();
		shownText[index] = "<b>" + shownText[index] + "</b>";
		textField.text = string.Join(" ", shownText);
	}

	char Validate(char c)
	{
		if (c == ' ')
		{
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
		}
		else
		{
			shownText[index] = "<color=red>" + originalText[index] + "</color>";
		}

		// Highlight next word.
		shownText[index + 1] = "<b>" + originalText[index + 1] + "</b>";
		textField.text = string.Join(" ", shownText);

		index++;
		inputField.text = string.Empty;
	}
}
