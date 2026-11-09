using System;
using System.Globalization;
using System.Text;

class Program
{
    static void Main()
    {
        // Needed to display the € symbol correctly in the console
        Console.OutputEncoding = Encoding.UTF8;

        // Constants
        const int ITEM_COUNT = 4;
        const int MIN_LEVEL = 1;
        const int MAX_LEVEL = 10;
        const int MIN_POWER = 100;
        const int MAX_POWER = 500;
        const double MIN_WEIGHT = 0.5;
        const double MAX_WEIGHT = 10.0;
        const double MIN_COST = 5.0;
        const double MAX_COST = 200.0;
        const double RARE_PROBABILITY = 0.5;
        const string ORDINARY_TYPE = "Ordinary";
        const string CURRENCY = "€";

        // Console colors
        const ConsoleColor TITLE_COLOR = ConsoleColor.Cyan;
        const ConsoleColor HEADER_COLOR = ConsoleColor.DarkYellow;
        const ConsoleColor RARE_COLOR = ConsoleColor.Magenta;
        const ConsoleColor COMMON_COLOR = ConsoleColor.White;

        string[] itemNames = { "Sword", "Shield", "Potion", "Bow" };
        string[] rareTypeOptions = { "Common", "Rare", "Legendary", "Ordinary" };

        // One array per attribute, the same index belongs to the same item
        int[] minLevels = new int[ITEM_COUNT];
        int[] powers = new int[ITEM_COUNT];
        double[] weights = new double[ITEM_COUNT];
        double[] costs = new double[ITEM_COUNT];
        bool[] isRareItem = new bool[ITEM_COUNT];
        string[] rareTypes = new string[ITEM_COUNT];

        Random random = new Random();

        for (int i = 0; i < ITEM_COUNT; i++)
        {
            bool isValid;

            // Generate the attributes and regenerate them if any value is not valid
            do
            {
                minLevels[i] = random.Next(MIN_LEVEL, MAX_LEVEL + 1);
                powers[i] = random.Next(MIN_POWER, MAX_POWER + 1);
                weights[i] = Math.Round(MIN_WEIGHT + random.NextDouble() * (MAX_WEIGHT - MIN_WEIGHT), 1);
                costs[i] = Math.Round(MIN_COST + random.NextDouble() * (MAX_COST - MIN_COST), 2);
                isRareItem[i] = random.NextDouble() < RARE_PROBABILITY;

                // Rare items get a random type, the others are always "Ordinary"
                rareTypes[i] = isRareItem[i]
                    ? rareTypeOptions[random.Next(rareTypeOptions.Length)]
                    : ORDINARY_TYPE;

                isValid = minLevels[i] >= MIN_LEVEL && minLevels[i] <= MAX_LEVEL
                          && powers[i] >= MIN_POWER && powers[i] <= MAX_POWER
                          && weights[i] > 0
                          && costs[i] > 0
                          && !string.IsNullOrEmpty(itemNames[i])
                          && !string.IsNullOrEmpty(rareTypes[i]);
            } while (!isValid);
        }

        // Show the table
        Console.ForegroundColor = TITLE_COLOR;
        Console.WriteLine("=== AVAILABLE SHOP ITEMS ===");
        Console.WriteLine();

        Console.ForegroundColor = HEADER_COLOR;
        Console.WriteLine("{0,-10}{1,-12}{2,-8}{3,-13}{4,-12}{5,-12}{6}",
            "Name", "Min level", "Power", "Weight (kg)", "Cost (" + CURRENCY + ")", "IsRareItem", "RareType");

        for (int i = 0; i < ITEM_COUNT; i++)
        {
            Console.ForegroundColor = isRareItem[i] ? RARE_COLOR : COMMON_COLOR;

            // InvariantCulture forces the dot as decimal separator (134.50)
            string weightText = weights[i].ToString("F1", CultureInfo.InvariantCulture);
            string costText = costs[i].ToString("F2", CultureInfo.InvariantCulture) + " " + CURRENCY;

            Console.WriteLine("{0,-10}{1,-12}{2,-8}{3,-13}{4,-12}{5,-12}{6}",
                itemNames[i], minLevels[i], powers[i], weightText, costText, isRareItem[i], rareTypes[i]);
        }

        Console.ResetColor();
    }
}