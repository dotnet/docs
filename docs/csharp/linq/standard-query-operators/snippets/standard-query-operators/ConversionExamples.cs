using System.Collections;

namespace StandardQueryOperators;

public class ConversionExamples
{
    private static readonly IEnumerable<Student> students = Sources.Students;
    public static void RunAllSnippets()
    {
        Console.WriteLine("ConversionExamples:");
        CastExampleQuery();
        CastExampleMethod();
    }

    private static void CastExampleQuery()
    {
        // <CastOperatorQuerySyntax>
        IEnumerable people = students;

        var query = from Student student in people
                    where student.Year == GradeLevel.ThirdYear
                    select student;

        foreach (Student student in query)
        {
            Console.WriteLine(student.FirstName);
        }
        // </CastOperatorQuerySyntax>
    }

    private static void CastExampleMethod()
    {
        // <CastOperatorMethodSyntax>
        IEnumerable people = students;

        var query = people
            .Cast<Student>()
            .Where(student => student.Year == GradeLevel.ThirdYear);

        foreach (Student student in query)
        {
            Console.WriteLine(student.FirstName);
        }
        // </CastOperatorMethodSyntax>
    }
}
