    Public Overrides Function CanConvertFrom( _
    ByVal ctx As ITypeDescriptorContext, _
    ByVal type As Type) As Boolean
        Return (type.ToString() = GetType(String).ToString())

    End Function 'CanConvertFrom
    