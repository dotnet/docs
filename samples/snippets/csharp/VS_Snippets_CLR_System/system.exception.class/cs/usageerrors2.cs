// <Snippet5>
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
       // This implementation handles a null obj argument.
       Person p = obj as Person; 
       if (p == null) 
          return false;
       else
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
      
      Console.WriteLine("p1 = p2: {0}", p1.Equals(p2));   
   }
}
// The example displays the following output:
//        p1 = p2: False
// </Snippet5>
