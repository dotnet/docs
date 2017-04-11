// <Snippet28>
using System;

[assembly: CLSCompliant(true)]

public class Animal
{
   private string _species;
   
   public Animal(string species)
   {
      _species = species;
   }
   
   public virtual string Species 
   {    
      get { return _species; }
   }
   
   public override string ToString()
   {
      return _species;   
   } 
}

public class Human : Animal
{
   private string _name;
   
   public Human(string name) : base("Homo Sapiens")
   {
      _name = name;
   }
   
   public string Name
   {
      get { return _name; }
   }
   
   private override string Species 
   {
      get { return base.Species; }
   }
   
   public override string ToString() 
   {
      return _name;
   }
}

public class Example
{
   public static void Main()
   {
      Human p = new Human("John");
      Console.WriteLine(p.Species);
      Console.WriteLine(p.ToString());
   }
}
// The example displays the following output:
//    error CS0621: 'Human.Species': virtual or abstract members cannot be private
// </Snippet28>
