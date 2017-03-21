' Define a custom section.
NotInheritable Public Class CustomSection
    Inherits ConfigurationSection
    
    
    Public Sub New() 
    
    End Sub 'New
    
    
    
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

    
    <ConfigurationProperty("maxIdleTime"), _
    TypeConverter(GetType(CustomizedTimeSpanMinutesConverter))> _
    Public Property MaxIdleTime() As TimeSpan
        Get
            Return CType(Me("maxIdleTime"), TimeSpan)
        End Get
        Set(ByVal value As TimeSpan)
            Me("maxIdleTime") = value
        End Set
    End Property
    
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
    
    <ConfigurationProperty("cdStr", _
    DefaultValue:="str0, str1", _
    IsRequired:=True), _
    TypeConverter(GetType(CommaDelimitedStringCollectionConverter))> _
    Public Property CdStr() As StringCollection
        Get
            Return CType(Me("cdStr"), StringCollection)
        End Get

        Set(ByVal value As StringCollection)
            Me("cdStr") = value
        End Set
    End Property
    
    
    Public Enum Permissions
        FullControl = 0
        Modify = 1
        ReadExecute = 2
        Read = 3
        Write = 4
        SpecialPermissions = 5
    End Enum 'Permissions
    
    
    <ConfigurationProperty("permission", _
    DefaultValue:=Permissions.Read)> _
    Public Property Permission() As Permissions
        Get
            Return CType(Me("permission"), Permissions)
        End Get

        Set(ByVal value As Permissions)
            Me("permission") = Value
        End Set
    End Property
    
    
    <ConfigurationProperty("maxUsers", _
    DefaultValue:="infinite"), _
    TypeConverter(GetType(InfiniteIntConverter))> _
    Public Property MaxUsers() As Integer
        Get
            Return Fix(Me("maxUsers"))
        End Get
        Set(ByVal value As Integer)
            Me("maxUsers") = Value
        End Set
    End Property
End Class 'CustomSection 
