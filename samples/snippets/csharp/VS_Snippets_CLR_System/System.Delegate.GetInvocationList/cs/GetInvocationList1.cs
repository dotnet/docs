// <Snippet1>
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

public class Example
{
   public static void Main()
   {
      Action<String> outputMessage = null;
      outputMessage += Console.WriteLine;
      outputMessage += OutputToFile;
      outputMessage += ShowMessageBox;

//       Dim output1 As Action(Of String) = AddressOf Console.WriteLine
//       Dim output2 As Action(Of String) = AddressOf OutputToFile 
//       Dim output3 As Action(Of String) = AddressOf MessageBox.Show
//       
//       outputMessage = [Delegate].Combine( { output1, output2, output3 } )
      Console.WriteLine("Invocation list has {0} methods.", 
                        outputMessage.GetInvocationList().Length);

      // Invoke delegates normally.
      outputMessage("Hello there!");
      Console.WriteLine("Press <Enter> to continue...");
      Console.ReadLine();
      
      // Invoke each delegate in the invocation list in reverse order.
      for (int ctr = outputMessage.GetInvocationList().Length - 1; ctr >= 0; ctr--) {
         var outputMsg = outputMessage.GetInvocationList()[ctr];
         outputMsg.DynamicInvoke("Greetings and salutations!");
      }
      Console.WriteLine("Press <Enter> to continue...");
      Console.ReadLine();

      // Invoke each delegate that doesn't write to a file.
      for (int ctr = 0; ctr < outputMessage.GetInvocationList().Length; ctr++) {  
         var outputMsg = outputMessage.GetInvocationList()[ctr];
         if (! outputMsg.GetMethodInfo().Name.Contains("File"))
            outputMsg.DynamicInvoke( new String[] { "Hi!" } );
         
      }
   }

   private static void OutputToFile(String s)
   {
      var sw = new StreamWriter(@".\output.txt");
      sw.WriteLine(s);
      sw.Close();
   }

   private static void ShowMessageBox(String s)
   {
      MessageBox.Show(s);
   }
}
// </Snippet1>

