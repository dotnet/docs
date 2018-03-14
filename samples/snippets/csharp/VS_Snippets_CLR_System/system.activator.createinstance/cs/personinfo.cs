// <Snippet1>
using System;

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
// </Snippet1>