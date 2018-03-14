' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet1>
      Dim numericStrings() As String = {"1293.8", "+1671.7", "28347.", _
                                        "   33113684  ", "(0)", "-0", "+1293617", _
                                        "18-", "119870", "31,024", "  3127094 ", _ 
                                        "0070000" }
      Dim number As ULong
      For Each numericString As String In numericStrings
         If UInt64.TryParse(numericString, number) Then
            Console.WriteLine("Converted '{0}' to {1}.", numericString, number)
         Else
            Console.WriteLine("Cannot convert '{0}' to a UInt64.", numericString)
         End If      
      Next
      ' The example displays the following output:
      '       Cannot convert '1293.8' to a UInt64.
      '       Cannot convert '+1671.7' to a UInt64.
      '       Cannot convert '28347.' to a UInt64.
      '       Converted '   33113684  ' to 33113684.
      '       Cannot convert '(0)' to a UInt64.
      '       Converted '-0' to 0.
      '       Converted '+1293617' to 1293617.
      '       Cannot convert '18-' to a UInt64.
      '       Converted '119870' to 119870.
      '       Cannot convert '31,024' to a UInt64.
      '       Converted '  3127094 ' to 3127094.
      '       Converted '0070000' to 70000.
      ' </Snippet1>
   End Sub
End Module

