using System;

public class Person 
{}

public class Example
{
   public static void Main()
   {
      var obj = new Person();
      // <Snippet1>
      if (obj is Person) {
         // Do something if obj is a Person.
      }
      // </Snippet1>


   }
}

