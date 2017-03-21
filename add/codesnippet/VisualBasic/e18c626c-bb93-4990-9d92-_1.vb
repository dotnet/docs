    Public Overrides Function ConvertTo( _
    ByVal ctx As ITypeDescriptorContext, _
    ByVal ci As CultureInfo, ByVal value As Object, _
    ByVal type As Type) As Object
        ValidateType(value, GetType(TimeSpan))

        Dim data As Long = _
        Fix(CType(value, TimeSpan).TotalMinutes)

        Return data.ToString(CultureInfo.InvariantCulture)

    End Function 'ConvertTo
    