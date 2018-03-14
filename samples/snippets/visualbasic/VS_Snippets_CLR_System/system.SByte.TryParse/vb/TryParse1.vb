' Visual Basic .NET Document
Option Strict On

Module ParseSByte
   Public Sub Main()
      ' <Snippet1>
      Dim numericStrings() As String = {"-3.6", "12.8", "+16.7", "    3   ", _
                                        "(17)", "-17", "+12", "18-", "987", _
                                        "1,024", "  127 "}
      Dim number As SByte
      For Each numericString As String In numericStrings
         If SByte.TryParse(numericString, number) Then
            Console.WriteLine("Converted '{0}' to {1}.", numericString, number)
         Else
            Console.WriteLine("Cannot convert '{0}' to an SByte.", numericString)
         End If      
      Next
      ' The example displays the following output to the console:
      '       Cannot convert '-3.6' to an SByte.
      '       Cannot convert '12.8' to an SByte.
      '       Cannot convert '+16.7' to an SByte.
      '       Converted '    3   ' to 3.
      '       Cannot convert '(17)' to an SByte.
      '       Converted '-17' to -17.
      '       Converted '+12' to 12.
      '       Cannot convert '18-' to an SByte.
      '       Cannot convert '987' to an SByte.
      '       Cannot convert '1,024' to an SByte.
      '       Converted '  127 ' to 127.
      ' </Snippet1>
   End Sub
End Module

