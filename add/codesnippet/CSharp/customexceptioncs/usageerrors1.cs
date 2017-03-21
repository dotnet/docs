// <Snippet4>
using System;

public class Person
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
      Person p = (Person) obj;
      return this.Name.Equals(p.Name);
   }
}

public class Example
{
   public static void Main()
   {
      Person p1 = new Person();
      p1.Name = "John";
      Person p2 = null; 
      
      // The following throws a NullReferenceException.
      Console.WriteLine("p1 = p2: {0}", p1.Equals(p2));   
   }
}
// </Snippet4>
