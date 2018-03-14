' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
	Declare Auto Function GetMyNumber Lib "User32.dll" () As Integer

   Public Sub Main()
      Try
         Dim number As Integer = GetMyNumber()
      Catch e As EntryPointNotFoundException
         Console.WriteLine("{0}:{2}   {1}", e.GetType().Name,  
                           e.Message, vbCrLf)
      End Try   
   End Sub
End Module
' The example displays the following output:
'    EntryPointNotFoundException:
'       Unable to find an entry point named 'GetMyNumber' in DLL 'User32.dll'.
' </Snippet1>
