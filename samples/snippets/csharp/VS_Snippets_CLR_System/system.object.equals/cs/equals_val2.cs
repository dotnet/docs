// <Snippet4>
using System;

// Define a value type that does not override Equals.
public struct Person
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

public struct Example
{
   public static void Main()
   {
      Person person1 = new Person("John");
      Person person2 = new Person("John");
      
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
