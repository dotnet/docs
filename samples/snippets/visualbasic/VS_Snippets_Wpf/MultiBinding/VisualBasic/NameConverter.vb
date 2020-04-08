Imports System.Globalization
Imports System.Windows.Data

'<Snippet3>
    Public Class NameConverter
        Implements IMultiValueConverter

    Public Function Convert1(ByVal values() As Object, _
                             ByVal targetType As System.Type, _
                             ByVal parameter As Object, _
                             ByVal culture As System.Globalization.CultureInfo) As Object _
                             Implements System.Windows.Data.IMultiValueConverter.Convert
        Select Case CStr(parameter)
            Case "FormatLastFirst"
                Return (values(1) & ", " & values(0))
        End Select
        Return (values(0) & " " & values(1))
    End Function

    Public Function ConvertBack1(ByVal value As Object, _
                                 ByVal targetTypes() As System.Type, _
                                 ByVal parameter As Object, _
                                 ByVal culture As System.Globalization.CultureInfo) As Object() _
                                 Implements System.Windows.Data.IMultiValueConverter.ConvertBack
        Return CStr(value).Split(New Char() {" "c})
    End Function
    End Class
'</Snippet3>

