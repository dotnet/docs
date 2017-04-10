' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Security

Module Example
   Public Sub Main()
      ' Define the string value to be assigned to the secure string.
      Dim initString As String = "TestString"
      ' Instantiate the secure string.
      Dim testString As SecureString = New SecureString()
      ' Use the AppendChar method to add each char value to the secure string.
      For Each ch As Char In initString
         testString.AppendChar(ch)
      Next   
      ' Display secure string length.
      Console.WriteLine("The length of the string is {0} characters.", _ 
                        testString.Length)
      testString.Dispose()
   End Sub
End Module
' The example displays the following output:
'      The length of the string is 10 characters.
' </Snippet3>

