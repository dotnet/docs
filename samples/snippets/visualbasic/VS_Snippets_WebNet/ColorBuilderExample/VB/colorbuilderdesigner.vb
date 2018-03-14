Imports System
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

'<Snippet2>
' Example designer provides a designer verb menu command to launch the 
' BuildColor method of the ColorBuilder.
<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.InheritanceDemand, Name:="FullTrust" ), _
System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust" )> _
Public Class ColorBuilderDesigner
    Inherits System.Web.UI.Design.UserControlDesigner

    Public Sub New()
    End Sub

    ' Provides a designer verb menu command for invoking the BuildColor 
    ' method of the ColorBuilder.
    Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
        Get
            Dim dvc As New DesignerVerbCollection()
            dvc.Add(New DesignerVerb("Launch Color Builder UI", New EventHandler(AddressOf Me.launchColorBuilder)))
            Return dvc
        End Get
    End Property

    ' This method handles the "Launch Color Builder UI" menu command.
    ' Invokes the BuildColor method of the System.Web.UI.Design.ColorBuilder.
    Private Sub launchColorBuilder(ByVal sender As Object, ByVal e As EventArgs)

        '<Snippet1>
        ' Create a parent control.
        Dim c As New System.Windows.Forms.Control()
        c.CreateControl()

        ' Launch the Color Builder using the specified control 
        ' parent and an initial HTML format ("RRGGBB") color string.
        System.Web.UI.Design.ColorBuilder.BuildColor(Me.Component, c, "405599")
        '</Snippet1>
      
    End Sub

End Class

' Example Web control displays the value of its text property.
' This control is associated with the ColorBuilderDesigner.
<DesignerAttribute(GetType(ColorBuilderDesigner), GetType(IDesigner))> _
Public Class ColorBuilderControl
    Inherits System.Web.UI.WebControls.WebControl
    Private [text_] As String

    <Bindable(True), Category("Appearance"), DefaultValue("")> _
    Public Property [Text]() As String
        Get
            Return [text_]
        End Get

        Set(ByVal Value As String)
            [text_] = Value
        End Set
    End Property

    Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
        output.Write([Text])
    End Sub

End Class
'</Snippet2>