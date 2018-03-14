// <Snippet1>
using System;
using System.Reflection;
using System.Runtime.InteropServices;

public class Example
{
   private const string WORD_CLSID = "{000209FF-0000-0000-C000-000000000046}";
   
   public static void Main()
   {
      // Start an instance of the Word application.
      var word = Type.GetTypeFromCLSID(Guid.Parse(WORD_CLSID));
      Console.WriteLine("Instantiated Type object from CLSID {0}",
                        WORD_CLSID);
      Object wordObj = Activator.CreateInstance(word);
      Console.WriteLine("Instantiated {0}", 
                        wordObj.GetType().FullName);
      
      // Close Word.
      word.InvokeMember("Quit", BindingFlags.InvokeMethod, null, 
                        wordObj, new object[] { 0, 0, false } );
   }
}
// The example displays the following output:
//    Instantiated Type object from CLSID {000209FF-0000-0000-C000-000000000046}
//    Instantiated Microsoft.Office.Interop.Word.ApplicationClass
// </Snippet1>
