' <snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Data
Imports System.Data.OleDb
Imports System.Security.Permissions
Imports System.Web

Namespace Samples.AspNet.VB.Controls
 
    ' An extremely simple AccessSiteMapProvider that only supports a
    ' site map node hierarchy one level deep.
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class AccessSiteMapProvider
        Inherits StaticSiteMapProvider

        Private aRootNode As SiteMapNode = Nothing
        Private accessConnection As OleDbConnection = Nothing

        ' This string is case sensitive.
        Private AccessConnectionStringName As String = "accessSiteMapConnectionString"

        ' Implement a default constructor.
        Public Sub New()
        End Sub 'New

        ' Some basic state to help track the initialization state of the provider.
        Private initialized As Boolean = False

        Public Overridable ReadOnly Property IsInitialized() As Boolean
            Get
                Return initialized
            End Get
        End Property

' <snippet5>
        ' Return the root node of the current site map.
        Public Overrides ReadOnly Property RootNode() As SiteMapNode
            Get
                Return BuildSiteMap()
            End Get
        End Property
' </snippet5>

' <snippet7>
        Protected Overrides Function GetRootNodeCore() As SiteMapNode
            Return RootNode
        End Function
' </snippet7>

' <snippet2>
        ' Initialize is used to initialize the properties and any state that the
        ' AccessProvider holds, but is not used to build the site map.
        ' The site map is built when the BuildSiteMap method is called.
        Public Overrides Sub Initialize(ByVal name As String, ByVal attributes As NameValueCollection)
            If IsInitialized Then
                Return
            End If
            MyBase.Initialize(name, attributes)

            ' Create and test the connection to the Microsoft Access database.
            ' Retrieve the Value of the Access connection string from the
            ' attributes NameValueCollection.
            Dim connectionString As String = attributes(AccessConnectionStringName)

            If Nothing = connectionString OrElse connectionString.Length = 0 Then
                Throw New Exception("The connection string was not found.")
            Else
                accessConnection = New OleDbConnection(connectionString)
            End If
            initialized = True
        End Sub 'Initialize
' </snippet2>

' <snippet3>
        ' SiteMapProvider and StaticSiteMapProvider methods that this derived class must override.
        '
        ' Clean up any collections or other state that an instance of this may hold.
        Protected Overrides Sub Clear()
            SyncLock Me
                aRootNode = Nothing
                MyBase.Clear()
            End SyncLock
        End Sub 'Clear
' </snippet3>

' <snippet4>
        ' Build an in-memory representation from persistent
        ' storage, and return the root node of the site map.
        Public Overrides Function BuildSiteMap() As SiteMapNode

            ' Since the SiteMap class is static, make sure that it is
            ' not modified while the site map is built.
            SyncLock Me

                ' If there is no initialization, this method is being
                ' called out of order.
                If Not IsInitialized Then
                    Throw New Exception("BuildSiteMap called incorrectly.")
                End If

                ' If there is no root node, then there is no site map.
                If aRootNode Is Nothing Then
                    ' Start with a clean slate
                    Clear()

                    ' Select the root node of the site map from Microsoft Access.
                    Dim rootNodeId As Integer = -1

                    If accessConnection.State = ConnectionState.Closed Then
                        accessConnection.Open()
                    End If
' <snippet6>
                    Dim rootNodeCommand As New OleDbCommand("SELECT nodeid, url, name FROM SiteMap WHERE parentnodeid IS NULL", accessConnection)
                    Dim rootNodeReader As OleDbDataReader = rootNodeCommand.ExecuteReader()

                    If rootNodeReader.HasRows Then
                        rootNodeReader.Read()
                        rootNodeId = rootNodeReader.GetInt32(0)
                        ' Create a SiteMapNode that references the current StaticSiteMapProvider.
                        aRootNode = New SiteMapNode(Me, rootNodeId.ToString(), rootNodeReader.GetString(1), rootNodeReader.GetString(2))
                    Else
                        Return Nothing
                    End If
                    rootNodeReader.Close()
' </snippet6>
                    ' Select the child nodes of the root node.
                    Dim childNodesCommand As New OleDbCommand("SELECT nodeid, url, name FROM SiteMap WHERE parentnodeid = ?", accessConnection)
                    Dim rootParam As New OleDbParameter("parentid", OleDbType.Integer)
                    rootParam.Value = rootNodeId
                    childNodesCommand.Parameters.Add(rootParam)

                    Dim childNodesReader As OleDbDataReader = childNodesCommand.ExecuteReader()

                    If childNodesReader.HasRows Then

                        Dim childNode As SiteMapNode = Nothing
                        While childNodesReader.Read()
                            childNode = New SiteMapNode(Me, _
                            childNodesReader.GetInt32(0).ToString(), _
                            childNodesReader.GetString(1), _
                            childNodesReader.GetString(2))

                            ' Use the SiteMapNode AddNode method to add
                            ' the SiteMapNode to the ChildNodes collection.
                            AddNode(childNode, aRootNode)
                        End While
                    End If

                    childNodesReader.Close()
                    accessConnection.Close()
                End If
                Return aRootNode
            End SyncLock

        End Function 'BuildSiteMap
' </snippet4>

    End Class 'AccessSiteMapProvider

End Namespace
' </snippet1>