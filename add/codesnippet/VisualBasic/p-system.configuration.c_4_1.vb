    <ConfigurationProperty("name", DefaultValue:="Contoso", IsRequired:=True, IsKey:=True)>
    Public Property Name() As String
        Get
            Return CStr(Me("name"))
        End Get
        Set(ByVal value As String)
            Me("name") = value
        End Set
    End Property