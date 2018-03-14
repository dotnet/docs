' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Security
 
Module Example
   Public Sub Main()
      ' Define the string value to assign to a new secure string.
      Dim chars() As Char = { "t"c, "e"c, "s"c, "t"c }
      ' Instantiate the secure string.
      Dim testString As SecureString = New SecureString()
      ' Assign the character array to the secure string.
      For Each ch As char In chars
         testString.AppendChar(ch)
      Next         
      ' Display secure string length.
      Console.WriteLine("The length of the string is {0} characters.", _ 
                        testString.Length)
      testString.Dispose()
   End Sub
End Module
' The example displays the following output:
'      The length of the string is 4 characters.
' </Snippet2>

