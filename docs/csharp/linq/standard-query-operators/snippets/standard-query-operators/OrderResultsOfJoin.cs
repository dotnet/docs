namespace StandardQueryOperators;

public class OrderResultsOfJoin
{
    // TODO: MOVE TO INDEX TO SHOW HOW QUERIES COMPOSE
    private static readonly IEnumerable<Department> departments = Department.Departments;
    private static readonly IEnumerable<Student> students = Student.Students;

    public static void RunAllSnippets()
    {
        OrderResultsOfJoinQuerySyntax();
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
            Beverages
              Cola       1
              Tea        1
            Condiments
              Mustard    2
              Pickles    2
            Fruit
              Melons     5
              Peaches    5
            Grains
            Vegetables
              Bok Choy   3
              Carrots    3
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

        /* Output:
            Beverages
              Cola       1
              Tea        1
            Condiments
              Mustard    2
              Pickles    2
            Fruit
              Melons     5
              Peaches    5
            Grains
            Vegetables
              Bok Choy   3
              Carrots    3
         */
        // </OrderResultsOfJoinMethod>
    }
}
