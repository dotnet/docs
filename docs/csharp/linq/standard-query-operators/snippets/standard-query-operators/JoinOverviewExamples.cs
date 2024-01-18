namespace StandardQueryOperators;
public class JoinOverviewExamples
{
    private static readonly IEnumerable<Student> students = Student.Students;
    private static readonly IEnumerable<Department> departments = Department.Departments;

    public static void RunAllSnippets()
    {
        JoinExampleQuery();
        JoinExampleMethod();
        GroupJoinExampleQuery();
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

        // NEW: Make sure all students are included in the result

        // This code produces the following output:
        //
        // Cola - Beverage
        // Tea - Beverage
        // Apple - Fruit
        // Kiwi - Fruit
        // Carrot - Vegetable
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

        // This code produces the following output:
        //
        // Cola - Beverage
        // Tea - Beverage
        // Apple - Fruit
        // Kiwi - Fruit
        // Carrot - Vegetable
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

        // This code produces the following output:
        //
        // Group
        //     Cola
        //      Tea
        // Group
        //    Apple
        //     Kiwi
        // Group
        //   Carrot
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

        // This code produces the following output:
        //
        // Group
        //     Cola
        //      Tea
        // Group
        //    Apple
        //     Kiwi
        // Group
        //   Carrot
        // </GroupJoinMethodSyntax>
    }
}
