
    <ConfigurationProperty("fileName", _
    DefaultValue:="default.txt", _
    IsRequired:=True, _
    IsKey:=False), _
    StringValidator( _
    InvalidCharacters:=" ~!@#$%^&*()[]{}/;'""|\", _
    MinLength:=1, _
    MaxLength:=60)> _
    Public Property FileName() As String
        Get
            Return CStr(Me("fileName"))
        End Get
        Set(ByVal value As String)
            Me("fileName") = value
        End Set
    End Property