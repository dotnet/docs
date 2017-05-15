' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim lines() As String = { "This is the first line.", _
                                "This is the second line." }
      ' Output the lines using the default newline sequence.
      Console.WriteLine("With the default new line characters:")
      Console.WriteLine()
      For Each line As String In lines
         Console.WriteLine(line)
      Next
      Console.WriteLine()
      
      ' Redefine the newline characters to double space.
      Console.Out.NewLine = vbCrLf + vbCrLf
      ' Output the lines using the new newline sequence.
      Console.WriteLine("With redefined new line characters:")
      Console.WriteLine()
      For Each line As String In lines
         Console.WriteLine(line)
      Next
   End Sub
End Module
' The example displays the following output:
'       With the default new line characters:
'       
'       This is the first line.
'       This is the second line.
'       
'       With redefined new line characters:
'       
'       
'       
'       This is the first line.
'       
'       This is the second line.
' </Snippet2>
