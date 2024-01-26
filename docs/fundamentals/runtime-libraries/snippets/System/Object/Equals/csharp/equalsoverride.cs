using System;

// <Snippet6>
public class Person6
{
   private string idNumber;
   private string personName;

   public Person6(string name, string id)
   {
      this.personName = name;
      this.idNumber = id;
   }

   public override bool Equals(Object obj)
   {
      Person6 personObj = obj as Person6;
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

public class Example6
{
   public static void Main()
   {
      Person6 p1 = new Person6("John", "63412895");
      Person6 p2 = new Person6("Jack", "63412895");
      Console.WriteLine(p1.Equals(p2));
      Console.WriteLine(Object.Equals(p1, p2));
   }
}
// The example displays the following output:
//       True
//       True
// </Snippet6>
