// <Snippet1>
using System;
using System.Reflection;

public class Employee
{
   private string _id;

   public String FirstName { get; set; }
   public String MiddleName { get; set; }
   public String LastName  { get; set; }
   public DateTime HireDate  { get; set; }

   public String ID
   {
      get { return _id; }
      set {
         if (ID.Trim().Length != 9)
            throw new ArgumentException("The ID is invalid");
         _id = value;
      }
   }
}

public class Example
{
   public static void Main()
   {
      Type t = typeof(Employee);
      Console.WriteLine("The {0} type has the following properties: ",
                        t.Name);
      foreach (var prop in t.GetProperties())
         Console.WriteLine("   {0} ({1})", prop.Name,
                           prop.PropertyType.Name);
   }
}
// The example displays the following output:
//       The Employee type has the following properties:
//          FirstName (String)
//          MiddleName (String)
//          LastName (String)
//          HireDate (DateTime)
//          ID (String)
// </Snippet1>
