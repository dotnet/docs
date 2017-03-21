    Public Sub New(ByVal permissionAccess As MailslotPermissionAccess, ByVal name As String, ByVal machineName1 As String)
        SetNames()
        Me.AddPermissionAccess(New MailslotPermissionEntry(permissionAccess, name, machineName1))
    End Sub 'New


    Public Sub New(ByVal permissionAccessEntries() As MailslotPermissionEntry)
        SetNames()
        If permissionAccessEntries Is Nothing Then
            Throw New ArgumentNullException("permissionAccessEntries")
        End If
        Dim index As Integer

        While index < permissionAccessEntries.Length
            Me.AddPermissionAccess(permissionAccessEntries(index))
        End While
    End Sub 'New 