' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet1>
      ' Define an array of numeric strings.
      Dim values() As String = { "-16", "  -3", "+ 12", " +12 ", "  12  ", _
                                 "+120", "(103)", "192", "-160" }
                                 
      ' Parse each string and display the result.
      For Each value As String In values
         Try
            Console.WriteLine("Converted '{0}' to the SByte value {1}.", _
                              value, SByte.Parse(value))
         Catch e As FormatException
            Console.WriteLine("'{0}' cannot be parsed successfully by SByte type.", _
                              value)
         Catch e As OverflowException
            Console.WriteLine("'{0}' is out of range of the SByte type.", _
                              value)
         End Try                                                                        
      Next        
      ' The example displays the following output:
      '       Converted '-16' to the SByte value -16.
      '       Converted '  -3' to the SByte value -3.
      '       '+ 12' cannot be parsed successfully by SByte type.
      '       Converted ' +12 ' to the SByte value 12.
      '       Converted '  12  ' to the SByte value 12.
      '       Converted '+120' to the SByte value 120.
      '       '(103)' cannot be parsed successfully by SByte type.
      '       '192' is out of range of the SByte type.
      '       '-160' is out of range of the SByte type.
      ' </Snippet1>                         
   End Sub
End Module

