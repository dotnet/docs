'<Snippet3>
Public Class SpecialFeaturesConverter
    Implements IMultiValueConverter

    Public Overridable Function Convert(ByVal values As Object(),
                                        ByVal targetType As Type,
                                        ByVal parameter As Object,
                                        ByVal culture As System.Globalization.CultureInfo) _
                                    As Object Implements IMultiValueConverter.Convert

        If values Is Nothing Or values.Length < 2 Then
            Return False
        End If
        If values(0) = System.Windows.DependencyProperty.UnsetValue Then
            Return False
        End If
        If values(1) = System.Windows.DependencyProperty.UnsetValue Then
            Return False
        End If
        Dim rating As Integer = CType(values(0), Integer)
        Dim theDate As DateTime = CType(values(1), DateTime)

        ' if the user has a good rating (10+) and has been a member for more than a year, special features are available
        If (rating >= 10) And
            (theDate.Date < (DateTime.Now.Date - New TimeSpan(365, 0, 0, 0))) Then
            Return True
        End If
        Return False
    End Function


    Public Overridable Function ConvertBack(ByVal value As Object,
                                            ByVal targetTypes As Type(),
                                            ByVal parameter As Object,
                                            ByVal culture As System.Globalization.CultureInfo) _
                                        As Object() Implements IMultiValueConverter.ConvertBack
        Return New Object(1) {Binding.DoNothing, Binding.DoNothing}
    End Function

End Class
'</Snippet3>
