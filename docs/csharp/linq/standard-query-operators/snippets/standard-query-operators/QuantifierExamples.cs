namespace StandardQueryOperators;
public class QuantifierExamples
{
    private static readonly IEnumerable<Student> students = Student.Students;

    public static void RunAllSnippets()
    {
        AllExample();
        AnyExample();
        ContainsExample();
    }

    private static void AllExample()
    {
        // <AllQuantifier>
        IEnumerable<string> names = from student in students
                                    where student.Scores.All(score => score > 80)
                                    select $"{student.FirstName} {student.LastName}";

        foreach (string name in names)
        {
            Console.WriteLine($"{name}");
        }

        // This code produces the following output:
        //
        // Kim's market
        // </AllQuantifier>
    }

    private static void AnyExample()
    {
        // <AnyQuantifier>

        IEnumerable<string> names = from student in students
                                    where student.Scores.Any(score => score > 90)
                                    select $"{student.FirstName} {student.LastName}";

        foreach (string name in names)
        {
            Console.WriteLine($"{name}");
        }

        // This code produces the following output:
        //
        // Kim's market
        // Adam's market
        // </AnyQuantifier>
    }

    private static void ContainsExample()
    {
        // <ContainsQuantifier>

        // Determine which market contains fruit names equal 'kiwi'
        IEnumerable<string> names = from student in students
                                    where student.Scores.Contains(95)
                                    select $"{student.FirstName} {student.LastName}";

        foreach (string name in names)
        {
            Console.WriteLine($"{name}");
        }

        // This code produces the following output:
        //
        // Emily's market
        // Adam's market
        // </ContainsQuantifier>
    }
}
