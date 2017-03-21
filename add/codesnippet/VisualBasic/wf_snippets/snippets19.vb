Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Workflow.Activities
Imports System.Workflow.Runtime
Imports System.Threading
Imports System.Workflow.ComponentModel
Imports System.ComponentModel

Namespace WF_Snippets

    '***************************
    '* Snippets from Technologies/BasicWorkflows and Technologies/Communication
    ' */


    '***************
    '* Snippets from BasicWorkflows/SimpleStateMachineWorkflow
    '*/

    Partial Public Class StateMachineWorkflow
        Inherits StateMachineWorkflowActivity
        Private Sub Code1Handler(ByVal sender As Object, ByVal e As EventArgs)

        End Sub
        Private Sub Code2Handler(ByVal sender As Object, ByVal e As EventArgs)

        End Sub
    End Class

    ' <snippet183>
    Partial Public Class StateMachineWorkflow

        <System.Diagnostics.DebuggerNonUserCode()> _
        Private Sub InitializeComponent()

            ' <snippet184>
            Me.CanModifyActivities = True
            Me.CompletedState = New System.Workflow.Activities.StateActivity
            Me.code2 = New System.Workflow.Activities.CodeActivity
            ' <snippet185>
            Me.state1Delay = New System.Workflow.Activities.DelayActivity
            ' </snippet185>
            ' <snippet186>
            Me.setState1 = New System.Workflow.Activities.SetStateActivity()
            ' </snippet186>
            Me.code1 = New System.Workflow.Activities.CodeActivity()
            Me.startStateDelay = New System.Workflow.Activities.DelayActivity()
            Me.eventDriven2 = New System.Workflow.Activities.EventDrivenActivity()
            ' <snippet187>
            Me.eventDriven1 = New System.Workflow.Activities.EventDrivenActivity()
            ' </snippet187>
            Me.CompletedState = New System.Workflow.Activities.StateActivity()
            Me.state1 = New System.Workflow.Activities.StateActivity()
            ' <snippet188>
            Me.StartState = New System.Workflow.Activities.StateActivity()
            ' </snippet188>
            ' 
            ' setCompletedState
            '
            ' <snippet189> 
            Me.setCompletedState.Name = "setCompletedState"
            Me.setCompletedState.TargetStateName = "CompletedState"
            ' </snippet189>
            ' 
            ' code2
            ' 
            Me.code2.Name = "code2"
            AddHandler Me.code2.ExecuteCode, AddressOf Me.Code2Handler

            ' 
            ' state1Delay
            '
            ' <snippet190> 
            Me.state1Delay.Name = "state1Delay"
            Me.state1Delay.TimeoutDuration = System.TimeSpan.Parse("00:00:02")
            ' </snippet190>
            ' 
            ' setState1
            ' 
            Me.setState1.Name = "setState1"
            Me.setState1.TargetStateName = "state1"
            ' 
            ' code1
            ' 
            Me.code1.Name = "code1"
            AddHandler Me.code1.ExecuteCode, AddressOf Me.Code1Handler
            ' 
            ' startStateDelay
            ' 
            Me.startStateDelay.Name = "startStateDelay"
            Me.startStateDelay.TimeoutDuration = System.TimeSpan.Parse("00:00:05")
            ' 
            ' eventDriven2
            ' 
            Me.eventDriven2.Activities.Add(Me.state1Delay)
            Me.eventDriven2.Activities.Add(Me.code2)
            Me.eventDriven2.Activities.Add(Me.setCompletedState)
            Me.eventDriven2.Name = "eventDriven2"
            ' 
            ' eventDriven1
            ' 
            Me.eventDriven1.Activities.Add(Me.startStateDelay)
            Me.eventDriven1.Activities.Add(Me.code1)
            Me.eventDriven1.Activities.Add(Me.setState1)
            Me.eventDriven1.Name = "eventDriven1"
            ' 
            ' CompletedState
            ' 
            Me.CompletedState.Name = "CompletedState"
            ' </snippet184>
            ' 
            ' state1
            ' 
            Me.state1.Activities.Add(Me.eventDriven2)
            Me.state1.Name = "state1"
            ' 
            ' StartState
            ' 
            Me.StartState.Activities.Add(Me.eventDriven1)
            Me.StartState.Name = "StartState"
            ' 
            ' StateMachineWorkflow
            ' 
            ' <snippet191>
            Me.Activities.Add(Me.StartState)
            Me.Activities.Add(Me.state1)
            Me.Activities.Add(Me.CompletedState)
            Me.CompletedStateName = "CompletedState"
            Me.DynamicUpdateCondition = Nothing
            Me.InitialStateName = "StartState"
            Me.Name = "StateMachineWorkflow"
            Me.CanModifyActivities = False
            ' </snippet191>
        End Sub
        Private StartState As System.Workflow.Activities.StateActivity
        Private eventDriven1 As System.Workflow.Activities.EventDrivenActivity
        Private setState1 As System.Workflow.Activities.SetStateActivity
        Private state1 As System.Workflow.Activities.StateActivity
        Private eventDriven2 As System.Workflow.Activities.EventDrivenActivity
        Private state1Delay As System.Workflow.Activities.DelayActivity
        Private setCompletedState As System.Workflow.Activities.SetStateActivity
        Private code1 As System.Workflow.Activities.CodeActivity
        Private code2 As System.Workflow.Activities.CodeActivity
        Private startStateDelay As System.Workflow.Activities.DelayActivity
        Private CompletedState As System.Workflow.Activities.StateActivity
    End Class
    ' </snippet183>

    '**************************
    '* Snippets from BasicWorkflows/WorkflowWithParameters
    '*/
    Class Snippets19
        Inherits SequentialWorkflowActivity
        Private ifElseActivity As New IfElseActivity()
        Private approveIfElseBranch As New IfElseBranchActivity()
        Private rejecteIfElseBranch As New IfElseBranchActivity()
        Private approve As New CodeActivity()
        Private reject As New CodeActivity()
        Shared waitHandle As New AutoResetEvent(False)

        ' <snippet192>
        Shared Sub OnWorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)

            'The order status is stored in the "status" "out" parameter
            Dim orderStatus As String = e.OutputParameters("Status").ToString()
            Console.WriteLine("Order was " + orderStatus)
            waitHandle.Set()
        End Sub
        ' </snippet192>

        ' <snippet193>
        Shared Sub OnWorkflowTerminated(ByVal sender As Object, ByVal e As WorkflowTerminatedEventArgs)
            Console.WriteLine(e.Exception.Message)
            waitHandle.Set()
        End Sub
        ' </snippet193>
        Sub container1()

            ' <snippet194>
            Me.CanModifyActivities = True
            Dim codecondition1 As System.Workflow.Activities.CodeCondition = New System.Workflow.Activities.CodeCondition
            Me.ifElseActivity = New System.Workflow.Activities.IfElseActivity
            Me.approveIfElseBranch = New System.Workflow.Activities.IfElseBranchActivity
            Me.rejecteIfElseBranch = New System.Workflow.Activities.IfElseBranchActivity
            Me.approve = New System.Workflow.Activities.CodeActivity
            Me.reject = New System.Workflow.Activities.CodeActivity
            ' 
            ' ifElseActivity
            ' 
            Me.ifElseActivity.Activities.Add(Me.approveIfElseBranch)
            Me.ifElseActivity.Activities.Add(Me.rejecteIfElseBranch)
            Me.ifElseActivity.Name = "ifElseActivity"
            ' </snippet194>
        End Sub
    End Class
    '************************
    '* Snippets from Communication/CorrelatedLocalService
    '*/



    Class Snippets20
        Inherits SequentialWorkflowActivity
        Private Sub OnTaskCompleted(ByVal sender As Object, ByVal e As ExternalDataEventArgs)

        End Sub

        Private taskCompleted1 As New TaskCompleted()
        Private taskCompleted2 As New TaskCompleted()
        Private createTask1 As New CreateTask()
        Private createTask2 As New CreateTask()
        Sub container1()

            '<snippet195>
            Dim correlationtoken1 As System.Workflow.Runtime.CorrelationToken = New System.Workflow.Runtime.CorrelationToken
            '</snippet195>
            Dim correlationtoken2 As System.Workflow.Runtime.CorrelationToken = New System.Workflow.Runtime.CorrelationToken
            '<snippet196>
            correlationtoken1.Name = "c2"
            '</snippet196>
            '<snippet197>
            correlationtoken1.OwnerActivityName = "sequence2"
            '</snippet197>
            '<snippet198>
            Me.taskCompleted2.CorrelationToken = correlationtoken1
            '</snippet198>
            '<snippet199>
            AddHandler Me.taskCompleted2.Invoked, AddressOf Me.OnTaskCompleted
            '</snippet199>
            '<snippet200>
            Me.createTask2.CorrelationToken = correlationtoken1
            '</snippet200>
            '<snippet201>
            Me.taskCompleted1.CorrelationToken = correlationtoken2
            '</snippet201>
            '<snippet202>
            Me.taskCompleted1.EventName = "TaskCompleted"
            '</snippet202>
            '<snippet203>
            AddHandler Me.taskCompleted1.Invoked, AddressOf Me.OnTaskCompleted
            '</snippet203>
            '<snippet204>
            Me.createTask1.CorrelationToken = correlationtoken2
            '</snippet204>
        End Sub
    End Class
    ' <snippet205>
    Partial Public Class CreateTask
        Inherits System.Workflow.Activities.CallExternalMethodActivity
        ' Properties on the task
        Public Shared AssigneeProperty As DependencyProperty = DependencyProperty.Register("Assignee", GetType(System.String), GetType(CreateTask))
        Public Shared TaskIdProperty As DependencyProperty = DependencyProperty.Register("TaskId", GetType(System.String), GetType(CreateTask))
        Public Shared TextProperty As DependencyProperty = DependencyProperty.Register("Text", GetType(System.String), GetType(CreateTask))

        Private Sub InitializeComponent()

        End Sub

        Public Sub New()

            ' <snippet206>
            Me.InterfaceType = GetType(ITaskService)
            Me.MethodName = "CreateTask"
            ' </snippet206>
        End Sub

        <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
    <BrowsableAttribute(True)> _
    Public Property Assignee() As System.String
            Get
                Return CType(MyBase.GetValue(AssigneeProperty), String)

            End Get
            Set(ByVal value As System.String)
                MyBase.SetValue(AssigneeProperty, value)

            End Set
        End Property

        <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
    <BrowsableAttribute(True)> _
    Public Property TaskId() As System.String
            Get
                Return CType(MyBase.GetValue(TaskIdProperty), String)

            End Get
            Set(ByVal value As System.String)
                MyBase.SetValue(TaskIdProperty, value)

            End Set
        End Property

        <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)> _
    <BrowsableAttribute(True)> _
    Public Property Text() As System.String
            Get
                Return CType(MyBase.GetValue(TextProperty), String)

            End Get
            Set(ByVal value As System.String)
                MyBase.SetValue(TextProperty, value)

            End Set
        End Property
        '<snippet207>
        Protected Overrides Sub OnMethodInvoking(ByVal e As EventArgs)
            Me.ParameterBindings("taskId").Value = Me.TaskId
            Me.ParameterBindings("assignee").Value = Me.Assignee
            Me.ParameterBindings("text").Value = Me.Text
        End Sub
        '</snippet207>

    End Class
    ' </snippet205>
    <ExternalDataExchange()> _
<CorrelationParameter("taskId")> _
Public Interface ITaskService
    End Interface
    Class TaskCompleted
        Inherits HandleExternalEventActivity
        Public EventArgs As TaskEventArgs
        '<snippet208>
        Protected Overrides Sub OnInvoked(ByVal e As EventArgs)
            EventArgs = CType(e, TaskEventArgs)
        End Sub
        '</snippet208>
    End Class
    Class TaskEventArgs
        Inherits EventArgs

    End Class

    '*********************
    '* Snippets from Communications/Listen
    '*/
    Interface IOrderService
        Event OrderApproved As EventHandler(Of OrderEventArgs)
        Event OrderRejected As EventHandler(Of OrderEventArgs)
    End Interface


    ' <snippet209>
    Class OrderServiceImpl
        Implements IOrderService

        ' <snippet210>
        Dim orderId As String
        Public instanceId As WorkflowInstance
        ' </snippet210>

        ' Called by the workflow to pass an order id
        Public Sub CreateOrder(ByVal Id As String)

            Console.WriteLine("\nPurchase Order Created in System")
            orderId = Id
        End Sub

        ' Called by the host to approve an order
        ' <snippet211>
        Public Sub ApproveOrder()
            RaiseEvent OrderApproved(Nothing, New OrderEventArgs(instanceId.InstanceId, orderId))
        End Sub
        ' </snippet211>

        ' Called by the host to reject an order
        Public Sub RejectOrder()
            RaiseEvent OrderRejected(Nothing, New OrderEventArgs(instanceId.InstanceId, orderId))
        End Sub

        ' Events that handled within a workflow by HandleExternalEventActivity activities
        Public Event OrderApproved(ByVal sender As Object, ByVal e As OrderEventArgs) Implements IOrderService.OrderApproved
        Public Event OrderRejected(ByVal sender As Object, ByVal e As OrderEventArgs) Implements IOrderService.OrderRejected
    End Class
    ' </snippet209>

    ' <snippet212>
    Class WorkflowApplication
        Shared WaitHandle As New AutoResetEvent(False)
        Shared orderService As New OrderServiceImpl()

        Shared Sub Main()
            ' Start the workflow runtime engine.
            Using currentWorkflowRuntime As WorkflowRuntime = New WorkflowRuntime()
                Dim dataService As ExternalDataExchangeService = New ExternalDataExchangeService()
                currentWorkflowRuntime.AddService(dataService)
                dataService.AddService(orderService)

                currentWorkflowRuntime.StartRuntime()

                ' Listen for the workflow events
                AddHandler currentWorkflowRuntime.WorkflowCompleted, AddressOf OnWorkflowCompleted
                AddHandler currentWorkflowRuntime.WorkflowTerminated, AddressOf OnWorkflowTerminated
                AddHandler currentWorkflowRuntime.WorkflowIdled, AddressOf OnWorkflowIdled

                ' Start the workflow and wait for it to complete
                Dim type As System.Type = GetType(PurchaseOrderWorkflow)
                currentWorkflowRuntime.CreateWorkflow(type).Start()

                WaitHandle.WaitOne()

                ' Stop the workflow runtime engine.
                currentWorkflowRuntime.StopRuntime()
            End Using
        End Sub

        ' This method will be called when a workflow instance is completed
        ' waitHandle is set so the main thread can continue
        Shared Sub OnWorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)
            WaitHandle.Set()
        End Sub

        ' This method is called when the workflow terminates and does not complete
        ' This should not occur in this sample; however, it is good practice to include a
        ' handler for this event so the host application can manage workflows that are
        ' unexpectedly terminated (e.g. unhandled workflow exception).
        ' waitHandle is set so the main thread can continue
        Shared Sub OnWorkflowTerminated(ByVal sender As Object, ByVal e As WorkflowTerminatedEventArgs)
            Console.WriteLine(e.Exception.Message)
            WaitHandle.Set()
        End Sub

        ' This method will be called when a workflow instance is idled
        Shared Sub OnWorkflowIdled(ByVal sender As Object, ByVal e As WorkflowEventArgs)
            orderService.instanceId = e.WorkflowInstance

            'Randomly approve, reject or timeout purchase orders
            Dim randGen As Random = New Random()

            Dim pick As Integer = randGen.Next(1, 100) Mod 3
            Select Case pick
                Case 0
                    orderService.ApproveOrder()
                Case 1
                    orderService.RejectOrder()
                Case 2
                    'timeout
            End Select
        End Sub
    End Class
    ' </snippet212>

    Class PurchaseOrderWorkflow
        Inherits SequentialWorkflowActivity
        Private Sub OnTimeout(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Private Sub OnRejectPO(ByVal sender As Object, ByVal e As ExternalDataEventArgs)

        End Sub

        Private Sub OnApprovePO(ByVal sender As Object, ByVal e As ExternalDataEventArgs)

        End Sub

        Private Sub OnBeforeCreateOrder(ByVal sender As Object, ByVal e As EventArgs)

        End Sub
        ' <snippet213>
        <System.Diagnostics.DebuggerNonUserCode()> _
    Private Sub InitializeComponent()
            ' <snippet214>
            Me.CanModifyActivities = True
            Me.CreatePO = New System.Workflow.Activities.CallExternalMethodActivity
            Me.POStatusListen = New System.Workflow.Activities.ListenActivity
            Me.OnOrderApprovedEventDriven = New System.Workflow.Activities.EventDrivenActivity
            Me.OnOrderRejectedEventDriven = New System.Workflow.Activities.EventDrivenActivity
            Me.OnTimeoutEventDriven = New System.Workflow.Activities.EventDrivenActivity
            Me.ApprovePO = New System.Workflow.Activities.HandleExternalEventActivity
            Me.RejectPO = New System.Workflow.Activities.HandleExternalEventActivity
            Me.Delay = New System.Workflow.Activities.DelayActivity
            Me.Timeout = New System.Workflow.Activities.CodeActivity
            ' </snippet214>
            '
            'Timeout
            '
            Me.Timeout.Name = "Timeout"
            AddHandler Me.Timeout.ExecuteCode, AddressOf Me.OnTimeout
            '
            'Delay
            '
            ' <snippet215>
            Me.Delay.Name = "Delay"
            Me.Delay.TimeoutDuration = System.TimeSpan.Parse("00:00:05")
            ' </snippet215>
            '
            'RejectPO
            '
            Me.RejectPO.EventName = "OrderRejected"
            Me.RejectPO.InterfaceType = GetType(IOrderService)
            Me.RejectPO.Name = "RejectPO"
            AddHandler Me.RejectPO.Invoked, AddressOf Me.OnRejectPO
            ' 
            ' ApprovePO
            ' 
            ' <snippet216>
            Me.ApprovePO.EventName = "OrderApproved"
            Me.ApprovePO.InterfaceType = GetType(IOrderService)
            Me.ApprovePO.Name = "ApprovePO"
            AddHandler Me.ApprovePO.Invoked, AddressOf Me.OnApprovePO
            ' </snippet216> 
            ' 
            ' OnTimeoutEventDriven
            ' 
            Me.OnTimeoutEventDriven.Activities.Add(Me.Delay)
            Me.OnTimeoutEventDriven.Activities.Add(Me.Timeout)
            Me.OnTimeoutEventDriven.Name = "OnTimeoutEventDriven"
            ' 
            ' OnOrderRejectedEventDriven
            ' 
            Me.OnOrderRejectedEventDriven.Activities.Add(Me.RejectPO)
            Me.OnOrderRejectedEventDriven.Name = "OnOrderRejectedEventDriven"
            ' 
            ' OnOrderApprovedEventDriven
            ' 
            Me.OnOrderApprovedEventDriven.Activities.Add(Me.ApprovePO)
            Me.OnOrderApprovedEventDriven.Name = "OnOrderApprovedEventDriven"
            ' 
            ' POStatusListen
            ' 
            Me.POStatusListen.Activities.Add(Me.OnOrderApprovedEventDriven)
            Me.POStatusListen.Activities.Add(Me.OnOrderRejectedEventDriven)
            Me.POStatusListen.Activities.Add(Me.OnTimeoutEventDriven)
            Me.POStatusListen.Name = "POStatusListen"
            ' 
            ' CreatePO
            ' 
            ' <snippet217>
            Me.CreatePO.InterfaceType = GetType(IOrderService)
            Me.CreatePO.MethodName = "CreateOrder"
            Me.CreatePO.Name = "CreatePO"
            AddHandler Me.CreatePO.MethodInvoking, AddressOf Me.OnBeforeCreateOrder
            ' </snippet217>
            ' 
            ' PurchaseOrderWorkflow
            ' 
            Me.Activities.Add(Me.CreatePO)
            Me.Activities.Add(Me.POStatusListen)
            Me.Name = "PurchaseOrderWorkflow"
            Me.CanModifyActivities = False

        End Sub
        ' </snippet213>

        Private POStatusListen As System.Workflow.Activities.ListenActivity
        Private OnOrderApprovedEventDriven As System.Workflow.Activities.EventDrivenActivity
        Private OnOrderRejectedEventDriven As System.Workflow.Activities.EventDrivenActivity
        Private ApprovePO As System.Workflow.Activities.HandleExternalEventActivity
        Private RejectPO As System.Workflow.Activities.HandleExternalEventActivity
        Private OnTimeoutEventDriven As System.Workflow.Activities.EventDrivenActivity
        Private Delay As System.Workflow.Activities.DelayActivity
        Private Timeout As System.Workflow.Activities.CodeActivity
        Private CreatePO As System.Workflow.Activities.CallExternalMethodActivity
    End Class
    ' <snippet218>
    <Serializable()> _
    Public Class OrderEventArgs1
        Inherits ExternalDataEventArgs
        Private id As String

        Public Sub New(ByVal instanceId As Guid, ByVal id As String)
            MyBase.new(instanceId)

            Me.id = id
        End Sub

        ' Gets or sets an order id value
        ' Sets by the workflow to pass an order id
        Public Property OrderId() As String
            Get
                Return Me.id
            End Get
            Set(ByVal value As String)

                Me.id = value
            End Set
        End Property
    End Class
    ' </snippet218>

    '*********************
    '* Snippets from Communication/SimpleInput
    '*/

    Public Class Snippets22

        '<snippet219>
        Shared Sub Submit(ByVal instance As WorkflowInstance, ByVal input As String)
            instance.EnqueueItem("Queue", input, Nothing, Nothing)
        End Sub
        '</snippet219>
    End Class

    '************************
    '* Snippets from Communication/WebService
    '*/

    Public Class Snippets23
        Inherits SequentialWorkflowActivity
        Private code1 As New CodeActivity()
        Private invokeWebService1 As New InvokeWebServiceActivity()
        Sub container1()

            Dim activitybind1 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
            Dim workflowparameterbinding1 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding
            Dim activitybind2 As System.Workflow.ComponentModel.ActivityBind = New System.Workflow.ComponentModel.ActivityBind
            Dim workflowparameterbinding2 As System.Workflow.ComponentModel.WorkflowParameterBinding = New System.Workflow.ComponentModel.WorkflowParameterBinding

            ' <snippet220>
            Me.invokeWebService1.MethodName = "CreateOrder"
            Me.invokeWebService1.Name = "invokeWebService1"
            activitybind1.Name = "WebServiceInvokeWorkflow"
            activitybind1.Path = "POStatus"
            workflowparameterbinding1.ParameterName = "(ReturnValue)"
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind1, System.Workflow.ComponentModel.ActivityBind))
            activitybind2.Name = "WebServiceInvokeWorkflow"
            activitybind2.Path = "PurchaseOrderId"
            workflowparameterbinding2.ParameterName = "id"
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, CType(activitybind2, System.Workflow.ComponentModel.ActivityBind))
            Me.invokeWebService1.ParameterBindings.Add(workflowparameterbinding1)
            Me.invokeWebService1.ParameterBindings.Add(workflowparameterbinding2)
            Me.invokeWebService1.ProxyClass = GetType(WebServicePublishWorkflow_WebService)
            AddHandler Me.invokeWebService1.Invoking, AddressOf Me.OnWebServiceInvoking
            ' </snippet220>
        End Sub
        Private Sub OnWebServiceInvoking(ByVal sender As Object, ByVal e As InvokeWebServiceEventArgs)

        End Sub

    End Class

    Partial Public Class WebServicePublishWorkflow_WebService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
    End Class
End Namespace

