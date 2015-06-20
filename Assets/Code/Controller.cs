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

	private string[] currentText;
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

		currentText = generator.Content.Split(' ');
		currentText[index] = "<b>" + currentText[index] + "</b>";
		textField.text = string.Join(" ", currentText);
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
		currentText = textField.text.Split(' ');

		// Check if the typed text is the same as the shown text.
		if (inputField.text == currentText[index].Replace("<b>", string.Empty).Replace("</b>", string.Empty))
		{
			currentText[index] = "<color=green>" + currentText[index].Replace("<b>", string.Empty).Replace("</b>", string.Empty) + "</color>";
		}
		else
		{
			currentText[index] = "<color=red>" + currentText[index].Replace("<b>", string.Empty).Replace("</b>", string.Empty) + "</color>";
		}

		currentText[index + 1] = "<b>" + currentText[index + 1] + "</b>";

		textField.text = string.Join(" ", currentText);
		index++;
		inputField.text = "";
	}
}
