' Visual Basic .NET Document
Option Strict On            

Module Example
   Public Sub Main()
      AppendBool()
      Console.WriteLine("-----")
      AppendByte()
      Console.WriteLine("-----")
      AppendChar()
      Console.WriteLine("-----")
      AppendMultipleChars()
      Console.WriteLine("-----")
      AppendCharArray()
      Console.WriteLine("-----")
      AppendPartialCharArray()
      Console.WriteLine("-----")
      AppendDecimal()
      Console.WriteLine("-----")
      AppendDouble()
      Console.WriteLine("-----")
   End Sub
   
   Private Sub AppendBool()
      ' <Snippet2>
      Dim flag As Boolean = false
      Dim sb As New System.Text.StringBuilder
      sb.Append("The value of the flag is ").Append(flag).Append(".")
      Console.WriteLine(sb.ToString())
      ' The example displays the following output:
      '       The value of the flag is False.
      ' </Snippet2>
   End Sub
   
   Private Sub AppendByte()
      ' <Snippet3>
      Dim bytes() As Byte = { 16, 132, 27, 253 }
      Dim sb As New System.Text.StringBuilder()
      For Each value In bytes
         sb.Append(value).Append(" ")         
      Next
      Console.WriteLine("The byte array: {0}", sb.ToString())
      ' The example displays the following output:
      '         The byte array: 16 132 27 253      
      ' </Snippet3>
   End Sub
   
   Private Sub AppendChar()
      ' <Snippet4>
      Dim str As String = "Characters in a string."
      Dim sb As New System.Text.StringBuilder()
      For Each ch In str
         sb.Append(" '").Append(ch).Append("' ")
      Next
      Console.WriteLine("Characters in the string:")
      Console.WriteLine("  {0}", sb)
      ' The example displays the following output:
      '    Characters in the string:
      '       'C'  'h'  'a'  'r'  'a'  'c'  't'  'e'  'r'  's'  ' '  'i'  'n'  ' '  'a'  ' '  's'  't' 'r'  'i'  'n'  'g'  '.'      
      ' </Snippet4>
   End Sub
   
   Private Sub AppendMultipleChars()
      ' <Snippet5> 
      Dim value As Decimal = 1346.19d
      Dim sb As New System.Text.StringBuilder()
      sb.Append("*"c, 5).AppendFormat("{0:C2}", value).Append("*"c, 5)
      Console.WriteLine(sb)
      ' The example displays the following output:
      '       *****$1,346.19*****
      ' </Snippet5>
   End Sub

   Private Sub AppendCharArray()
      ' <Snippet6>
      Dim chars() As Char = { "a"c, "e"c, "i"c, "o"c, "u"c }
      Dim sb As New System.Text.StringBuilder()
      sb.Append("The characters in the array: ").Append(chars)
      Console.WriteLine(sb)
      ' The example displays the following output:
      '      The characters in the array: aeiou
      ' </Snippet6>
   End Sub
   
   Private Sub AppendPartialCharArray()
      ' <Snippet7>
      Dim chars() As Char = { "a"c, "b"c, "c"c, "d"c, "e"c}
      Dim sb As New System.Text.StringBuilder()
      Dim startPosition As Integer = Array.IndexOf(chars, "a"c)
      Dim endPosition As Integer = Array.IndexOf(chars, "c"c)
      If startPosition >= 0 AndAlso endPosition >= 0 Then
         sb.Append("The array from positions ").Append(startPosition).
                   Append(" to ").Append(endPosition).Append(" contains ").
                   Append(chars, startPosition, endPosition + 1).Append(".")
         Console.WriteLine(sb)
      End If             
      ' The example displays the following output:
      '       The array from positions 0 to 2 contains abc.
      ' </Snippet7>
   End Sub 
     
   Private Sub AppendDecimal()
      ' <Snippet8> 
      Dim value As Decimal = 1346.19d
      Dim sb As New System.Text.StringBuilder()
      sb.Append("*"c, 5).Append(value).Append("*"c, 5)
      Console.WriteLine(sb)
      ' The example displays the following output:
      '       *****1346.19*****
      ' </Snippet8>       
   End Sub
   
   Private Sub AppendDouble()
      ' <Snippet9> 
      Dim value As Double = 1034769.47
      Dim sb As New System.Text.StringBuilder()
      sb.Append("*"c, 5).Append(value).Append("*"c, 5)
      Console.WriteLine(sb)
      ' The example displays the following output:
      '       *****1034769.47*****
      ' </Snippet9>
   End Sub
End Module

