' <Snippet1>
Imports System.Globalization
Imports System.Text

Public Module Example
   Public Sub Main() 
      ' Parse the string as a hex value and display the value as a decimal.
      Dim num As String = "A"
      Dim val As Integer = Int32.Parse(num, NumberStyles.HexNumber)
      Console.WriteLine("{0} in hex = {1} in decimal.", num, val)

      ' Parse the string, allowing a leading sign, and ignoring leading and trailing white spaces.
      num = "    -45   "
      val = Integer.Parse(num, NumberStyles.AllowLeadingSign Or 
                               NumberStyles.AllowLeadingWhite Or 
                               NumberStyles.AllowTrailingWhite)
      Console.WriteLine("'{0}' parsed to an integer is '{1}'.", num, val)

      ' Parse the string, allowing parentheses, and ignoring leading and trailing white spaces.
      num = "    (37)   "
      val = Integer.Parse(num, NumberStyles.AllowParentheses Or 
                               NumberStyles.AllowLeadingSign Or
                               NumberStyles.AllowLeadingWhite Or 
                               NumberStyles.AllowTrailingWhite)
      Console.WriteLine("'{0}' parsed to an integer is '{1}'.", num, val)
   End Sub
End Module
' The example displays the following output:
'       A in hex = 10 in decimal.
'       '    -45   ' parsed to an int is '-45'.
'       '    (37)   ' parsed to an int is '-37'.
'</snippet1>