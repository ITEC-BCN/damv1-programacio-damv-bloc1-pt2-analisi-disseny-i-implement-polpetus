using System;

class Program
{
    static void Main()
    {
        // Constants
        const char SPACE = ' ';

        // Console colors
        const ConsoleColor TITLE_COLOR = ConsoleColor.Cyan;
        const ConsoleColor PROMPT_COLOR = ConsoleColor.Yellow;
        const ConsoleColor SUCCESS_COLOR = ConsoleColor.Green;
        const ConsoleColor ERROR_COLOR = ConsoleColor.Red;

        Console.ForegroundColor = TITLE_COLOR;
        Console.WriteLine("The King of Hyrule is waiting for the hero's registration!");
        Console.ResetColor();

        string heroName;
        bool isValid;

        // Ask for the name until it is valid
        do
        {
            Console.WriteLine();
            Console.ForegroundColor = TITLE_COLOR;
            Console.WriteLine("Enter the hero's name:");
            Console.ForegroundColor = PROMPT_COLOR;
            Console.Write("> ");
            Console.ResetColor();

            // ReadLine() can return null, and Trim() removes the extra spaces at the start and the end
            heroName = (Console.ReadLine() ?? string.Empty).Trim();

            // The name can't be empty and can only contain letters (and spaces between words)
            isValid = heroName.Length > 0;

            // The loop stops as soon as a wrong character is found (isValid becomes false)
            for (int i = 0; i < heroName.Length && isValid; i++)
            {
                if (!char.IsLetter(heroName[i]) && heroName[i] != SPACE)
                {
                    isValid = false;
                }
            }

            if (!isValid)
            {
                Console.ForegroundColor = ERROR_COLOR;
                Console.WriteLine("Error: the name can't be empty and can only contain letters.");
                Console.ResetColor();
            }
        } while (!isValid);

        // First letter in uppercase and the rest in lowercase
        string normalizedName = char.ToUpperInvariant(heroName[0]) + heroName.Substring(1).ToLowerInvariant();

        Console.WriteLine();
        Console.ForegroundColor = SUCCESS_COLOR;
        Console.WriteLine($"Welcome, {normalizedName}! Hyrule trusts you.");
        Console.ResetColor();
    }
}