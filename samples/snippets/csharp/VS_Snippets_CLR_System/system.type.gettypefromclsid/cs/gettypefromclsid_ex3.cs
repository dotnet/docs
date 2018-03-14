// <Snippet3>
using System;
using System.Reflection;
using System.Runtime.InteropServices;

public class Example
{
   private const string WORD_CLSID = "{000209FF-0000-0000-C000-000000000046}";
   
   public static void Main()
   {
      // Start an instance of the Word application.
      var word = Type.GetTypeFromCLSID(Guid.Parse(WORD_CLSID), "computer17.central.contoso.com");
      Console.WriteLine("Instantiated Type object from CLSID {0}",
                        WORD_CLSID);
      try {
         Object wordObj = Activator.CreateInstance(word);
         Console.WriteLine("Instantiated {0}", 
                           wordObj.GetType().FullName, WORD_CLSID);
            
         // Close Word.
         word.InvokeMember("Quit", BindingFlags.InvokeMethod, null, 
                           wordObj, new object[] { 0, 0, false } );
      }
      catch (COMException) {
         Console.WriteLine("Unable to instantiate object.");   
      }
   }
}
// The example displays the following output:
//    Instantiated Type object from CLSID {000209FF-0000-0000-C000-000000000046}
//    Instantiated Microsoft.Office.Interop.Word.ApplicationClass
// </Snippet3>
