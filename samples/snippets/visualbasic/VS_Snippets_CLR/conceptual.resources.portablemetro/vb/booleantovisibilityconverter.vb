Namespace Common

    ''' <summary>
    ''' Value converter that translates true to <see cref="Visibility.Visible"/> and false to
    ''' <see cref="Visibility.Collapsed"/>.
    ''' </summary>
    Public NotInheritable Class BooleanToVisibilityConverter
        Implements IValueConverter

        Public Function Convert(value As Object, targetType As Type, parameter As Object,
                                language As String) As Object Implements IValueConverter.Convert
            If TypeOf value Is Boolean AndAlso DirectCast(value, Boolean) Then Return Visibility.Visible
            Return Visibility.Collapsed
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object,
                                    language As String) As Object Implements IValueConverter.ConvertBack
            Return TypeOf value Is Visibility AndAlso DirectCast(value, Visibility) = Visibility.Visible
        End Function

    End Class

End Namespace
