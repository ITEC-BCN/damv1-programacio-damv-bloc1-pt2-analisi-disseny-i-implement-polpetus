# Arrays, Matrices and Jagged Arrays — BLOC1.PT2

Console application project written in **C#** for the module *Entorns, programació i processos* (0485, RA3) at Institut Tecnològic de Barcelona, course 2026/2027.

The goal is to practise writing and debugging code with the control structures of the language, working with:

- One-dimensional arrays (`int[]`, `string[]`)
- Multidimensional arrays (`int[,]`, `char[,]`)
- Jagged arrays (`int[][]`)
- Strings and text processing

## Coding rules

- All the code is written in **English**: variables, constants, messages and comments.
- **Error control** in every program: input validation with `int.TryParse` inside loops, range checks and safe handling of `null` input.
- No magic numbers: values are stored in `const` variables.
- Colored console output using `ConsoleColor` constants.

## Activities

| # | Activity | Main concepts |
|---|----------|---------------|
| 1 | Reads or generates 20 integers and prints them in two rows: even and odd | Arrays, `%`, filtering |
| 2 | Pokédex with 15 Pokémon and a menu to list and release them (`"empty"` slots) | `string[]`, menus, slot states |
| 3 | Generates 10 integers (1-9) and prints them forwards and backwards | `Random`, `for` loops |
| 4 | Sorts the numbers, searches a value and counts its appearances | `Array.Sort()`, searching, counting |
| 5 | Video game shop: four items with random attributes shown in a table | Random values, validation, `decimal`, currency format |
| 6 | Medieval map using a 1D array, a 5x5 matrix and a jagged array (even/odd rules) | Matrices, jagged arrays, nested loops |
| 7 | Treasure explorer: 10x10 map, 3 attempts to dig and a menu | `char[,]`, menus, ternary operator |
| 8 | Kill stats of 4 players in 5 matches shown as a table | `int[,]`, `PadRight`, tables |
| 9 | Tournament scores where each player plays a different number of games | Jagged array, averages, totals |
| 10 | Normalizes the name of a hero (trim and capitalize) | `Trim()`, `ToUpperInvariant()`, string interpolation |
| 11 | Chat moderator that censors banned words, ignoring case | `string[]`, `Split`, `Join`, `Replace` |
| 12 | Summoner name validation with several rules | Validation, `char` methods, helper method |
| 13 | Combat log report: damage dealt, damage taken and MVP | `Split`, parsing, parallel arrays |

## Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) (the version used in the project file)
- A terminal (Git Bash, PowerShell, etc.)

## How to run

```bash
# Clone the repository
git clone <repository-url>
cd <repository-folder>

# Go to the activity you want to try
git switch activity-8

# Run it
dotnet run
```

## Git workflow

Every activity is developed in its own branch and merged into `main`:

```text
main
 ├── activity-1  → merge
 ├── activity-2  → merge
 ├── ...
 └── activity-13 → merge
```

1. Create a branch from an updated `main` (`git switch -c activity-N`).
2. Write the activity and test it with `dotnet run`.
3. Commit with a descriptive message (`git commit -m "Add activity N: description"`).
4. Merge the branch into `main` with a merge commit (`git merge --no-ff activity-N`).
5. Push everything to GitHub (`git push origin --all`).

Because every activity replaces `Program.cs`, the file in `main` is the last merged activity. The code of each one is available in its own branch and in the commit history (`git log --oneline --graph`).

## Author

Student of the DAMv course, Institut Tecnològic de Barcelona.
