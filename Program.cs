using System;

class Program
{
    static void Main()
    {
        // Constants
        const int PLAYER_COUNT = 4;
        const int MATCH_COUNT = 5;
        const int MIN_KILLS = 0;
        const int MAX_KILLS = 10;
        const int HIGH_KILLS = 8;
        const int LOW_KILLS = 2;

        // Table layout
        const int NAME_COLUMN_WIDTH = 14;
        const int MATCH_COLUMN_WIDTH = 8;
        const int TABLE_WIDTH = NAME_COLUMN_WIDTH + MATCH_COUNT * MATCH_COLUMN_WIDTH;
        const char TITLE_LINE = '=';
        const char ROW_LINE = '-';

        // Console colors
        const ConsoleColor TITLE_COLOR = ConsoleColor.Cyan;
        const ConsoleColor HEADER_COLOR = ConsoleColor.DarkYellow;
        const ConsoleColor LINE_COLOR = ConsoleColor.DarkGray;
        const ConsoleColor NAME_COLOR = ConsoleColor.White;
        const ConsoleColor HIGH_KILLS_COLOR = ConsoleColor.Green;
        const ConsoleColor LOW_KILLS_COLOR = ConsoleColor.Red;
        const ConsoleColor NORMAL_KILLS_COLOR = ConsoleColor.Gray;
        const ConsoleColor ERROR_COLOR = ConsoleColor.Red;

        string[] playerNames = { "ShadowWolf", "PixelNinja", "CyberMage", "DragonSlayer" };

        // Error control: every player needs exactly one row in the matrix
        if (playerNames.Length != PLAYER_COUNT)
        {
            Console.ForegroundColor = ERROR_COLOR;
            Console.WriteLine($"Error: expected {PLAYER_COUNT} player names but found {playerNames.Length}.");
            Console.ResetColor();
            return;
        }

        // Matrix: one row per player, one column per match
        int[,] kills = new int[PLAYER_COUNT, MATCH_COUNT];
        Random random = new Random();

        for (int player = 0; player < PLAYER_COUNT; player++)
        {
            for (int match = 0; match < MATCH_COUNT; match++)
            {
                // Upper bound of Next() is exclusive, so we add 1 to include MAX_KILLS
                int value = random.Next(MIN_KILLS, MAX_KILLS + 1);

                // Error control: never store a value outside the allowed range
                if (value < MIN_KILLS || value > MAX_KILLS)
                {
                    Console.ForegroundColor = ERROR_COLOR;
                    Console.WriteLine($"Error: invalid kills value {value}.");
                    Console.ResetColor();
                    return;
                }

                kills[player, match] = value;
            }
        }

        // Title
        Console.ForegroundColor = LINE_COLOR;
        Console.WriteLine(new string(TITLE_LINE, TABLE_WIDTH));
        Console.ForegroundColor = TITLE_COLOR;
        Console.WriteLine("Game Kill Stats");
        Console.ForegroundColor = LINE_COLOR;
        Console.WriteLine(new string(TITLE_LINE, TABLE_WIDTH));

        // Header row: Player, Match1, Match2, ...
        Console.ForegroundColor = HEADER_COLOR;
        Console.Write("Player".PadRight(NAME_COLUMN_WIDTH));
        for (int match = 0; match < MATCH_COUNT; match++)
        {
            Console.Write($"Match{match + 1}".PadRight(MATCH_COLUMN_WIDTH));
        }
        Console.WriteLine();

        Console.ForegroundColor = LINE_COLOR;
        Console.WriteLine(new string(ROW_LINE, TABLE_WIDTH));

        // One row per player (green = many kills, red = few kills)
        for (int player = 0; player < PLAYER_COUNT; player++)
        {
            Console.ForegroundColor = NAME_COLOR;
            Console.Write(playerNames[player].PadRight(NAME_COLUMN_WIDTH));

            for (int match = 0; match < MATCH_COUNT; match++)
            {
                int value = kills[player, match];

                Console.ForegroundColor = value >= HIGH_KILLS ? HIGH_KILLS_COLOR
                                        : value <= LOW_KILLS ? LOW_KILLS_COLOR
                                        : NORMAL_KILLS_COLOR;
                Console.Write(value.ToString().PadRight(MATCH_COLUMN_WIDTH));
            }

            Console.WriteLine();
        }

        Console.ForegroundColor = LINE_COLOR;
        Console.WriteLine(new string(ROW_LINE, TABLE_WIDTH));
        Console.ResetColor();
    }
}