'<Snippet1>
Imports System
Imports System.Web.Security


Namespace Samples.AspNet.Membership.VB

    Public Class OdbcMembershipUser
        Inherits MembershipUser

        Private _IsSubscriber As Boolean
        Private _CustomerID As String

        Public Property IsSubscriber() As Boolean
            Get
                Return _IsSubscriber
            End Get
            Set(ByVal value As Boolean)
                _IsSubscriber = value
            End Set
        End Property

        Public Property CustomerID() As String
            Get
                Return _CustomerID
            End Get
            Set(ByVal value As String)
                _CustomerID = value
            End Set
        End Property

        Public Sub New(ByVal providername As String, _
                       ByVal username As String, _
                       ByVal providerUserKey As Object, _
                       ByVal email As String, _
                       ByVal passwordQuestion As String, _
                       ByVal comment As String, _
                       ByVal isApproved As Boolean, _
                       ByVal isLockedOut As Boolean, _
                       ByVal creationDate As DateTime, _
                       ByVal lastLoginDate As DateTime, _
                       ByVal lastActivityDate As DateTime, _
                       ByVal lastPasswordChangedDate As DateTime, _
                       ByVal lastLockedOutDate As DateTime, _
                       ByVal isSubscriber As Boolean, _
                       ByVal customerID As String)

            MyBase.New(providername, _
                       username, _
                       providerUserKey, _
                       email, _
                       passwordQuestion, _
                       comment, _
                       isApproved, _
                       isLockedOut, _
                       creationDate, _
                       lastLoginDate, _
                       lastActivityDate, _
                       lastPasswordChangedDate, _
                       lastLockedOutDate)

            Me.IsSubscriber = isSubscriber
            Me.CustomerID = customerID

        End Sub

    End Class
End Namespace
'</Snippet1>
