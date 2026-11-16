using System;
using System.Globalization;

class program
{
    static void Main()
    {
        // Constants
        const int MIN_SCORE = 0;
        const int MAX_SCORE = 100;
        const double GOOD_AVERAGE = 70.0;
        const int NAME_COLUMN_WIDTH = 13;
        const string AVERAGE_FORMAT = "F2";

        // Console colors
        const ConsoleColor NAME_COLOR = ConsoleColor.DarkYellow;
        const ConsoleColor SCORES_COLOR = ConsoleColor.White;
        const ConsoleColor GOOD_AVERAGE_COLOR = ConsoleColor.Green;
        const ConsoleColor NORMAL_AVERAGE_COLOR = ConsoleColor.Yellow;
        const ConsoleColor TOTAL_COLOR = ConsoleColor.Cyan;
        const ConsoleColor ERROR_COLOR = ConsoleColor.Red;

        string[] playerNames = { "LunaBlade", "IronFist", "ShadowNova", "PixelMage" };
        int[] gamesPlayed = { 3, 5, 2, 4 };

        // Error control: one number of games per player, and at least one game each
        if (playerNames.Length != gamesPlayed.Length)
        {
            Console.ForegroundColor = ERROR_COLOR;
            Console.WriteLine("Error: the players and the games played don't match.");
            Console.ResetColor();
            return;
        }

        foreach (int games in gamesPlayed)
        {
            if (games < 1)
            {
                Console.ForegroundColor = ERROR_COLOR;
                Console.WriteLine("Error: every player must play at least one game.");
                Console.ResetColor();
                return;
            }
        }

        // Jagged array: each row (player) has a different length
        int[][] scores = new int[playerNames.Length][];
        Random random = new Random();

        for (int player = 0; player < scores.Length; player++)
        {
            scores[player] = new int[gamesPlayed[player]];

            for (int game = 0; game < scores[player].Length; game++)
            {
                // Upper bound of Next() is exclusive, so we add 1 to include MAX_SCORE
                scores[player][game] = random.Next(MIN_SCORE, MAX_SCORE + 1);
            }
        }

        // Show the scores and the average of each player
        int globalTotal = 0;

        for (int player = 0; player < scores.Length; player++)
        {
            int playerTotal = 0;

            Console.ForegroundColor = NAME_COLOR;
            Console.Write($"{playerNames[player]}:".PadRight(NAME_COLUMN_WIDTH));

            Console.ForegroundColor = SCORES_COLOR;
            for (int game = 0; game < scores[player].Length; game++)
            {
                Console.Write(scores[player][game] + " ");
                playerTotal += scores[player][game];
            }

            globalTotal += playerTotal;
            double average = (double)playerTotal / scores[player].Length;

            Console.ResetColor();
            Console.Write("-> Average: ");
            Console.ForegroundColor = average >= GOOD_AVERAGE ? GOOD_AVERAGE_COLOR : NORMAL_AVERAGE_COLOR;

            // InvariantCulture so the decimal separator is always a dot
            Console.WriteLine(average.ToString(AVERAGE_FORMAT, CultureInfo.InvariantCulture));
            Console.ResetColor();
        }

        Console.WriteLine();
        Console.ForegroundColor = TOTAL_COLOR;
        Console.WriteLine($"Global tournament points total: {globalTotal}");
        Console.ResetColor();
    }
}