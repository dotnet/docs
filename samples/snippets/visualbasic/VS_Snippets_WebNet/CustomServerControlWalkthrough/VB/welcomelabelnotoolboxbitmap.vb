' <Snippet1>
Imports System.Drawing
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

<DefaultProperty("Text")> _
    <ToolboxData("<{0}:WelcomeLabel runat=server></{0}:WelcomeLabel>")> _
    Public Class WelcomeLabel
    Inherits Label

    < _
    Bindable(True), _
    Category("Appearance"), _
    DefaultValue(""), _
    Description("The welcome message text."), _
    Localizable(True) _
    > _
    Public Overridable Property DefaultUserName() As String
        Get
            Dim s As String = CType(ViewState("DefaultUserName"), String)
            Return If((s Is Nothing), [String].Empty, s)
        End Get
        Set(ByVal value As String)
            ViewState("DefaultUserName") = value
        End Set
    End Property


    Protected Overrides Sub RenderContents( _
        ByVal writer As HtmlTextWriter)
        writer.WriteEncodedText(Text)

        Dim displayUserName As String = DefaultUserName
        If Context IsNot Nothing Then
            Dim userName As String = Context.User.Identity.Name
            If Not String.IsNullOrEmpty(userName) Then
                displayUserName = userName
            End If
        End If

        If Not String.IsNullOrEmpty(displayUserName) Then
            writer.Write(", ")
            writer.WriteEncodedText(displayUserName)
        End If

        writer.Write("!")
    End Sub

End Class
' </Snippet1>
