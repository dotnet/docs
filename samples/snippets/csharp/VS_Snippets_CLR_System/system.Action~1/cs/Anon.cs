// <Snippet3>
using System;
using System.Windows.Forms;

public class TestAnonMethod
{
   public static void Main()
   {
      Action<string> messageTarget; 
      
      if (Environment.GetCommandLineArgs().Length > 1)
         messageTarget = delegate(string s) { ShowWindowsMessage(s); };
      else
         messageTarget = delegate(string s) { Console.WriteLine(s); };
      
      messageTarget("Hello, World!");
   }
      
   private static void ShowWindowsMessage(string message)
   {
      MessageBox.Show(message);      
   }
}
// </Snippet3>
