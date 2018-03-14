Imports System
Imports System.Web
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls

    ' The TestLinkButton control generates client-side JavaScript 
    ' to cause postback to the server. It participates
    ' in postback event handling by implementing
    ' the IPostBackEventHandler interface. It
    ' exposes a Click event which it raises in the
    ' IPostBackEventHandler.RaisePostBackEvent method.
    <DefaultEvent("Click"), DefaultProperty("Text"), AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class TestLinkButton
        Inherits WebControl
        Implements IPostBackEventHandler

        Private Shared EventClick As New Object()

        <Bindable(True), _
        Category("Behavior"), _
        DefaultValue(""), _
        Description("The text to display on the link")> _
        Public Property [Text]() As String
            Get
                Dim s As String = CStr(ViewState("Text"))
                If (s Is Nothing) Then
                    Return String.Empty
                Else
                    Return s
                End If
            End Get
            Set(ByVal value As String)
                ViewState("Text") = value
            End Set
        End Property


        Protected Overrides ReadOnly Property TagKey() As HtmlTextWriterTag
            Get
                Return HtmlTextWriterTag.A
            End Get
        End Property

        ' Create an event that adds and removes handlers from the
        ' Control.Events collection when this event is called from
        ' a participating page.
        <Category("Action"), _
        Description("Raised when the hyperlink is clicked")> _
        Public Event Click(ByVal sender As Object, _
        ByVal e As CollectionChangeEventArgs)

        ' Method of IPostBackEventHandler that raises postback events.
        Sub RaisePostBackEvent(ByVal eventArgument As String) Implements IPostBackEventHandler.RaisePostBackEvent
            OnClick(EventArgs.Empty)

        End Sub


        ' <snippet2>
        ' Override the WebControl.AddAttributesToRender method to add an
        ' HRef attribute and a string that represents EcmaScript passed from 
        ' using the GetPostBackClientHyperlink method.
        Protected Overrides Sub AddAttributesToRender(ByVal writer As HtmlTextWriter)

            MyBase.AddAttributesToRender(writer)
            writer.AddAttribute(HtmlTextWriterAttribute.Href, Page.ClientScript.GetPostBackClientHyperlink(Me, String.Empty))
            'writer.AddAttribute(HtmlTextWriterAttribute.Href, Page.GetPostBackClientHyperlink(this, String.Empty));  

        End Sub

        ' </snippet2>
        ' Retrieves the delegate for the Click event and 
        ' invokes the handlers registered with the delegate.
        Public Sub OnClick(ByVal e As EventArgs)
            Dim clickHandler As EventHandler = CType(Events(EventClick), EventHandler)
            If Not (clickHandler Is Nothing) Then
                clickHandler(Me, e)
            End If

        End Sub

        ' <snippet3>
        ' Override the Render method to ensure that this control
        ' is nested in an HtmlForm server control, between a <form runat=server>
        ' opening tag and a </form> closing tag.
        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)

            ' Ensure that the control is nested in a server form.
            If Not (Page Is Nothing) Then
                Page.VerifyRenderingInServerForm(Me)
            End If

            MyBase.Render(writer)

        End Sub

        ' </snippet3>
        Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)

            writer.Write([Text])

        End Sub

    End Class

End Namespace
