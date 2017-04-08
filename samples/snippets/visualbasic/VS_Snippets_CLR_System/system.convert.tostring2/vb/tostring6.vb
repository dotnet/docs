Option Strict On

Public Module Example
   Public Sub Main()
      ConvertInt32()
      Console.WriteLine("-----")
      ConvertInt64()
   End Sub

   Private Sub ConvertInt32()
      ' Create a NumberFormatInfo object and set several of its
      ' properties that control default integer formatting.
      Dim provider As New System.Globalization.NumberFormatInfo()
      provider.NegativeSign = "minus "

      Dim values() As Integer = { -20, 0, 100 }
      
      For Each value As Integer In values
         Console.WriteLine("{0,-5}  -->  {1,8}", _
                           value, Convert.ToString(value, provider))
      Next
      ' The example displays the following output:
      '       -20    -->  minus 20
      '       0      -->         0
      '       100    -->       100
   End Sub
   
   Private Sub ConvertInt64()
      ' <Snippet28>
      ' Create a NumberFormatInfo object and set several of its
      ' properties that control default integer formatting.
      Dim provider As New System.Globalization.NumberFormatInfo()
      provider.NegativeSign = "minus "

      Dim values() As Long = { -200, 0, 1000 }
      
      For Each value As Long In values
         Console.WriteLine("{0,-6}  -->  {1,10}", _
                           value, Convert.ToString(value, provider))
      Next
      ' The example displays the following output:
      '       -200    -->   minus 200
      '       0       -->           0
      '       1000    -->        1000
      ' </Snippet28>
   End Sub
End Module

