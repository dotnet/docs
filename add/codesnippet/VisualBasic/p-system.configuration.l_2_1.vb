    <ConfigurationProperty("maxUsers", _
    DefaultValue:=10000, _
    IsRequired:=False), _
    LongValidator(MinValue:=1, _
    MaxValue:=10000000, _
    ExcludeRange:=False)> _
    Public Property MaxUsers() As Long
        Get
            Return Fix(Me("maxUsers"))
        End Get
        Set(ByVal value As Long)
            Me("maxUsers") = value
        End Set
    End Property