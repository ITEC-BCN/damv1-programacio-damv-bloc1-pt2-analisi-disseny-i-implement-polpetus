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
        const ConsoleColor PROMPT_COLOR = ConsoleColor.Yellow;
        const ConsoleColor SUCCESS_COLOR = ConsoleColor.Green;
        const ConsoleColor WARNING_COLOR = ConsoleColor.Yellow;
        const ConsoleColor ERROR_COLOR = ConsoleColor.Red;

        Random random = new Random();
        int[] numbers = new int[ARRAY_SIZE];

        // Fill the array (the upper bound of Next() is exclusive, so we add 1)
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(MIN_VALUE, MAX_VALUE + 1);
        }

        // Show the generated numbers
        Console.ForegroundColor = TITLE_COLOR;
        Console.WriteLine("Generated numbers:");
        Console.ForegroundColor = NUMBERS_COLOR;
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine();
        Console.ResetColor();

        // Sort in ascending order
        Array.Sort(numbers);

        // Ask for the value to search until it is valid
        int searchValue;
        bool isValid;

        do
        {
            Console.WriteLine();
            Console.ForegroundColor = TITLE_COLOR;
            Console.WriteLine($"Which value do you want to search? ({MIN_VALUE}-{MAX_VALUE})");
            Console.ForegroundColor = PROMPT_COLOR;
            Console.Write("> ");
            Console.ResetColor();

            isValid = int.TryParse(Console.ReadLine(), out searchValue)
                      && searchValue >= MIN_VALUE && searchValue <= MAX_VALUE;

            if (!isValid)
            {
                Console.ForegroundColor = ERROR_COLOR;
                Console.WriteLine($"Error: enter a whole number between {MIN_VALUE} and {MAX_VALUE}.");
                Console.ResetColor();
            }
        } while (!isValid);

        // Count how many times the value appears
        int count = 0;

        foreach (int number in numbers)
        {
            if (number == searchValue)
            {
                count++;
            }
        }

        Console.WriteLine();

        if (count > 0)
        {
            Console.ForegroundColor = SUCCESS_COLOR;
            Console.WriteLine($"The value {searchValue} is in the list and appears {count} time(s).");
        }
        else
        {
            Console.ForegroundColor = WARNING_COLOR;
            Console.WriteLine($"The value {searchValue} is not in the list.");
        }

        // Show the sorted list
        Console.WriteLine();
        Console.ForegroundColor = TITLE_COLOR;
        Console.WriteLine("Sorted list:");
        Console.ForegroundColor = NUMBERS_COLOR;
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine();

        Console.ResetColor();
    }
}
