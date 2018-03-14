'<snippet1>
Imports System
Imports System.Security.Permissions
Imports System.Collections

<Serializable()> Public Class MailslotPermission
    Inherits ResourcePermissionBase

    Private innerCollection As ArrayList


    Public Sub New()
        SetNames()
    End Sub 'New


    Public Sub New(ByVal state As PermissionState)
        MyBase.New(state)
        SetNames()
    End Sub 'New


    '<Snippet2>
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
    '</Snippet2>

    Public ReadOnly Property PermissionEntries() As ArrayList
        Get
            If Me.innerCollection Is Nothing Then
                Me.innerCollection = New ArrayList()
            End If
            Me.innerCollection.InsertRange(0, MyBase.GetPermissionEntries())

            Return Me.innerCollection
        End Get
    End Property


    Friend Overloads Sub AddPermissionAccess(ByVal entry As MailslotPermissionEntry)
        MyBase.AddPermissionAccess(entry.GetBaseEntry())
    End Sub 'AddPermissionAccess


    Friend Shadows Sub Clear()
        MyBase.Clear()
    End Sub 'Clear


    Friend Overloads Sub RemovePermissionAccess(ByVal entry As MailslotPermissionEntry)
        MyBase.RemovePermissionAccess(entry.GetBaseEntry())
    End Sub 'RemovePermissionAccess


    Private Sub SetNames()
        Me.PermissionAccessType = GetType(MailslotPermissionAccess)
        Me.TagNames = New String() {"Name", "Machine"}
    End Sub 'SetNames
End Class 'MailslotPermission

<Flags()> Public Enum MailslotPermissionAccess
    None = 0
    Send = 2
    Receive = 4 Or Send
End Enum 'MailslotPermissionAccess

<Serializable()> Public Class MailslotPermissionEntry
    Private nameVar As String
    Private machineNameVar As String
    Private permissionAccessVar As MailslotPermissionAccess


    Public Sub New(ByVal permissionAccess As MailslotPermissionAccess, ByVal name As String, ByVal machineName1 As String)
        Me.permissionAccessVar = permissionAccess
        Me.nameVar = name
        Me.machineNameVar = machineName1
    End Sub 'New


    Friend Sub New(ByVal baseEntry As ResourcePermissionBaseEntry)
        Me.permissionAccessVar = CType(baseEntry.PermissionAccess, MailslotPermissionAccess)
        Me.nameVar = baseEntry.PermissionAccessPath(0)
        Me.machineNameVar = baseEntry.PermissionAccessPath(1)
    End Sub 'New


    Public ReadOnly Property Name() As String
        Get
            Return Me.nameVar
        End Get
    End Property


    Public ReadOnly Property MachineName() As String
        Get
            Return Me.machineNameVar
        End Get
    End Property


    Public ReadOnly Property PermissionAccess() As MailslotPermissionAccess
        Get
            Return Me.permissionAccessVar
        End Get
    End Property


    Friend Function GetBaseEntry() As ResourcePermissionBaseEntry
        Dim baseEntry As New ResourcePermissionBaseEntry(CInt(Me.PermissionAccess), New String() {Me.Name, Me.MachineName})
        Return baseEntry
    End Function 'GetBaseEntry


End Class 'MailslotPermissionEntry
'</snippet1>