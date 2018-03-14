Imports System

Imports System.Collections.ObjectModel
Imports System.Workflow.Activities
Imports System.Workflow.ComponentModel
Imports System.Workflow.Runtime
Imports System.Workflow.ComponentModel.Serialization
Imports System.Workflow.ComponentModel.Compiler
Imports System.Windows.Forms
Imports System.Xml
Imports System.IO
Imports System.ComponentModel.Design
Imports System.Workflow.ComponentModel.Design
Imports System.Drawing
Imports System.Workflow.Runtime.Tracking
Imports System.Threading
Imports System.Collections.Specialized
Imports System.Diagnostics
Imports System.Text
Imports System.ComponentModel.Design.Serialization
Imports System.Drawing.Design
Imports System.Collections.Generic
Imports System.Globalization
Imports System.ComponentModel

Namespace WF_Snippets

    'Snippets1.cs:  New home for snippets taken from Workflow Application Samples for Windows Workflow Foundation API pages
    '
    ' * Snippets from OrderingStateMachine
    ' */

    Class snippets1


        Private handleExternalEventActivity1 As HandleExternalEventActivity
        Private setOrderOpenState As SetStateActivity
        Dim activitybind1 As New System.Workflow.ComponentModel.ActivityBind()


        Dim runtime As WorkflowRuntime
        Private Sub StartWorkflowRuntime()
            Dim orderService As OrderService
            '<snippet81>
            ' Create a new Workflow Runtime for me application
            runtime = New WorkflowRuntime()
            '</snippet81>
            ' Create EventHandlers for the WorkflowRuntime
            
            '<snippet82>
            ' Add the External Data Exchange Service
            Dim dataExchangeService As New ExternalDataExchangeService()
            runtime.AddService(dataExchangeService)

            ' Add a new instance of the OrderService to the External Data Exchange Service
            orderService = New OrderService()
            dataExchangeService.AddService(orderService)
            '</snippet82>

            ' Start the Workflow services
            runtime.StartRuntime()
        End Sub

        Public Class OrderService

        End Class
        Sub Runtime_WorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)

        End Sub



        Sub Runtime_WorkflowTerminated(ByVal sender As Object, ByVal e As WorkflowTerminatedEventArgs)

        End Sub


        Sub Runtime_WorkflowIdled(ByVal sender As Object, ByVal e As WorkflowEventArgs)

        End Sub



        Public Class Workflow1
            Inherits SequentialWorkflowActivity
        End Class


        Sub Container1()

            Dim workflowType As Type = GetType(Workflow1)
            Dim instance As WorkflowInstance = runtime.CreateWorkflow(workflowType)

            '<snippet83>
            Dim stateMachineInstance As New StateMachineWorkflowInstance(runtime, instance.InstanceId)
            '</snippet83>
            '<snippet84>
            instance.Start()
            '</snippet84>

            '<snippet85>
            Dim subActivities As ReadOnlyCollection(Of WorkflowQueueInfo) = stateMachineInstance.WorkflowInstance.GetWorkflowQueueData()
            '</snippet85>

            '<snippet86>
            ' Get a reference to the root activity for the workflow
            Dim root As Activity = instance.GetWorkflowDefinition()
            '</snippet86>

            '<snippet87>
            '<snippet88>
            ' Create a new instance of the WorkflowChanges class for managing
            ' the in-memory changes to the workflow
            Dim changes As New WorkflowChanges(root)
            '</snippet87>

            ' Create a new State activity to the workflow
            Dim orderOnHoldState As New StateActivity()
            orderOnHoldState.Name = "OrderOnHoldState"

            ' Add a new EventDriven activity to the State
            Dim eventDrivenDelay As New EventDrivenActivity()
            eventDrivenDelay.Name = "DelayOrderEvent"
            orderOnHoldState.Activities.Add(eventDrivenDelay)

            ' Add a new Delay, initialized to 5 seconds
            Dim delayOrder As New DelayActivity()
            delayOrder.Name = "delayOrder"
            delayOrder.TimeoutDuration = New TimeSpan(0, 0, 5)
            eventDrivenDelay.Activities.Add(delayOrder)

            ' Add a new SetState to the OrderOpenState
            Dim setStateOrderOpen As New SetStateActivity()
            setStateOrderOpen.TargetStateName = "OrderOpenState"
            eventDrivenDelay.Activities.Add(setStateOrderOpen)

            ' Add the OnHoldState to the workflow
            changes.TransientWorkflow.Activities.Add(orderOnHoldState)
            '</snippet88>

            '<snippet89>
            ' Apply the changes to the workflow instance
            Try
                instance.ApplyWorkflowChanges(changes)
            Catch e As WorkflowValidationFailedException
                ' New state has already been added
                MessageBox.Show("On Hold state has already been added to this workflow.")
            End Try
            '</snippet89>

            '<snippet90>
            Dim workflowparameterbinding1 As New System.Workflow.ComponentModel.WorkflowParameterBinding()
            '</snippet90>

            '<snippet91>
            Me.handleExternalEventActivity1 = New System.Workflow.Activities.HandleExternalEventActivity()
            '</snippet91>

            '<snippet92>
            Me.setOrderOpenState = New System.Workflow.Activities.SetStateActivity()
            '</snippet92>

            '<snippet93>
            Me.handleExternalEventActivity1.InterfaceType = GetType(IOrderService)
            '</snippet93>

            '<snippet94>
            workflowparameterbinding1.ParameterName = "sender"
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, (CType(activitybind1, System.Workflow.ComponentModel.ActivityBind)))
            Me.handleExternalEventActivity1.ParameterBindings.Add(workflowparameterbinding1)
            '</snippet94>

        End Sub
    End Class

    '<snippet96>
    <Serializable()> _
Public Class OrderEventArgs
        Inherits ExternalDataEventArgs

        Private orderIdValue As String

        Public Sub New(ByVal instanceId As Guid, ByVal orderId As String)
            MyBase.New(instanceId)
            orderIdValue = orderId
        End Sub

        Public Property OrderId() As String
            Get
                Return orderIdValue
            End Get
            Set(ByVal value As String)
                orderIdValue = value
            End Set
        End Property
    End Class
    '</snippet96>

    '*****************
    '* Snippets from OutlookWorkflowWizard
    '*/

    Public Class snippets2

        Dim xamlFile As String = ""
        Sub Container2()

            Dim xamlFile As String = String.Empty
            Dim service As New Activity()
            Using writer As XmlWriter = XmlWriter.Create(Me.xamlFile)

                ' <snippet97>
                Dim xamlSerializer As New WorkflowMarkupSerializer()
                xamlSerializer.Serialize(writer, service)
                ' </snippet97>
            End Using
        End Sub
    End Class



    Partial Public Class AutoReplyEmail
        Inherits Activity

        'Stub of Outlook so I don't have to import it
        Class Outlook
            Public Class Application
                Public Function CreateItem(ByVal item As String) As _MailItem
                    Return New _MailItem()
                End Function
           

                Public Class SessionClass
                    Public CurrentUser As CurrentUserClass
                End Class


                Public Class CurrentUserClass

                    Public Address As String
                End Class
                Public Session As SessionClass
            End Class



            Public Class _MailItem
                Public MailTo As String
                Public Subject As String
                Public Body As String
                Public Sub Send()
                End Sub
            End Class

            Public Class OlItemType

                Public Shared olMailItem As String

            End Class
        End Class


        '<snippet98>
        Protected Overrides Function Execute(ByVal executionContext As System.Workflow.ComponentModel.ActivityExecutionContext) As System.Workflow.ComponentModel.ActivityExecutionStatus
            ' Create an Outlook Application object. 
            Dim outlookApp As Outlook.Application = New Outlook.Application()

            Dim oMailItem As Outlook._MailItem = CType(outlookApp.CreateItem(Outlook.OlItemType.olMailItem), Outlook._MailItem)
            oMailItem.MailTo = outlookApp.Session.CurrentUser.Address
            oMailItem.Subject = "Auto-Reply"
            oMailItem.Body = "Out of Office"

            Dim dummy As Activity

            If TypeOf Me.Parent.Parent Is ParallelActivity Then
                dummy = Me.Parent.Parent.Parent.Activities.Item(1)
                If Not (CType(dummy, DummyActivity).Title = "") Then
                    MessageBox.Show("Process Auto-Reply for Email")
                    oMailItem.Send()
                End If
            End If
            If TypeOf Me.Parent.Parent Is SequentialWorkflowActivity Then
                dummy = Me.Parent.Parent.Activities.Item(1)
                If Not (CType(dummy, DummyActivity).Title = "") Then
                    MessageBox.Show("Process Auto-Reply for Email")
                    oMailItem.Send()
                End If
            End If

            Return ActivityExecutionStatus.Closed
        End Function
        '</snippet98>
        Public Class DummyActivity
            Inherits Activity
            Public Title As String
        End Class

        Dim xamlFile As String = ""
        Dim results As WorkflowCompilerResults
        Sub Container2()

            ' <snippet99>
            ' Compile the workflow
            Dim assemblyNames() As String = {"ReadEmailActivity.dll"}

            Dim compiler As WorkflowCompiler = New WorkflowCompiler()
            Dim parameters As WorkflowCompilerParameters = New WorkflowCompilerParameters(assemblyNames)
            parameters.LibraryPaths.Add(Path.GetDirectoryName(GetType(BaseMailbox).Assembly.Location))
            parameters.OutputAssembly = "CustomOutlookWorkflow" + Guid.NewGuid().ToString() + ".dll"
            results = compiler.Compile(parameters, Me.xamlFile)
            ' </snippet99>
        End Sub
        Public Class BaseMailbox
        End Class
        Sub Container3()

            '<snippet100>
            ' Start the runtime engine
            Dim workflowRuntime As WorkflowRuntime = New WorkflowRuntime()
            workflowRuntime.StartRuntime()
            '</snippet100>
            ' Add workflow event handlers
            AddHandler workflowRuntime.WorkflowCompleted, AddressOf OnWorkflowCompleted
            '<snippet101>
            ' Start the workflow
            workflowRuntime.CreateWorkflow(results.CompiledAssembly.GetType(Me.GetType().Namespace + ".CustomOutlookWorkflow")).Start()
            '</snippet101>
        End Sub

        Private Sub OnWorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)

        End Sub
    End Class

    Public Class WorkflowViewWrapper
        Inherits System.Windows.Forms.Panel

        Private loaderValue As Loader
        Private surface As DesignSurface
        Friend Host As IDesignerHost
        Friend SequentialWorkflow As SequentialWorkflowActivity
        Private workflowView As WorkflowView

        ' <snippet102>
        Public Sub New()

            ' <snippet103>
            Me.loaderValue = New Loader()

            ' Create a Workflow Design Surface
            Me.surface = New DesignSurface()
            Me.surface.BeginLoad(Me.loaderValue)

            ' Get the Workflow Designer Host
            If Me.surface.GetService(GetType(IDesignerHost)) IsNot Nothing AndAlso TypeOf Me.surface.GetService(GetType(IDesignerHost)) Is IDesignerHost Then
                Me.Host = CType(Me.surface.GetService(GetType(IDesignerHost)), IDesignerHost)
            Else
                Return
            End If

            ' Create a Sequential Workflow by using the Workflow Designer Host
            SequentialWorkflow = CType(Host.CreateComponent(GetType(SequentialWorkflowActivity)), SequentialWorkflowActivity)
            SequentialWorkflow.Name = "CustomOutlookWorkflow"

            ' Create a Workflow View on the Workflow Design Surface
            Me.workflowView = New WorkflowView(CType(Me.surface, IServiceProvider))
            ' </snippet103>

            ' Add a message filter to the workflow view, to support panning
            Dim filter As MessageFilter = New MessageFilter(CType(Me.surface, IServiceProvider), Me.workflowView)
            Me.workflowView.AddDesignerMessageFilter(filter)

            ' Activate the Workflow View
            Me.Host.Activate()

            Me.workflowView.Dock = DockStyle.Fill
            Me.Controls.Add(workflowView)
            Me.Dock = DockStyle.Fill
        End Sub

        ' </snippet102>
        Public Class Loader
            Inherits WorkflowDesignerLoader

            Public Overrides Function GetFileReader(ByVal filePath As String) As System.IO.TextReader
                Return Nothing
            End Function

            Public Overrides Function GetFileWriter(ByVal filePath As String) As System.IO.TextWriter
                Return Nothing
            End Function

            Public Overrides ReadOnly Property FileName() As String
                Get
                    Return Nothing
                End Get
            End Property
        End Class
        ' <snippet104>
        Friend Class MessageFilter
            Inherits WorkflowDesignerMessageFilter

            Private mouseDown As Boolean
            Private serviceProvider As IServiceProvider
            Private workflowView As WorkflowView

            Public Sub New(ByVal provider As IServiceProvider, ByVal view As WorkflowView)
                Me.serviceProvider = provider
                Me.workflowView = view
            End Sub

            Protected Overrides Function OnMouseDown(ByVal eventArgs As System.Windows.Forms.MouseEventArgs) As Boolean
                ' Allow other components to process this event by not returning true.
                Me.mouseDown = True
                Return False
            End Function
            '<snippet105>
            Protected Overrides Function OnMouseMove(ByVal eventArgs As System.Windows.Forms.MouseEventArgs) As Boolean
                ' Allow other components to process this event by not returning true.
                If (Me.mouseDown) Then
                    Me.workflowView.ScrollPosition = New Point(eventArgs.X, eventArgs.Y)
                End If
                Return False
            End Function
            '</snippet105>
            Protected Overrides Function OnMouseUp(ByVal eventArgs As System.Windows.Forms.MouseEventArgs) As Boolean
                ' Allow other components to process this event by not returning true.
                Me.mouseDown = False
                Return False
            End Function

            Protected Overrides Function OnMouseDoubleClick(ByVal eventArgs As System.Windows.Forms.MouseEventArgs) As Boolean
                Me.mouseDown = False
                Return True
            End Function

            Protected Overrides Function OnMouseEnter(ByVal eventArgs As System.Windows.Forms.MouseEventArgs) As Boolean
                ' Allow other components to process this event by not returning true.
                Me.mouseDown = False
                Return False
            End Function

            Protected Overrides Function OnMouseHover(ByVal eventArgs As System.Windows.Forms.MouseEventArgs) As Boolean
                ' Allow other components to process this event by not returning true.
                Me.mouseDown = False
                Return False
            End Function

            Protected Overrides Function OnMouseLeave() As Boolean
                ' Allow other components to process this event by not returning true.
                Me.mouseDown = False
                Return False
            End Function

            Protected Overrides Function OnMouseWheel(ByVal eventArgs As System.Windows.Forms.MouseEventArgs) As Boolean
                Me.mouseDown = False
                Return True
            End Function

            Protected Overrides Function OnMouseCaptureChanged() As Boolean
                ' Allow other components to process this event by not returning true.
                Me.mouseDown = False
                Return False
            End Function

            Protected Overrides Function OnDragEnter(ByVal eventArgs As System.Windows.Forms.DragEventArgs) As Boolean
                Return True
            End Function

            Protected Overrides Function OnDragOver(ByVal eventArgs As System.Windows.Forms.DragEventArgs) As Boolean
                Return True
            End Function

            Protected Overrides Function OnDragLeave() As Boolean
                Return True
            End Function

            Protected Overrides Function OnDragDrop(ByVal eventArgs As System.Windows.Forms.DragEventArgs) As Boolean
                Return True
            End Function

            Protected Overrides Function OnGiveFeedback(ByVal eventArgs As System.Windows.Forms.GiveFeedbackEventArgs) As Boolean
                Return True
            End Function

            Protected Overrides Function OnQueryContinueDrag(ByVal eventArgs As System.Windows.Forms.QueryContinueDragEventArgs) As Boolean
                Return True
            End Function

            Protected Overrides Function OnKeyUp(ByVal eventArgs As System.Windows.Forms.KeyEventArgs) As Boolean
                Return True
            End Function

            Protected Overrides Function OnShowContextMenu(ByVal screenMenuPoint As System.Drawing.Point) As Boolean
                Return True
            End Function

            Protected Overrides Function OnKeyDown(ByVal eventArgs As System.Windows.Forms.KeyEventArgs) As Boolean
                If eventArgs.KeyCode = Keys.Delete Then
                    Dim selectionService As ISelectionService = CType(Me.serviceProvider.GetService(GetType(ISelectionService)), ISelectionService)
                    If selectionService IsNot Nothing AndAlso TypeOf selectionService.PrimarySelection Is CodeActivity Then
                        Dim codeActivityComponent As CodeActivity = CType(selectionService.PrimarySelection, CodeActivity)
                        Dim parentActivity As CompositeActivity = codeActivityComponent.Parent
                        If parentActivity IsNot Nothing Then
                            parentActivity.Activities.Remove(codeActivityComponent)
                            Me.ParentView.Update()
                        End If
                    End If
                End If
                Return True
            End Function
        End Class
        ' </snippet104>
        'End Message Filter
    End Class 'WorkflowViewWrapper

    '*******************
    '* Snippets from SpeechApplication
    '*/

    Class Snippets3

        Public Class SpeechApplication
            Public Class ISpeechService
            End Class
        End Class

        Private sequentialSubMenu_SendSequentialTextToMenu As New CallExternalMethodActivity()
        Dim workflowRuntime As New WorkflowRuntime()
        Sub Container1()

            '<snippet106>
            ' Create EventHandlers for the WorkflowRuntime
            AddHandler workflowRuntime.WorkflowTerminated, AddressOf WorkflowRuntime_WorkflowTerminated
            '</snippet106>

            '<snippet107>
            ' Add an instance of the External Data Exchange Service
            Dim externalDataExchange As New ExternalDataExchangeService()
            workflowRuntime.AddService(externalDataExchange)
            '</snippet107>
        End Sub
        '<snippet108>
        Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
            Me.workflowRuntime.Dispose()
        End Sub
        '</snippet108>
        Sub Container2()

            '<snippet109>
            Me.sequentialSubMenu_SendSequentialTextToMenu.InterfaceType = GetType(SpeechApplication.ISpeechService)
            '</snippet109>
            '<snippet110>
            Me.sequentialSubMenu_SendSequentialTextToMenu.MethodName = "SendMenuText"
            '</snippet110>
        End Sub
        Public Sub WorkflowRuntime_WorkflowTerminated(ByVal sender As Object, ByVal e As WorkflowTerminatedEventArgs)
        End Sub

    End Class

    '**********************
    '* Snippets from TerminationTrackingService
    '*/

    Class Snippets4

        Sub WorkflowRuntime_WorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)

        End Sub
        Sub WorkflowRuntime_WorkflowTerminated(ByVal sender As Object, ByVal e As WorkflowTerminatedEventArgs)

        End Sub
        Const eventSource As String = "TerminationTrackingService"
        Sub Container1()

            '<snippet111>
            Using workflowRuntime As New WorkflowRuntime()

                Dim waitHandle As New AutoResetEvent(False)
                Dim parameters As New NameValueCollection()
                parameters.Add("EventSource", eventSource)

                workflowRuntime.AddService(New TerminationTrackingService(parameters))
                AddHandler workflowRuntime.WorkflowCompleted, AddressOf WorkflowRuntime_WorkflowCompleted
                AddHandler workflowRuntime.WorkflowTerminated, AddressOf WorkflowRuntime_WorkflowTerminated

                Dim instance As WorkflowInstance = workflowRuntime.CreateWorkflow(GetType(SampleWorkflow))
                instance.Start()

                waitHandle.WaitOne()
            End Using
            '</snippet111>
        End Sub
    End Class



    Class TerminationTrackingService
        Inherits TrackingService

        Const source As String = "TerminationTrackingService"
        Public Sub New(ByVal parameters As NameValueCollection)

        End Sub
        Private Sub ValidateEventLogSource(ByVal source As String)

        End Sub

        '<snippet112>
        Protected Overrides Sub Start()
            MyBase.Start()
            '
            ' This will throw if we are invalid to inform the host immediately
            ValidateEventLogSource(source)
        End Sub
        '</snippet112>

        '<snippet113>
        ' <summary>
        ' Returns a tracking channel that will receive instnce terminated events.
        ' </summary>
        Protected Overrides Function GetTrackingChannel(ByVal parameters As TrackingParameters) As TrackingChannel
            Return New TerminationTrackingChannel(parameters, source)
        End Function
        '</snippet113>

        '<snippet114>
        ' <summary>
        ' Returns a Shared tracking profile that only tracks instance terminated events.
        ' </summary>
        Protected Overrides Function TryGetProfile(ByVal workflowType As Type, ByRef profile As TrackingProfile) As Boolean
            profile = GetProfile()
            Return True
        End Function
        '</snippet114>

        '<snippet115>
        '/ <summary>
        '/ Returns a Shared tracking profile that only tracks instance terminated events.
        '/ </summary>
        Protected Overrides Function GetProfile(ByVal workflowInstanceId As Guid) As TrackingProfile
            Return GetProfile()
        End Function

        Private Shared profile As TrackingProfile = Nothing
        Private sourceExists As Boolean = False
        Private Overloads Function GetProfile() As TrackingProfile

            '
            ' We shouldn't hit me point without the host ignoring an earlier exception.
            ' However if we're here and the source doesn't exist we can't function.
            ' Throwing an exception from here will block instance creation
            ' but that is better than failing silently on termination 
            ' and having the admin think everything is OK because the event log is clear.
            If Not sourceExists Then
                Throw New InvalidOperationException(String.Format(System.Globalization.CultureInfo.InvariantCulture, "EventLog Source with the name '0}' does not exist", source))
            End If
            '
            ' The profile for me instance will never change
            If profile Is Nothing Then

                SyncLock (GetType(TerminationTrackingService))

                    If profile Is Nothing Then

                        profile = New TrackingProfile()
                        profile.Version = New Version("3.0.0.0")
                        Dim point As New WorkflowTrackPoint()
                        point.MatchingLocation = New WorkflowTrackingLocation()
                        point.MatchingLocation.Events.Add(TrackingWorkflowEvent.Terminated)
                        profile.WorkflowTrackPoints.Add(point)
                    End If
                End SyncLock

            End If

            Return profile
        End Function
        '</snippet115>
        '<snippet116>
        ' <summary>
        ' Always returns false me tracking service has no need to reload its tracking profile for a running instance.
        ' </summary>
        ' <param name="workflowType"></param>
        ' <param name="workflowInstanceId"></param>
        ' <param name="profile"></param>
        ' <returns></returns>
        Protected Overrides Function TryReloadProfile(ByVal workflowType As Type, ByVal workflowInstanceId As Guid, ByRef profile As TrackingProfile) As Boolean
            '
            ' There is no reason for me service to ever reload a profile
            profile = Nothing
            Return False
        End Function
        '</snippet116>


        Protected Overrides Function GetProfile(ByVal workflowType As Type, ByVal profileVersionId As Version) As TrackingProfile
            Throw New Exception("The method or operation is not implemented.")
        End Function
    End Class

    Public Class TerminationTrackingChannel
        Inherits TrackingChannel
        Public Sub New(ByVal parameters As TrackingParameters, ByVal source As String)

        End Sub
        Private sourceValue As String = Nothing
        Private parametersValue As TrackingParameters = Nothing
        '<snippet117>
        '/ <summary>
        '/ Receives tracking events.  Instance terminated events are written to the event log.
        '/ </summary>
        Protected Overrides Sub Send(ByVal record As TrackingRecord)

            Dim instanceTrackingRecord As WorkflowTrackingRecord = CType(record, WorkflowTrackingRecord)

            If instanceTrackingRecord Is Nothing Or Not TrackingWorkflowEvent.Terminated = instanceTrackingRecord.TrackingWorkflowEvent Then
                Return
            End If

            ' Create an EventLog instance and assign its source.
            Dim log As New EventLog()
            log.Source = sourceValue

            ' Write an informational entry to the event log.  
            Dim terminatedEventArgs As TrackingWorkflowTerminatedEventArgs = CType(instanceTrackingRecord.EventArgs, TrackingWorkflowTerminatedEventArgs)

            Dim Message As New StringBuilder(512)
            Message.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture, "Workflow instance 0} has been terminated.", parametersValue.InstanceId.ToString()))
            Message.AppendLine()

            If terminatedEventArgs.Exception Is Nothing Then
                Message.AppendLine(terminatedEventArgs.Exception.ToString())
            End If


            log.WriteEntry(Message.ToString(), EventLogEntryType.Warning)
        End Sub
        '</snippet117>


        Protected Overrides Sub InstanceCompletedOrTerminated()
            Throw New Exception("The method or operation is not implemented.")
        End Sub

        '<snippet118>
        Private Sub Track_ExecuteCode(ByVal sender As Object, ByVal e As EventArgs)

            Console.WriteLine("Calling TrackData from workflow")
            Me.TrackData("Hello - me is a UserTrackPoint")
        End Sub
        '</snippet118>
        Private Sub TrackData(ByVal p As String)

            Throw New Exception("The method or operation is not implemented.")
        End Sub
    End Class

    '********************
    '* Snippets from TrackingProfileDesigner
    ' * *****************/

    Class Resources
        Public Shared errorIcon As New Bitmap(0, 0)

    End Class
    '<snippet119>
    ' <summary>
    ' This glyph shows that the activity's track point is not correctly configured
    ' </summary>
    Friend NotInheritable Class ErrorActivityGlyph
        Inherits DesignerGlyph

        Shared image As Bitmap = Resources.errorIcon
        Dim errorMessage As String

        Friend Sub New(ByVal errorMessage As String)
            Me.errorMessage = errorMessage
        End Sub

        Public Overrides ReadOnly Property CanBeActivated() As Boolean
            Get
                Return True
            End Get
        End Property

        ' Display an error message when this glyph is clicked
        Protected Overrides Sub OnActivate(ByVal designer As ActivityDesigner)
            MessageBox.Show(errorMessage)
        End Sub

        Public Overrides Function GetBounds(ByVal designer As ActivityDesigner, ByVal activated As Boolean) As Rectangle
            Dim imageBounds As New Rectangle()
            If image IsNot Nothing Then
                imageBounds.Size = image.Size
                imageBounds.Location = New Point(designer.Bounds.Right - imageBounds.Size.Width / 4, designer.Bounds.Top - imageBounds.Size.Height / 2)
            End If
            Return imageBounds
        End Function


        Protected Overrides Sub OnPaint(ByVal graphics As Graphics, ByVal activated As Boolean, ByVal ambientTheme As AmbientTheme, ByVal designer As ActivityDesigner)
            image.MakeTransparent(Color.FromArgb(255, 255, 255))
            If image IsNot Nothing Then
                graphics.DrawImage(image, GetBounds(designer, activated), New Rectangle(Point.Empty, image.Size), GraphicsUnit.Pixel)
            End If
        End Sub
    End Class
    '</snippet119>

    Public Class Snippets6

        '<snippet120>
        ' <summary>
        ' Saves a tracking condition for an activity
        ' </summary>
        ' <param name="activity"></param>
        ' <param name="key"></param>
        ' <param name="member"></param>
        ' <param name="op"></param>
        ' <param name="value"></param>
        Friend Sub SaveTrackingCondition(ByVal activity As Activity, ByRef key As ActivityTrackingCondition, ByVal member As String, ByVal op As ComparisonOperator, ByVal value As String)
            Dim trackPoint As ActivityTrackPoint = GetTrackPointForActivity(activity)
            If trackPoint IsNot Nothing Then
                If (key Is Nothing) Then
                    key = New ActivityTrackingCondition()
                    trackPoint.MatchingLocations(0).Conditions.Add(key)
                End If
                key.Member = member
                key.Value = value
                key.Operator = op
            End If
        End Sub
        '</snippet120>
        Private Function GetTrackPointForActivity(ByVal activity As Activity) As ActivityTrackPoint
            Throw New Exception("The method or operation is not implemented.")
        End Function
    End Class
    Friend NotInheritable Class Snippets7
        Inherits WorkflowDesignerLoader
        '<snippet121>
        Public Overrides Sub Dispose()
            Try
                Dim host As IDesignerLoaderHost = LoaderHost
                If host IsNot Nothing Then
                    host.RemoveService(GetType(IIdentifierCreationService))
                    host.RemoveService(GetType(IMenuCommandService))
                    host.RemoveService(GetType(IToolboxService))
                    host.RemoveService(GetType(ITypeProvider), True)
                    host.RemoveService(GetType(IWorkflowCompilerOptionsService))
                    host.RemoveService(GetType(IEventBindingService))
                End If
            Finally
                MyBase.Dispose()
            End Try
        End Sub
        '</snippet121>
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

    Friend Class Snippets8
        Implements IWorkflowCompilerOptionsService

        '<snippet122>
        Public ReadOnly Property RootNamespace() As String Implements IWorkflowCompilerOptionsService.RootNamespace
            Get
                Return String.Empty
            End Get
        End Property
        '</snippet122>

        '<snippet123>
        Public ReadOnly Property Language() As String Implements IWorkflowCompilerOptionsService.Language
            Get
                Return "VisualBasic"
            End Get
        End Property
        '</snippet123>
        Public ReadOnly Property CheckTypes() As Boolean Implements IWorkflowCompilerOptionsService.CheckTypes
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property
    End Class
    Public Class WorkflowDesignerControl

        '<snippet124>
        ' <snippet125>
        Public Sub New()
            InitializeComponent()

            WorkflowTheme.CurrentTheme.ReadOnly = False
            WorkflowTheme.CurrentTheme.AmbientTheme.ShowConfigErrors = False
            WorkflowTheme.CurrentTheme.ReadOnly = True
        End Sub
        ' </snippet125>
        '</snippet124>
        Private Sub InitializeComponent()
            Throw New Exception("The method or operation is not implemented.")
        End Sub

        Dim workflowView As WorkflowView
        Dim designSurface As New DesignSurface
        Dim loader As New WorkflowLoader()
        Private WithEvents panel1 As New System.Windows.Forms.Panel()

        Sub container1()
            ' <snippet126>
            Dim designerHost As IDesignerHost = CType(designSurface.GetService(GetType(IDesignerHost)), IDesignerHost)
            If designerHost IsNot Nothing AndAlso designerHost.RootComponent IsNot Nothing Then
                Dim rootDesigner As IRootDesigner = TryCast(designerHost.GetDesigner(designerHost.RootComponent), IRootDesigner)
                If rootDesigner IsNot Nothing Then
                    UnloadWorkflow()
                    Me.designSurface = designSurface
                    Me.loader = loader
                    Me.workflowView = TryCast(rootDesigner.GetView(ViewTechnology.Default), WorkflowView)
                    Me.panel1.Controls.Add(Me.workflowView)
                    Me.workflowView.Dock = DockStyle.Fill
                    Me.workflowView.TabIndex = 1
                    Me.workflowView.TabStop = True
                    Me.workflowView.HScrollBar.TabStop = False
                    Me.workflowView.VScrollBar.TabStop = False
                    Me.workflowView.Focus()
                    Me.workflowView.FitToScreenSize()
                End If
            End If
            ' </snippet126>
        End Sub
        Class WorkflowLoader

        End Class
        Private Sub UnloadWorkflow()

            Throw New Exception("The method or operation is not implemented.")
        End Sub
    End Class

    '*****************
    '* * WorkflowMonitor snippets
    '*/

    Class Snippets9

        Private connectionString As String = ""
        ' <snippet127>
        Friend Function GetWorkflows( _
            ByVal workflowEvent As String, _
            ByVal from As System.DateTime, _
            ByVal until As DateTime, _
            ByVal trackingDataItemValue As TrackingDataItemValue) _
            As List(Of SqlTrackingWorkflowInstance)
            '<snippet_128>
            Try
                Dim queriedWorkflows As List(Of SqlTrackingWorkflowInstance) = New List(Of SqlTrackingWorkflowInstance)()
                Dim sqlTrackingQuery As SqlTrackingQuery = New SqlTrackingQuery(connectionString)
                Dim sqlTrackingQueryOptions As SqlTrackingQueryOptions = New SqlTrackingQueryOptions()
                sqlTrackingQueryOptions.StatusMinDateTime = from.ToUniversalTime()
                sqlTrackingQueryOptions.StatusMaxDateTime = until.ToUniversalTime()
                ' If QualifiedName, FieldName, or DataValue is not supplied, we will not query since they are all required to match
                If (Not ((trackingDataItemValue.QualifiedName = String.Empty) Or (trackingDataItemValue.FieldName = String.Empty) Or ((trackingDataItemValue.DataValue = String.Empty)))) Then
                    sqlTrackingQueryOptions.TrackingDataItems.Add(trackingDataItemValue)
                End If

                queriedWorkflows.Clear()
                If (workflowEvent.ToLower(CultureInfo.InvariantCulture) = "created") Then
                    sqlTrackingQueryOptions.WorkflowStatus = System.Workflow.Runtime.WorkflowStatus.Created
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions))
                ElseIf (workflowEvent.ToLower(CultureInfo.InvariantCulture) = "completed") Then
                    sqlTrackingQueryOptions.WorkflowStatus = System.Workflow.Runtime.WorkflowStatus.Completed
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions))
                ElseIf (workflowEvent.ToLower(CultureInfo.InvariantCulture) = "running") Then
                    sqlTrackingQueryOptions.WorkflowStatus = System.Workflow.Runtime.WorkflowStatus.Running
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions))
                ElseIf (workflowEvent.ToLower(CultureInfo.InvariantCulture) = "suspended") Then
                    sqlTrackingQueryOptions.WorkflowStatus = System.Workflow.Runtime.WorkflowStatus.Suspended
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions))
                ElseIf (workflowEvent.ToLower(CultureInfo.InvariantCulture) = "terminated") Then
                    sqlTrackingQueryOptions.WorkflowStatus = System.Workflow.Runtime.WorkflowStatus.Terminated
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions))
                ElseIf ((workflowEvent = Nothing) Or _
                        (workflowEvent.ToLower(CultureInfo.InvariantCulture) = "all") Or _
                        (workflowEvent = String.Empty)) Then
                    sqlTrackingQueryOptions.WorkflowStatus = System.Workflow.Runtime.WorkflowStatus.Created
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions))

                    sqlTrackingQueryOptions.WorkflowStatus = System.Workflow.Runtime.WorkflowStatus.Completed
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions))

                    sqlTrackingQueryOptions.WorkflowStatus = System.Workflow.Runtime.WorkflowStatus.Running
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions))

                    sqlTrackingQueryOptions.WorkflowStatus = System.Workflow.Runtime.WorkflowStatus.Suspended
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions))

                    sqlTrackingQueryOptions.WorkflowStatus = System.Workflow.Runtime.WorkflowStatus.Terminated
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions))

                End If

                Return queriedWorkflows

            Catch exception As Exception
                'Dim errorMessage As String = "Exception in GetWorkflows" + vbCrLf + "Database: " + databaseName + vbCrLf + "Server: " + serverName
                Throw (New Exception("Exception in GetWorkflows", exception))
            End Try
            '</snippet_128>
        End Function
        ' </snippet127>

        ' <snippet129>
        Friend Function TryGetWorkflow(ByVal workflowInstanceId As Guid, ByVal sqlTrackingWorkflowInstance As SqlTrackingWorkflowInstance) As Boolean
            Dim SqlTrackingQuery As New SqlTrackingQuery(connectionString)
            Return SqlTrackingQuery.TryGetWorkflow(workflowInstanceId, sqlTrackingWorkflowInstance)
        End Function
        ' </snippet129>
    End Class
    ' <snippet130>
    'Custom glyphprovider used to draw the monitor glyphs on the designer surface
    Friend Class WorkflowMonitorDesignerGlyphProvider
        Implements IDesignerGlyphProvider

        Dim activityStatusList As Dictionary(Of String, ActivityStatusInfo)

        Friend Sub New(ByVal activityStatusList As Dictionary(Of String, ActivityStatusInfo))
            Me.activityStatusList = activityStatusList
        End Sub
        ' <snippet131>
        Public Function GetGlyphs(ByVal activityDesigner As System.Workflow.ComponentModel.Design.ActivityDesigner) As System.Workflow.ComponentModel.Design.ActivityDesignerGlyphCollection Implements System.Workflow.ComponentModel.Design.IDesignerGlyphProvider.GetGlyphs
            Dim glyphList As ActivityDesignerGlyphCollection = New ActivityDesignerGlyphCollection()

            'Walk all of the activities and use the 'CompletedGlyph' for all activities that are not 'closed'
            For Each activityStatus As ActivityStatusInfo In activityStatusList.Values
                If activityStatus.Name = activityDesigner.Activity.Name Then
                    If activityStatus.Status = "Closed" Then
                        glyphList.Add(New CompletedGlyph())
                    Else
                        glyphList.Add(New ExecutingGlyph())
                    End If
                End If
            Next

            Return glyphList
        End Function
        ' </snippet131>
    End Class
    ' </snippet130>

    Friend Class AppResources
        Friend Shared Executing As New Bitmap(0, 0)
    End Class
    ' <snippet132>
    'Define a glyph to show an activity is executing, i.e. not 'closed'
    Friend Class ExecutingGlyph
        Inherits DesignerGlyph
        ' <snippet133>
        Public Overrides Function GetBounds(ByVal designer As System.Workflow.ComponentModel.Design.ActivityDesigner, ByVal activated As Boolean) As System.Drawing.Rectangle
            Dim imageBounds As Rectangle = Rectangle.Empty
            Dim image As Image = AppResources.Executing
            If Not image Is Nothing Then
                Dim glyphSize As Size = WorkflowTheme.CurrentTheme.AmbientTheme.GlyphSize
                imageBounds.Location = New Point(designer.Bounds.Right - glyphSize.Width / 2, designer.Bounds.Top - glyphSize.Height / 2)
                imageBounds.Size = glyphSize
            End If
            Return imageBounds
        End Function
        ' </snippet133>

        ' <snippet134>
        Protected Overrides Sub OnPaint(ByVal graphics As System.Drawing.Graphics, ByVal activated As Boolean, ByVal ambientTheme As System.Workflow.ComponentModel.Design.AmbientTheme, ByVal designer As System.Workflow.ComponentModel.Design.ActivityDesigner)
            Dim bitmap As Bitmap = AppResources.Executing
            bitmap.MakeTransparent(Color.FromArgb(0, 255, 255))

            If Not bitmap Is Nothing Then
                graphics.DrawImage(bitmap, GetBounds(designer, activated), New Rectangle(Point.Empty, bitmap.Size), GraphicsUnit.Pixel)
            End If
        End Sub
        ' </snippet134>
    End Class
    ' </snippet132>
    Friend Class ActivityStatusInfo

        Public Name As String = ""
        Public Status As String = ""
    End Class
    Friend Class CompletedGlyph
        Inherits DesignerGlyph
        Protected Overrides Sub OnPaint(ByVal graphics As System.Drawing.Graphics, ByVal activated As Boolean, ByVal ambientTheme As System.Workflow.ComponentModel.Design.AmbientTheme, ByVal designer As System.Workflow.ComponentModel.Design.ActivityDesigner)

            Throw New Exception("The method or operation is not implemented.")
        End Sub
    End Class

    Public Class Snippets10

        Private surface As WorkflowDesignSurface = Nothing
        Private parentValue As Mainform = New Mainform()
        ' <snippet135>
        Friend Sub Expand(ByVal expand As Boolean)
            Dim host As IDesignerHost = GetService(GetType(IDesignerHost))
            If host Is Nothing Then
                Return
            End If

            Me.SuspendLayout()

            Dim root As CompositeActivity = host.RootComponent
            Dim activity As Activity
            For Each activity In root.Activities
                Dim compositeActivityDesigner As CompositeActivityDesigner = host.GetDesigner(CType(activity, IComponent))
                If compositeActivityDesigner IsNot Nothing Then
                    compositeActivityDesigner.Expanded = expand
                End If
            Next

            Me.ResumeLayout(True)
        End Sub
        ' </snippet135>
        Private Function GetService(ByVal type As Type) As IDesignerHost

            Throw New Exception("The method or operation is not implemented.")
        End Function
        Private Sub SuspendLayout()

            Throw New Exception("The method or operation is not implemented.")
        End Sub
        Private Sub ResumeLayout(ByVal p As Boolean)

            Throw New Exception("The method or operation is not implemented.")
        End Sub
        Sub container1()

            Dim glyphService As IDesignerGlyphProviderService = CType(Me.surface.GetService(GetType(IDesignerGlyphProviderService)), IDesignerGlyphProviderService)
            Dim glyphProvider As WorkflowMonitorDesignerGlyphProvider = New WorkflowMonitorDesignerGlyphProvider(parentValue.ActivityStatusList)
            glyphService.AddGlyphProvider(glyphProvider)
        End Sub
        Friend NotInheritable Class WorkflowDesignSurface
            Inherits DesignSurface
        End Class
        Friend Class Mainform
            Inherits Form
            Private activityStatusListValue As Dictionary(Of String, ActivityStatusInfo) = Nothing
            Friend ReadOnly Property ActivityStatusList() As Dictionary(Of String, ActivityStatusInfo)
                Get
                    Return activityStatusListValue
                End Get
            End Property
        End Class

        Dim displayedWorkflows As List(Of SqlTrackingWorkflowInstance) = Nothing
        Private listViewWorkflows As New ListView()
        Private workflowStatusList As Dictionary(Of String, WorkflowStatusInfo) = Nothing
        Sub container2()

            ' <snippet137>
            ' For every workflow instance create a new WorkflowStatusInfo object and store in the workflowStatusList
            ' Also populate the workflow ListView
            ' For every workflow instance create a new WorkflowStatusInfo object and store in the workflowStatusList
            ' Also populate the workflow ListView
            For Each sqlTrackingWorkflowInstance As SqlTrackingWorkflowInstance In displayedWorkflows
                Dim listViewItem As ListViewItem = New ListViewItem(New String() { _
                    sqlTrackingWorkflowInstance.WorkflowInstanceInternalId.ToString(), _
                    sqlTrackingWorkflowInstance.WorkflowType.ToString(), _
                    sqlTrackingWorkflowInstance.Status.ToString()}, -1)

                listViewWorkflows.Items.Add(listViewItem)

                workflowStatusList.Add(sqlTrackingWorkflowInstance.WorkflowInstanceInternalId.ToString(), _
                            New WorkflowStatusInfo( _
                                sqlTrackingWorkflowInstance.WorkflowInstanceInternalId.ToString(), _
                                sqlTrackingWorkflowInstance.WorkflowType.ToString(), _
                                sqlTrackingWorkflowInstance.Status.ToString(), _
                                sqlTrackingWorkflowInstance.Initialized.ToString(), _
                                sqlTrackingWorkflowInstance.WorkflowInstanceId, _
                                listViewItem))
            Next
            ' </snippet137>
        End Sub
        Friend Class WorkflowStatusInfo
            Friend Sub New(ByVal id As String, ByVal name As String, ByVal status As String, ByVal createdDateTime As String, ByVal instanceId As Guid, ByVal listViewItem As ListViewItem)

            End Sub
        End Class
        Private WithEvents toolStripComboBoxZoom As New ToolStripComboBox()
        Private workflowViewHost As New ViewHost()
        Friend Class ViewHost
            Inherits Control
            Implements IMemberCreationService

            Public WorkflowView As New WorkflowView()

            Public Sub CreateEvent(ByVal className As String, ByVal eventName As String, ByVal eventType As System.Type, ByVal attributes() As System.Workflow.ComponentModel.Compiler.AttributeInfo, ByVal emitDependencyProperty As Boolean) Implements System.Workflow.ComponentModel.Design.IMemberCreationService.CreateEvent

            End Sub

            Public Sub CreateField(ByVal className As String, ByVal fieldName As String, ByVal fieldType As System.Type, ByVal genericParameterTypes() As System.Type, ByVal attributes As System.CodeDom.MemberAttributes, ByVal initializationExpression As System.CodeDom.CodeSnippetExpression, ByVal overwriteExisting As Boolean) Implements System.Workflow.ComponentModel.Design.IMemberCreationService.CreateField

            End Sub

            Public Sub CreateProperty(ByVal className As String, ByVal propertyName As String, ByVal propertyType As System.Type, ByVal attributes() As System.Workflow.ComponentModel.Compiler.AttributeInfo, ByVal emitDependencyProperty As Boolean, ByVal isMetaProperty As Boolean, ByVal isAttached As Boolean, ByVal ownerType As System.Type, ByVal isReadOnly As Boolean) Implements System.Workflow.ComponentModel.Design.IMemberCreationService.CreateProperty

            End Sub

            Public Sub RemoveEvent(ByVal className As String, ByVal eventName As String, ByVal eventType As System.Type) Implements System.Workflow.ComponentModel.Design.IMemberCreationService.RemoveEvent

            End Sub

            Public Sub RemoveProperty(ByVal className As String, ByVal propertyName As String, ByVal propertyType As System.Type) Implements System.Workflow.ComponentModel.Design.IMemberCreationService.RemoveProperty

            End Sub

            Public Sub ShowCode() Implements System.Workflow.ComponentModel.Design.IMemberCreationService.ShowCode

            End Sub

            Public Sub ShowCode(ByVal activity As System.Workflow.ComponentModel.Activity, ByVal methodName As String, ByVal delegateType As System.Type) Implements System.Workflow.ComponentModel.Design.IMemberCreationService.ShowCode

            End Sub

            Public Sub UpdateBaseType(ByVal className As String, ByVal baseType As System.Type) Implements System.Workflow.ComponentModel.Design.IMemberCreationService.UpdateBaseType

            End Sub

            Public Sub UpdateEvent(ByVal className As String, ByVal oldEventName As String, ByVal oldEventType As System.Type, ByVal newEventName As String, ByVal newEventType As System.Type, ByVal attributes() As System.Workflow.ComponentModel.Compiler.AttributeInfo, ByVal emitDependencyProperty As Boolean, ByVal isMetaProperty As Boolean) Implements System.Workflow.ComponentModel.Design.IMemberCreationService.UpdateEvent

            End Sub

            Public Sub UpdateProperty(ByVal className As String, ByVal oldPropertyName As String, ByVal oldPropertyType As System.Type, ByVal newPropertyName As String, ByVal newPropertyType As System.Type, ByVal attributes() As System.Workflow.ComponentModel.Compiler.AttributeInfo, ByVal emitDependencyProperty As Boolean, ByVal isMetaProperty As Boolean) Implements System.Workflow.ComponentModel.Design.IMemberCreationService.UpdateProperty

            End Sub

            Public Sub UpdateTypeName(ByVal oldClassName As String, ByVal newClassName As String) Implements System.Workflow.ComponentModel.Design.IMemberCreationService.UpdateTypeName

            End Sub
        End Class
        ' <snippet138>
        Private Sub ToolStripComboBoxZoom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripComboBoxZoom.SelectedIndexChanged
            If workflowViewHost.WorkflowView Is Nothing Then
                Return
            End If

            'Parse the value and set the WorkflowView zoom - set to 100% if invalid
            Dim NewZoom As String = Me.toolStripComboBoxZoom.Text.Trim()
            If NewZoom.EndsWith("%") Then
                NewZoom = NewZoom.Substring(0, NewZoom.Length - 1)
            End If

            If NewZoom.Length > 0 Then
                Try
                    Me.workflowViewHost.WorkflowView.Zoom = Convert.ToInt32(NewZoom)
                Catch
                    Me.workflowViewHost.WorkflowView.Zoom = 100
                End Try
            Else
                Me.workflowViewHost.WorkflowView.Zoom = 100
            End If
        End Sub
        ' </snippet138>
        Dim toolStripTextBoxArtifactQualifiedId As New ToolStripTextBox()
        Dim toolStripTextBoxArtifactKeyName As New ToolStripTextBox()
        Dim toolStripTextBoxArtifactKeyValue As New ToolStripTextBox()

        Sub container3()

            Dim TrackingDataItemValue As New TrackingDataItemValue(String.Empty, String.Empty, String.Empty)

            '<snippet139>
            TrackingDataItemValue = New TrackingDataItemValue(String.Empty, String.Empty, String.Empty)
            TrackingDataItemValue.QualifiedName = Me.toolStripTextBoxArtifactQualifiedId.Text.ToString()
            TrackingDataItemValue.FieldName = Me.toolStripTextBoxArtifactKeyName.Text.ToString()
            TrackingDataItemValue.DataValue = Me.toolStripTextBoxArtifactKeyValue.Text.ToString()
            '</snippet139>

        End Sub


    End Class
End Namespace

