using System;
using System.Text;

class Program
{
    static void Main()
    {
        // Needed to display emojis correctly in the console
        Console.OutputEncoding = Encoding.UTF8;

        // Constants
        const int TROOPS_SIZE = 10;
        const int MAP_SIZE = 5;
        const int REGION_COUNT = 3;
        const int FIRST_REGION_COLUMNS = 4;
        const int SECOND_REGION_COLUMNS = 2;
        const int THIRD_REGION_COLUMNS = 3;

        const string DEFENSIVE_ZONE = "🛡️";
        const string ATTACK_ZONE = "⚔️";
        const string WATCHTOWER = "🗼";
        const string HIDDEN_CAVE = "🕳️";
        const string NEUTRAL_TERRAIN = "🌿";
        const string EXTRA_RESOURCE = "💎";
        const string EMPTY_LAND = "➖";

        const ConsoleColor TITLE_COLOR = ConsoleColor.Cyan;
        const ConsoleColor LEGEND_COLOR = ConsoleColor.DarkGray;

        // 1. One-dimensional array (troops)
        string[] troops = new string[TROOPS_SIZE];

        for (int i = 0; i < troops.Length; i++)
        {
            // Even positions are defensive zones, odd positions are attack zones
            troops[i] = i % 2 == 0 ? DEFENSIVE_ZONE : ATTACK_ZONE;
        }

        Console.ForegroundColor = TITLE_COLOR;
        Console.WriteLine("=== 1. TROOPS (one-dimensional array) ===");
        Console.ForegroundColor = LEGEND_COLOR;
        Console.WriteLine($"{DEFENSIVE_ZONE} Defensive zone (even)  {ATTACK_ZONE} Attack zone (odd)");
        Console.ResetColor();

        for (int i = 0; i < troops.Length; i++)
        {
            Console.Write(troops[i] + " ");
        }
        Console.WriteLine();

        // 2. Two-dimensional array (map)
        string[,] map = new string[MAP_SIZE, MAP_SIZE];

        for (int row = 0; row < MAP_SIZE; row++)
        {
            for (int column = 0; column < MAP_SIZE; column++)
            {
                bool isRowEven = row % 2 == 0;
                bool isColumnEven = column % 2 == 0;

                if (isRowEven && isColumnEven)
                {
                    map[row, column] = WATCHTOWER;
                }
                else if (!isRowEven && !isColumnEven)
                {
                    map[row, column] = HIDDEN_CAVE;
                }
                else
                {
                    map[row, column] = NEUTRAL_TERRAIN;
                }
            }
        }

        Console.WriteLine();
        Console.ForegroundColor = TITLE_COLOR;
        Console.WriteLine("=== 2. MAP (two-dimensional array) ===");
        Console.ForegroundColor = LEGEND_COLOR;
        Console.WriteLine($"{WATCHTOWER} Watchtower (both even)  {HIDDEN_CAVE} Hidden cave (both odd)  {NEUTRAL_TERRAIN} Neutral terrain (other)");
        Console.ResetColor();

        for (int row = 0; row < MAP_SIZE; row++)
        {
            for (int column = 0; column < MAP_SIZE; column++)
            {
                Console.Write(map[row, column] + " ");
            }
            Console.WriteLine();
        }

        // 3. Jagged array (regions)
        string[][] regions = new string[REGION_COUNT][];
        regions[0] = new string[FIRST_REGION_COLUMNS];
        regions[1] = new string[SECOND_REGION_COLUMNS];
        regions[2] = new string[THIRD_REGION_COLUMNS];

        for (int row = 0; row < regions.Length; row++)
        {
            for (int column = 0; column < regions[row].Length; column++)
            {
                // Odd row + column is an extra resource, even is empty land
                regions[row][column] = (row + column) % 2 != 0 ? EXTRA_RESOURCE : EMPTY_LAND;
            }
        }

        Console.WriteLine();
        Console.ForegroundColor = TITLE_COLOR;
        Console.WriteLine("=== 3. REGIONS (jagged array) ===");
        Console.ForegroundColor = LEGEND_COLOR;
        Console.WriteLine($"{EXTRA_RESOURCE} Extra resource (row + column odd)  {EMPTY_LAND} Empty land (row + column even)");
        Console.ResetColor();

        for (int row = 0; row < regions.Length; row++)
        {
            for (int column = 0; column < regions[row].Length; column++)
            {
                Console.Write(regions[row][column] + " ");
            }
            Console.WriteLine();
        }
    }
}