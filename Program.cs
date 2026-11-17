using System;

class Program
{
    static void Main()
    {
        // Constants
        const string CENSOR = "****";
        const char WORD_SEPARATOR = ' ';

        // Console colors
        const ConsoleColor TITLE_COLOR = ConsoleColor.Cyan;
        const ConsoleColor PROMPT_COLOR = ConsoleColor.Yellow;
        const ConsoleColor SUCCESS_COLOR = ConsoleColor.Green;
        const ConsoleColor WARNING_COLOR = ConsoleColor.Red;
        const ConsoleColor ERROR_COLOR = ConsoleColor.Red;
        const ConsoleColor MESSAGE_COLOR = ConsoleColor.White;

        string[] bannedWords =
        {
            "noob", "nub", "uninstall", "trash", "ez", "bot", "garbage", "loser", "kys",
            "nigger", "niga", "niger" , "nigga", "faggot", "fag", "retard", "bitch", "cunt", "whore", "slut",
            "bastard", "idiot", "stupid", "dumbass", "asshole",
            "maricon", "marica", "maricón", "puta", "puto", "zorra", "cabron", "cabrón", "gilipollas",
            "imbecil", "imbécil", "subnormal", "mongolo", "capullo", "hijoputa"
        };

        // Punctuation that can be stuck to a word ("ez!" must be detected too)
        char[] punctuation = { '.', ',', ';', ':', '!', '?' };

        Console.ForegroundColor = TITLE_COLOR;
        Console.WriteLine("Summoner's Rift chat moderator");
        Console.ResetColor();

        string message;
        bool isValid;

        // Ask for the message until it is not empty
        do
        {
            Console.WriteLine();
            Console.ForegroundColor = TITLE_COLOR;
            Console.WriteLine("Enter a chat message:");
            Console.ForegroundColor = PROMPT_COLOR;
            Console.Write("> ");
            Console.ResetColor();

            message = Console.ReadLine() ?? string.Empty;
            isValid = message.Trim().Length > 0;

            if (!isValid)
            {
                Console.ForegroundColor = ERROR_COLOR;
                Console.WriteLine("Error: the message can't be empty.");
                Console.ResetColor();
            }
        } while (!isValid);

        // Check every word, ignoring uppercase and lowercase
        string[] words = message.Split(WORD_SEPARATOR);
        bool containsBannedWord = false;

        for (int i = 0; i < words.Length; i++)
        {
            string cleanWord = words[i].Trim(punctuation);
            bool isBanned = false;

            foreach (string bannedWord in bannedWords)
            {
                if (string.Equals(cleanWord, bannedWord, StringComparison.OrdinalIgnoreCase))
                {
                    isBanned = true;
                    break;
                }
            }

            if (isBanned)
            {
                // Only the word is replaced, so the punctuation stays
                words[i] = words[i].Replace(cleanWord, CENSOR);
                containsBannedWord = true;
            }
        }

        Console.WriteLine();
        Console.ForegroundColor = containsBannedWord ? WARNING_COLOR : SUCCESS_COLOR;
        Console.WriteLine(containsBannedWord
            ? "The message contains banned words!"
            : "The message is clean.");

        Console.ForegroundColor = TITLE_COLOR;
        Console.Write("Censored message: ");
        Console.ForegroundColor = MESSAGE_COLOR;
        Console.WriteLine(string.Join(WORD_SEPARATOR, words));
        Console.ResetColor();
    }
}