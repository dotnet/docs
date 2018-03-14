
// <Snippet1>
using System;
using System.Collections.Generic;

public class Employee : IComparable
{
   public String Name { get; set; }
   public int Id { get; set; }

   public int CompareTo(Object o )
   {
      Employee e = o as Employee;
      if (e == null)
         throw new ArgumentException("o is not an Employee object.");

      return Name.CompareTo(e.Name);
   }
}

public class EmployeeSearch
{
   String _s;

   public EmployeeSearch(String s)
   {
      _s = s;
   }

   public bool StartsWith(Employee e)
   {
      return e.Name.StartsWith(_s, StringComparison.InvariantCultureIgnoreCase);
   }
}

public class Example
{
   public static void Main()
   {
      var employees = new List<Employee>();
      employees.AddRange( new Employee[] { new Employee { Name = "Frank", Id = 2 },
                                           new Employee { Name = "Jill", Id = 3 },
                                           new Employee { Name = "Dave", Id = 5 },
                                           new Employee { Name = "Jack", Id = 8 },
                                           new Employee { Name = "Judith", Id = 12 },
                                           new Employee { Name = "Robert", Id = 14 },
                                           new Employee { Name = "Adam", Id = 1 } } );
      employees.Sort();

      var es = new EmployeeSearch("J");
      Console.WriteLine("'J' starts at index {0}",
                        employees.FindIndex(0, employees.Count - 1, es.StartsWith));

      es = new EmployeeSearch("Ju");
      Console.WriteLine("'Ju' starts at index {0}",
                        employees.FindIndex(0, employees.Count - 1,es.StartsWith));
   }
}
// The example displays the following output:
//       'J' starts at index 3
//       'Ju' starts at index 5
// </Snippet1>

