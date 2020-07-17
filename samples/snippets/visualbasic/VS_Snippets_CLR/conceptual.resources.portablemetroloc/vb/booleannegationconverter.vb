Namespace Common

    ''' <summary>
    ''' Value converter that translates true to false and vice versa.
    ''' </summary>
    Public NotInheritable Class BooleanNegationConverter
        Implements IValueConverter

        Public Function Convert(value As Object, targetType As Type, parameter As Object,
                                language As String) As Object Implements IValueConverter.Convert
            Return Not (TypeOf value Is Boolean AndAlso DirectCast(value, Boolean))
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object,
                                    language As String) As Object Implements IValueConverter.ConvertBack
            Return Not (TypeOf value Is Boolean AndAlso DirectCast(value, Boolean))
        End Function

    End Class

End Namespace
