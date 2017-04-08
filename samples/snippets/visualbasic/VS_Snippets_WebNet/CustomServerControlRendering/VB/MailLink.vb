' <Snippet1>
' MailLink.vb
Option Strict On
Imports System
Imports System.ComponentModel
Imports System.Security
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB.Controls
    < _
    AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal), _
    AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal), _
    DefaultProperty("Email"), _
    ParseChildren(True, "Text"), _
    ToolboxData("<{0}:MailLink runat=""server""> </{0}:MailLink>") _
    > _
    Public Class MailLink
        Inherits WebControl
        < _
        Bindable(True), _
        Category("Appearance"), _
        DefaultValue(""), _
        Description("The e-mail address.") _
        > _
        Public Overridable Property Email() As String
            Get
                Dim s As String = CStr(ViewState("Email"))
                If s Is Nothing Then s = String.Empty
                Return s
            End Get
            Set(ByVal value As String)
                ViewState("Email") = value
            End Set
        End Property

        < _
        Bindable(True), _
        Category("Appearance"), _
        DefaultValue(""), _
        Description("The text to display on the link."), _
        Localizable(True), _
        PersistenceMode(PersistenceMode.InnerDefaultProperty) _
        > _
        Public Overridable Property Text() As String
            Get
                Dim s As String = CStr(ViewState("Text"))
                If s Is Nothing Then s = String.Empty
                Return s
            End Get
            Set(ByVal value As String)
                ViewState("Text") = value
            End Set
        End Property

        Protected Overrides ReadOnly Property TagKey() _
            As HtmlTextWriterTag
            Get
                Return HtmlTextWriterTag.A
            End Get
        End Property


        Protected Overrides Sub AddAttributesToRender( _
            ByVal writer As HtmlTextWriter)
            MyBase.AddAttributesToRender(writer)
            writer.AddAttribute(HtmlTextWriterAttribute.Href, _
                "mailto:" & Email)
        End Sub

        Protected Overrides Sub RenderContents( _
            ByVal writer As HtmlTextWriter)
            If (Text = String.Empty) Then
                Text = Email
            End If
            writer.WriteEncodedText(Text)
        End Sub

    End Class
End Namespace
' </Snippet1>
