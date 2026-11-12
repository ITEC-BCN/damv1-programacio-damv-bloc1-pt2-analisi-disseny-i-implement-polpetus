using System;

class Program
{
    static void Main()
    {
        // Constants
        const int MAP_SIZE = 10;
        const int MAX_ATTEMPTS = 3;
        const double TREASURE_PROBABILITY = 0.1;
        const char GROUND = '0';
        const char TREASURE = '*';

        const int OPTION_DIG = 1;
        const int OPTION_SHOW_MAP = 2;
        const int OPTION_EXIT = 3;

        // Console colors
        const ConsoleColor TITLE_COLOR = ConsoleColor.Cyan;
        const ConsoleColor INDEX_COLOR = ConsoleColor.DarkYellow;
        const ConsoleColor PROMPT_COLOR = ConsoleColor.Yellow;
        const ConsoleColor SUCCESS_COLOR = ConsoleColor.Green;
        const ConsoleColor WARNING_COLOR = ConsoleColor.Yellow;
        const ConsoleColor ERROR_COLOR = ConsoleColor.Red;
        const ConsoleColor GROUND_COLOR = ConsoleColor.DarkGray;
        const ConsoleColor TREASURE_COLOR = ConsoleColor.Yellow;

        // Create the map and fill it randomly with ground or treasure
        char[,] map = new char[MAP_SIZE, MAP_SIZE];
        Random random = new Random();

        for (int row = 0; row < MAP_SIZE; row++)
        {
            for (int column = 0; column < MAP_SIZE; column++)
            {
                map[row, column] = random.NextDouble() < TREASURE_PROBABILITY ? TREASURE : GROUND;
            }
        }

        Console.ForegroundColor = TITLE_COLOR;
        Console.WriteLine("Welcome to the treasure explorer game!");
        Console.ResetColor();
        Console.WriteLine($"A {MAP_SIZE}x{MAP_SIZE} map with hidden treasures has been generated and you have {MAX_ATTEMPTS} attempts to get as many diamonds as possible...");

        int attemptsLeft = MAX_ATTEMPTS;
        int treasuresFound = 0;
        int option;
        bool isValid;

        do
        {
            // Ask for the menu option until it is valid
            do
            {
                Console.WriteLine();
                Console.ForegroundColor = TITLE_COLOR;
                Console.WriteLine("Main menu");
                Console.ForegroundColor = INDEX_COLOR;
                Console.Write($"{OPTION_DIG} - ");
                Console.ResetColor();
                Console.WriteLine("I want to dig!");
                Console.ForegroundColor = INDEX_COLOR;
                Console.Write($"{OPTION_SHOW_MAP} - ");
                Console.ResetColor();
                Console.WriteLine("Show the map");
                Console.ForegroundColor = INDEX_COLOR;
                Console.Write($"{OPTION_EXIT} - ");
                Console.ResetColor();
                Console.WriteLine("Exit");
                Console.ForegroundColor = PROMPT_COLOR;
                Console.Write("> ");
                Console.ResetColor();

                isValid = int.TryParse(Console.ReadLine(), out option)
                          && option >= OPTION_DIG && option <= OPTION_EXIT;

                if (!isValid)
                {
                    Console.ForegroundColor = ERROR_COLOR;
                    Console.WriteLine($"Error: enter a number between {OPTION_DIG} and {OPTION_EXIT}.");
                    Console.ResetColor();
                }
            } while (!isValid);

            if (option == OPTION_DIG)
            {
                Console.WriteLine();
                Console.ForegroundColor = SUCCESS_COLOR;
                Console.WriteLine("You chose to dig!");
                Console.ResetColor();

                // Ask for the row until it is valid
                int digRow;
                do
                {
                    Console.WriteLine($"Enter the row (0-{MAP_SIZE - 1}):");
                    Console.ForegroundColor = PROMPT_COLOR;
                    Console.Write("> ");
                    Console.ResetColor();

                    isValid = int.TryParse(Console.ReadLine(), out digRow)
                              && digRow >= 0 && digRow < MAP_SIZE;

                    if (!isValid)
                    {
                        Console.ForegroundColor = ERROR_COLOR;
                        Console.WriteLine($"Error: enter a number between 0 and {MAP_SIZE - 1}.");
                        Console.ResetColor();
                    }
                } while (!isValid);

                // Ask for the column until it is valid
                int digColumn;
                do
                {
                    Console.WriteLine($"Enter the column (0-{MAP_SIZE - 1}):");
                    Console.ForegroundColor = PROMPT_COLOR;
                    Console.Write("> ");
                    Console.ResetColor();

                    isValid = int.TryParse(Console.ReadLine(), out digColumn)
                              && digColumn >= 0 && digColumn < MAP_SIZE;

                    if (!isValid)
                    {
                        Console.ForegroundColor = ERROR_COLOR;
                        Console.WriteLine($"Error: enter a number between 0 and {MAP_SIZE - 1}.");
                        Console.ResetColor();
                    }
                } while (!isValid);

                attemptsLeft--;
                Console.WriteLine($"Digging at coordinates ({digRow},{digColumn})...");

                if (map[digRow, digColumn] == TREASURE)
                {
                    // The treasure is collected, so it can't be found twice
                    map[digRow, digColumn] = GROUND;
                    treasuresFound++;

                    Console.ForegroundColor = SUCCESS_COLOR;
                    Console.WriteLine("You found a treasure! :D");
                }
                else
                {
                    Console.ForegroundColor = WARNING_COLOR;
                    Console.WriteLine("There's nothing here :(!");
                }

                Console.ResetColor();

                if (attemptsLeft == 0)
                {
                    Console.ForegroundColor = ERROR_COLOR;
                    Console.WriteLine("You have run out of attempts!");
                    Console.ResetColor();
                }
            }
            else if (option == OPTION_SHOW_MAP)
            {
                Console.WriteLine();
                Console.ForegroundColor = TITLE_COLOR;
                Console.WriteLine("Current map:");
                Console.ResetColor();

                for (int row = 0; row < MAP_SIZE; row++)
                {
                    for (int column = 0; column < MAP_SIZE; column++)
                    {
                        Console.ForegroundColor = map[row, column] == TREASURE ? TREASURE_COLOR : GROUND_COLOR;
                        Console.Write(map[row, column] + " ");
                    }
                    Console.WriteLine();
                }

                Console.ResetColor();
            }
        } while (option != OPTION_EXIT && attemptsLeft > 0);

        Console.WriteLine();
        Console.ForegroundColor = TITLE_COLOR;
        Console.WriteLine($"You found {treasuresFound} treasure(s) in total!");
        Console.ResetColor();
    }
}