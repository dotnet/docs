using System;

public class Person
{
   string name;
   
// <Snippet1>
   public string Name
   {
       get => name;
       set => name = value ?? 
           throw new ArgumentNullException("Name cannot be null", nameof(value));
   }   
// </Snippet1>
}

class Program
{
   static void Main(string[] args)
   {
      Person p = new Person();
      string name = null;
      p.Name = name;
   }
}

