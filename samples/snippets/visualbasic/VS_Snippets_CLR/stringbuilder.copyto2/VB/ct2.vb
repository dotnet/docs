' This example demonstrates the CopyTo(Int32, Char[], Int32, Int32) method.

'<snippet1>
' Typically the destination array is small, preallocated, and global while 
' the StringBuilder is large with programmatically defined data. 
' However, for this example both the array and StringBuilder are small 
' and the StringBuilder has predefined data.

Imports System.Text

Class Sample
   Protected Shared dest(5) As Char
   
   Public Shared Sub Main()
      Dim src As New StringBuilder("abcdefghijklmnopqrstuvwxyz!")
      dest(1) = ")"c
      dest(2) = " "c
      
      ' Copy the source to the destination in 9 pieces, 3 characters per piece.
      Console.WriteLine(vbCrLf & "Piece) Data:")
      Dim ix As Integer
      For ix = 0 To 8
         dest(0) = ix.ToString()(0)
         src.CopyTo(ix * 3, dest, 3, 3)
         Console.Write("    ")
         Console.WriteLine(dest)
      Next ix
   End Sub 'Main
End Class 'Sample
'
' This example produces the following results:
'
' Piece) Data:
'     0) abc
'     1) def
'     2) ghi
'     3) jkl
'     4) mno
'     5) pqr
'     6) stu
'     7) vwx
'     8) yz!
'</snippet1>
