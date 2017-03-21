    <ConfigurationProperty("url", DefaultValue:="http://www.contoso.com", IsRequired:=True), RegexStringValidator("\w+:\/\/[\w.]+\S*")>
    Public Property Url() As String
        Get
            Return CStr(Me("url"))
        End Get
        Set(ByVal value As String)
            Me("url") = value
        End Set
    End Property