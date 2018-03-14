// <Snippet11>
using System;

[assembly: CLSCompliant(true)]

public class Person
{
   private string fName, lName, _id;
   
   public Person(string firstName, string lastName, string id)
   {
      if (String.IsNullOrEmpty(firstName + lastName))
         throw new ArgumentNullException("Either a first name or a last name must be provided.");    
      
      fName = firstName;
      lName = lastName;
      _id = id;
   }
   
   public string FirstName 
   {
      get { return fName; }
   }

   public string LastName 
   {
      get { return lName; }
   }
   
   public string Id 
   {
      get { return _id; }
   }

   public override string ToString()
   {
      return String.Format("{0}{1}{2}", fName, 
                           String.IsNullOrEmpty(fName) ?  "" : " ",
                           lName);
   }
}

public class Doctor : Person
{
   public Doctor(string firstName, string lastName, string id)
   {
   }

   public override string ToString()
   {
      return "Dr. " + base.ToString();
   }
}
// Attempting to compile the example displays output like the following:
//    ctor1.cs(45,11): error CS1729: 'Person' does not contain a constructor that takes 0
//            arguments
//    ctor1.cs(10,11): (Location of symbol related to previous error)
// </Snippet11>

public class Example
{
   public static void Main()
   {


   }
}

