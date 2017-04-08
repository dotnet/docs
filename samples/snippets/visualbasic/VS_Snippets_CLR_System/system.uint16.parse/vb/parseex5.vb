' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Module Example
   Public Sub Main()
      Dim values() As String = { "-0", "17", "-12", "185", "66012", _ 
                                 "+0", "", Nothing, "16.1", "28.0", _
                                 "1,034" }
      For Each value As String In values
         Try
            Dim number As UShort = UInt16.Parse(value)
            Console.WriteLine("'{0}' --> {1}", value, number)
         Catch e As FormatException
            Console.WriteLine("'{0}' --> Bad Format", value)
         Catch e As OverflowException   
            Console.WriteLine("'{0}' --> OverflowException", value)
         Catch e As ArgumentNullException
            Console.WriteLine("'{0}' --> Null", value)
         End Try
      Next                                 
   End Sub
End Module
' The example displays the following output:
'       '-0' --> 0
'       '17' --> 17
'       '-12' --> OverflowException
'       '185' --> 185
'       '66012' --> OverflowException
'       '+0' --> 0
'       '' --> Bad Format
'       '' --> Null
'       '16.1' --> Bad Format
'       '28.0' --> Bad Format
'       '1,034' --> Bad Format
' </Snippet5>
