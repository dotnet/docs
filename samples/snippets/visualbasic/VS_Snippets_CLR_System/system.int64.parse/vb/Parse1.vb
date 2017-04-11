' Visual Basic .NET Document
'
' Example code illustrating the overloads of the Int32.Parse method.
'
Option Strict On

' <Snippet1>
Module ParseInt64
   Public Sub Main()
      Convert("  179032  ")
      Convert(" -2041326 ")
      Convert(" +8091522 ")
      Convert("   1064.0   ")
      Convert("  178.3")
      Convert(String.Empty)
      Convert((CDec(Int64.MaxValue) + 1).ToString())
   End Sub

   Private Sub Convert(value As String)
      Try
         Dim number As Long = Int64.Parse(value)
         Console.WriteLine("Converted '{0}' to {1}.", value, number)
      Catch e As FormatException
         Console.WriteLine("Unable to convert '{0}'.", value)
      Catch e As OverflowException
         Console.WriteLine("'{0}' is out of range.", value)      
      End Try
   End Sub
End Module
' This example displays the following output to the console:
'       Converted '  179032  ' to 179032.
'       Converted ' -2041326 ' to -2041326.
'       Converted ' +8091522 ' to 8091522.
'       Unable to convert '   1064.0   '.
'       Unable to convert '  178.3'.
'       Unable to convert ''.
'       '9223372036854775808' is out of range.
' </Snippet1>
