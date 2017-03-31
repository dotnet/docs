using System;

// <Snippet6>
public class Person
{
   private string idNumber;
   private string personName;
   
   public Person(string name, string id)
   {
      this.personName = name;
      this.idNumber = id;
   }
   
   public override bool Equals(Object obj)
   {
      Person personObj = obj as Person; 
      if (personObj == null)
         return false;
      else
         return idNumber.Equals(personObj.idNumber);
   }
   
   public override int GetHashCode()
   {
      return this.idNumber.GetHashCode(); 
   }
}

public class Example
{
   public static void Main()
   {
      Person p1 = new Person("John", "63412895");
      Person p2 = new Person("Jack", "63412895");
      Console.WriteLine(p1.Equals(p2));
      Console.WriteLine(Object.Equals(p1, p2));
   }
}
// The example displays the following output:
//       True
//       True
// </Snippet6>
