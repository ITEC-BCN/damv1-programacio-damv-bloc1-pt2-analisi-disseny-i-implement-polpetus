using System;

class Program
{
    // Constants: a valid line is "<attacker> hits <target> for <damage> damage"
    const int EXPECTED_PARTS = 6;
    const int ATTACKER_INDEX = 0;
    const int HITS_INDEX = 1;
    const int TARGET_INDEX = 2;
    const int FOR_INDEX = 3;
    const int DAMAGE_INDEX = 4;
    const int DAMAGE_WORD_INDEX = 5;
    const string HITS_WORD = "hits";
    const string FOR_WORD = "for";
    const string DAMAGE_WORD = "damage";
    const string SEPARATOR = " | ";

    // Console colors
    const ConsoleColor TITLE_COLOR = ConsoleColor.Cyan;
    const ConsoleColor NAME_COLOR = ConsoleColor.White;
    const ConsoleColor DEALT_COLOR = ConsoleColor.Green;
    const ConsoleColor TAKEN_COLOR = ConsoleColor.Red;
    const ConsoleColor MVP_COLOR = ConsoleColor.Yellow;
    const ConsoleColor WARNING_COLOR = ConsoleColor.Yellow;
    const ConsoleColor ERROR_COLOR = ConsoleColor.Red;

    static void Main()
    {
        string[] combatLog =
        {
            "Link hits Ganon for 35 damage",
            "Ganon hits Link for 20 damage",
            "Link hits Ganon for 50 damage",
            "Zelda hits Ganon for 40 damage",
            "Ganon hits Zelda for 25 damage"
        };

        // Parallel arrays: the name and the total damage of each character
        // (a character can't appear more times than the lines in the log)
        string[] attackers = new string[combatLog.Length];
        int[] damageDealt = new int[combatLog.Length];
        int attackerCount = 0;

        string[] targets = new string[combatLog.Length];
        int[] damageTaken = new int[combatLog.Length];
        int targetCount = 0;

        // Read every line of the log
        foreach (string line in combatLog)
        {
            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int damage = 0;

            // Error control: the line must follow the exact format
            bool isValid = parts.Length == EXPECTED_PARTS
                           && parts[HITS_INDEX] == HITS_WORD
                           && parts[FOR_INDEX] == FOR_WORD
                           && parts[DAMAGE_WORD_INDEX] == DAMAGE_WORD
                           && int.TryParse(parts[DAMAGE_INDEX], out damage)
                           && damage >= 0;

            if (!isValid)
            {
                Console.ForegroundColor = WARNING_COLOR;
                Console.WriteLine($"Warning: invalid line ignored -> \"{line}\"");
                Console.ResetColor();
                continue;
            }

            damageDealt[FindOrAdd(attackers, ref attackerCount, parts[ATTACKER_INDEX])] += damage;
            damageTaken[FindOrAdd(targets, ref targetCount, parts[TARGET_INDEX])] += damage;
        }

        // Error control: nothing to show if every line was wrong
        if (attackerCount == 0)
        {
            Console.ForegroundColor = ERROR_COLOR;
            Console.WriteLine("Error: the combat log has no valid lines.");
            Console.ResetColor();
            return;
        }

        // The MVP is the character that dealt the most damage
        int mvpIndex = 0;
        for (int i = 1; i < attackerCount; i++)
        {
            if (damageDealt[i] > damageDealt[mvpIndex])
            {
                mvpIndex = i;
            }
        }

        Console.WriteLine();
        PrintDamage("Damage dealt: ", attackers, damageDealt, attackerCount, DEALT_COLOR);
        PrintDamage("Damage taken: ", targets, damageTaken, targetCount, TAKEN_COLOR);

        Console.ForegroundColor = TITLE_COLOR;
        Console.Write("Battle MVP: ");
        Console.ForegroundColor = MVP_COLOR;
        Console.WriteLine(attackers[mvpIndex]);
        Console.ResetColor();
    }

    // Returns the position of the name, adding it to the array if it's the first time
    static int FindOrAdd(string[] names, ref int count, string name)
    {
        int index = Array.IndexOf(names, name, 0, count);

        if (index < 0)
        {
            index = count;
            names[count] = name;
            count++;
        }

        return index;
    }

    // Prints "Title: Name 10 | Name 20 | ..." using only the used part of the arrays
    static void PrintDamage(string title, string[] names, int[] damage, int count, ConsoleColor damageColor)
    {
        Console.ForegroundColor = TITLE_COLOR;
        Console.Write(title);

        for (int i = 0; i < count; i++)
        {
            Console.ForegroundColor = NAME_COLOR;
            Console.Write(names[i] + " ");
            Console.ForegroundColor = damageColor;
            Console.Write(damage[i]);
            Console.ForegroundColor = NAME_COLOR;
            Console.Write(i < count - 1 ? SEPARATOR : string.Empty);
        }

        Console.WriteLine();
        Console.ResetColor();
    }
}