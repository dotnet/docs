// <Snippet1>
using System;
using Corporate.EmployeeObjects;

public class Example
{
   public static void Main()
   {
      var empA = new EmployeeA{ Name = "Robert",};
      Console.WriteLine(empA.ToString());
      
      var empB = new EmployeeB{ Name = "Robert",};
      Console.WriteLine(empB.ToString());
   }
}

namespace Corporate.EmployeeObjects
{
    public struct EmployeeA
    {
         public String Name { get; set; }
    }
    
    public struct EmployeeB
    {
         public String Name { get; set; }

         public override String ToString()
         {
              return Name;
         }
    }  
}
// The example displays the following output:
//     Corporate.EmployeeObjects.EmployeeA
//     Robert
// </Snippet1>

