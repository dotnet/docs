namespace StandardQueryOperators;

public class OrderResultsOfJoin
{
    private static readonly IEnumerable<Department> departments = Sources.Departments;
    private static readonly IEnumerable<Student> students = Sources.Students;

    public static void RunAllSnippets()
    {
        Console.WriteLine("Order Results of Join");
        OrderResultsOfJoinQuerySyntax();
        Console.WriteLine("Order Results of Join Method");
        OrderResultsOfJoinMethodSyntax();
    }

    private static void OrderResultsOfJoinQuerySyntax()
    {
        // <OrderResultsOfJoinQuery>
        var orderedQuery = from department in departments
                           join student in students on department.ID equals student.DepartmentID into studentGroup
                           orderby department.Name
                           select new
                           {
                               DepartmentName = department.Name,
                               Students = from student in studentGroup
                                          orderby student.LastName
                                            select student
                           };

        foreach (var departmentList in orderedQuery)
        {
            Console.WriteLine(departmentList.DepartmentName);
            foreach (var student in departmentList.Students)
            {
                Console.WriteLine($"  {student.LastName,-10} {student.FirstName,-10}");
            }
        }
        /* Output:
        Chemistry
          Balzan     Josephine
          Fakhouri   Fadi
          Popov      Innocenty
          Seleznyova Sofiya
          Vella      Carmen
        Economics
          Adams      Terry
          Adaobi     Izuchukwu
          Berggren   Jeanette
          Garcia     Cesar
          Ifeoma     Nwanneka
          Jamuike    Ifeanacho
          Larsson    Naima
          Svensson   Noel
          Ugomma     Ifunanya
        Engineering
          Axelsson   Erik
          Berg       Veronika
          Engström   Nancy
          Hicks      Cassie
          Keever     Bruce
          Micallef   Nicholas
          Mortensen  Sven
          Nilsson    Erna
          Tucker     Michael
          Yermolayeva Anna
        English
          Andersson  Sarah
          Feng       Hanying
          Ivanova    Arina
          Jakobsson  Jesper
          Jensen     Christiane
          Johansson  Mark
          Kolpakova  Nadezhda
          Omelchenko Svetlana
          Urquhart   Donald
        Mathematics
          Frost      Gaby
          Garcia     Hugo
          Hedlund    Anna
          Kovaleva   Katerina
          Lindgren   Max
          Maslova    Evgeniya
          Olsson     Ruth
          Sammut     Maria
          Sazonova   Anastasiya
        Physics
          Åkesson    Sami
          Edwards    Amy E.
          Falzon     John
          Garcia     Debra
          Hansson    Sanna
          Mattsson   Martina
          Richardson Don
          Zabokritski Eugene
        */
        // </OrderResultsOfJoinQuery>
    }

    private static void OrderResultsOfJoinMethodSyntax()
    {
        // <OrderResultsOfJoinMethod>
        var orderedQuery = departments
            .GroupJoin(students, department => department.ID, student => student.DepartmentID,
            (department, studentGroup) => new
            {
                DepartmentName = department.Name,
                Students = studentGroup.OrderBy(student => student.LastName)
            })
            .OrderBy(department => department.DepartmentName);


        foreach (var departmentList in orderedQuery)
        {
            Console.WriteLine(departmentList.DepartmentName);
            foreach (var student in departmentList.Students)
            {
                Console.WriteLine($"  {student.LastName,-10} {student.FirstName,-10}");
            }
        }
        // </OrderResultsOfJoinMethod>
    }
}
