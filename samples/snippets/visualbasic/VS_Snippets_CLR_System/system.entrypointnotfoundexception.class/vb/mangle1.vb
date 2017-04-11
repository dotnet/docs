' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Module Example
   Public Declare Function DoubleNum Lib ".\TestDll.dll" Alias "Double" _
                  (ByVal number As Integer) As Integer
   
   Public Sub Main()
      Console.WriteLine(DoubleNum(10))
   End Sub
End Module
' The example displays the following output:
'    Unhandled Exception: System.EntryPointNotFoundException: Unable to find an 
'    entry point named 'Double' in DLL '.\TestDll.dll'.
'       at Example.Double(Int32 number)
'       at Example.Main()
' </Snippet7>
