using System;

public class Program
{
    public static void Main()
    {
        Random random = new Random();

        const int ARRAY_SIZE = 20;
        const int MAX_VALUE = 100;
        int[] numbers = new int [ARRAY_SIZE];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(MAX_VALUE);
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine($"Number {i + 1}: {numbers[i]}");
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"Evens: ");
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                Console.Write($"|{numbers[i]}| ");
            }
        }
        Console.WriteLine();
        Console.Write($"Odds: ");
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % 2 != 0)
            {
                Console.Write($"|{numbers[i]}| ");
            }
        }
        Console.ForegroundColor = ConsoleColor.DarkGray;
    }
}