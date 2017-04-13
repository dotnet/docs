'<Snippet1>
Imports System
Imports System.IO

Public Class ObjectDisposedExceptionTest
   
   Public Shared Sub Main()
      Dim ms As New MemoryStream(16)
      ms.Close()
      Try
         ms.ReadByte()
      Catch e As ObjectDisposedException
         Console.WriteLine("Caught: {0}", e.Message)
      End Try
   End Sub 'Main
End Class 'ObjectDisposedExceptionTest
'</Snippet1>