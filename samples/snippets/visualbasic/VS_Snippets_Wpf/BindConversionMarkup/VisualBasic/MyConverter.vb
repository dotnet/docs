Imports System
Imports System.Globalization
Imports System.Windows.Data
Imports System.Windows.Media

'<Snippet2>
Public Class MyConverter
    Implements IValueConverter

    Public Function Convert(ByVal value As Object, _
                            ByVal targetType As System.Type, _
                            ByVal parameter As Object, _
                            ByVal culture As System.Globalization.CultureInfo) _
                            As Object Implements System.Windows.Data.IValueConverter.Convert
        Dim time As DateTime = CDate(value)
        Select Case targetType.Name
            Case "String"
                Return time.ToString("F", culture)
            Case "Brush"
                Return Brushes.Red
        End Select
        Return value
    End Function

    Public Function ConvertBack(ByVal value As Object, _
                                ByVal targetType As System.Type, _
                                ByVal parameter As Object, _
                                ByVal culture As System.Globalization.CultureInfo) _
                                As Object Implements System.Windows.Data.IValueConverter.ConvertBack
        Return Nothing
    End Function
End Class
'</Snippet2>

