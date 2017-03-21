    Public Overrides Function ConvertFrom( _
    ByVal ctx As ITypeDescriptorContext, _
    ByVal ci As CultureInfo, ByVal data As Object) As Object

        Dim min As Long = _
        Long.Parse(CStr(data), CultureInfo.InvariantCulture)

        Return TimeSpan.FromMinutes(System.Convert.ToDouble(min))

    End Function 'ConvertFrom