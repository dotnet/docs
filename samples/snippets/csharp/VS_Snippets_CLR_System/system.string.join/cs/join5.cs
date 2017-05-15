// <Snippet5>
using System;
using System.Collections.Generic;
using System.Linq;

public class Animal
{
   public string Kind;
   public string Order;
   
   public Animal(string kind, string order)
   {
      this.Kind = kind;
      this.Order = order;
   }
   
   public override string ToString()
   {
      return this.Kind;
   }
}

public class Example
{
   public static void Main()
   {
      List<Animal> animals = new List<Animal>();
      animals.Add(new Animal("Squirrel", "Rodent"));
      animals.Add(new Animal("Gray Wolf", "Carnivora"));
      animals.Add(new Animal("Capybara", "Rodent"));
      string output = String.Join(" ", animals.Where( animal => 
                      (animal.Order == "Rodent")));
      Console.WriteLine(output);  
   }
}
// The example displays the following output:
//      Squirrel Capybara
// </Snippet5>
