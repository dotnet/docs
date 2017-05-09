' Visual Basic .NET Document
Option Strict On
' <Snippet1>
Module BooleanConversion
   Public Sub Main()
      Dim values() As String = { Nothing, String.Empty, "true", 
                                 "TrueString", "False", "    false    ",
                                 "-1", "0" }
      For Each value In values                                 
         Try
            Console.WriteLine("Converted '{0}' to {1}.", value, _ 
                              Convert.ToBoolean(value))
         Catch e As FormatException
            Console.WriteLine("Unable to convert '{0}' to a Boolean.", value)
         End Try
      Next
   End Sub
End Module
' The example displays the following output to the console:
'       Converted '' to False.
'       Unable to convert '' to a Boolean.
'       Converted 'true' to True.
'       Unable to convert 'TrueString' to a Boolean.
'       Converted 'False' to False.
'       Converted '    false    ' to False.
'       Unable to convert '-1' to a Boolean.
'       Unable to convert '0' to a Boolean.
' </Snippet1>

