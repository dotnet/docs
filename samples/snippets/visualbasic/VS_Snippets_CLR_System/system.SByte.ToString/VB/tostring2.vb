' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim value As SByte = -123
      ' Display value using default ToString method.
      Console.WriteLine(value.ToString())            ' Displays -123
      ' Display value using some standard format specifiers.
      Console.WriteLine(value.ToString("G"))         ' Displays -123
      Console.WriteLine(value.ToString("C"))         ' Displays ($-123.00)
      Console.WriteLine(value.ToString("D"))         ' Displays -123
      Console.WriteLine(value.ToString("F"))         ' Displays -123.00
      Console.WriteLine(value.ToString("N"))         ' Displays -123.00
      Console.WriteLine(value.ToString("X"))         ' Displays 85
   End Sub
End Module
' </Snippet2>
