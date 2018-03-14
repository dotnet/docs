' 
' System.Uri.IsHexDigit
' 
' The following program reads a string from console and determines whether the
' specified character is valid hexadecimal digit.
'
Class MyIsHexDigitSample
   Public Shared Sub Main()
      Try
         ' <Snippet1>
         Console.Write("Type a string : ")
         Dim myString As String = Console.ReadLine()
         Dim i As Integer
         For i = 0 To myString.Length - 1
            If Uri.IsHexDigit(myString.Chars(i)) Then
               Console.WriteLine("{0} is a hexadecimal digit.", myString.Chars(i))
            Else
               Console.WriteLine("{0} is not a hexadecimal digit.", myString.Chars(i))
            End If 
         Next
         ' The example produces output like the following:
         '    Type a string : 3f5EaZ
         '    3 is a hexadecimal digit.
         '    f is a hexadecimal digit.
         '    5 is a hexadecimal digit.
         '    E is a hexadecimal digit.
         '    a is a hexadecimal digit.
         '    Z is not a hexadecimal digit.         
         ' </Snippet1>
      Catch e As Exception
         Console.WriteLine(e.Message)
      End Try
   End Sub 'Main
End Class 'MyIsHexDigitSample

'****** Output *****
'

'