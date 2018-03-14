' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      CopyUp()
      Console.WriteLine()
      CopyDown()
   End Sub
   
   Private Sub CopyUp()
      ' <Snippet3>
      Const INT_SIZE As Integer = 4
      Dim arr() As Integer = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 }
      Buffer.BlockCopy(arr, 0 * INT_SIZE, arr, 3 * INT_SIZE, 4 * INT_SIZE)
      For Each value As Integer In arr
         Console.Write("{0}  ", value)
      Next
      ' The example displays the following output:
      '       2  4  6  2  4  6  8  16  18  20      
      ' </Snippet3>
   End Sub
   
   Private Sub CopyDown()
      ' <Snippet4>
      Const INT_SIZE As Integer = 4
      Dim arr() As Integer = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 }
      Buffer.BlockCopy(arr, 3 * INT_SIZE, arr, 0 * INT_SIZE, 4 * INT_SIZE)
      For Each value As Integer In arr
         Console.Write("{0}  ", value)
      Next
      ' The example displays the following output:
      '       8  10  12  14  10  12  14  16  18  20      
      ' </Snippet4>
   End Sub
End Module

