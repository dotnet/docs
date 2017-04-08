' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet1>
      Dim numericStrings() As String = {"1293.8", "+1671.7", "28347.", _
                                        "   33113  ", "(0)", "-0", "+12936", _
                                        "18-", "9870", "31,024", "  3127 ", _ 
                                        "70000" }
      Dim number As UShort
      For Each numericString As String In numericStrings
         If UInt16.TryParse(numericString, number) Then
            Console.WriteLine("Converted '{0}' to {1}.", numericString, number)
         Else
            Console.WriteLine("Cannot convert '{0}' to a UInt16.", numericString)
         End If      
      Next
      ' The example displays the following output:
      '       Cannot convert '1293.8' to a UInt16.
      '       Cannot convert '+1671.7' to a UInt16.
      '       Cannot convert '28347.' to a UInt16.
      '       Converted '   33113  ' to 33113.
      '       Cannot convert '(0)' to a UInt16.
      '       Converted '-0' to 0.
      '       Converted '+12936' to 12936.
      '       Cannot convert '18-' to a UInt16.
      '       Converted '9870' to 9870.
      '       Cannot convert '31,024' to a UInt16.
      '       Converted '  3127 ' to 3127.
      '       Cannot convert '70000' to a UInt16.
      ' </Snippet1>
   End Sub
End Module

