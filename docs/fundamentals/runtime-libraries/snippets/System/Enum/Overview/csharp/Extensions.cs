//<snippet18>
using System;

// Define an enumeration to represent student grades.
public enum Grades { F = 0, D = 1, C = 2, B = 3, A = 4 };

// Define an extension method for the Grades enumeration.
public static class Extensions
{
    public static Grades minPassing = Grades.D;

    public static bool Passing(this Grades grade)
    {
        return grade >= minPassing;
    }
}

class Example8
{
    static void Main()
    {
        Grades g1 = Grades.D;
        Grades g2 = Grades.F;
        Console.WriteLine($"{g1} {(g1.Passing() ? "is" : "is not")} a passing grade.");
        Console.WriteLine($"{g2} {(g2.Passing() ? "is" : "is not")} a passing grade.");

        Extensions.minPassing = Grades.C;
        Console.WriteLine("\nRaising the bar!\n");
        Console.WriteLine($"{g1} {(g1.Passing() ? "is" : "is not")} a passing grade.");
        Console.WriteLine($"{g2} {(g2.Passing() ? "is" : "is not")} a passing grade.");
    }
}
// The exmaple displays the following output:
//       D is a passing grade.
//       F is not a passing grade.
//
//       Raising the bar!
//
//       D is not a passing grade.
//       F is not a passing grade.
//</snippet18>
