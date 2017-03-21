Public Class BigIntegerFormatProvider : Implements IFormatProvider
   Public Function GetFormat(formatType As Type) As Object _
                            Implements IFormatProvider.GetFormat
      If formatType Is GetType(NumberFormatInfo) Then
         Dim numberFormat As New NumberFormatInfo
         numberFormat.NegativeSign = "~"
         Return numberFormat
      Else
         Return Nothing
      End If      
   End Function
End Class