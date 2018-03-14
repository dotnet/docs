'<snippet1>
' This example demonstrates the StringBuilder.AppendLine() 
' method.
Imports System
Imports System.Text

Class Sample
   Public Shared Sub Main()
      Dim sb As New StringBuilder()
      Dim line As String = "A line of text."
      Dim number As Integer = 123
      
      ' Append two lines of text.
      sb.AppendLine("The first line of text.")
      sb.AppendLine(line)
      
      ' Append a new line, an empty string, and a null cast as a string.
      sb.AppendLine()
      sb.AppendLine("")
      sb.AppendLine(CStr(Nothing))
      
      ' Append the non-string value, 123, and two new lines.
      sb.Append(number).AppendLine().AppendLine()
      
      ' Append two lines of text.
      sb.AppendLine(line)
      sb.AppendLine("The last line of text.")
      
      ' Convert the value of the StringBuilder to a string and display the string.
      Console.WriteLine(sb.ToString())
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'The first line of text.
'A line of text.
'
'
'
'123
'
'A line of text.
'The last line of text.
'</snippet1>