namespace StandardQueryOperators;
public class JoinOverviewExamples
{
    private static readonly IEnumerable<Student> students = Sources.Students;
    private static readonly IEnumerable<Department> departments = Sources.Departments;

    public static void RunAllSnippets()
    {
        Console.WriteLine("Join Example");
        JoinExampleQuery();
        Console.WriteLine("Join Example Method");
        JoinExampleMethod();
        Console.WriteLine("Group Join Example");
        GroupJoinExampleQuery();
        Console.WriteLine("Group Join Example Method");
        GroupJoinExampleMethod();
    }

    private static void JoinExampleQuery()
    {
        // <JoinQuerySyntax>
        var query = from student in students
                    join department in departments on student.DepartmentID equals department.ID
                    select new { Name = $"{student.FirstName} {student.LastName}", DepartmentName = department.Name };

        foreach (var item in query)
        {
            Console.WriteLine($"{item.Name} - {item.DepartmentName}");
        }
        // </JoinQuerySyntax>
    }

    private static void JoinExampleMethod()
    {
        // <JoinMethodSyntax>
        var query = students.Join(departments,
            student => student.DepartmentID, department => department.ID,
            (student, department) => new { Name = $"{student.FirstName} {student.LastName}", DepartmentName = department.Name });

        foreach (var item in query)
        {
            Console.WriteLine($"{item.Name} - {item.DepartmentName}");
        }
        // </JoinMethodSyntax>
    }
    private static void GroupJoinExampleQuery()
    {
        // <GroupJoinQuerySyntax>
        IEnumerable<IEnumerable<Student>> studentGroups = from department in departments
                            join student in students on department.ID equals student.DepartmentID into studentGroup
                            select studentGroup;

        foreach (IEnumerable<Student> studentGroup in studentGroups)
        {
            Console.WriteLine("Group");
            foreach (Student student in studentGroup)
            {
                Console.WriteLine($"  - {student.FirstName}, {student.LastName}");
            }
        }
        // </GroupJoinQuerySyntax>
    }

    private static void GroupJoinExampleMethod()
    {
        // <GroupJoinMethodSyntax>
        // Join department and student based on DepartmentId and grouping result
        IEnumerable<IEnumerable<Student>> studentGroups = departments.GroupJoin(students,
            department => department.ID, student => student.DepartmentID,
            (department, studentGroup) => studentGroup);

        foreach (IEnumerable<Student> studentGroup in studentGroups)
        {
            Console.WriteLine("Group");
            foreach (Student student in studentGroup)
            {
                Console.WriteLine($"  - {student.FirstName}, {student.LastName}");
            }
        }
        // </GroupJoinMethodSyntax>
    }
}
