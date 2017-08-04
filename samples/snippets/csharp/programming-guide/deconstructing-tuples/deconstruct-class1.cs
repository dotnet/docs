using System;

public class Person
{
   public string FirstName { get; set; }
   public string MiddleName { get; set; }
   public string LastName { get; set; }

   // <Snippet1>
   public Person(string fname, string mname, string lname)
   // </Snippet1>
   {
      FirstName = fname;
      MiddleName = mname;
      LastName = lname;
   }   
   
   public void Deconstruct(out string fname, out string mname, out string lname)
   {
      fname = FirstName;
      mname = MiddleName;
      lname = LastName;
   }
}


public class Example
{
   public static void Main()
   {
       Person p = new Person("John", "Quincy", "Adams");
       // <Snippet2>
       var (fName, mName, lName) = p;
       // </Snippet2>
   }
}
