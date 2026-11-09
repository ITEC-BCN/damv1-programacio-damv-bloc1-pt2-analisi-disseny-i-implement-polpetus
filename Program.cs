using System;

class Program
{
    static void Main()
    {
        // Constants
        const int ARRAY_SIZE = 10;
        const int MIN_VALUE = 1;
        const int MAX_VALUE = 9;

        // Console colors
        const ConsoleColor TITLE_COLOR = ConsoleColor.Cyan;
        const ConsoleColor NUMBERS_COLOR = ConsoleColor.Green;

        Random random = new Random();
        int[] numbers = new int[ARRAY_SIZE];

        // Fill the array (the upper bound of Next() is exclusive, so we add 1)
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(MIN_VALUE, MAX_VALUE + 1);
        }

        // Left to right
        Console.ForegroundColor = TITLE_COLOR;
        Console.WriteLine("Left to right:");
        Console.ForegroundColor = NUMBERS_COLOR;
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine();

        // Right to left
        Console.WriteLine();
        Console.ForegroundColor = TITLE_COLOR;
        Console.WriteLine("Right to left:");
        Console.ForegroundColor = NUMBERS_COLOR;
        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine();

        Console.ResetColor();
    }
}