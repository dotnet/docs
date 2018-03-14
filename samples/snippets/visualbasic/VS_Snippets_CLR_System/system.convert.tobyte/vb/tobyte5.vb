' Visual Basic .NET Document
Option Strict On

' <Snippet15>
Module Example
   Public Sub Main()
      Dim values() As String = { Nothing, "", "0xC9", "C9", "101", 
                                 "16.3", "$12", "$12.01", "-4", 
                                 "1,032", "255", "   16  " }
      For Each value In values
         Try 
            Dim number As Byte = Convert.ToByte(value)
            Console.WriteLine("'{0}' --> {1}", 
                              If(value Is Nothing, "<null>", value), number)
         Catch e As FormatException
            Console.WriteLine("Bad Format: '{0}'", 
                              If(value Is Nothing, "<null>", value))
         Catch e As OverflowException
            Console.WriteLine("OverflowException: '{0}'", value)
         End Try
      Next
   End Sub
End Module
' The example displays the following output:
'     '<null>' --> 0
'     Bad Format: ''
'     Bad Format: '0xC9'
'     Bad Format: 'C9'
'     '101' --> 101
'     Bad Format: '16.3'
'     Bad Format: '$12'
'     Bad Format: '$12.01'
'     OverflowException: '-4'
'     Bad Format: '1,032'
'     '255' --> 255
'     '   16  ' --> 16
' </Snippet15>

