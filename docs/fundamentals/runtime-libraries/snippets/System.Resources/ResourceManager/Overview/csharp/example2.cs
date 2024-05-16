// <Snippet8>
using System;
using System.Resources;

[assembly: NeutralResourcesLanguageAttribute("en")]

public class Example3
{
   public static void Main()
   {
      string fmtString = String.Empty;
      ResourceManager rm = new ResourceManager("UIResources", typeof(Example).Assembly);
      string title = rm.GetString("TableName");
      PersonTable tableInfo = (PersonTable) rm.GetObject("Employees");

      if (! String.IsNullOrEmpty(title)) {
         fmtString = "{0," + ((Console.WindowWidth + title.Length) / 2).ToString() + "}";
         Console.WriteLine(fmtString, title);
         Console.WriteLine();
      }

      for (int ctr = 1; ctr <= tableInfo.nColumns; ctr++) {
         string columnName = "column"  + ctr.ToString();
         string widthName = "width" + ctr.ToString();
         string value = tableInfo.GetType().GetField(columnName).GetValue(tableInfo).ToString();
         int width = (int) tableInfo.GetType().GetField(widthName).GetValue(tableInfo);
         fmtString = "{0,-" + width.ToString() + "}";
         Console.Write(fmtString, value);
      }
      Console.WriteLine();
   }
}
// </Snippet8>

[Serializable] public struct PersonTable3
{
   public readonly int nColumns;
   public readonly string column1;
   public readonly string column2;
   public readonly string column3;
   public readonly int width1;
   public readonly int width2;
   public readonly int width3;

   public PersonTable3(string column1, string column2, string column3,
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
