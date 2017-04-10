'<snippet1>

' File name:templatecontainerattribute.vb.

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections


Namespace Samples.AspNet.VB.Controls
    <ParseChildren(True)> _
    Public Class VB_TemplatedFirstControl
        Inherits Control
        Implements INamingContainer

        Private _firstTemplate As ITemplate
        Private [_text] As [String] = Nothing
        Private _myTemplateContainer As Control

        <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Protected Overrides Sub OnDataBinding(ByVal e As EventArgs)
            EnsureChildControls()
            MyBase.OnDataBinding(e)
        End Sub


        Public Property FirstTemplate() As ITemplate
            Get
                Return _firstTemplate
            End Get

            Set(ByVal value As ITemplate)
                _firstTemplate = Value
            End Set
        End Property

        Public Property [Text]() As [String]
            Get
                Return [_text]
            End Get

            Set(ByVal value As [String])
                [_text] = Value
            End Set
        End Property

        Public ReadOnly Property DateTime() As [String]
            Get
                Return System.DateTime.Now.ToLongTimeString()
            End Get
        End Property

        Public ReadOnly Property MyTemplateContainer() As Control
            Get
                Return _myTemplateContainer
            End Get
        End Property

        <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Protected Overrides Sub CreateChildControls()

            If Not (FirstTemplate Is Nothing) Then
                _myTemplateContainer = New VB_FirstTemplateContainer(Me)
                FirstTemplate.InstantiateIn(_myTemplateContainer)
                Controls.Add(_myTemplateContainer)
            Else
                Controls.Add(New LiteralControl([Text] + " " + DateTime))
            End If
        End Sub 'CreateChildControls

    End Class 'VB_TemplatedFirstControl


    Public Class VB_FirstTemplateContainer
        Inherits Control
        Implements INamingContainer

        Private _parent As VB_TemplatedFirstControl

        Public Sub New(ByVal parent As VB_TemplatedFirstControl)
            Me._parent = parent
        End Sub 'New

        Public ReadOnly Property [Text]() As [String]
            Get
                Return _parent.Text
            End Get
        End Property

        Public ReadOnly Property DateTime() As [String]
            Get
                Return _parent.DateTime
            End Get
        End Property

    End Class 'VB_FirstTemplateContainer

End Namespace 'CustomControls

'</snippet1>
