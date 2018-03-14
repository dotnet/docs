' The following code example gets two instances of the same encoding (one by codepage and another by name), and checks their equality.

' <Snippet1>
Imports System
Imports System.Text

Public Class SamplesEncoding   

   Public Shared Sub Main()

      ' Get a UTF-32 encoding by codepage.
      Dim e1 As Encoding = Encoding.GetEncoding(12000)

      ' Get a UTF-32 encoding by name.
      Dim e2 As Encoding = Encoding.GetEncoding("utf-32")

      ' Check their equality.
      Console.WriteLine("e1 equals e2? {0}", e1.Equals(e2))

   End Sub 'Main 

End Class 'SamplesEncoding


'This code produces the following output.
'
'e1 equals e2? True

' </Snippet1>
