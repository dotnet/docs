namespace StandardQueryOperators;
public class InnerJoins
{
    private static readonly IEnumerable<Department> departments = Sources.Departments;
    private static readonly IEnumerable<Teacher> teachers = Sources.Teachers;
    private static readonly IEnumerable<Student> students = Sources.Students;
    public static void RunAllSnippets()
    {
        Console.WriteLine("Simple Inner Join Query Syntax");
        SimpleInnerJoinQuerySyntax();
        Console.WriteLine("Simple Inner Join Method Syntax");
        SimpleInnerJoinMethodSyntax();
        Console.WriteLine("Composite Key Query Syntax");
        CompositeKeyQuerySyntax();
        Console.WriteLine("Composite Key Method Syntax");
        CompositeKeyMethodSyntax();
        Console.WriteLine("Multiple Join Query Syntax");
        MultipleJoinQuerySyntax();
        Console.WriteLine("Multiple Join Method Syntax");
        MultipleJoinMethodSyntax();
        Console.WriteLine("Inner Group Join Query Syntax");
        InnerGroupJoinQuerySyntax();
        Console.WriteLine("Inner Join Query Syntax");
        InnerJoinQuerySyntax();
        Console.WriteLine("Inner Group Join Method Syntax");
        InnerGroupJoinMethodSyntax();
        Console.WriteLine("Inner Join Method Syntax");
        InnerJoinMethodSyntax();
    }

    private static void SimpleInnerJoinQuerySyntax()
    {
        // <SimpleInnerJoinQuery>
        var query = from department in departments
                    join teacher in teachers on department.TeacherID equals teacher.ID
                    select new
                    {
                        DepartmentName = department.Name,
                        TeacherName = $"{teacher.First} {teacher.Last}"
                    };

        foreach (var departmentAndTeacher in query)
        {
            Console.WriteLine($"{departmentAndTeacher.DepartmentName} is managed by {departmentAndTeacher.TeacherName}");
        }
        // </SimpleInnerJoinQuery>
    }

    private static void SimpleInnerJoinMethodSyntax()
    {
        // <SimpleInnerJoinMethod>
        var query = teachers
            .Join(departments, teacher => teacher.ID, department => department.TeacherID,
                (teacher, department) =>
                new { DepartmentName = department.Name, TeacherName = $"{teacher.First} {teacher.Last}" });

        foreach (var departmentAndTeacher in query)
        {
            Console.WriteLine($"{departmentAndTeacher.DepartmentName} is managed by {departmentAndTeacher.TeacherName}");
        }
        // </SimpleInnerJoinMethod>
    }

    private static void CompositeKeyQuerySyntax()
    {
        // <CompositeKeyQuery>
        // Join the two data sources based on a composite key consisting of first and last name,
        // to determine which employees are also students.
        IEnumerable<string> query =
            from teacher in teachers
            join student in students on new
            {
                FirstName = teacher.First,
                LastName = teacher.Last
            } equals new
            {
                student.FirstName,
                student.LastName
            }
            select teacher.First + " " + teacher.Last;

        string result = "The following people are both teachers and students:\r\n";
        foreach (string name in query)
        {
            result += $"{name}\r\n";
        }
        Console.Write(result);
        // </CompositeKeyQuery>

    }

    private static void CompositeKeyMethodSyntax()
    {
        // <CompositeKeyMethod>
        IEnumerable<string> query = teachers
            .Join(students,
                teacher => new { FirstName = teacher.First, LastName = teacher.Last },
                student => new { student.FirstName, student.LastName },
                (teacher, student) => $"{teacher.First} {teacher.Last}"
         );

        Console.WriteLine("The following people are both teachers and students:");
        foreach (string name in query)
        {
            Console.WriteLine(name);
        }
        // </CompositeKeyMethod>
    }

    private static void MultipleJoinQuerySyntax()
    {
        // <MultipleJoinQuery>
        // The first join matches Department.ID and Student.DepartmentID from the list of students and
        // departments, based on a common ID. The second join matches teachers who lead departments
        // with the students studying in that department.
        var query = from student in students
            join department in departments on student.DepartmentID equals department.ID
            join teacher in teachers on department.TeacherID equals teacher.ID
            select new {
                StudentName = $"{student.FirstName} {student.LastName}",
                DepartmentName = department.Name,
                TeacherName = $"{teacher.First} {teacher.Last}"
            };

        foreach (var obj in query)
        {
            Console.WriteLine($"""The student "{obj.StudentName}" studies in the department run by "{obj.TeacherName}".""");
        }
        // </MultipleJoinQuery>
    }

    private static void MultipleJoinMethodSyntax()
    { 
        // <MultipleJoinMethod>
        var query = students
            .Join(departments, student => student.DepartmentID, department => department.ID,
                (student, department) => new { student, department })
            .Join(teachers, commonDepartment => commonDepartment.department.TeacherID, teacher => teacher.ID,
                (commonDepartment, teacher) => new
                {
                    StudentName = $"{commonDepartment.student.FirstName} {commonDepartment.student.LastName}",
                    DepartmentName = commonDepartment.department.Name,
                    TeacherName = $"{teacher.First} {teacher.Last}"
                });

        foreach (var obj in query)
        {
            Console.WriteLine($"""The student "{obj.StudentName}" studies in the department run by "{obj.TeacherName}".""");
        }
        // </MultipleJoinMethod>
    }

    private static void InnerGroupJoinQuerySyntax()
    {
        // <InnerGroupJoinQuery>
        var query1 =
            from department in departments
            join student in students on department.ID equals student.DepartmentID into gj
            from subStudent in gj
            select new
            {
                DepartmentName = department.Name,
                StudentName = $"{subStudent.FirstName} {subStudent.LastName}"
            };
        Console.WriteLine("Inner join using GroupJoin():");
        foreach (var v in query1)
        {
            Console.WriteLine($"{v.DepartmentName} - {v.StudentName}");
        }
        // </InnerGroupJoinQuery>
    }

    private static void InnerJoinQuerySyntax()
    {
        // <InnerJoinQuery>
        var query2 = from department in departments
            join student in students on department.ID equals student.DepartmentID
            select new
            {
                DepartmentName = department.Name,
                StudentName = $"{student.FirstName} {student.LastName}"
            };

        Console.WriteLine("The equivalent operation using Join():");
        foreach (var v in query2)
        {
            Console.WriteLine($"{v.DepartmentName} - {v.StudentName}");
        }
        // </InnerJoinQuery>
    }

    private static void InnerGroupJoinMethodSyntax()
    {
        // <InnerGroupJoinMethod>
        var queryMethod1 = departments
            .GroupJoin(students, department => department.ID, student => student.DepartmentID,
                (department, gj) => new { department, gj })
            .SelectMany(departmentAndStudent => departmentAndStudent.gj,
                (departmentAndStudent, subStudent) => new
                {
                    DepartmentName = departmentAndStudent.department.Name,
                    StudentName = $"{subStudent.FirstName} {subStudent.LastName}"
                });

        Console.WriteLine("Inner join using GroupJoin():");
        foreach (var v in queryMethod1)
        {
            Console.WriteLine($"{v.DepartmentName} - {v.StudentName}");
        }
        // </InnerGroupJoinMethod>
    }

    private static void InnerJoinMethodSyntax()
    { 
        // <InnerJoinMethod>
        var queryMethod2 = departments.Join(students, departments => departments.ID, student => student.DepartmentID,
            (department, student) => new
            {
                DepartmentName = department.Name,
                StudentName = $"{student.FirstName} {student.LastName}"
            });

        Console.WriteLine("The equivalent operation using Join():");
        foreach (var v in queryMethod2)
        {
            Console.WriteLine($"{v.DepartmentName} - {v.StudentName}");
        }
        // </InnerJoinMethod>
    }
}
