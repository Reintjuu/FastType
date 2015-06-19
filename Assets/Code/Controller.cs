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

	private string[] textContent;
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
		
		textField.text = generator.Content;
		textContent = generator.Content.Split(' ');
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
		string[] currentText = textField.text.Split(' ');

		// Check if the typed text is the same as the shown text.
		if (inputField.text == textContent[index])
		{
			currentText[index] = "<color=green>" + currentText[index] + "</color>";
		}
		else
		{
			currentText[index] = "<color=red>" + currentText[index] + "</color>";
		}

		textField.text = string.Join(" ", currentText);
		index++;
		inputField.text = "";
	}
}
