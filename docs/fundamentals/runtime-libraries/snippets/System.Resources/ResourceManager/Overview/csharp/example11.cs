// <Snippet7>
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
// </Snippet7>

[Serializable] public struct PersonTable2
{
   public readonly int nColumns;
   public readonly string column1;
   public readonly string column2;
   public readonly string column3;
   public readonly int width1;
   public readonly int width2;
   public readonly int width3;

   public PersonTable2(string column1, string column2, string column3,
                  int width1, int width2, int width3)
   {
      this.column1 = column1;
      this.column2 = column2;
      this.column3 = column3;
      this.width1 = width1;
      this.width2 = width2;
      this.width3 = width3;
      this.nColumns = typeof(PersonTable).GetFields().Length / 2;
   }
}
