namespace TourOfCsharp;
internal class LinqExample
{
    private record Student(string FirstName, string LastName, double GPA);

    private static List<Student> Students = [];

    private static void LinqExampleQuery()
    {
        // <LinqExampleQuery>
        var honorRoll = from student in Students
                        where student.GPA > 3.5
                        select student;
        // </LinqExampleQuery>
    }
}
