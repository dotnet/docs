' <Snippet1>
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
    ToolboxData("<{0}:BookNew runat=""server""> </{0}:BookNew>") _
    > _
    Public Class BookNew
        Inherits WebControl
        Private authorValue As StateManagedAuthor

        < _
        Bindable(True), _
        Category("Appearance"), _
        DefaultValue(""), _
        Description("The name of the author."), _
        DesignerSerializationVisibility( _
            DesignerSerializationVisibility.Content), _
        PersistenceMode(PersistenceMode.InnerProperty) _
        > _
        Public Overridable ReadOnly Property Author() _
            As StateManagedAuthor
            Get
                If authorValue Is Nothing Then
                    authorValue = New StateManagedAuthor
                    If IsTrackingViewState Then
                        CType(authorValue, IStateManager).TrackViewState()
                    End If
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

        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
            MyBase.AddAttributesToRender(writer)
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

#Region "state management"
        Protected Overrides Sub LoadViewState( _
            ByVal savedState As Object)
            Dim p As Pair = TryCast(savedState, Pair)
            If p IsNot Nothing Then
                MyBase.LoadViewState(p.First)
                CType(Author, IStateManager).LoadViewState(p.Second)
                Return
            End If
            MyBase.LoadViewState(savedState)
        End Sub

        Protected Overrides Function SaveViewState() As Object
            Dim baseState As Object = MyBase.SaveViewState
            Dim thisState As Object = Nothing

            If authorValue IsNot Nothing Then
                thisState = _
                    CType(authorValue, IStateManager).SaveViewState()
            End If

            If thisState IsNot Nothing Then
                Return New Pair(baseState, thisState)
            Else
                Return baseState
            End If
        End Function

        Protected Overrides Sub TrackViewState()
            If authorValue IsNot Nothing Then
                CType(Author, IStateManager).TrackViewState()
            End If
            MyBase.TrackViewState()
        End Sub
#End Region

    End Class
End Namespace
' </Snippet1>
