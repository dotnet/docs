using System.Collections;

namespace StandardQueryOperators;

public class ConversionExamples
{
    private static readonly IEnumerable<Student> students = Student.Students;
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

        var query = from Student student in students
                    where student.Year == GradeLevel.ThirdYear
                    select student;

        foreach (Student student in query)
            Console.WriteLine(student.FirstName);

        /* This code produces the following output:

            Venus Fly Trap
            Waterwheel Plant
        */
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
            Console.WriteLine(student.FirstName);

        /* This code produces the following output:

            Venus Fly Trap
            Waterwheel Plant
        */
        // </CastOperatorMethodSyntax>
    }
}
