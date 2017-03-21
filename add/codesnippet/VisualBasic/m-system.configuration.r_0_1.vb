    <ConfigurationProperty("alias2", _
    DefaultValue:="alias.txt", _
    IsRequired:=True, _
    IsKey:=False), _
    RegexStringValidator("\w+\S*")> _
    Public Property Alias2() As String
        Get
            Return CStr(Me("alias2"))
        End Get
        Set(ByVal value As String)
            Me("alias2") = value
        End Set
    End Property