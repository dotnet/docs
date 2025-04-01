namespace StandardQueryOperators;
public class LeftOuterJoins
{
    private static readonly IEnumerable<Department> departments = Sources.Departments;
    private static readonly IEnumerable<Student> students = Sources.Students;

    public static void RunAllSnippets()
    {
        Console.WriteLine("Left Outer Join Query Syntax");
        LeftOuterJoinQuerySyntax();
        Console.WriteLine("Left Outer Join Method Syntax");
        LeftOuterJoinMethodSyntax();
    }

    private static void LeftOuterJoinQuerySyntax()
    {
        // <LeftOuterJoinQuery>
        var query =
            from student in students
            join department in departments on student.DepartmentID equals department.ID into gj
            from subgroup in gj.DefaultIfEmpty()
            select new
            {
                student.FirstName,
                student.LastName,
                Department = subgroup?.Name ?? string.Empty
            };

        foreach (var v in query)
        {
            Console.WriteLine($"{v.FirstName:-15} {v.LastName:-15}: {v.Department}");
        }
        // </LeftOuterJoinQuery>
    }

    private static void LeftOuterJoinMethodSyntax()
    {
        // <LeftOuterJoinMethod>
        var query = students
            .GroupJoin(
                departments,
                student => student.DepartmentID,
                department => department.ID,
                (student, departmentList) => new { student, subgroup = departmentList })
            .SelectMany(
                joinedSet => joinedSet.subgroup.DefaultIfEmpty(),
                (student, department) => new
                {
                    student.student.FirstName,
                    student.student.LastName,
                    Department = department.Name
                });

        foreach (var v in query)
        {
            Console.WriteLine($"{v.FirstName:-15} {v.LastName:-15}: {v.Department}");
        }
        // </LeftOuterJoinMethod>
    }
}
