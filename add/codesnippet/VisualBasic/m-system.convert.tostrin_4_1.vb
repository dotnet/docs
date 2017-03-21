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