using System;

public class Person
{
   private string firstName;
   private string lastName;
   
   public Person(string first, string last)
   {
      firstName = first;
      lastName = last;
   }

   public string Name => $"{firstName} {lastName}";   
}

public class Example
{
   public static void Main()
   {
      var person = new Person("John", "Doe");
      Console.WriteLine(person.Name);
   }
}
// The example displays the following output:
//       John Doe

