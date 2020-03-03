' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module ByteConversion
   Public Sub Main()
      Dim byteStrings() As String = { Nothing, String.Empty, "1024", 
                                    "100.1", "100", "+100", "-100",
                                    "000000000000000100", "00,100",
                                    "   20   ", "FF", "0x1F"}

      For Each byteString As String In byteStrings
        CallTryParse(byteString)
      Next
   End Sub
   
   Private Sub CallTryParse(stringToConvert As String)  
      Dim byteValue As Byte
      Dim success As Boolean = Byte.TryParse(stringToConvert, byteValue)
      If success Then
         Console.WriteLine("Converted '{0}' to {1}", _
                        stringToConvert, byteValue)
      Else
         Console.WriteLine("Attempted conversion of '{0}' failed.", _
                           stringToConvert)
      End If                        
   End Sub
End Module
' The example displays the following output to the console:
'       Attempted conversion of '' failed.
'       Attempted conversion of '' failed.
'       Attempted conversion of '1024' failed.
'       Attempted conversion of '100.1' failed.
'       Converted '100' to 100
'       Converted '+100' to 100
'       Attempted conversion of '-100' failed.
'       Converted '000000000000000100' to 100
'       Attempted conversion of '00,100' failed.
'       Converted '   20   ' to 20
'       Attempted conversion of 'FF' failed.
'       Attempted conversion of '0x1F' failed.
' </Snippet1>
