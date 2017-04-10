' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module ByteConversion
   Public Sub Main()
      Dim byteString As String = Nothing
      CallTryParse(byteString)
      
      byteString = String.Empty
      CallTryParse(byteString)
      
      byteString = "1024"
      CallTryParse(byteString)
      
      byteString = "100.1"
      CallTryParse(byteString)
      
      byteString = "100"
      CallTryParse(byteString)
      
      byteString = "+100"
      CallTryParse(byteString)
      
      byteString = "-100"
      CallTryParse(byteString)
      
      byteString = "000000000000000100"
      CallTryParse(byteString)
      
      byteString = "00,100"      
      CallTryParse(byteString)
      
      byteString = "   20   "
      CallTryParse(byteString)
      
      byteString = "FF"
      CallTryParse(byteString)
      
      byteString = "0x1F"
      CallTryParse(byteString)
   End Sub
   
   Private Sub CallTryParse(stringToConvert As String)  
      Dim byteValue As Byte
      Dim result As Boolean = Byte.TryParse(stringToConvert, byteValue)
      If result Then
         Console.WriteLine("Converted '{0}' to {1}", _
                        stringToConvert, byteValue)
      Else
         If stringToConvert Is Nothing Then stringToConvert = ""
         Console.WriteLine("Attempted conversion of '{0}' failed.", _
                           stringToConvert.ToString())
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
