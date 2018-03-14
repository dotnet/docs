' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim values() As String = { Nothing, String.Empty, "True", "False", 
                                 "true", "false", "    true    ", "0", 
                                 "1", "-1", "string" }
      For Each value In values
         Dim flag As Boolean
         
         If Boolean.TryParse(value, flag) Then
            Console.WriteLine("'{0}' --> {1}", value, flag)
         Else
            Console.WriteLine("Unable to parse '{0}'.", 
                              If(value Is Nothing, "<null>", value))
         End If         
      Next                                     
   End Sub
End Module
' The example displays the following output:
'       Unable to parse '<null>'.
'       Unable to parse ''.
'       'True' --> True
'       'False' --> False
'       'true' --> True
'       'false' --> False
'       '    true    ' --> True
'       Unable to parse '0'.
'       Unable to parse '1'.
'       Unable to parse '-1'.
'       Unable to parse 'string'.
' </Snippet1>

