using System.Xml.Linq;

namespace StandardQueryOperators;
public static class GroupJoins
{
    private static readonly IEnumerable<Department> departments = Sources.Departments;
    private static readonly IEnumerable<Student> students = Sources.Students;

    public static void RunAllSnippets()
    {
        GroupJoinQuerySyntax();
        GroupJoinMethodSyntax();
        GroupJoinToXmlQuerySyntax();
        GroupJoinToXmlMethodSyntax();
    }

    private static void GroupJoinQuerySyntax()
    {
        // <GroupJoinQuery>
        var query = from department in departments
            join student in students on department.ID equals student.DepartmentID into studentGroup
            select new
            {
                DepartmentName = department.Name,
                Students = studentGroup
            };

        foreach (var v in query)
        {
            // Output the department's name.
            Console.WriteLine($"{v.DepartmentName}:");

            // Output each of the owner's pet's names.
            foreach (Student? student in v.Students)
            {
                Console.WriteLine($"  {student.FirstName} {student.LastName}");
            }
        }

        /* Output:
             Magnus:
               Daisy
             Terry:
               Barley
               Boots
               Blue Moon
             Charlotte:
               Whiskers
             Arlene:
         */
        // </GroupJoinQuery>
    }

    private static void GroupJoinMethodSyntax()
    {
        // <GroupJoinMethod>
        var query = departments.GroupJoin(students, department => department.ID, student => student.DepartmentID,
            (department, Students) => new { DepartmentName = department.Name, Students });

        foreach (var v in query)
        {
            // Output the department's name.
            Console.WriteLine($"{v.DepartmentName}:");

            // Output each of the owner's pet's names.
            foreach (Student? student in v.Students)
            {
                Console.WriteLine($"  {student.FirstName} {student.LastName}");
            }
        }

        /* Output:
             Magnus:
               Daisy
             Terry:
               Barley
               Boots
               Blue Moon
             Charlotte:
               Whiskers
             Arlene:
         */
        // </GroupJoinMethod>
    }
    private static void GroupJoinToXmlQuerySyntax()
    {
        // <GroupJoinToXmlQuery>
        XElement departmentsAndStudents = new("DepartmentEnrollment",
            from department in departments
            join student in students on department.ID equals student.DepartmentID into studentGroup
            select new XElement("Department",
                new XAttribute("Name", department.Name),
                from student in studentGroup
                select new XElement("Student",
                    new XAttribute("FirstName", student.FirstName),
                    new XAttribute("LastName", student.LastName)
                )
            )
        );

        Console.WriteLine(departmentsAndStudents);

        /* Output:
             <PetOwners>
               <Person FirstName="Magnus" LastName="Hedlund">
                 <Pet>Daisy</Pet>
               </Person>
               <Person FirstName="Terry" LastName="Adams">
                 <Pet>Barley</Pet>
                 <Pet>Boots</Pet>
                 <Pet>Blue Moon</Pet>
               </Person>
               <Person FirstName="Charlotte" LastName="Weiss">
                 <Pet>Whiskers</Pet>
               </Person>
               <Person FirstName="Arlene" LastName="Huff" />
             </PetOwners>
        */
        // </GroupJoinToXmlQuery>
    }

    private static void GroupJoinToXmlMethodSyntax()
    {
        // <GroupJoinToXmlMethod>
        XElement departmentsAndStudents = new("DepartmentEnrollment",
            departments.GroupJoin(students, department => department.ID, student => student.DepartmentID,
                (department, Students) => new XElement("Department",
                    new XAttribute("Name", department.Name),
                    from student in Students
                    select new XElement("Student",
                        new XAttribute("FirstName", student.FirstName),
                        new XAttribute("LastName", student.LastName)
                    )
                )
            )
        );

        Console.WriteLine(departmentsAndStudents);

        /* Output:
             <PetOwners>
               <Person FirstName="Magnus" LastName="Hedlund">
                 <Pet>Daisy</Pet>
               </Person>
               <Person FirstName="Terry" LastName="Adams">
                 <Pet>Barley</Pet>
                 <Pet>Boots</Pet>
                 <Pet>Blue Moon</Pet>
               </Person>
               <Person FirstName="Charlotte" LastName="Weiss">
                 <Pet>Whiskers</Pet>
               </Person>
               <Person FirstName="Arlene" LastName="Huff" />
             </PetOwners>
        */
        // </GroupJoinToXmlMethod>
    }
}
