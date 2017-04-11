' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Reflection
Imports System.Runtime.InteropServices

Module Example
   Private Const WORD_CLSID As String = "{000209FF-0000-0000-C000-000000000046}"
   
   Public Sub Main()
      Try
         ' Start an instance of the Word application.
         Dim word As Type = Type.GetTypeFromCLSID(Guid.Parse(WORD_CLSID), 
                                                  "computer17.central.contoso.com",
                                                  True)
         Console.WriteLine("Instantiated Type object from CLSID {0}",
                           WORD_CLSID)

         Dim wordObj As Object = Activator.CreateInstance(word)
         Console.WriteLine("Instantiated {0}", 
                           wordObj.GetType().FullName)
         
         ' Close Word.
         word.InvokeMember("Quit", BindingFlags.InvokeMethod, Nothing, 
                           wordObj, New Object() { 0, 0, False } )
      ' The method can throw any of a variety of exceptions.
      Catch e As Exception
         Console.WriteLine("{0}: Unable to instantiate an object for {1}", 
                           e.GetType().Name, WORD_CLSID)
      End Try
   End Sub
End Module
' The example displays the following output:
'    Instantiated Type object from CLSID {000209FF-0000-0000-C000-000000000046}
'    Instantiated Microsoft.Office.Interop.Word.ApplicationClass
' </Snippet4>

