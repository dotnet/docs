'<snippet1>
' Sample for String.ToCharArray(Int32, Int32)
Imports System

Class Sample
   
   Public Shared Sub Main()
      Dim str As String = "012wxyz789"
      Dim arr() As Char
      
      arr = str.ToCharArray(3, 4)
      Console.Write("The letters in '{0}' are: '", str)
      Console.Write(arr)
      Console.WriteLine("'")
      Console.WriteLine("Each letter in '{0}' is:", str)
      Dim c As Char
      For Each c In arr
         Console.WriteLine(c)
      Next c
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'The letters in '012wxyz789' are: 'wxyz'
'Each letter in '012wxyz789' is:
'w
'x
'y
'z
'
'</snippet1>