    
    <ConfigurationProperty("fileName", _
    DefaultValue:="   default.txt  "), _
    TypeConverter(GetType(WhiteSpaceTrimStringConverter))> _
    Public Property FileName() As String
        Get
            Return CStr(Me("fileName"))
        End Get
        Set(ByVal value As String)
            Me("fileName") = value
        End Set
    End Property