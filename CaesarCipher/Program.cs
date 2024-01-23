using System;

class CaesarCipher
{
	static void Main()
	{
		Console.Write("Enter the text: ");
		string inputText = Console.ReadLine();

		Console.Write("Enter the key (integer): ");
		int key = int.Parse(Console.ReadLine());

		Console.Write("Encrypt or Decrypt? (E/D): ");
		char choice = Console.ReadLine().ToUpper()[0];

		string resultText = "";

		switch (choice)
		{
			case 'E':
				resultText = Encrypt(inputText, key);
				break;
			case 'D':
				resultText = Decrypt(inputText, key);
				break;
			default:
				Console.WriteLine("Invalid choice. Please enter 'E' or 'D'.");
				return;
		}

		Console.WriteLine($"Result: {resultText}");
	}

	static string Encrypt(string text, int key)
	{
		char[] characters = text.ToCharArray();

		for (int i = 0; i < characters.Length; i++)
		{
			if (Char.IsLetter(characters[i]))
			{
				char start = characters[i] >= 'A' && characters[i] <= 'Z' ? 'A' : 'a';
				characters[i] = (char)((characters[i] - start + key) % 26 + start);
			}
		}

		return new string(characters);
	}

	static string Decrypt(string text, int key)
	{
		return Encrypt(text, 26 - key);
	}
}
