// <Snippet15>
using System;
using System.Collections.Generic;

public class Person
{
   public Person(String fName, String lName)
   {
      FirstName = fName;
      LastName = lName;
   }

   public String FirstName { get; set; }
   public String LastName { get; set; }
}

public class ListSortEx4
{
   public static void Main()
   {
      var people = new List<Person>();

      people.Add(new Person("John", "Doe"));
      people.Add(new Person("Jane", "Doe"));
      people.Sort(PersonComparison);
      foreach (var person in people)
         Console.WriteLine($"{person.FirstName} {person.LastName}");
   }

   public static int PersonComparison(Person x, Person y)
   {
      return String.Format("{0} {1}", x.LastName, x.FirstName).
             CompareTo(String.Format("{0} {1}", y.LastName, y.FirstName));
   }
}
// The example displays the following output:
//       Jane Doe
//       John Doe
// </Snippet15>
