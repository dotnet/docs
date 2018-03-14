' System.Web.UI.Control.OnPreRender;
' System.Web.UI.Control.PreRender;

' The following example demontrates implementation of 'PreRender' event and 
' 'OnPreRender' method of 'System.Web.UI.Control' class.   
' This program creates a custom control 'ParentControl' by inheriting from 
' 'Control' Class. Method 'OnPreRender' is overridden to call 'PreRender' 
' event. Custom handler written for PreRender event renders custom controls
' to web client. 

Imports System
Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace RenderChildrenSample

    Public Class ParentControl
        Inherits Control
        Private _message As String = "Parent"

        Public Property Message() As String
            Get
                Return _message
            End Get
            Set(ByVal value As String)
                _message = value
            End Set
        End Property

        ' Call base class constructor.
        Public Sub New()
            ' Attach new handler to PreRender Event.
            AddHandler PreRender, AddressOf PreRender_Handler
        End Sub

        Protected Overrides Sub CreateChildControls()
            ' Creates a new ControlCollection. 
            Me.CreateControlCollection()

            Dim firstControl As New ChildControl()
            firstControl.Message = "FirstChildControl"
            Dim secondControl As New ChildControl()
            secondControl.Message = "SecondChildControl"

            Controls.Add(firstControl)
            Controls.Add(secondControl)

            ' Prevent child controls from being created again.
            ChildControlsCreated = True
        End Sub


        ' <Snippet2>
        ' <Snippet1>
        ' Override the OnPreRender method to set _message to
        ' a default value if it is null.
        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
            MyBase.OnPreRender(e)
            If _message Is Nothing Then
                _message = "Here is some default text."
            End If
        End Sub
        ' </Snippet1>

        Private Sub PreRender_Handler(ByVal sender As Object, ByVal e As System.EventArgs)
            _message = "Parent Text was changed by PreRender method"
        End Sub

        ' </Snippet2>

        Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
            output.Write(("<br>Message : " + _message))
        End Sub

        Public Class ChildControl
            Inherits Control
            Private _message As String = "Child"

            Public Property Message() As String
                Get
                    Return _message
                End Get
                Set(ByVal value As String)
                    _message = value
                End Set
            End Property

            Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
                output.Write(("<br>Message from Control : " + Message))
            End Sub
        End Class
    End Class
End Namespace