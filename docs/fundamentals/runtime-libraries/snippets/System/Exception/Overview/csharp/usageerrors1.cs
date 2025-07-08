// <Snippet4>
using System;

public class Person1
{
   private string _name;

   public string Name
   {
      get { return _name; }
      set { _name = value; }
   }

   public override int GetHashCode()
   {
      return this.Name.GetHashCode();
   }

   public override bool Equals(object obj)
   {
      // This implementation contains an error in program logic:
      // It assumes that the obj argument is not null.
      Person1 p = (Person1) obj;
      return this.Name.Equals(p.Name);
   }
}

public class UsageErrorsEx1
{
   public static void Main()
   {
      Person1 p1 = new Person1();
      p1.Name = "John";
      Person1 p2 = null;

      // The following throws a NullReferenceException.
      Console.WriteLine($"p1 = p2: {p1.Equals(p2)}");
   }
}
// </Snippet4>
