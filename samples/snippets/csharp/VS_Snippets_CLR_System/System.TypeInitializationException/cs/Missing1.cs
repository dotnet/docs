// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      Person p = new Person("John", "Doe");
      Console.WriteLine(p);   
   }
}

public class Person
{
   static InfoModule infoModule;
   
   String fName;
   String mName;
   String lName;
   
   static Person()
   {
      infoModule = new InfoModule(DateTime.UtcNow);
   }
   
   public Person(String fName, String lName)
   {
      this.fName = fName;
      this.lName = lName;
      infoModule.Increment();
   }
   
   public override String ToString()
   {
      return String.Format("{0} {1}", fName, lName);
   }
}
// The example displays the following output if missing1a.dll is renamed or removed:
//    Unhandled Exception: System.TypeInitializationException: 
//       The type initializer for 'Person' threw an exception. ---> 
//       System.IO.FileNotFoundException: Could not load file or assembly 
//       'Missing1a, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' 
//       or one of its dependencies. The system cannot find the file specified.
//       at Person..cctor()
//       --- End of inner exception stack trace ---
//       at Person..ctor(String fName, String lName)
//       at Example.Main()
// </Snippet2>

