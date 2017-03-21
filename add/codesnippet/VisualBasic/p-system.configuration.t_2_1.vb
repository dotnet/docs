    <ConfigurationProperty("maxIdleTime", _
    DefaultValue:="0:10:0", _
    IsRequired:=False), _
    TimeSpanValidator(MinValueString:="0:0:30", _
    MaxValueString:="5:00:0", _
    ExcludeRange:=False)> _
    Public Property MaxIdleTime() As TimeSpan
        Get
            Return CType(Me("maxIdleTime"), TimeSpan)
        End Get
        Set(ByVal value As TimeSpan)
            Me("maxIdleTime") = value
        End Set
    End Property