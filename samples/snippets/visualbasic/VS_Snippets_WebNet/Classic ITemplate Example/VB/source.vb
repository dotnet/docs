' <Snippet1>
Imports System
Imports System.Web
Imports System.Web.UI

Namespace TemplateControlSamplesVB

    Public Class TemplateItem
        Inherits Control
        Implements INamingContainer

        Private _message As String = Nothing

        Public Sub New(Message As String)
            _message = message
        End Sub

        Public Property Message As String
           Get
              Return _message
           End Get
           Set
              _message = Value
           End Set
        End Property
    End Class
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust"), _
    ParseChildren(true)> _
    Public Class Template1VB
        Inherits Control
        Implements INamingContainer

        Private _messageTemplate As ITemplate = Nothing
        Private _message As String = Nothing

        Public Property Message As String

           Get
              Return _message
           End Get
           Set
              _message = Value
           End Set
        End Property

        <TemplateContainer(GetType(TemplateItem))> _
        Public Property MessageTemplate As ITemplate

           Get
              Return _messageTemplate
           End Get
           Set
              _messageTemplate = Value
           End Set
        End Property

        Protected Overrides Sub CreateChildControls()

           ' If a template has been specified, use it to create children.
           ' Otherwise, create a single LiteralControl with the message value.

           If Not (MessageTemplate Is Nothing)
              Controls.Clear()
              Dim I As New TemplateItem(Me.Message)
              MessageTemplate.InstantiateIn(I)
              Controls.Add(I)
           Else
              Me.Controls.Add(New LiteralControl(Me.Message))
           End If
        End Sub

    End Class

End Namespace
   
' </Snippet1>
