    
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