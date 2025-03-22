// <Snippet14>
using System;
using System.Collections.Generic;

public class Person3
{
    public Person3(String fName, String lName)
    {
        FirstName = fName;
        LastName = lName;
    }

    public String FirstName { get; set; }
    public String LastName { get; set; }
}

public class PersonComparer : IComparer<Person3>
{
    public int Compare(Person3 x, Person3 y)
    {
        return String.Format("{0} {1}", x.LastName, x.FirstName).
               CompareTo(String.Format("{0} {1}", y.LastName, y.FirstName));
    }
}

public class ListSortEx3
{
    public static void Main()
    {
        var people = new List<Person3>();

        people.Add(new Person3("John", "Doe"));
        people.Add(new Person3("Jane", "Doe"));
        people.Sort(new PersonComparer());
        foreach (var person in people)
            Console.WriteLine($"{person.FirstName} {person.LastName}");
    }
}
// The example displays the following output:
//       Jane Doe
//       John Doe
// </Snippet14>
