// <Snippet1>
using System;
using System.Reflection;
using Contoso.Libraries;

namespace Contoso.Libraries
{
   public class Person
   {
      private string _name;
   
      public Person()
      { }
   
      public Person(string name)
      {
         this._name = name;
      }
   
      public string Name
      { get { return this._name; }
        set { this._name = value; } }
   
      public override string ToString()
      {
         return this._name;
      }
   }
}

public class Example
{
   public static void Main()
   {
      Assembly assem = typeof(Person).Assembly;
      Person p = (Person) assem.CreateInstance("Contoso.Libraries.Person");
      if (! (p == null)) {
         p.Name = "John";
         Console.WriteLine("Instantiated a {0} object whose value is '{1}'",
                           p.GetType().Name, p);
      }
      else {
         Console.WriteLine("Unable to instantiate a Person object.");
      }   
   }
}
// The example displays the following output:
//        Instantiated a Person object whose value is 'John'
// </Snippet1>

