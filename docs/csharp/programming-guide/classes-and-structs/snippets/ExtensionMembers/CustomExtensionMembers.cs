using CustomExtensionMethods;

namespace CustomExtensionMembers;

public enum Grades
{
    F = 0,
    D = 1,
    C = 2,
    B = 3,
    A = 4
};

// <EnumExtensionMembers>
public static class EnumExtensions
{
    private static Grades minimumPassingGrade = Grades.D;

    extension(Grades grade)
    {
        public static Grades MinimumPassingGrade
        {
            get => minimumPassingGrade;
            set => minimumPassingGrade = value;
        }

        public bool Passing => grade >= minimumPassingGrade;
    }
}
// </EnumExtensionMembers>

public static class ExtensionMemberUsage
{
    public static void Examples()
    {
        // <ExampleExtendEnum>
        Grades g1 = Grades.D;
        Grades g2 = Grades.F;
        Console.WriteLine($"First {(g1.Passing ? "is" : "is not")} a passing grade.");
        Console.WriteLine($"Second {(g2.Passing ? "is" : "is not")} a passing grade.");

        Grades.MinimumPassingGrade = Grades.C;
        Console.WriteLine($"\r\nRaising the bar. Passing grade is now {Grades.MinimumPassingGrade}!\r\n");
        Console.WriteLine($"First {(g1.Passing ? "is" : "is not")} a passing grade.");
        Console.WriteLine($"Second {(g2.Passing ? "is" : "is not")} a passing grade.");
        /* Output:
            First is a passing grade.
            Second is not a passing grade.

            Raising the bar!

            First is not a passing grade.
            Second is not a passing grade.
        */
        // </ExampleExtendEnum>
    }
}
