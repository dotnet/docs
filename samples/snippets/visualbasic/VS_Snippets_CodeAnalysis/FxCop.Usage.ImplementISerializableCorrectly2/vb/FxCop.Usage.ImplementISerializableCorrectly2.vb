'<Snippet1>
Imports System
Imports System.Security.Permissions
Imports System.Runtime.Serialization

Namespace Samples2

    <Serializable()> _
    Public Class Book
        Implements ISerializable

        Private ReadOnly _Title As String

        Public Sub New(ByVal title As String)
            If (title Is Nothing) Then Throw New ArgumentNullException("title")
            _Title = title
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            If (info Is Nothing) Then Throw New ArgumentNullException("info")

            _Title = info.GetString("Title")
        End Sub

        Public ReadOnly Property Title() As String
            Get
                Return _Title
            End Get
        End Property

        <SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.SerializationFormatter)> _
        Protected Overridable Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) _
            Implements ISerializable.GetObjectData

            If (info Is Nothing) Then Throw New ArgumentNullException("info")

            info.AddValue("Title", _Title)
        End Sub
    End Class


    <Serializable()> _
    Public Class LibraryBook
        Inherits Book

        Private ReadOnly _CheckedOut As Date

        Public Sub New(ByVal text As String, ByVal checkedOut As Date)
            MyBase.New(text)
            _CheckedOut = checkedOut
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)

            _CheckedOut = info.GetDateTime("CheckedOut")
        End Sub

        Public ReadOnly Property CheckedOut() As Date
            Get
                Return _CheckedOut
            End Get
        End Property

        <SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.SerializationFormatter)> _
        Protected Overrides Sub GetObjectData(ByVal info As System.Runtime.Serialization.SerializationInfo, _
                                              ByVal context As System.Runtime.Serialization.StreamingContext)

            MyBase.GetObjectData(info, context)

            info.AddValue("CheckedOut", _CheckedOut)
        End Sub
    End Class
End Namespace
'</Snippet1>