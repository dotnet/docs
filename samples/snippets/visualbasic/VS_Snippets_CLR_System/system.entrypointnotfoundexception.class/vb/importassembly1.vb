' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Module Example
   Declare Unicode Function GoodMorning Lib "StringUtilities.dll" (
      ByVal name As String) As String  

   Public Sub Main()
      Console.WriteLine(SayGoodMorning("Dakota"))
   End Sub
End Module
' The example displays the following output:
'    Unhandled Exception: System.EntryPointNotFoundException: Unable to find an entry point 
'    named 'GoodMorning' in DLL 'StringUtilities.dll'.
'       at Example.GoodMorning(String& name)
'       at Example.Main()
' </Snippet4>
