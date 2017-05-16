// <Snippet4>
using System;
using System.Windows.Forms;

public class TestLambdaExpression
{
   public static void Main()
   {
      Action<string> messageTarget; 
      
      if (Environment.GetCommandLineArgs().Length > 1)
         messageTarget = s => ShowWindowsMessage(s); 
      else
         messageTarget = s => Console.WriteLine(s);
      
      messageTarget("Hello, World!");
   }
      
   private static void ShowWindowsMessage(string message)
   {
      MessageBox.Show(message);      
   }
}
// </Snippet4>
