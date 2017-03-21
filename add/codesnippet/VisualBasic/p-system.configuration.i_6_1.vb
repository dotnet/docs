    <ConfigurationProperty("maxAttempts", _
    DefaultValue:=101, _
    IsRequired:=True), _
    IntegerValidator(MinValue:=1, _
    MaxValue:=100, _
    ExcludeRange:=True)> _
    Public Property MaxAttempts() As Integer
        Get
            Return Fix(Me("maxAttempts"))
        End Get
        Set(ByVal value As Integer)
            Me("maxAttempts") = value
        End Set
    End Property