// <Snippet10>
using System;

public class Example
{
   public static void Main()
   {
      Object o = new Person("Jane");
      ShowValue(o);
      
      o = new Dog("Alaskan Malamute");
      ShowValue(o);
   }

   public static void ShowValue(object o)
   {
      if (o is Person) {
         Person p = (Person) o;
         Console.WriteLine(p.Name);
      }   
      else if (o is Dog) {
         Dog d = (Dog) o;
         Console.WriteLine(d.Breed);
      }             
   }
}

public struct Person
{  
   public string Name { get; set; }
   
   public Person(string name) : this()
   {
      Name = name;
   }
}

public struct Dog
{
   public string Breed { get; set; }

   public Dog(string breedName) : this()
   {
      Breed = breedName;
   }
}
// The example displays the following output:
//       Jane
//       Alaskan Malamute
// </Snippet10>

