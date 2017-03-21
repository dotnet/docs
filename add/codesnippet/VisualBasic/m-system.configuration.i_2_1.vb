    <ConfigurationProperty("maxSize", _
    DefaultValue:=1000, _
    IsRequired:=True), _
    IntegerValidator()> _
    Public Property MaxSize() As Integer
        Get
            Return Fix(Me("maxSize"))
        End Get
        Set(ByVal value As Integer)
            Me("maxSize") = value
        End Set
    End Property