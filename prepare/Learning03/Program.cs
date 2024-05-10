using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var scriptures = new List<Scripture>
        {
            new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture("Proverbs 3:5-6", "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.")
        };

        foreach (var scripture in scriptures)
        {
            RunScriptureGame(scripture);
        }
    }

    static void RunScriptureGame(Scripture scripture)
    {
        var hiddenWords = new HashSet<int>();
        var allWords = scripture.Text.Split(' ');

        while (hiddenWords.Count < allWords.Length)
        {
            Console.Clear();
            DisplayScripture(scripture, hiddenWords);
            Console.WriteLine("\nPress Enter to hide a word or type 'quit' to exit.");
            var input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            var random = new Random();
            int wordIndex;
            do
            {
                wordIndex = random.Next(allWords.Length);
            } while (hiddenWords.Contains(wordIndex));

            hiddenWords.Add(wordIndex);
        }
    }

    static void DisplayScripture(Scripture scripture, HashSet<int> hiddenWords)
    {
        var allWords = scripture.Text.Split(' ');

        for (int i = 0; i < allWords.Length; i++)
        {
            if (hiddenWords.Contains(i))
                Console.Write("______ ");
            else
                Console.Write(allWords[i] + " ");
        }

        Console.WriteLine($"\n\n{scripture.Reference}: {scripture.Text}");
    }
}

class Scripture
{
    public string Reference { get; }
    public string Text { get; }

    public Scripture(string reference, string text)
    {
        Reference = reference;
        Text = text;
    }
}
