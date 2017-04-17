' <Snippet1>
Module Example
   Sub Main()
      EnumerateAndDisplay("Test Case")
      EnumerateAndDisplay("This is a sentence.")
      EnumerateAndDisplay("Has" & vbTab & "two" & vbTab & "tabs")
      EnumerateAndDisplay("Two" & vbLf & "new" & vbLf & "lines")
   End Sub 
       
   Sub EnumerateAndDisplay(phrase As String)
      Console.WriteLine("The characters in the string ""{0}"" are:", phrase)
       
      Dim charCount As Integer = 0
      Dim controlChars As Integer = 0
      Dim alphanumeric As Integer = 0
      Dim punctuation As Integer = 0
        
      For Each ch In phrase          
         Console.Write("'{0}' ", If(Not Char.IsControl(ch), ch, 
                                     "0x" + Convert.ToUInt16(ch).ToString("X4")))
         If Char.IsLetterOrDigit(ch) Then 
            alphanumeric += 1
         Else If Char.IsControl(ch) Then 
            controlChars += 1
         Else If Char.IsPunctuation(ch) Then 
            punctuation += 1             
         End If
         CharCount += 1
      Next

      Console.WriteLine()
      Console.WriteLine("   Total characters:        {0,3}", CharCount)
      Console.WriteLine("   Alphanumeric characters: {0,3}", alphanumeric)
      Console.WriteLine("   Punctuation characters:  {0,3}", punctuation)
      Console.WriteLine("   Control Characters:      {0,3}", controlChars)
      Console.WriteLine()
    End Sub 
End Module 
' This example displays the following output:
'    The characters in the string "Test Case" are:
'    'T' 'e' 's' 't' ' ' 'C' 'a' 's' 'e'
'       Total characters:          9
'       Alphanumeric characters:   8
'       Punctuation characters:    0
'       Control Characters:        0
'    
'    The characters in the string "This is a sentence." are:
'       'T' 'h' 'i' 's' ' ' 'i' 's' ' ' 'a' ' ' 's' 'e' 'n' 't' 'e' 'n' 'c' 'e' '.'
'          Total characters:         19
'          Alphanumeric characters:  15
'          Punctuation characters:    1
'          Control Characters:        0
'       
'       The characters in the string "Has       two     tabs" are:
'       'H' 'a' 's' '0x0009' 't' 'w' 'o' '0x0009' 't' 'a' 'b' 's'
'          Total characters:         12
'          Alphanumeric characters:  10
'          Punctuation characters:    0
'          Control Characters:        2
'       
'       The characters in the string "Two
'       new
'       lines" are:
'       'T' 'w' 'o' '0x000A' 'n' 'e' 'w' '0x000A' 'l' 'i' 'n' 'e' 's'
'          Total characters:         13
'          Alphanumeric characters:  11
'          Punctuation characters:    0
'          Control Characters:        2
' </Snippet1>
