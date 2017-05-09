' MailLink.cs
' <Snippet1>
Imports System
Imports System.ComponentModel
Imports System.Security
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

<Assembly: TagPrefix("Samples.AspNet", "Sample")> 
Namespace Samples.AspNet

    <AspNetHostingPermission( _
    SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal), _
    AspNetHostingPermission( _
    SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal), _
    ParseChildren(True, "Text"), _
    DefaultProperty("Email"), _
    ToolboxData("<{0}:MailLink ID='MailLinkID' Text='Mail Web Master' runat=""server""> </{0}:MailLink>")> _
    Public Class MailLink
        Inherits WebControl

        <Browsable(True), Category("Appearance"), _
        DefaultValue("webmaster@contoso.com"), _
        Description("The e-mail address.")> _
        Public Overridable Property Email() As String
            Get
                Dim s As String = CStr(ViewState("Email"))
                If s Is Nothing Then s = "webmaster@contoso.com"
                Return s
            End Get
            Set(ByVal value As String)
                ViewState("Email") = value
            End Set
        End Property


        <Browsable(True), Category("Appearance"), _
        DefaultValue("Web Master"), _
        Description("The name to display."), _
        Localizable(True), _
        PersistenceMode(PersistenceMode.InnerDefaultProperty)> _
        Public Overridable Property [Text]() As String
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


        Protected Overrides Sub AddAttributesToRender(ByVal writer _
        As HtmlTextWriter)
            MyBase.AddAttributesToRender(writer)
            writer.AddAttribute( _
            HtmlTextWriterAttribute.Href, "mailto:" + Email)

        End Sub 'AddAttributesToRender


        Protected Overrides Sub RenderContents(ByVal writer _
        As HtmlTextWriter)
            If [Text] = String.Empty Then
                [Text] = Email
            End If
            writer.WriteEncodedText([Text])

        End Sub 'RenderContents
    End Class 'MailLink
End Namespace

' </Snippet1>