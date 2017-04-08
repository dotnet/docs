' <Snippet1>
' Register.vb
Option Strict On
Imports System
Imports System.ComponentModel
Imports System.Drawing
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
    DefaultEvent("Submit"), _
    DefaultProperty("ButtonText"), _
    ToolboxData("<{0}:Register runat=""server""> </{0}:Register>") _
    > _
    Public Class Register
        Inherits CompositeControl

        Private submitButton As Button
        Private nameTextBox As TextBox
        Private nameLabel As Label
        Private emailTextBox As TextBox
        Private emailLabel As Label
        Private emailValidator As RequiredFieldValidator
        Private nameValidator As RequiredFieldValidator

        Private Shared ReadOnly EventSubmitKey As New Object()

        ' The following properties are delegated to child controls.
        ' <Snippet2>
        < _
        Bindable(True), _
        Category("Appearance"), _
        DefaultValue(""), _
        Description("The text to display on the button.") _
        > _
        Public Property ButtonText() As String
            Get
                EnsureChildControls()
                Return submitButton.Text
            End Get
            Set(ByVal value As String)
                EnsureChildControls()
                submitButton.Text = value
            End Set
        End Property
        ' </Snippet2>

        < _
        Bindable(True), _
        Category("Default"), _
        DefaultValue(""), _
        Description("The user name.") _
        > _
        Public Property Name() As String
            Get
                EnsureChildControls()
                Return nameTextBox.Text
            End Get
            Set(ByVal value As String)
                EnsureChildControls()
                nameTextBox.Text = value
            End Set
        End Property

        < _
        Bindable(True), _
        Category("Appearance"), _
        DefaultValue(""), _
        Description("Error message for the name validator.") _
        > _
        Public Property NameErrorMessage() As String
            Get
                EnsureChildControls()
                Return nameValidator.ErrorMessage
            End Get
            Set(ByVal value As String)
                EnsureChildControls()
                nameValidator.ErrorMessage = value
                nameValidator.ToolTip = value
            End Set
        End Property

        < _
        Bindable(True), _
        Category("Appearance"), _
        DefaultValue(""), _
        Description("The text for the name label.") _
        > _
        Public Property NameLabelText() As String
            Get
                EnsureChildControls()
                Return nameLabel.Text
            End Get
            Set(ByVal value As String)
                EnsureChildControls()
                nameLabel.Text = value
            End Set
        End Property

        < _
        Bindable(True), _
        Category("Default"), _
        DefaultValue(""), _
        Description("The e-mail address.") _
        > _
        Public Property Email() As String
            Get
                EnsureChildControls()
                Return emailTextBox.Text
            End Get
            Set(ByVal value As String)
                EnsureChildControls()
                emailTextBox.Text = value
            End Set
        End Property

        < _
        Bindable(True), _
        Category("Appearance"), _
        DefaultValue(""), _
        Description("Error message for the e-mail validator.") _
        > _
        Public Property EmailErrorMessage() As String
            Get
                EnsureChildControls()
                Return emailValidator.ErrorMessage
            End Get
            Set(ByVal value As String)
                EnsureChildControls()
                emailValidator.ErrorMessage = value
                emailValidator.ToolTip = value
            End Set
        End Property

        < _
        Bindable(True), _
        Category("Appearance"), _
        DefaultValue(""), _
        Description("The text for the e-mail label.") _
        > _
        Public Property EmailLabelText() As String
            Get
                EnsureChildControls()
                Return emailLabel.Text
            End Get
            Set(ByVal value As String)
                EnsureChildControls()
                emailLabel.Text = value
            End Set
        End Property

        ' The Submit event.
        < _
        Category("Action"), _
        Description("Raised when the user clicks the button.") _
        > _
        Public Custom Event Submit As EventHandler
            AddHandler(ByVal value As EventHandler)
                Events.AddHandler(EventSubmitKey, value)
            End AddHandler
            RemoveHandler(ByVal value As EventHandler)
                Events.RemoveHandler(EventSubmitKey, value)
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, _
                ByVal e As System.EventArgs)
                CType(Events(EventSubmitKey), _
                    EventHandler).Invoke(sender, e)
            End RaiseEvent
        End Event

        ' The method that raises the Submit event.
        Protected Overridable Sub OnSubmit(ByVal e As EventArgs)
            Dim submitHandler As EventHandler = _
                CType(Events(EventSubmitKey), EventHandler)
            If submitHandler IsNot Nothing Then
                submitHandler(Me, e)
            End If
        End Sub

        ' Handles the Click event of the Button and raises
        ' the Submit event.
        Private Sub submitButton_Click(ByVal source As Object, _
            ByVal e As EventArgs)
            OnSubmit(EventArgs.Empty)
        End Sub

        Protected Overrides Sub CreateChildControls()
            Controls.Clear()

            nameLabel = New Label()

            nameTextBox = New TextBox()
            nameTextBox.ID = "nameTextBox"

            nameValidator = New RequiredFieldValidator()
            nameValidator.ID = "validator1"
            nameValidator.ControlToValidate = nameTextBox.ID
            nameValidator.Text = "Failed validation."
            nameValidator.Display = ValidatorDisplay.Static

            emailLabel = New Label()

            emailTextBox = New TextBox()
            emailTextBox.ID = "emailTextBox"

            emailValidator = New RequiredFieldValidator()
            emailValidator.ID = "validator2"
            emailValidator.ControlToValidate = emailTextBox.ID
            emailValidator.Text = "Failed validation."
            emailValidator.Display = ValidatorDisplay.Static

            submitButton = New Button()
            submitButton.ID = "button1"
            AddHandler submitButton.Click, _
                AddressOf submitButton_Click

            Me.Controls.Add(nameLabel)
            Me.Controls.Add(nameTextBox)
            Me.Controls.Add(nameValidator)
            Me.Controls.Add(emailLabel)
            Me.Controls.Add(emailTextBox)
            Me.Controls.Add(emailValidator)
            Me.Controls.Add(submitButton)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
            AddAttributesToRender(writer)

            writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, _
                "1", False)
            writer.RenderBeginTag(HtmlTextWriterTag.Table)

            writer.RenderBeginTag(HtmlTextWriterTag.Tr)
            writer.RenderBeginTag(HtmlTextWriterTag.Td)
            nameLabel.RenderControl(writer)
            writer.RenderEndTag()
            writer.RenderBeginTag(HtmlTextWriterTag.Td)
            nameTextBox.RenderControl(writer)
            writer.RenderEndTag()
            writer.RenderBeginTag(HtmlTextWriterTag.Td)
            nameValidator.RenderControl(writer)
            writer.RenderEndTag()
            writer.RenderEndTag()

            writer.RenderBeginTag(HtmlTextWriterTag.Tr)
            writer.RenderBeginTag(HtmlTextWriterTag.Td)
            emailLabel.RenderControl(writer)
            writer.RenderEndTag()
            writer.RenderBeginTag(HtmlTextWriterTag.Td)
            emailTextBox.RenderControl(writer)
            writer.RenderEndTag()
            writer.RenderBeginTag(HtmlTextWriterTag.Td)
            emailValidator.RenderControl(writer)
            writer.RenderEndTag()
            writer.RenderEndTag()

            writer.RenderBeginTag(HtmlTextWriterTag.Tr)
            writer.AddAttribute(HtmlTextWriterAttribute.Colspan, _
                "2", False)
            writer.AddAttribute(HtmlTextWriterAttribute.Align, _
                "right", False)
            writer.RenderBeginTag(HtmlTextWriterTag.Td)
            submitButton.RenderControl(writer)
            writer.RenderEndTag()
            writer.RenderBeginTag(HtmlTextWriterTag.Td)
            writer.Write("&nbsp")
            writer.RenderEndTag()
            writer.RenderEndTag()

            writer.RenderEndTag()
        End Sub

        Protected Overrides Sub RecreateChildControls()
            EnsureChildControls()
        End Sub

    End Class
End Namespace
' </Snippet1>
