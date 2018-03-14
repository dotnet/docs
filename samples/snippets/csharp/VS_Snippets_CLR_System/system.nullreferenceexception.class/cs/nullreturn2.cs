// <Snippet4>
using System;

public class Example
{
   public static void Main()
   {
      Person[] persons = Person.AddRange( new String[] { "Abigail", "Abra", 
                                          "Abraham", "Adrian", "Ariella", 
                                          "Arnold", "Aston", "Astor" } );    
      String nameToFind = "Robert";
      Person found = Array.Find(persons, p => p.FirstName == nameToFind);
      Console.WriteLine(found.FirstName);
   }
}

public class Person
{
   public static Person[] AddRange(String[] firstNames) 
   {
      Person[] p = new Person[firstNames.Length];
      for (int ctr = 0; ctr < firstNames.Length; ctr++)
         p[ctr] = new Person(firstNames[ctr]);

      return p;
   }
   
   public Person(String firstName)
   {
      this.FirstName = firstName;
   } 
   
   public String FirstName;
}
// The example displays the following output:
//       Unhandled Exception: System.NullReferenceException: 
//       Object reference not set to an instance of an object.
//          at Example.Main()
// </Snippet4>