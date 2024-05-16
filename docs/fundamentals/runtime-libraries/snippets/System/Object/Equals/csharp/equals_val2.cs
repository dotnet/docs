// <Snippet4>
using System;

// Define a value type that does not override Equals.
public struct Person3
{
   private string personName;

   public Person3(string name)
   {
      this.personName = name;
   }

   public override string ToString()
   {
      return this.personName;
   }
}

public struct Example3
{
   public static void Main()
   {
      Person3 person1 = new Person3("John");
      Person3 person2 = new Person3("John");

      Console.WriteLine("Calling Equals:");
      Console.WriteLine(person1.Equals(person2));

      Console.WriteLine("\nCasting to an Object and calling Equals:");
      Console.WriteLine(((object) person1).Equals((object) person2));
   }
}
// The example displays the following output:
//       Calling Equals:
//       True
//
//       Casting to an Object and calling Equals:
//       True
// </Snippet4>
