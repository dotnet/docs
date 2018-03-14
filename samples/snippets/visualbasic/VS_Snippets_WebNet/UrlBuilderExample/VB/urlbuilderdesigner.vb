Imports System
Imports System.Drawing
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
Imports System.Security.Permissions

'<Snippet2>
' Example designer provides a designer verb menu command to launch the 
' BuildUrl method of the UrlBuilder.
<AspNetHostingPermission(SecurityAction.Demand, _
    Level := AspNetHostingPermissionLevel.Minimal)> _
Public Class UrlBuilderDesigner
    Inherits System.Web.UI.Design.UserControlDesigner

    Public Sub New()
    End Sub

    ' Provides a designer verb menu command for invoking the BuildUrl 
    ' method of the UrlBuilder.
    Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
        Get
            Dim dvc As New DesignerVerbCollection()
            dvc.Add(New DesignerVerb("Launch URL Builder UI", New EventHandler(AddressOf Me.launchUrlBuilder)))
            Return dvc
        End Get
    End Property

    '<Snippet1>
    ' This method handles the "Launch Url Builder UI" menu command.
    ' Invokes the BuildUrl method of the System.Web.UI.Design.UrlBuilder.
    Private Sub launchUrlBuilder(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a parent control.
        Dim c As New System.Windows.Forms.Control()
        c.CreateControl()

        ' Launch the Url Builder using the specified control
        ' parent, initial URL, empty relative base URL path,
        ' window caption, filter string and URLBuilderOptions value.
        UrlBuilder.BuildUrl( _
            Me.Component, _
            c, _
            "http://www.example.com", _
            "Select a URL", _
            "", _
            UrlBuilderOptions.None)
    End Sub
    '</Snippet1>

End Class

' Example Web control displays the value of its text property.
' This control is associated with the UrlBuilderDesigner.
<DesignerAttribute(GetType(UrlBuilderDesigner), GetType(IDesigner))> _
Public Class UrlBuilderControl
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