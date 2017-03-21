    
    <ConfigurationProperty("timeDelay", _
    DefaultValue:="infinite"), _
    TypeConverter(GetType(InfiniteTimeSpanConverter))> _
    Public Property TimeDelay() As TimeSpan
        Get
            Return CType(Me("timeDelay"), TimeSpan)
        End Get
        Set(ByVal value As TimeSpan)
            Me("timeDelay") = Value
        End Set
    End Property