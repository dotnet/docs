// <Snippet2>
using System;

// Define a reference type that does not override Equals.
public class Person
{
   private string personName;

   public Person(string name)
   {
      this.personName = name;
   }

   public override string ToString()
   {
      return this.personName;
   }
}

public class Example1
{
   public static void Main()
   {
      Person person1a = new Person("John");
      Person person1b = person1a;
      Person person2 = new Person(person1a.ToString());

      Console.WriteLine("Calling Equals:");
      Console.WriteLine($"person1a and person1b: {person1a.Equals(person1b)}");
      Console.WriteLine($"person1a and person2: {person1a.Equals(person2)}");

      Console.WriteLine("\nCasting to an Object and calling Equals:");
      Console.WriteLine($"person1a and person1b: {((object) person1a).Equals((object) person1b)}");
      Console.WriteLine($"person1a and person2: {((object) person1a).Equals((object) person2)}");
   }
}
// The example displays the following output:
//       person1a and person1b: True
//       person1a and person2: False
//
//       Casting to an Object and calling Equals:
//       person1a and person1b: True
//       person1a and person2: False
// </Snippet2>
