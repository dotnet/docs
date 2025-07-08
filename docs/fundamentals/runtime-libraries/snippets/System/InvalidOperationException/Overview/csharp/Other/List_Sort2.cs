// <Snippet13>
using System;
using System.Collections.Generic;

public class Person2 : IComparable<Person>
{
    public Person2(String fName, String lName)
    {
        FirstName = fName;
        LastName = lName;
    }

    public String FirstName { get; set; }
    public String LastName { get; set; }

    public int CompareTo(Person other)
    {
        return String.Format("{0} {1}", LastName, FirstName).
               CompareTo(String.Format("{0} {1}", other.LastName, other.FirstName));
    }
}

public class ListSortEx2
{
    public static void Main()
    {
        var people = new List<Person2>();

        people.Add(new Person2("John", "Doe"));
        people.Add(new Person2("Jane", "Doe"));
        people.Sort();
        foreach (var person in people)
            Console.WriteLine($"{person.FirstName} {person.LastName}");
    }
}
// The example displays the following output:
//       Jane Doe
//       John Doe
// </Snippet13>
