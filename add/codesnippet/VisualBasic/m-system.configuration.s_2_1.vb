    <ConfigurationProperty("alias", _
    DefaultValue:="anotherName.txt", _
    IsRequired:=True, _
    IsKey:=False), _
    StringValidator()> _
    Public Property [Alias]() As String
        Get
            Return CStr(Me("alias"))
        End Get
        Set(ByVal value As String)
            Me("alias") = value
        End Set
    End Property