using System;
using System.Resources;

[assembly: NeutralResourcesLanguageAttribute("en")]

public class Example
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