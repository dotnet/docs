' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim values() As String = { "1,643.57", "$1,643.57", "-1.643e6", 
                                "-168934617882109132", "123AE6", 
                                Nothing, String.Empty, "ABCDEF" }
      Dim number As Double
      
      For Each value In values
         If Double.TryParse(value, number) Then
            Console.WriteLine("'{0}' --> {1}", value, number)
         Else
            Console.WriteLine("Unable to parse '{0}'.", value)      
         End If   
      Next   
   End Sub
End Module
' The example displays the following output:
'       '1,643.57' --> 1643.57
'       Unable to parse '$1,643.57'.
'       '-1.643e6' --> -1643000
'       '-168934617882109132' --> -1.68934617882109E+17
'       Unable to parse '123AE6'.
'       Unable to parse ''.
'       Unable to parse ''.
'       Unable to parse 'ABCDEF'.
' </Snippet1>

