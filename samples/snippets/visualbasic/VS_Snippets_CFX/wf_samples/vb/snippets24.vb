Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Workflow.ComponentModel
Imports System.Workflow.Runtime
Imports System.Workflow.Activities
Imports System.IO
Imports System.Workflow.ComponentModel.Compiler
Imports System.ComponentModel
Imports System.Drawing
Imports System.Net.Mail
Imports System.Windows.Forms
Imports System.Workflow.ComponentModel.Design
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Workflow.Activities.Rules
Imports System.CodeDom
Imports System.Workflow.Runtime.Hosting
Imports System.Threading
Imports System.Collections.ObjectModel
Imports System.Workflow.Runtime.Tracking
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Data

Namespace WF_Snippets

    '***************************
    ' Snippets from Technologies/CustomActivities, Technologies/DesignerHosting, 
    ' Technologies/DynamicUpdate, Technologies/Hosting, Technologies/Roles,
    ' Technologies/Tracking
    '************************************** 

    '****************************
    ' Snippets from CustomActivities/FileWatcher
    '********************************************

    Public Class FileSystemEvent
        Inherits Activity
        Implements IEventActivity, IActivityEventListener(Of QueueEventArgs)

        Private subscriptionId As Guid = Guid.Empty
        Private queueNameValue As IComparable
        Public Path As String
        Public NotifyFilter As NotifyFilters
        Public IncludeSubdirectories As Boolean

        Public Filter As String

        Public Shared FileWatcherEventHandlerEvent As DependencyProperty = DependencyProperty.Register("FileWatcherEventHandler", GetType(EventHandler(Of FileWatcherEventArgs)), GetType(FileSystemEvent))

        ' <snippet221>
        Sub Subscribe(ByVal parentContext As ActivityExecutionContext, ByVal parentEventHandler As IActivityEventListener(Of QueueEventArgs)) Implements IEventActivity.Subscribe
            Console.WriteLine("Subscribe")
            DoSubscribe(parentContext, parentEventHandler)
        End Sub
        ' </snippet221>
        ' <snippet222>
        Sub Unsubscribe(ByVal parentContext As ActivityExecutionContext, ByVal parentEventHandler As IActivityEventListener(Of QueueEventArgs)) Implements IEventActivity.Unsubscribe
            Console.WriteLine("Unsubscribe")
            DoUnsubscribe(parentContext, parentEventHandler)
        End Sub
        ' </snippet222>

        ' <snippet223>
        Private Function CreateQueue(ByVal context As ActivityExecutionContext) As WorkflowQueue
            Console.WriteLine("CreateQueue")
            Dim qService As WorkflowQueuingService = context.GetService(Of WorkflowQueuingService)()

            If Not qService.Exists(Me.queueName) Then
                qService.CreateWorkflowQueue(Me.queueName, True)
            End If

            Return qService.GetWorkflowQueue(Me.QueueName)
        End Function

        ' </snippet223>

        ' <snippet224>
        Private Sub DeleteQueue(ByVal context As ActivityExecutionContext)
            Console.WriteLine("DeleteQueue")
            Dim qService As WorkflowQueuingService = context.GetService(Of WorkflowQueuingService)()
            qService.DeleteWorkflowQueue(Me.QueueName)
        End Sub

        ' </snippet224>

        ' <snippet225>
        Private Function DoSubscribe(ByVal context As ActivityExecutionContext, ByVal listener As IActivityEventListener(Of QueueEventArgs)) As Boolean
            Dim Queue As WorkflowQueue = CreateQueue(context)
            Queue.RegisterForQueueItemAvailable(listener)

            Dim fileService As FileWatcherService = context.GetService(Of FileWatcherService)()
            Me.subscriptionId = fileService.RegisterListener(Me.queueName, Me.Path, Me.Filter, Me.NotifyFilter, Me.IncludeSubdirectories)
            Return Not subscriptionId = Guid.Empty
        End Function
        ' </snippet225>

        ' <snippet226>
        Private Sub DoUnsubscribe(ByVal context As ActivityExecutionContext, ByVal listener As IActivityEventListener(Of QueueEventArgs))
            If Not Me.subscriptionId.Equals(Guid.Empty) Then
                Dim fileService As FileWatcherService = context.GetService(Of FileWatcherService)()
                fileService.UnregisterListener(Me.subscriptionId)
                Me.subscriptionId = Guid.Empty
            End If

            Dim qService As WorkflowQueuingService = context.GetService(Of WorkflowQueuingService)()
            Dim queue As WorkflowQueue = qService.GetWorkflowQueue(Me.QueueName)
            queue.UnregisterForQueueItemAvailable(listener)
        End Sub
        ' </snippet226>
        ' <snippet227>
        Private Function ProcessQueueItem(ByVal context As ActivityExecutionContext) As Boolean

            Dim qService As WorkflowQueuingService = context.GetService(Of WorkflowQueuingService)()

            If Not qService.Exists(Me.QueueName) Then
                Return False
            End If

            Dim Queue As WorkflowQueue = qService.GetWorkflowQueue(Me.QueueName)

            ' If the queue has messages, then process the first one
            If Queue.Count = 0 Then
                Return False
            End If

            Dim e As FileWatcherEventArgs = CType(Queue.Dequeue(), FileWatcherEventArgs)

            ' Raise the FileSystemEvent
            MyBase.RaiseGenericEvent(Of FileWatcherEventArgs)(FileSystemEvent.FileWatcherEventHandlerEvent, Me, e)
            DoUnsubscribe(context, Me)
            DeleteQueue(context)
            Return True
        End Function
        ' </snippet227>

#Region "IEventActivity Members"

        Public ReadOnly Property QueueName() As IComparable Implements IEventActivity.QueueName
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property

#End Region

#Region "IActivityEventListener<QueueEventArgs> Members"

        Public Sub OnEvent(ByVal sender As Object, ByVal e As QueueEventArgs) Implements IActivityEventListener(Of System.Workflow.ComponentModel.QueueEventArgs).OnEvent
            Throw New Exception("The method or operation is not implemented.")
        End Sub

#End Region
    End Class

    Public Class FileWatcherService
        Public Function RegisterListener(ByVal queueName As IComparable, ByVal path As String, ByVal filter As String, ByVal notifyFilter As NotifyFilters, ByVal includeSubdirectories As Boolean) As Guid
            Return Guid.NewGuid()
        End Function
        Public Sub UnregisterListener(ByVal subscriptionId As Guid)
        End Sub
    End Class

    Public Class FileWatcherEventArgs
        Inherits EventArgs
    End Class

    '*********************
    ' Snippets from CustomActivites/SendEmail
    '*/
    Partial Public Class SendEmailActivity
        Inherits Activity

        Private Sub InitializeComponent()
        End Sub
    End Class

    ' <snippet228>
    <ActivityValidator(GetType(SendEmailValidator))> _
    <ToolboxBitmap(GetType(SendEmailActivity), "Resources.EmailMessage.png")> _
    <DefaultEvent("SendingEmail")> _
    <DefaultProperty("To")> _
    Partial Public Class SendEmailActivity
        Inherits System.Workflow.ComponentModel.Activity

        ' <snippet229>
        ' <snippet230>
        ' Define the DependencyProperty objects for all of the Properties 
        ' ...and Events exposed by me activity
        Public Shared FromEmailProperty As DependencyProperty = DependencyProperty.Register("From", GetType(String), GetType(SendEmailActivity), New PropertyMetadata("someone@example.com"))
        Public Shared ToProperty As DependencyProperty = DependencyProperty.Register("To", GetType(String), GetType(SendEmailActivity), New PropertyMetadata("someone@example.com"))
        ' </snippet230>
        Public Shared BodyProperty As DependencyProperty = DependencyProperty.Register("Body", GetType(String), GetType(SendEmailActivity))
        Public Shared SubjectProperty As DependencyProperty = DependencyProperty.Register("Subject", GetType(String), GetType(SendEmailActivity))
        Public Shared HtmlBodyProperty As DependencyProperty = DependencyProperty.Register("HtmlBody", GetType(Boolean), GetType(SendEmailActivity), New PropertyMetadata(False))
        Public Shared CCProperty As DependencyProperty = DependencyProperty.Register("CC", GetType(String), GetType(SendEmailActivity))
        Public Shared BccProperty As DependencyProperty = DependencyProperty.Register("Bcc", GetType(String), GetType(SendEmailActivity))
        Public Shared PortProperty As DependencyProperty = DependencyProperty.Register("Port", GetType(Integer), GetType(SendEmailActivity), New PropertyMetadata(25))
        Public Shared SmtpHostProperty As DependencyProperty = DependencyProperty.Register("SmtpHost", GetType(String), GetType(SendEmailActivity), New PropertyMetadata("localhost"))
        Public Shared ReplyToProperty As DependencyProperty = DependencyProperty.Register("ReplyTo", GetType(String), GetType(SendEmailActivity))

        Public Shared SendingEmailEvent As DependencyProperty = DependencyProperty.Register("SendingEmail", GetType(EventHandler), GetType(SendEmailActivity), New PropertyMetadata())
        Public Shared SentEmailEvent As DependencyProperty = DependencyProperty.Register("SentEmail", GetType(EventHandler), GetType(SendEmailActivity), New PropertyMetadata())

        ' </snippet229>

        ' Define constant values for the Property categories.  
        Private Const MessagePropertiesCategory As String = "Email Message"
        Private Const SMTPPropertiesCategory As String = "Email Server"
        Private Const EventsCategory As String = "Handlers"

        Public Sub New()
            InitializeComponent()
        End Sub


#Region "Email Message Properties"
        ' <snippet231>
        <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
        <DescriptionAttribute("The To property is used to specify the receipient's email address.")> _
        <CategoryAttribute(MessagePropertiesCategory)> _
        Public Property EmailTo() As String
            Get
                Return CType(MyBase.GetValue(SendEmailActivity.ToProperty), String)
            End Get
            Set(ByVal value As String)
                MyBase.SetValue(SendEmailActivity.ToProperty, value)
            End Set
        End Property

        <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
        <DescriptionAttribute("The Subject property is used to specify the subject of the Email message.")> _
        <CategoryAttribute(MessagePropertiesCategory)> _
        Public Property Subject() As String
            Get
                Return CType(MyBase.GetValue(SendEmailActivity.SubjectProperty), String)
            End Get
            Set(ByVal value As String)
                MyBase.SetValue(SendEmailActivity.SubjectProperty, value)
            End Set
        End Property


        <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
        <DescriptionAttribute("The From property is used to specify the From (Sender's) address for the email mesage.")> _
        <CategoryAttribute(MessagePropertiesCategory)> _
        Public Property FromEmail() As String
            Get
                Return CType(MyBase.GetValue(SendEmailActivity.FromEmailProperty), String)
            End Get
            Set(ByVal value As String)
                MyBase.SetValue(SendEmailActivity.FromEmailProperty, value)
            End Set
        End Property


        ' </snippet231>
        <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <BrowsableAttribute(True)> _
        <DescriptionAttribute("The Body property is used to specify the Body of the email message.")> _
        <CategoryAttribute(MessagePropertiesCategory)> _
        Public Property Body() As String
            Get
                Return CType(MyBase.GetValue(SendEmailActivity.BodyProperty), String)
            End Get
            Set(ByVal value As String)
                MyBase.SetValue(SendEmailActivity.BodyProperty, value)
            End Set
        End Property


        <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
        <DescriptionAttribute("The HTMLBody property is used to specify whether the Body is formatted as HTML (True) or not (False)")> _
        <CategoryAttribute(MessagePropertiesCategory)> _
        <Browsable(True)> _
        <DefaultValue(False)> _
        Public Property HtmlBody() As Boolean
            Get
                Return CType(MyBase.GetValue(SendEmailActivity.HtmlBodyProperty), Boolean)
            End Get
            Set(ByVal value As Boolean)
                MyBase.SetValue(SendEmailActivity.HtmlBodyProperty, value)
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
        <Description("The CC property is used to set the CC recipients for the email message.")> _
        <Category(MessagePropertiesCategory)> _
        <Browsable(True)> _
        Public Property CC() As String
            Get
                Return CType(MyBase.GetValue(SendEmailActivity.CCProperty), String)
            End Get

            Set(ByVal value As String)
                MyBase.SetValue(SendEmailActivity.CCProperty, value)
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
        <Description("The Bcc property is used to set the Bcc recipients for the email message.")> _
        <Category(MessagePropertiesCategory)> _
        <Browsable(True)> _
        Public Property Bcc() As String
            Get
                Return CType(MyBase.GetValue(SendEmailActivity.BccProperty), String)
            End Get

            Set(ByVal value As String)
                MyBase.SetValue(SendEmailActivity.BccProperty, value)
            End Set
        End Property


        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
        <Description("The email address that should be used for reply messages.")> _
        <Category(MessagePropertiesCategory)> _
        <Browsable(True)> _
        Public Property ReplyTo() As String
            Get
                Return CType(MyBase.GetValue(SendEmailActivity.ReplyToProperty), String)
            End Get
            Set(ByVal value As String)
                MyBase.SetValue(SendEmailActivity.ReplyToProperty, value)
            End Set
        End Property

#End Region

#Region "SMTP Properties"

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
        <Description("The SMTP host is the machine running SMTP that will send the email.  The default is 'localhost'")> _
        <Category(SMTPPropertiesCategory)> _
        <Browsable(True)> _
        Public Property SmtpHost() As String
            Get
                Return CType(MyBase.GetValue(SendEmailActivity.SmtpHostProperty), String)
            End Get
            Set(ByVal value As String)
                MyBase.SetValue(SendEmailActivity.SmtpHostProperty, value)
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
        <Description("Specify the Port used for SMTP.  The default is 25.")> _
        <Category(SMTPPropertiesCategory)> _
        <Browsable(True)> _
        Public Property Port() As Integer
            Get
                Return CType(MyBase.GetValue(SendEmailActivity.PortProperty), Integer)
            End Get
            Set(ByVal value As Integer)
                MyBase.SetValue(SendEmailActivity.PortProperty, value)
            End Set
        End Property
#End Region

        ' <snippet232>

#Region "Public Events"

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
        <Description("The SendingEmail event is raised before an email is sent through SMTP.")> _
        <Category(EventsCategory)> _
        <Browsable(True)> _
        Public Custom Event SendingEmail As EventHandler
            AddHandler(ByVal value As EventHandler)
                MyBase.AddHandler(SendEmailActivity.SendingEmailEvent, value)
            End AddHandler

            RemoveHandler(ByVal value As EventHandler)
                MyBase.RemoveHandler(SendEmailActivity.SendingEmailEvent, value)
            End RemoveHandler

            RaiseEvent(ByVal sender As Object, ByVal e As System.EventArgs)

            End RaiseEvent
        End Event


        ' </snippet232>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
        <Description("The SentEmail event is raised after an email is sent through SMTP.")> _
        <Category(EventsCategory)> _
        <Browsable(True)> _
        Public Custom Event SentEmail As EventHandler
            AddHandler(ByVal value As EventHandler)
                MyBase.AddHandler(SendEmailActivity.SentEmailEvent, value)
            End AddHandler

            RemoveHandler(ByVal value As EventHandler)
                MyBase.RemoveHandler(SendEmailActivity.SentEmailEvent, value)
            End RemoveHandler

            RaiseEvent(ByVal sender As Object, ByVal e As System.EventArgs)

            End RaiseEvent
        End Event
#End Region

#Region "Activity Execution Logic"


        ' During execution the SendEmail activity should create and send the email using SMTP.  

        ' <snippet233>
        Protected Overrides Function Execute(ByVal context As ActivityExecutionContext) As ActivityExecutionStatus
            Try
                ' Raise the SendingEmail event to the parent workflow or activity
                MyBase.RaiseEvent(SendEmailActivity.SendingEmailEvent, Me, EventArgs.Empty)

                ' Send the email now
                Me.SendEmailUsingSmtp()

                ' Raise the SentEmail event to the parent workflow or activity
                MyBase.RaiseEvent(SendEmailActivity.SentEmailEvent, Me, EventArgs.Empty)

                ' Return the closed status indicating that this activity is complete.
                Return ActivityExecutionStatus.Closed
            Catch
                ' An unhandled exception occurred.  Throw it back to the WorkflowRuntime.
                Throw
            End Try
        End Function

        ' </snippet233>

        Private Sub SendEmailUsingSmtp()
            ' Create a new SmtpClient for sending the email
            Dim client As New SmtpClient()

            ' Use the properties of the activity to construct a new MailMessage
            Dim message As New MailMessage()
            message.From = New MailAddress(Me.FromEmail)
            message.To.Add(Me.EmailTo)


            ' Assign the message values if they are valid.
            If Not String.IsNullOrEmpty(Me.CC) Then
                message.CC.Add(Me.CC)
            End If

            If Not String.IsNullOrEmpty(Me.Bcc) Then
                message.Bcc.Add(Me.Bcc)
            End If

            If Not String.IsNullOrEmpty(Me.Subject) Then
                message.Subject = Me.Subject
            End If

            If Not String.IsNullOrEmpty(Me.Body) Then
                message.Body = Me.Body
            End If

            If Not String.IsNullOrEmpty(Me.ReplyTo) Then
                message.ReplyTo = New MailAddress(Me.ReplyTo)
            End If

            message.IsBodyHtml = Me.HtmlBody

            ' Set the SMTP host and send the mail
            client.Host = Me.SmtpHost
            client.Port = Me.Port
            client.Send(message)
        End Sub


#End Region

    End Class
    ' <snippet234>
    Public Class SendEmailValidator
        Inherits System.Workflow.ComponentModel.Compiler.ActivityValidator

        ' Define private constants for the Validation Errors 
        Private Const InvalidToAddress As Integer = 1
        Private Const InvalidFromAddress As Integer = 2
        Private Const InvalidSMTPPort As Integer = 3

        ' customizing the default activity validation
        Public Overrides Function ValidateProperties(ByVal manager As ValidationManager, ByVal obj As Object) As ValidationErrorCollection

            ' Create a new collection for storing the validation errors
            Dim validationErrors As New ValidationErrorCollection()

            Dim activity As SendEmailActivity = TryCast(obj, SendEmailActivity)

            If activity IsNot Nothing Then

                ' Validate the Email and SMTP Properties
                Me.ValidateEmailProperties(validationErrors, activity)
                Me.ValidateSMTPProperties(validationErrors, activity)

                ' Raise an exception if we have ValidationErrors
                If validationErrors.HasErrors Then

                    Dim validationErrorsMessage As String = String.Empty

                    For Each validationError As ValidationError In validationErrors
                        validationErrorsMessage += _
                            String.Format("Validation Error:  Number 0} - '1}' \n", _
                            validationError.ErrorNumber, validationError.ErrorText)
                    Next

                    ' Throw a new exception with the validation errors.
                    Throw New InvalidOperationException(validationErrorsMessage)
                End If
            End If
            Return validationErrors
        End Function

        ' </snippet234>
        ' <snippet235>
        Private Sub ValidateEmailProperties(ByVal validationErrors As ValidationErrorCollection, ByVal activity As SendEmailActivity)
            'Validate the To property
            If String.IsNullOrEmpty(activity.EmailTo) Then
                Dim validationError As ValidationError = System.Workflow.ComponentModel.Compiler.ValidationError.GetNotSetValidationError(SendEmailActivity.ToProperty.Name)
                validationErrors.Add(validationError)
            ElseIf Not activity.EmailTo.Contains("@") Then
                Dim validationError As New ValidationError("Invalid To e-mail address", _
                  InvalidToAddress, False, SendEmailActivity.ToProperty.Name)
                validationErrors.Add(validationError)
            End If

            ' Validate the From property
            If String.IsNullOrEmpty(activity.FromEmail) Then
                validationErrors.Add(ValidationError.GetNotSetValidationError(SendEmailActivity.FromEmailProperty.Name))
            ElseIf Not activity.FromEmail.Contains("@") Then
                Dim validationError As New ValidationError("Invalid From e-mail address", _
                    InvalidFromAddress, False, SendEmailActivity.FromEmailProperty.Name)
                validationErrors.Add(validationError)
            End If
        End Sub
        ' </snippet235>

        Private Sub ValidateSMTPProperties(ByVal validationErrors As ValidationErrorCollection, ByVal activity As SendEmailActivity)
            ' Validate the SMTPHost property
            If String.IsNullOrEmpty(activity.SmtpHost) Then
                Dim validationError As ValidationError = System.Workflow.ComponentModel.Compiler.ValidationError.GetNotSetValidationError(SendEmailActivity.SmtpHostProperty.Name)
                validationErrors.Add(validationError)
            End If

            ' Validate the Port property
            If activity.Port = 0 Then
                validationErrors.Add(ValidationError.GetNotSetValidationError(SendEmailActivity.PortProperty.Name))
            ElseIf activity.Port < 1 Then
                Dim validationError As New ValidationError("Invalid Port Number", _
                    InvalidSMTPPort, False, SendEmailActivity.PortProperty.Name)
                validationErrors.Add(validationError)
            End If
        End Sub
    End Class

    ' </snippet228>

    '*************************
    '* Snippets from DesignerHosting
    '*/
    Class WorkflowDesignSurface
        Inherits DesignSurface
    End Class

    Public Class WorkflowViewPanel
        Inherits Panel
        Implements IServiceProvider

        Dim workflowView As WorkflowView = New WorkflowView()

        Public Function OnCodeActivityAdded() As Boolean
            Return True
        End Function

        Public Function GetWorkflowView() As WorkflowView
            Return Me.workflowView
        End Function

#Region "IServiceProvider Members"

        Protected Overrides Function GetService(ByVal serviceType As Type) As Object Implements IServiceProvider.GetService
            Throw New Exception("The method or operation is not implemented.")
        End Function

#End Region
    End Class


    Class Snippets24
        Inherits Form
        Private WithEvents addButton As New System.Windows.Forms.Button

        Private workflowPanel As WorkflowViewPanel

        ' <snippet236>
        Private Sub addButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addButton.Click
            Dim viewId As Integer
            Dim rootDesigner As SequentialWorkflowRootDesigner
            rootDesigner = Me.workflowPanel.GetWorkflowView().RootDesigner
            viewId = rootDesigner.ActiveView.ViewId
            If viewId = 1 Then
                Me.workflowPanel.OnCodeActivityAdded()
            Else
                Dim resultBox As DialogResult
                resultBox = MessageBox.Show("This sample supports adding a code activity only in workflow view")
            End If
        End Sub
        ' </snippet236>
    End Class
    ' <snippet237>
    Friend NotInheritable Class CustomMessageFilter
        Inherits WorkflowDesignerMessageFilter

#Region "Members and Constructor"

        Private mouseDown As Boolean
        Private serviceProvider As IServiceProvider
        Private workflowView As WorkflowView
        Private loader As WorkflowDesignerLoader

        Public Sub New(ByVal provider As IServiceProvider, ByVal workflowView As WorkflowView, ByVal loader As WorkflowDesignerLoader)
            Me.serviceProvider = provider
            Me.workflowView = workflowView
            Me.loader = loader
        End Sub

#End Region

#Region "WorkflowDesignerMessageFilter Overridables"

        '<snippet238>
        Protected Overrides Function OnMouseDown(ByVal eventArgs As System.Windows.Forms.MouseEventArgs) As Boolean
            ' Allow other components to process this event by not returning true.
            mouseDown = True
            Return False
        End Function
        '</snippet238>

        '<snippet239>
        Protected Overrides Function OnMouseMove(ByVal eventArgs As System.Windows.Forms.MouseEventArgs) As Boolean
            ' Allow other components to process this event by not returning true.
            If mouseDown Then
                workflowView.ScrollPosition = New Point(eventArgs.X, eventArgs.Y)
            End If
            Return False
        End Function
        '</snippet239>

        '<snippet240>
        Protected Overrides Function OnMouseUp(ByVal eventArgs As MouseEventArgs) As Boolean
            ' Allow other components to process this event by not returning true.
            mouseDown = False
            Return False
        End Function
        '</snippet240>

        '<snippet241>
        Protected Overrides Function OnMouseDoubleClick(ByVal eventArgs As MouseEventArgs) As Boolean
            mouseDown = False
            Return True
        End Function
        '</snippet241>

        '<snippet242>
        Protected Overrides Function OnMouseEnter(ByVal eventArgs As MouseEventArgs) As Boolean
            ' Allow other components to process this event by not returning true.
            mouseDown = False
            Return False
        End Function
        '</snippet242>

        '<snippet243>
        Protected Overrides Function OnMouseHover(ByVal eventArgs As MouseEventArgs) As Boolean
            ' Allow other components to process this event by not returning true.
            mouseDown = False
            Return False
        End Function
        '</snippet243>

        '<snippet244>
        Protected Overrides Function OnMouseLeave() As Boolean
            ' Allow other components to process this event by not returning true.
            mouseDown = False
            Return False
        End Function
        '</snippet244>

        '<snippet245>
        Protected Overrides Function OnMouseWheel(ByVal eventArgs As MouseEventArgs) As Boolean
            mouseDown = False
            Return True
        End Function
        '</snippet245>

        '<snippet246>
        Protected Overrides Function OnMouseCaptureChanged() As Boolean
            ' Allow other components to process this event by not returning true.
            mouseDown = False
            Return False
        End Function
        '</snippet246>

        '<snippet247>
        Protected Overrides Function OnDragEnter(ByVal eventArgs As DragEventArgs) As Boolean
            Return True
        End Function
        '</snippet247>

        '<snippet248>
        Protected Overrides Function OnDragOver(ByVal eventArgs As DragEventArgs) As Boolean
            Return True
        End Function
        '</snippet248>

        '<snippet249>
        Protected Overrides Function OnDragLeave() As Boolean
            Return True
        End Function
        '</snippet249>

        '<snippet250>
        Protected Overrides Function OnDragDrop(ByVal eventArgs As DragEventArgs) As Boolean
            Return True
        End Function
        '</snippet250>

        '<snippet251>
        Protected Overrides Function OnGiveFeedback(ByVal gfbevent As GiveFeedbackEventArgs) As Boolean
            Return True
        End Function
        '</snippet251>

        '<snippet252>
        Protected Overrides Function OnQueryContinueDrag(ByVal qcdevent As QueryContinueDragEventArgs) As Boolean
            Return True
        End Function
        '</snippet252>

        '<snippet253>
        Protected Overrides Function OnKeyDown(ByVal eventArgs As KeyEventArgs) As Boolean
            If eventArgs.KeyCode = Keys.Delete Then
                Dim selectionService As ISelectionService = CType(serviceProvider.GetService(GetType(ISelectionService)), ISelectionService)
                If selectionService IsNot Nothing AndAlso TypeOf selectionService.PrimarySelection Is CodeActivity Then
                    Dim codeActivityComponent As CodeActivity = CType(selectionService.PrimarySelection, CodeActivity)
                    Dim parentActivity As CompositeActivity = codeActivityComponent.Parent
                    If parentActivity IsNot Nothing Then
                        parentActivity.Activities.Remove(codeActivityComponent)
                        Me.ParentView.Update()
                    End If
                    loader.RemoveActivityFromDesigner(codeActivityComponent)
                End If
            End If
            Return True
        End Function
        '</snippet253>

        '<snippet254>
        Protected Overrides Function OnKeyUp(ByVal eventArgs As KeyEventArgs) As Boolean
            Return True
        End Function
        '</snippet254>

        '<snippet255>
        Protected Overrides Function OnShowContextMenu(ByVal menuPoint As Point) As Boolean
            Return True
        End Function
        '</snippet255>

#End Region

    End Class
    ' </snippet237>

    Class Snippets25
        Inherits WorkflowDesignerLoader
        Sub container1()
            Dim host As IDesignerLoaderHost = LoaderHost
            ' <snippet256>
            Dim typeProvider As TypeProvider = New TypeProvider(host)
            typeProvider.AddAssemblyReference(GetType(String).Assembly.Location)
            ' </snippet256>
        End Sub

        Public Overrides ReadOnly Property FileName() As String
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property


        Public Overrides Function GetFileReader(ByVal filePath As String) As TextReader
            Throw New Exception("The method or operation is not implemented.")
        End Function

        Public Overrides Function GetFileWriter(ByVal filePath As String) As TextWriter
            Throw New Exception("The method or operation is not implemented.")
        End Function
    End Class

    '********************
    ' Snippets from DynamicUpdate/ChangingRules
    '**********************

    Class Snippets26
        Shared Sub OnWorkflowIdle(ByVal sender As Object, ByVal e As WorkflowEventArgs)

            Dim newAmount As Integer = 15000
            Dim workflowInstance As WorkflowInstance = e.WorkflowInstance
            ' <snippet257>
            Dim workflowchanges As WorkflowChanges = New WorkflowChanges(workflowInstance.GetWorkflowDefinition)

            Dim transient As CompositeActivity = workflowchanges.TransientWorkflow
            Dim ruleDefinitions As RuleDefinitions = CType(transient.GetValue(ruleDefinitions.RuleDefinitionsProperty), RuleDefinitions)
            Dim conditions As RuleConditionCollection = ruleDefinitions.Conditions
            Dim condition1 As RuleExpressionCondition = CType(conditions("Check"), RuleExpressionCondition)
            CType(condition1.Expression, CodeBinaryOperatorExpression).Right = New CodePrimitiveExpression(newAmount)

            workflowInstance.ApplyWorkflowChanges(workflowchanges)
            ' </snippet257>
        End Sub
    End Class

    '*****************
    '* Snippets from Hosting/CancelWorkflow
    '*/

    Class Snippets27

        Shared waitHandle As AutoResetEvent = New AutoResetEvent(False)
        Shared expenseService As New ExpenseReportServiceImpl()

        Shared Sub OnWorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)
        End Sub

        Shared Sub OnWorkflowTerminated(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)
        End Sub

        Shared Sub OnWorkflowAborted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)
        End Sub

        '<snippet258>
        '<snippet259>
        Shared Sub Main()
            Dim connectionString As String = "Initial Catalog=SqlPersistenceService;Data Source=localhost;Integrated Security=SSPI;"
            Using workflowRuntime As New WorkflowRuntime()
                Dim dataService As New ExternalDataExchangeService()
                workflowRuntime.AddService(dataService)
                dataService.AddService(expenseService)

                workflowRuntime.AddService(New SqlWorkflowPersistenceService(connectionString))


                AddHandler workflowRuntime.WorkflowCompleted, AddressOf OnWorkflowCompleted
                AddHandler workflowRuntime.WorkflowTerminated, AddressOf OnWorkflowTerminated
                AddHandler workflowRuntime.WorkflowIdled, AddressOf OnWorkflowIdled
                AddHandler workflowRuntime.WorkflowAborted, AddressOf OnWorkflowAborted


                ' <snippet260>
                Dim workflowInstance As WorkflowInstance
                workflowInstance = workflowRuntime.CreateWorkflow(GetType(SampleWorkflow))
                workflowInstance.Start()
                ' </snippet260>

                waitHandle.WaitOne()

                workflowRuntime.StopRuntime()
            End Using
        End Sub
        '</snippet259>
        '</snippet258>
        Shared Sub OnWorkflowTerminated(ByVal sender As Object, ByVal e As WorkflowTerminatedEventArgs)
            Console.WriteLine(e.Exception.Message)
            WaitHandle.Set()
        End Sub

        Shared Sub OnWorkflowAborted(ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Console.WriteLine("Ending workflow...")
            WaitHandle.Set()
        End Sub
        ' <snippet261>
        Shared Sub OnWorkflowIdled(ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Dim workflow As WorkflowInstance = e.WorkflowInstance

            Console.WriteLine(vbCrLf + "...waiting for 3 seconds... " + vbCrLf)
            Thread.Sleep(3000)

            ' what activity is blocking the workflow
            Dim wqi As ReadOnlyCollection(Of WorkflowQueueInfo) = workflow.GetWorkflowQueueData()
            For Each q As WorkflowQueueInfo In wqi

                Dim eq As EventQueueName = TryCast(q.QueueName, EventQueueName)

                If eq IsNot Nothing Then
                    ' get activity that is waiting for event
                    Dim blockedActivity As ReadOnlyCollection(Of String) = q.SubscribedActivityNames
                    Console.WriteLine("Host: Workflow is blocked on " + blockedActivity(0))

                    ' this event is never going to arrive eg. employee left the company
                    ' lets send an exception to this queue
                    ' it will either be handled by exception handler that was modeled in workflow
                    ' or the runtime will unwind running compensation handlers and exit the workflow
                    Console.WriteLine("Host: This event is not going to arrive")
                    Console.WriteLine("Host: Cancel workflow with unhandled exception")
                    workflow.EnqueueItem(q.QueueName, New Exception("ExitWorkflowException"), Nothing, Nothing)
                End If
            Next
        End Sub
        ' </snippet261>
    End Class

    Partial Public Class SampleWorkflow1
        Inherits SequentialWorkflowActivity
        Sub submitExpense_MethodInvoking(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
        Sub expenseApproval_Executing(ByVal sender As Object, ByVal e As ActivityExecutionStatusChangedEventArgs)
        End Sub
    End Class
    ' <snippet262>
    Partial Public Class SampleWorkflow
        Inherits SequentialWorkflowActivity

        'NOTE: The following procedure is required by the Workflow Designer
        'It can be modified using the Workflow Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Private Sub InitializeComponent()
            Me.CanModifyActivities = True
            Me.ExpenseApproval = New System.Workflow.Activities.HandleExternalEventActivity
            Me.SubmitExpense = New System.Workflow.Activities.CallExternalMethodActivity
            '
            'ExpenseApproval
            '
            Me.ExpenseApproval.EventName = "ExpenseApproval"
            Me.ExpenseApproval.InterfaceType = GetType(IExpenseReportService)
            Me.ExpenseApproval.Name = "ExpenseApproval"
            AddHandler Me.ExpenseApproval.Executing, AddressOf Me.ExpenseApproval_Executing

            '
            'SubmitExpense
            '
            Me.SubmitExpense.InterfaceType = GetType(IExpenseReportService)
            Me.SubmitExpense.MethodName = "SubmitExpense"
            Me.SubmitExpense.Name = "SubmitExpense"
            AddHandler Me.SubmitExpense.MethodInvoking, AddressOf Me.SubmitExpense_MethodInvoking
            '
            'SampleWorkflow
            '
            Me.Activities.Add(Me.SubmitExpense)
            Me.Activities.Add(Me.ExpenseApproval)
            Me.Name = "SampleWorkflow"
            Me.CanModifyActivities = False

        End Sub
        Private WithEvents ExpenseApproval As System.Workflow.Activities.HandleExternalEventActivity
        Private WithEvents SubmitExpense As System.Workflow.Activities.CallExternalMethodActivity
    End Class
    ' </snippet262>
    Partial Public Class SampleWorkflow
        Inherits SequentialWorkflowActivity
        Private Sub ExpenseApproval_Executing(ByVal sender As System.Object, ByVal e As System.Workflow.ComponentModel.ActivityExecutionStatusChangedEventArgs)
            Console.WriteLine("Workflow: waiting for approval")
        End Sub

        Private Sub SubmitExpense_MethodInvoking(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Console.WriteLine("Workflow: submits expense report")
        End Sub
    End Class
    ' Interface for the event and method to be invoked
    <ExternalDataExchange()> _
    Public Interface IExpenseReportService
        Sub SubmitExpense(ByVal id As String)
        Event ExpenseApproval As EventHandler(Of ExpenseReportEventArgs)
    End Interface

    <Serializable()> _
    Public Class ExpenseReportEventArgs
        Inherits ExternalDataEventArgs

        Private approvalValue As String

        Public Sub New(ByVal instanceId As Guid, ByVal id As String)
            MyBase.New(instanceId)
            Me.approvalValue = id
        End Sub

        Public Property Approval() As String
            Get
                Return approvalValue
            End Get
            Set(ByVal value As String)
                approvalValue = value
            End Set
        End Property
    End Class
    Class ExpenseReportServiceImpl
        Implements IExpenseReportService

        Dim expenseId As String

        ' Expense report is created in the system 
        ' This method is invoked by the SubmitExpense activity
        Public Sub SubmitExpense(ByVal Id As String) Implements IExpenseReportService.SubmitExpense
            Console.WriteLine("Host: expense report sent")
            expenseId = Id
        End Sub

        ' This method corresponds to the event being raised to approve the order
        Public Sub ApprovalResult(ByVal workflow As WorkflowInstance, ByVal approval As String)
            RaiseEvent ExpenseApproval(workflow, New ExpenseReportEventArgs(workflow.InstanceId, approval))
        End Sub


        Public Event ExpenseApproval As EventHandler(Of ExpenseReportEventArgs) Implements IExpenseReportService.ExpenseApproval
    End Class

    '**********************
    '* Snippets from Hosting/CustomPersistenceService
    '*/

    ' <snippet263>
    Public Class FilePersistenceService
        Inherits WorkflowPersistenceService

        Private unloadOnIdleValue As Boolean = False

        Public Sub New(ByVal unloadOnIdle As Boolean)
            Me.unloadOnIdleValue = unloadOnIdle
        End Sub

        ' <snippet264>
        ' Save the workflow instance state at the point of persistence with option of locking the instance state if it is shared
        ' across multiple runtimes or multiple phase instance updates
        Protected Overrides Sub SaveWorkflowInstanceState(ByVal rootActivity As System.Workflow.ComponentModel.Activity, ByVal unlock As Boolean)
            Dim contextGuid As Guid = CType(rootActivity.GetValue(Activity.ActivityContextGuidProperty), Guid)
            Console.WriteLine("Saving instance: 0}" + vbLf, contextGuid)
            SerializeToFile( _
                WorkflowPersistenceService.GetDefaultSerializedForm(rootActivity), contextGuid)

            ' See when the next timer (Delay activity) for this workflow will expire
            Dim timers As TimerEventSubscriptionCollection = CType(rootActivity.GetValue(TimerEventSubscriptionCollection.TimerCollectionProperty), TimerEventSubscriptionCollection)
            Dim subscription As TimerEventSubscription = timers.Peek()
            If subscription IsNot Nothing Then
                ' Set a system timer to automatically reload this workflow when it's next timer expires
                Dim timeDifference As TimeSpan = subscription.ExpiresAt - DateTime.UtcNow
                Dim callback As TimerCallback = New TimerCallback(AddressOf ReloadWorkflow)
                Dim timer As New System.Threading.Timer( _
                    callback, _
                    subscription.WorkflowInstanceId, _
                    CType(IIf(timeDifference < TimeSpan.Zero, TimeSpan.Zero, timeDifference), TimeSpan), _
                    New TimeSpan(-1))
            End If
        End Sub
        ' </snippet264>

        ' <snippet265>
        Private Sub ReloadWorkflow(ByVal id As Object)
            ' Reload the workflow so that it will continue processing
            Me.Runtime.GetWorkflow(CType(id, Guid)).Load()
        End Sub
        ' </snippet265>

        ' <snippet266>
        ' Load workflow instance state.
        Protected Overrides Function LoadWorkflowInstanceState(ByVal instanceId As System.Guid) As System.Workflow.ComponentModel.Activity
            Console.WriteLine("Loading instance: 0}" + vbLf, instanceId)
            Dim obj As Object = DeserializeFromFile(instanceId)
            Dim workflowBytes As Byte() = DeserializeFromFile(instanceId)
            Return WorkflowPersistenceService.RestoreFromDefaultSerializedForm(workflowBytes, Nothing)
        End Function
        ' </snippet266>

        ' <snippet267>
        ' unlock workflow instance state.  
        ' instance state locking is necessary when multiple runtimes share instance persistence store
        Protected Overrides Sub UnlockWorkflowInstanceState(ByVal rootActivity As System.Workflow.ComponentModel.Activity)
            ' File locking is not supported in this sample
        End Sub
        ' </snippet267>

        ' <snippet268>
        ' Save completed activity state
        Protected Overrides Sub SaveCompletedContextActivity(ByVal activity As System.Workflow.ComponentModel.Activity)
            Dim contextGuid As Guid = CType(activity.GetValue(activity.ActivityContextGuidProperty), Guid)
            Console.WriteLine("Saving completed activity context: 0}", contextGuid)
            SerializeToFile( _
                WorkflowPersistenceService.GetDefaultSerializedForm(activity), contextGuid)
        End Sub
        ' </snippet268>

        ' <snippet269>
        ' Load completed activity state.
        Protected Overrides Function LoadCompletedContextActivity(ByVal scopeId As System.Guid, ByVal outerActivity As System.Workflow.ComponentModel.Activity) As System.Workflow.ComponentModel.Activity
            Console.WriteLine("Loading completed activity context: 0}", scopeId)
            Dim workflowBytes As Byte() = DeserializeFromFile(scopeId)
            Dim deserializedActivities As Activity = WorkflowPersistenceService.RestoreFromDefaultSerializedForm(workflowBytes, outerActivity)
            Return deserializedActivities
        End Function
        ' </snippet269>

        ' <snippet270>
        ' Returns status of unloadOnIdle flag
        Protected Overrides Function UnloadOnIdle(ByVal rootActivity As System.Workflow.ComponentModel.Activity) As Boolean
            Return unloadOnIdleValue
        End Function
        ' </snippet270>
        ' </snippet263>

        ' serialize activity instance state to file with option to lock state file
        Public Shared Sub SerializeToFile(ByVal workflowBytes As Byte(), ByVal id As Guid)
            Dim filename As String = id.ToString()
            Dim fileStream As FileStream = Nothing

            Try
                If File.Exists(filename) Then
                    File.Delete(filename)
                End If

                fileStream = New FileStream(filename, FileMode.CreateNew, FileAccess.Write, FileShare.None)

                ' get the compressed serialized form
                fileStream.Write(workflowBytes, 0, workflowBytes.Length)
            Finally
                If Not fileStream Is Nothing Then
                    fileStream.Close()
                End If
            End Try
        End Sub

        ' deserialize instance state from file given instance id 
        ' and outerActivity used in the case of compensation for a completed scope
        Public Shared Function DeserializeFromFile(ByVal id As Guid) As Byte()
            Dim filename As String = id.ToString()
            Dim fileStream As FileStream = Nothing

            Dim obj As Object = Nothing
            Try
                ' file opened for shared reads but no writes by anyone
                fileStream = New FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read)
                fileStream.Seek(0, SeekOrigin.Begin)
                Dim workflowBytes((CType(fileStream.Length, Integer))) As Byte

                ' get the serialized form
                fileStream.Read(workflowBytes, 0, workflowBytes.Length)

                Return workflowBytes
            Finally
                fileStream.Close()
            End Try
        End Function
    End Class


    Class Snippets28
        Shared waitHandle As New AutoResetEvent(False)

        ' <snippet271>
        Shared Sub Main()

            Using currentWorkflowRuntime As New WorkflowRuntime()
                Try

                    ' engine will unload workflow instance when it is idle
                    '<snippet272>
                    currentWorkflowRuntime.AddService(New FilePersistenceService(True))
                    '</snippet272>

                    '<snippet273>
                    AddHandler currentWorkflowRuntime.WorkflowCreated, AddressOf OnWorkflowCreated
                    '</snippet273>
                    AddHandler currentWorkflowRuntime.WorkflowCompleted, AddressOf OnWorkflowCompleted
                    '<snippet274>
                    AddHandler currentWorkflowRuntime.WorkflowIdled, AddressOf OnWorkflowIdled
                    '</snippet274>
                    '<snippet275>
                    AddHandler currentWorkflowRuntime.WorkflowUnloaded, AddressOf OnWorkflowUnloaded
                    '</snippet275>
                    '<snippet276>
                    AddHandler currentWorkflowRuntime.WorkflowLoaded, AddressOf OnWorkflowLoaded
                    '</snippet276>
                    AddHandler currentWorkflowRuntime.WorkflowTerminated, AddressOf OnWorkflowTerminated
                    AddHandler currentWorkflowRuntime.ServicesExceptionNotHandled, AddressOf OnExceptionNotHandled

                    currentWorkflowRuntime.CreateWorkflow(GetType(PersistenceServiceWorkflow)).Start()

                    waitHandle.WaitOne()

                Catch e As Exception
                    Console.WriteLine("Exception \n\t Source: 0} \n\t Message: 1}", e.Source, e.Message)
                Finally
                    currentWorkflowRuntime.StopRuntime()
                    Console.WriteLine("Workflow runtime stopped, program exiting... \n")
                End Try
            End Using
        End Sub
        ' </snippet271>

        ' <snippet277>
        Shared Sub OnExceptionNotHandled(ByVal sender As Object, ByVal e As System.Workflow.Runtime.ServicesExceptionNotHandledEventArgs)
            Console.WriteLine("Unhandled Workflow Exception ")
            Console.WriteLine("  Type: " + e.GetType().ToString())
            Console.WriteLine("  Message: " + e.Exception.Message)
        End Sub
        ' </snippet277>
        Shared Sub OnWorkflowCreated(ByVal sender As Object, ByVal e As System.Workflow.Runtime.WorkflowEventArgs)
            Console.WriteLine("Workflow created " + vbLf)
        End Sub

        Shared Sub OnWorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)
            Console.WriteLine("Workflow completed " + vbLf)
            waitHandle.Set()
        End Sub

        Shared Sub OnWorkflowIdled(ByVal sender As Object, ByVal e As System.Workflow.Runtime.WorkflowEventArgs)
            Console.WriteLine("Workflow idling " + vbLf)
        End Sub

        Shared Sub OnWorkflowUnloaded(ByVal sender As Object, ByVal e As System.Workflow.Runtime.WorkflowEventArgs)
            Console.WriteLine("Workflow unloaded " + vbLf)
        End Sub

        Shared Sub OnWorkflowLoaded(ByVal sender As Object, ByVal e As System.Workflow.Runtime.WorkflowEventArgs)
            Console.WriteLine("Workflow loaded " + vbLf)
        End Sub

        Shared Sub OnWorkflowTerminated(ByVal sender As Object, ByVal e As WorkflowTerminatedEventArgs)
            Console.WriteLine(e.Exception.Message)
            waitHandle.Set()
        End Sub

    End Class

    Partial Public Class PersistenceServiceWorkflow
        Inherits SequentialWorkflowActivity
    End Class


    '***************************************
    '* Snippets from Hosting/PersistenceHost
    '*/

    Class Snippets29

        Private SendDocument As New CallExternalMethodActivity()
        Sub Container1()
            '<snippet278>
            Me.SendDocument = New System.Workflow.Activities.CallExternalMethodActivity()
            '</snippet278>
        End Sub
    End Class

    '***********************************************
    '* Snippets from Hosting/PersistenceServices
    '*/
    Class Snippets30
        Private workflowRuntime As New WorkflowRuntime()
        Sub container1()
            '<snippet279>
            AddHandler workflowRuntime.WorkflowPersisted, AddressOf OnWorkflowPersisted
            '</snippet279>
        End Sub
        '<snippet280>
        'Called when the workflow is idle - in me sample me occurs when the workflow is waiting on the
        ' delay1 activity to expire
        Shared Sub OnWorkflowIdled(ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Console.WriteLine("Workflow is idle.")
            e.WorkflowInstance.TryUnload()
        End Sub
        '</snippet280>
        Shared Sub OnWorkflowPersisted(ByVal sender As Object, ByVal e As WorkflowEventArgs)
        End Sub
    End Class
    '********************************
    '* Snippets from Hosting/RaiseEventToLoadWorkflow
    '*/
    Class Snippets31
        Dim documentApproved As HandleExternalEventActivity
        Sub container1()
            ' <snippet281>
            Me.documentApproved = New HandleExternalEventActivity()
            Me.documentApproved.Name = "documentApproved"
            Me.documentApproved.InterfaceType = GetType(IDocumentApproval)
            Me.documentApproved.EventName = "DocumentApproved"
            Me.documentApproved.Roles = Nothing
            AddHandler Me.documentApproved.Invoked, AddressOf Me.OnInvoked
            ' </snippet281>
        End Sub
        Public Interface IDocumentApproval
        End Interface
        Private Sub OnInvoked(ByVal sender As System.Object, ByVal e As ExternalDataEventArgs)
            Console.WriteLine("Workflow: Received document approval" + vbLf)
        End Sub
    End Class

    '**************************************
    '* Snippets from Hosting/WorkflowThreading
    '*/

    Class Snippets32

        Shared workflowRuntime As New WorkflowRuntime()
        Shared readyHandle As New AutoResetEvent(False)
        Shared workflowInstance As WorkflowInstance
        Shared Sub SetReloadWorkflowTimer()

        End Sub

        Sub container1(ByVal args As String())
            '<snippet282>
            Dim scheduler As ManualWorkflowSchedulerService = Nothing
            If args(0).ToString().Equals("Single", StringComparison.OrdinalIgnoreCase) Then
                scheduler = New ManualWorkflowSchedulerService()
                workflowRuntime.AddService(scheduler)
            End If
            '</snippet282>

            '<snippet283>
            If workflowRuntime.GetService(Of ManualWorkflowSchedulerService)() IsNot Nothing Then
                ' Set a system timer to reload me workflow when its next timer expires
                SetReloadWorkflowTimer()
            Else
                readyHandle.Set()
            End If
            '</snippet283>
        End Sub
        '<snippet284>
        Shared Sub ReloadWorkflow(ByVal state As Object)
            If workflowInstance.GetWorkflowNextTimerExpiration() > DateTime.UtcNow Then
                SetReloadWorkflowTimer()
            Else
                readyHandle.Set()
            End If
        End Sub
        '</snippet284>
    End Class
    '***********************
    '* Snippets from Roles/ActiveDirectoryRoles
    '*/

    ' <snippet_ActiveDirectoryRoles1>
    <ExternalDataExchange()> _
    Public Interface IStartPurchaseOrder
        Event InitiatePurchaseOrder As EventHandler(Of InitiatePOEventArgs)
    End Interface
    ' </snippet_ActiveDirectoryRoles1>

    Public Class InitiatePOEventArgs
        Inherits ExternalDataEventArgs

        Public Sub New()
            MyBase.New(Guid.NewGuid())
        End Sub
    End Class

    '****************************
    '* Snippets from Tracking/EventArgsTrackingSample
    '*/

    Class Snippets33

        ' <snippet286>
        ' Manipulating and Writing Information to Console
        Shared Sub WriteEventDescriptionAndArgs(ByVal eventDescription As String, ByVal argData As Object, ByVal eventDateTime As DateTime)
            ' Checking the type and the corresponding event
            If TypeOf argData Is TrackingWorkflowSuspendedEventArgs Then
                WriteSuspendedEventArgs(eventDescription, CType(argData, TrackingWorkflowSuspendedEventArgs), eventDateTime)
            End If
            If TypeOf argData Is TrackingWorkflowTerminatedEventArgs Then
                WriteTerminatedEventArgs(eventDescription, CType(argData, TrackingWorkflowTerminatedEventArgs), eventDateTime)
            End If
            If TypeOf argData Is TrackingWorkflowExceptionEventArgs Then
                WriteExceptionEventArgs(eventDescription, CType(argData, TrackingWorkflowExceptionEventArgs), eventDateTime)
            End If
        End Sub
        ' </snippet286>

        ' <snippet287>
        Shared Sub WriteSuspendedEventArgs(ByVal eventDescription As String, ByVal suspendedEventArgs As TrackingWorkflowSuspendedEventArgs, ByVal eventDataTime As DateTime)
            Console.WriteLine(vbCrLf + "Suspended Event Arguments Read From Tracking Database:")
            Console.WriteLine("EventDataTime: " + eventDataTime.ToString(CultureInfo.CurrentCulture))
            Console.WriteLine("EventDescription: " + eventDescription)
            Console.WriteLine("SuspendedEventArgs Info: " + suspendedEventArgs.Error)
        End Sub
        ' </snippet287>

        ' <snippet288>
        Shared Sub WriteTerminatedEventArgs(ByVal eventDescription As String, ByVal terminatedEventArgs As TrackingWorkflowTerminatedEventArgs, ByVal eventDataTime As DateTime)
            Console.WriteLine(vbCrLf + "Terminated Event Arguments Read From Tracking Database:")
            Console.WriteLine("EventDataTime: " + eventDataTime.ToString(CultureInfo.CurrentCulture))
            Console.WriteLine("EventDescription: " + eventDescription)
            If terminatedEventArgs.Exception IsNot Nothing Then
                Console.WriteLine("TerminatedEventArgs Exception Message: " + terminatedEventArgs.Exception.Message.ToString())
            End If
        End Sub
        ' </snippet288>

        ' <snippet289>
        Shared Sub WriteExceptionEventArgs(ByVal eventDescription As String, ByVal exceptionEventArgs As TrackingWorkflowExceptionEventArgs, ByVal eventDataTime As DateTime)
            Console.WriteLine(vbCrLf + "Exception Event Arguments Read From Tracking Database:")
            Console.WriteLine("EventDataTime: " + eventDataTime.ToString(CultureInfo.CurrentCulture))
            Console.WriteLine("EventDescription: " + eventDescription)
            If exceptionEventArgs.Exception IsNot Nothing Then
                Console.WriteLine("ExceptionEventArgs Exception Message: " + exceptionEventArgs.Exception.Message.ToString())
            End If
            Console.WriteLine("ExceptionEventArgs Original Activity Path: " + exceptionEventArgs.OriginalActivityPath.ToString())
        End Sub
        ' </snippet289>
    End Class
    '*********************
    '* Snippets from Tracking/QueryImportsSqlTrackingService
    '*/

    Class Snippets34
        Shared WaitHandle As New AutoResetEvent(False)
        Const connectionString As String = "Initial Catalog=Tracking;Data Source=localhost;Integrated Security=SSPI;"
        Shared version As Version

        Private Shared Function GetTrackingProfileVersion(ByVal version As Version) As Version
            Return New Version()
        End Function

        Shared Sub OnWorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)

        End Sub
        Shared Sub OnWorkflowTerminated(ByVal sender As Object, ByVal e As WorkflowTerminatedEventArgs)

        End Sub
        Shared Sub OutputActivityTrackingEvents(ByVal instanceId As Guid)

        End Sub
        Shared Sub InsertTrackingProfile(ByVal profile As String)

        End Sub
        Partial Public Class SimpleWorkflow
            Inherits SequentialWorkflowActivity
        End Class
        ' <snippet290>
        Shared Sub Main()
            Try
                version = GetTrackingProfileVersion(New Version("3.0.0.0"))
                CreateAndInsertTrackingProfile()

                Using currentWorkflowRuntime As New WorkflowRuntime()
                    currentWorkflowRuntime.AddService(New SqlTrackingService(connectionString))
                    currentWorkflowRuntime.StartRuntime()

                    AddHandler currentWorkflowRuntime.WorkflowCompleted, AddressOf OnWorkflowCompleted
                    AddHandler currentWorkflowRuntime.WorkflowTerminated, AddressOf OnWorkflowTerminated

                    Dim type As System.Type = GetType(SimpleWorkflow)
                    Dim instance As WorkflowInstance = currentWorkflowRuntime.CreateWorkflow(type)
                    instance.Start()

                    WaitHandle.WaitOne()

                    currentWorkflowRuntime.StopRuntime()

                    OutputWorkflowTrackingEvents(instance.InstanceId)
                    OutputActivityTrackingEvents(instance.InstanceId)

                    Console.WriteLine(vbLf + "Done Running The workflow.")
                End Using
            Catch ex As Exception
                If Not ex.InnerException Is Nothing Then
                    Console.WriteLine(ex.InnerException.Message)
                Else
                    Console.WriteLine(ex.Message)
                End If
            End Try
        End Sub
        ' </snippet290>

        ' <snippet291>
        Shared Sub CreateAndInsertTrackingProfile()
            Dim profile As TrackingProfile = New TrackingProfile()

            Dim activityTrack As ActivityTrackPoint = New ActivityTrackPoint()
            Dim activityLocation As ActivityTrackingLocation = New ActivityTrackingLocation(GetType(Activity))
            activityLocation.MatchDerivedTypes = True
            Dim statuses As IEnumerable(Of ActivityExecutionStatus) = CType(System.Enum.GetValues(GetType(ActivityExecutionStatus)), IEnumerable(Of ActivityExecutionStatus))
            For Each status As ActivityExecutionStatus In statuses
                activityLocation.ExecutionStatusEvents.Add(status)
            Next

            activityTrack.MatchingLocations.Add(activityLocation)
            profile.ActivityTrackPoints.Add(activityTrack)
            profile.Version = version

            Dim workflowTrack As WorkflowTrackPoint = New WorkflowTrackPoint()
            Dim workflowLocation As WorkflowTrackingLocation = New WorkflowTrackingLocation()
            Dim eventStatuses As IEnumerable(Of TrackingWorkflowEvent) = CType(System.Enum.GetValues(GetType(TrackingWorkflowEvent)), IEnumerable(Of TrackingWorkflowEvent))
            For Each status As TrackingWorkflowEvent In eventStatuses
                workflowLocation.Events.Add(status)
            Next

            workflowTrack.MatchingLocation = workflowLocation
            profile.WorkflowTrackPoints.Add(workflowTrack)

            Dim serializer As TrackingProfileSerializer = New TrackingProfileSerializer()
            Dim writer As StringWriter = New StringWriter(New StringBuilder(), CultureInfo.InvariantCulture)
            serializer.Serialize(writer, profile)
            Dim trackingProfile As String = writer.ToString()
            InsertTrackingProfile(trackingProfile)
        End Sub
        ' </snippet291>

        ' <snippet292>
        Shared Sub OutputWorkflowTrackingEvents(ByVal instanceId As Guid)
            Dim sqlTrackingQuery As SqlTrackingQuery = New SqlTrackingQuery(connectionString)


            Dim sqlTrackingWorkflowInstance As SqlTrackingWorkflowInstance = Nothing
            sqlTrackingQuery.TryGetWorkflow(instanceId, sqlTrackingWorkflowInstance)

            Console.WriteLine(vbCrLf + "Instance Level Events:" + vbCrLf)

            Dim workflowTrackingRecord As WorkflowTrackingRecord
            For Each workflowTrackingRecord In sqlTrackingWorkflowInstance.WorkflowEvents
                Console.WriteLine("EventDescription : 0}  DateTime : 1}", workflowTrackingRecord.TrackingWorkflowEvent, workflowTrackingRecord.EventDateTime)
            Next
        End Sub
        ' </snippet292>
    End Class

    '**************************************
    '* Snippets from Tracking/RuleActionTrackingEventSample
    '*/

    Class Snippets35
        Inherits SequentialWorkflowActivity

        Private Sub OnWorkflowCompleted(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub
        Private Shared Sub WriteTitle(ByVal title As String)


        End Sub

        ' <snippet293>
        Private Shared Sub WriteUserTrackingRecord(ByVal userTrackingRecord As UserTrackingRecord)
            WriteTitle("User Activity Record")
            Console.WriteLine("EventDataTime: " + userTrackingRecord.EventDateTime.ToString())
            Console.WriteLine("QualifiedId: " + userTrackingRecord.QualifiedName.ToString())
            Console.WriteLine("ActivityType: " + userTrackingRecord.ActivityType.FullName.ToString())
            If TypeOf userTrackingRecord.UserData Is RuleActionTrackingEvent Then
                WriteRuleActionTrackingEvent(CType(userTrackingRecord.UserData, RuleActionTrackingEvent))
            End If
        End Sub

        Private Shared Sub WriteRuleActionTrackingEvent(ByVal ruleActionTrackingEvent As RuleActionTrackingEvent)
            Console.WriteLine("RuleActionTrackingEvent")
            Console.WriteLine("***********************")
            Console.WriteLine("RuleName: " + ruleActionTrackingEvent.RuleName.ToString())
            Console.WriteLine("ConditionResult: " + ruleActionTrackingEvent.ConditionResult.ToString())
        End Sub
        ' </snippet293>
        Sub container1()

            ' <snippet294>
            Me.CanModifyActivities = True
            Dim rulesetreference1 As System.Workflow.Activities.Rules.RuleSetReference = New System.Workflow.Activities.Rules.RuleSetReference
            Me.simpleDiscountPolicy = New System.Workflow.Activities.PolicyActivity
            ' 
            ' simpleDiscountPolicy
            ' 
            Me.simpleDiscountPolicy.Name = "simpleDiscountPolicy"
            rulesetreference1.RuleSetName = "DiscountRuleSet"
            Me.simpleDiscountPolicy.RuleSetReference = rulesetreference1
            ' 
            ' SimplePolicyWorkflow
            ' 
            Me.Activities.Add(Me.simpleDiscountPolicy)
            Me.Name = "SimplePolicyWorkflow"
            AddHandler Completed, AddressOf Me.OnWorkflowCompleted
            Me.CanModifyActivities = False
            ' </snippet294>
        End Sub

        Private WithEvents discountPolicy As System.Workflow.Activities.PolicyActivity
        Private WithEvents simpleDiscountPolicy As System.Workflow.Activities.PolicyActivity
    End Class

    '*************************
    '* Snippets from Tracking/SimpleTrackingSample
    '*/

    Class Snippets36
        Sub container1()
            Dim WorkflowRuntime As New WorkflowRuntime()
            '<snippet295>
            Dim workflowInstance As WorkflowInstance = WorkflowRuntime.CreateWorkflow(GetType(SimpleTrackingWorkflow))
            Dim instanceId As Guid = WorkflowInstance.InstanceId
            '</snippet295>
        End Sub
        Class SimpleTrackingWorkflow

        End Class
    End Class

    '**********************************************
    ' Snippets from SqlDataMaintenance
    '***************************************

    Class Snippets37
        Friend Const connectionString As String = "Initial Catalog=TrackingData Source=localhostIntegrated Security=SSPI"

        ' <snippet296>
        Friend Shared Sub SetPartitionInterval(ByVal interval As Char)
            ' Valid values are 'd' (daily), 'm' (monthly), and 'y' (yearly).  The default is 'm'.
            Using Command As New SqlCommand("dbo.SetPartitionInterval")
                Command.CommandType = CommandType.StoredProcedure
                Command.Connection = New SqlConnection(connectionString)

                Dim intervalParameter As New SqlParameter("@Interval", SqlDbType.Char)
                intervalParameter.SqlValue = interval
                Command.Parameters.Add(intervalParameter)

                Command.Connection.Open()
                Command.ExecuteNonQuery()

            End Using

        End Sub
        ' </snippet296>
    End Class
End Namespace
