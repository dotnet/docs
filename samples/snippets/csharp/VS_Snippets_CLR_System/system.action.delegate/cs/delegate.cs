// <Snippet1>
using System;
using System.Windows.Forms;

public delegate void ShowValue();

public class Name
{
   private string instanceName;
   
   public Name(string name)
   {
      this.instanceName = name;
   }

   public void DisplayToConsole()
   {
      Console.WriteLine(this.instanceName);
   }

   public void DisplayToWindow()
   {
      MessageBox.Show(this.instanceName);
   }
}

public class testTestDelegate
{
   public static void Main()
   {
      Name testName = new Name("Koani");
      ShowValue showMethod = testName.DisplayToWindow;
      showMethod();
   }
}
// </Snippet1>
