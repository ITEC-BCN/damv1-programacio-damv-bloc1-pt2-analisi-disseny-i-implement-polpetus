using System;

class Program
{
    // Constants
    const int MIN_LENGTH = 3;
    const int MAX_LENGTH = 16;
    const char SPACE = ' ';
    const char UNDERSCORE = '_';
    const string RESERVED_NAME = "admin";

    // Console colors
    const ConsoleColor TITLE_COLOR = ConsoleColor.Cyan;
    const ConsoleColor PROMPT_COLOR = ConsoleColor.Yellow;
    const ConsoleColor SUCCESS_COLOR = ConsoleColor.Green;
    const ConsoleColor ERROR_COLOR = ConsoleColor.Red;

    static void Main()
    {
        Console.ForegroundColor = TITLE_COLOR;
        Console.WriteLine("Summoner registration");
        Console.ResetColor();

        string name;
        string error;

        // Ask for the name until it follows all the rules
        do
        {
            Console.WriteLine();
            Console.ForegroundColor = TITLE_COLOR;
            Console.WriteLine("Enter your summoner name:");
            Console.ForegroundColor = PROMPT_COLOR;
            Console.Write("> ");
            Console.ResetColor();

            // No Trim() here: a name ending with a space must be rejected
            name = Console.ReadLine() ?? string.Empty;
            error = GetNameError(name);

            if (error != null)
            {
                Console.ForegroundColor = ERROR_COLOR;
                Console.WriteLine($"Invalid name: {error}");
                Console.ResetColor();
            }
        } while (error != null);

        Console.WriteLine();
        Console.ForegroundColor = SUCCESS_COLOR;
        Console.WriteLine($"Welcome to the Rift, {name}!");
        Console.ResetColor();
    }

    // Returns the first broken rule, or null if the name is valid
    static string GetNameError(string name)
    {
        if (name.Length < MIN_LENGTH || name.Length > MAX_LENGTH)
        {
            return $"it must have between {MIN_LENGTH} and {MAX_LENGTH} characters.";
        }

        if (char.IsDigit(name[0]))
        {
            return "it can't start with a number.";
        }

        if (name[name.Length - 1] == SPACE)
        {
            return "it can't end with a space.";
        }

        foreach (char character in name)
        {
            if (!char.IsLetterOrDigit(character) && character != UNDERSCORE)
            {
                return "it can only contain letters, digits and underscores.";
            }
        }

        if (string.Equals(name, RESERVED_NAME, StringComparison.OrdinalIgnoreCase))
        {
            return "this name is reserved.";
        }

        return null;
    }
}