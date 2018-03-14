' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection
Imports System.Runtime.InteropServices

Module Example
   Private Const WORD_CLSID As String = "{000209FF-0000-0000-C000-000000000046}"
   
   Public Sub Main()
      ' Start an instance of the Word application.
      Dim word As Type = Type.GetTypeFromCLSID(Guid.Parse(WORD_CLSID))
      Console.WriteLine("Instantiated Type object from CLSID {0}",
                        WORD_CLSID)
      Dim wordObj As Object = Activator.CreateInstance(word)
      Console.WriteLine("Instantiated {0}", 
                        wordObj.GetType().FullName)
      
      ' Close Word.
      word.InvokeMember("Quit", BindingFlags.InvokeMethod, Nothing, 
                        wordObj, New Object() { 0, 0, False } )
   End Sub
End Module
' The example displays the following output:
'    Instantiated Type object from CLSID {000209FF-0000-0000-C000-000000000046}
'    Instantiated Microsoft.Office.Interop.Word.ApplicationClass
' </Snippet1>

