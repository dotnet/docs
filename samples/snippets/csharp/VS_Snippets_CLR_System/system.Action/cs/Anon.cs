// <Snippet3>
using System;
using System.Windows.Forms;

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

public class Anonymous
{
   public static void Main()
   {
      Name testName = new Name("Koani");
      Action showMethod = delegate() { testName.DisplayToWindow();} ;
      showMethod();
   }
}
// </Snippet3>
