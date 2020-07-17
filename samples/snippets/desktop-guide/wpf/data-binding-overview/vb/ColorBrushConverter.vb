' <ColorBrushConverter>
<ValueConversion(GetType(Color), GetType(SolidColorBrush))>
Public Class ColorBrushConverter
    Implements IValueConverter
    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        Dim color As Color = CType(value, Color)
        Return New SolidColorBrush(color)
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return Nothing
    End Function
End Class
' </ColorBrushConverter>
