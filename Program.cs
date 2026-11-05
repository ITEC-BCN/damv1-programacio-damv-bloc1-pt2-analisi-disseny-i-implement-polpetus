using System;

class Program
{
    static void Main()
    {
        // Constants
        const int POKEDEX_SIZE = 15;
        const int OPTION_LIST = 1;
        const int OPTION_EXIT = 0;
        const string EMPTY_SLOT = "Empty";

        // Console colors
        const ConsoleColor TITLE_COLOR = ConsoleColor.Cyan;
        const ConsoleColor INDEX_COLOR = ConsoleColor.DarkYellow;
        const ConsoleColor NAME_COLOR = ConsoleColor.White;
        const ConsoleColor EMPTY_COLOR = ConsoleColor.DarkGray;
        const ConsoleColor PROMPT_COLOR = ConsoleColor.Yellow;
        const ConsoleColor SUCCESS_COLOR = ConsoleColor.Green;
        const ConsoleColor WARNING_COLOR = ConsoleColor.Yellow;
        const ConsoleColor ERROR_COLOR = ConsoleColor.Red;

        string[] pokedex =
        {
            "Pikachu", "Charizard", "Eevee",
            "Rowlet", "Litten", "Popplio", "Rockruff", "Mimikyu",
            "Togedemaru", "Salandit", "Wishiwashi", "Oricorio",
            "Crabrawler", "Bewear", "Tapu Koko"
        };

        int option;
        bool isValidOption;

        do
        {
            do
            {
                Console.WriteLine();
                Console.ForegroundColor = TITLE_COLOR;
                Console.WriteLine("Choose an option:");
                Console.ForegroundColor = INDEX_COLOR;
                Console.Write($"{OPTION_LIST}- ");
                Console.ResetColor();
                Console.WriteLine("List Pokémon");
                Console.ForegroundColor = INDEX_COLOR;
                Console.Write($"{OPTION_EXIT}- ");
                Console.ResetColor();
                Console.WriteLine("Exit");
                Console.ForegroundColor = PROMPT_COLOR;
                Console.Write("> ");
                Console.ResetColor();

                isValidOption = int.TryParse(Console.ReadLine(), out option)
                                && (option == OPTION_LIST || option == OPTION_EXIT);

                if (!isValidOption)
                {
                    Console.ForegroundColor = ERROR_COLOR;
                    Console.WriteLine("Error: invalid option.");
                    Console.ResetColor();
                }
            } while (!isValidOption);

            if (option == OPTION_LIST)
            {
                // Show the Pokédex
                Console.WriteLine();
                Console.ForegroundColor = TITLE_COLOR;
                Console.WriteLine("Your Pokédex contains:");
                Console.ResetColor();

                for (int i = 0; i < pokedex.Length; i++)
                {
                    Console.ForegroundColor = INDEX_COLOR;
                    Console.Write($"{i + 1}. ");
                    Console.ForegroundColor = pokedex[i] == EMPTY_SLOT ? EMPTY_COLOR : NAME_COLOR;
                    Console.WriteLine(pokedex[i]);
                    Console.ResetColor();
                }

                int index;
                bool isValidIndex;

                do
                {
                    Console.WriteLine();
                    Console.ForegroundColor = TITLE_COLOR;
                    Console.WriteLine("Which Pokémon do you want to release? Enter the index:");
                    Console.ForegroundColor = PROMPT_COLOR;
                    Console.Write("> ");
                    Console.ResetColor();

                    isValidIndex = int.TryParse(Console.ReadLine(), out index)
                                   && index >= 1 && index <= POKEDEX_SIZE;

                    if (!isValidIndex)
                    {
                        Console.ForegroundColor = ERROR_COLOR;
                        Console.WriteLine($"Error: enter a number between 1 and {POKEDEX_SIZE}.");
                        Console.ResetColor();
                    }
                } while (!isValidIndex);

                // The user sees 1-15, the array uses 0-14
                int position = index - 1;

                Console.WriteLine();

                if (pokedex[position] == EMPTY_SLOT)
                {
                    Console.ForegroundColor = WARNING_COLOR;
                    Console.WriteLine($"The index {index} is empty. There's no Pokémon in that slot to release.");
                }
                else
                {
                    Console.ForegroundColor = SUCCESS_COLOR;
                    Console.WriteLine($"You released {pokedex[position]}!");
                    pokedex[position] = EMPTY_SLOT;
                }

                Console.ResetColor();
            }
        } while (option != OPTION_EXIT);

        Console.ForegroundColor = TITLE_COLOR;
        Console.WriteLine("Goodbye!");
        Console.ResetColor();
    }
}