' <Snippet1>
' Book.vb
Option Strict On
Imports System
Imports System.ComponentModel
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
    DefaultProperty("Title"), _
    ToolboxData("<{0}:Book runat=""server""> </{0}:Book>") _
    > _
    Public Class Book
        Inherits WebControl
        Private authorValue As Author
        Private initialAuthorString As String

        < _
        Bindable(True), _
        Category("Appearance"), _
        DefaultValue(""), _
        Description("The name of the author."), _
        DesignerSerializationVisibility( _
            DesignerSerializationVisibility.Content), _
        PersistenceMode(PersistenceMode.InnerProperty) _
        > _
        Public Overridable ReadOnly Property Author() As Author
            Get
                If (authorValue Is Nothing) Then
                    authorValue = New Author()
                End If
                Return authorValue
            End Get
        End Property

        < _
        Bindable(True), _
        Category("Appearance"), _
        DefaultValue(BookType.NotDefined), _
        Description("Fiction or Not") _
        > _
        Public Overridable Property BookType() As BookType
            Get
                Dim t As Object = ViewState("BookType")
                If t Is Nothing Then t = BookType.NotDefined
                Return CType(t, BookType)
            End Get
            Set(ByVal value As BookType)
                ViewState("BookType") = value
            End Set
        End Property

        < _
        Bindable(True), _
        Category("Appearance"), _
        DefaultValue(""), _
        Description("The symbol for the currency."), _
        Localizable(True) _
        > _
        Public Overridable Property CurrencySymbol() As String
            Get
                Dim s As String = CStr(ViewState("CurrencySymbol"))
                If s Is Nothing Then s = String.Empty
                Return s
            End Get
            Set(ByVal value As String)
                ViewState("CurrencySymbol") = value
            End Set
        End Property

        < _
        Bindable(True), _
        Category("Appearance"), _
        DefaultValue("0.00"), _
        Description("The price of the book."), _
        Localizable(True) _
        > _
        Public Overridable Property Price() As Decimal
            Get
                Dim p As Object = ViewState("Price")
                If p Is Nothing Then p = Decimal.Zero
                Return CType(p, Decimal)
            End Get
            Set(ByVal value As Decimal)
                ViewState("Price") = value
            End Set
        End Property

        < _
        Bindable(True), _
        Category("Appearance"), _
        DefaultValue(""), _
        Description("The title of the book."), _
        Localizable(True) _
        > _
        Public Overridable Property Title() As String
            Get
                Dim s As String = CStr(ViewState("Title"))
                If s Is Nothing Then s = String.Empty
                Return s
            End Get
            Set(ByVal value As String)
                ViewState("Title") = value
            End Set
        End Property

        Protected Overrides Sub RenderContents( _
            ByVal writer As HtmlTextWriter)
            writer.RenderBeginTag(HtmlTextWriterTag.Table)

            writer.RenderBeginTag(HtmlTextWriterTag.Tr)
            writer.RenderBeginTag(HtmlTextWriterTag.Td)
            writer.WriteEncodedText(Title)
            writer.RenderEndTag()
            writer.RenderEndTag()

            writer.RenderBeginTag(HtmlTextWriterTag.Tr)
            writer.RenderBeginTag(HtmlTextWriterTag.Td)
            writer.WriteEncodedText(Author.ToString())
            writer.RenderEndTag()
            writer.RenderEndTag()

            writer.RenderBeginTag(HtmlTextWriterTag.Tr)
            writer.RenderBeginTag(HtmlTextWriterTag.Td)
            writer.WriteEncodedText(BookType.ToString())
            writer.RenderEndTag()
            writer.RenderEndTag()

            writer.RenderBeginTag(HtmlTextWriterTag.Tr)
            writer.RenderBeginTag(HtmlTextWriterTag.Td)
            writer.Write(CurrencySymbol)
            writer.Write("&nbsp")
            writer.Write(String.Format("{0:F2}", Price))
            writer.RenderEndTag()
            writer.RenderEndTag()

            writer.RenderEndTag()
        End Sub

        Protected Overrides Sub LoadViewState( _
            ByVal savedState As Object)
            MyBase.LoadViewState(savedState)
            Dim auth As Author = CType(ViewState("Author"), Author)
            If auth IsNot Nothing Then
                authorValue = auth
            End If
        End Sub

        Protected Overrides Function SaveViewState() As Object
            If authorValue IsNot Nothing Then
                Dim currentAuthorString As String = _
                    authorValue.ToString()
                If Not _
                    (currentAuthorString.Equals(initialAuthorString)) Then
                    ViewState("Author") = authorValue
                End If
            End If
            Return MyBase.SaveViewState()
        End Function

        Protected Overrides Sub TrackViewState()
            If authorValue IsNot Nothing Then
                initialAuthorString = authorValue.ToString()
            End If
            MyBase.TrackViewState()
        End Sub

    End Class
End Namespace
' </Snippet1>
