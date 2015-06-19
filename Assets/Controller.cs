using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour
{
	[SerializeField]
	private InputField inputField;
	[SerializeField]
	private Text textField;

	RandomText generator;

	private string[] words = new string[] { "ik", "hallo", "je", "het", "een", "goed", "van", "en", "is", "voor",
											"dat", "met", "in", "zijn", "mooi", "jij", "de", "leuk", "niet", "mijn",
											"gaan", "lief", "nog", "ook", "veel", "groeten", "maar", "wat", "op",											"naar", "hoe", "ben", "als", "Zweeds", "jou", "lekker", "dag", "hoi",											"kus", "dan", "kunnen", "meisje", "Zweden", "wil", "eten", "heb", "liefde",											"hebben", "mij", "doei", "huis", "meer", "groetjes", "jullie", "bedankt",											"waar", "zien", "doen", "vakantie", "om", "willen", "aan", "alles", "ja",											"ga", "vinden", "bij", "zeggen", "of", "te", "geen", "gefeliciteerd",											"morgen", "kan", "weer", "leren", "zo", "Nederland", "gaat", "vriend",											"snel", "omdat", "die", "nu", "heel", "maken", "tot", "slapen", "hou",
											"goedemorgen", "er", "was", "gek", "schat" };

	void Start ()
	{
		inputField.onValidateInput += delegate(string input, int charIndex, char addedChar) { return Validate(addedChar); };

		generator = new RandomText(words);
		generator.AddContentParagraphs(1, 1, 1, 100, 1000);
		textField.text = generator.Content;
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
		// Check if the typed text is the same as the shown text.


		inputField.text = "";
	}
}
