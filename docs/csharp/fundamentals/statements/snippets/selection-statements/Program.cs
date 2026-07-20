namespace SelectionStatements;

public static class Program
{
    public static void Main()
    {
        IfElseExample();
        ElseIfExample();
        SwitchStatementExample();
        SwitchWhenExample();
        TernaryExample();
    }

    private static void IfElseExample()
    {
        // <IfElse>
        int temperature = 28;

        // An if statement runs its block only when the condition is true.
        // The else block runs when the condition is false.
        if (temperature >= 25)
        {
            Console.WriteLine("Warm"); // => Warm
        }
        else
        {
            Console.WriteLine("Cool");
        }
        // </IfElse>
    }

    private static void ElseIfExample()
    {
        // <ElseIf>
        int score = 82;

        // Chain conditions with else if. The first branch whose condition is
        // true runs; the compiler skips the rest.
        string grade;
        if (score >= 90)
        {
            grade = "A";
        }
        else if (score >= 80)
        {
            grade = "B";
        }
        else if (score >= 70)
        {
            grade = "C";
        }
        else
        {
            grade = "F";
        }

        Console.WriteLine(grade); // => B
        // </ElseIf>
    }

    private static void SwitchStatementExample()
    {
        // <SwitchStatement>
        DayOfWeek day = DayOfWeek.Saturday;

        // A switch statement compares one value against several case labels.
        // Stacked labels share a body. Each section ends with break, and the
        // default section runs when no case matches.
        switch (day)
        {
            case DayOfWeek.Saturday:
            case DayOfWeek.Sunday:
                Console.WriteLine("Weekend"); // => Weekend
                break;
            default:
                Console.WriteLine("Weekday");
                break;
        }
        // </SwitchStatement>
    }

    private static void SwitchWhenExample()
    {
        // <SwitchWhen>
        int measurement = 42;

        // A case label can test a pattern instead of a constant. A when clause
        // adds a condition that must also be true for the case to match.
        switch (measurement)
        {
            case < 0:
                Console.WriteLine("Negative");
                break;
            case 0:
                Console.WriteLine("Zero");
                break;
            case > 0 when measurement % 2 == 0:
                Console.WriteLine("Positive and even"); // => Positive and even
                break;
            default:
                Console.WriteLine("Positive and odd");
                break;
        }
        // </SwitchWhen>
    }

    private static void TernaryExample()
    {
        // <Ternary>
        int hour = 9;

        // The conditional operator ?: chooses between two values in a single
        // expression: condition ? valueIfTrue : valueIfFalse.
        string greeting = hour < 12 ? "Good morning" : "Good afternoon";

        Console.WriteLine(greeting); // => Good morning
        // </Ternary>
    }
}
