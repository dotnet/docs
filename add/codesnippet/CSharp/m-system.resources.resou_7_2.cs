using System;
using System.Resources;

public class CreateResource
{
   public static void Main()
   {
      PersonTable table = new PersonTable("Name", "Employee Number", 
                                          "Age", 30, 18, 5);
      ResXResourceWriter rr = new ResXResourceWriter(@".\UIResources.resx");
      rr.AddResource("TableName", "Employees of Acme Corporation");
      rr.AddResource("Employees", table);
      rr.Generate();
      rr.Close();
   }
}