Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Workflow.Runtime
Imports System.Workflow.ComponentModel
Imports System.Workflow.Activities
Imports System.Workflow.Runtime.Hosting
Imports System.Threading

Namespace WF_Snippets

    '******************
    ''* Snippets taken from Technology/Activities samples
    '*********************************

    Class snippets11

        '********************
        ''* Snippets from Activities/Compensation
        '***************

        Private CompensateRefund As CompensateActivity
        Private NoProductFaultHandler As FaultHandlerActivity
        Private Available As IfElseBranchActivity
        Private Discontinued As IfElseBranchActivity
        Private CompensateOrder As CompensationHandlerActivity
        Private OrderScope As CompensatableTransactionScopeActivity
        Private NoProductFault As New ThrowActivity()
        Private DiscontinuedProduct As New CodeActivity()
        Private Ship As New CodeActivity()
        Private ReceiverOrder As New CodeActivity()

        Sub container1()

            Dim activitybind1 As New System.Workflow.ComponentModel.ActivityBind()
            Dim codecondition1 As New System.Workflow.Activities.CodeCondition()
            Dim workflowRuntime As New WorkflowRuntime()
            '<snippet140>
            AddHandler workflowRuntime.WorkflowCompleted, AddressOf OnWorkflowCompleted
            '</snippet140>

            '<snippet141>
            AddHandler workflowRuntime.WorkflowAborted, AddressOf OnWorkflowAborted
            '</snippet141>
            '<snippet142>
            workflowRuntime.StopRuntime()
            '</snippet142>

            ' <snippet143>
            '<snippet144>
            Me.CompensateRefund = New System.Workflow.ComponentModel.CompensateActivity()
            '</snippet144>
            '<snippet145>
            Me.NoProductFaultHandler = New System.Workflow.ComponentModel.FaultHandlerActivity()
            '</snippet145>
            ' <snippet146>
            Me.Discontinued = New System.Workflow.Activities.IfElseBranchActivity()
            Me.Available = New System.Workflow.Activities.IfElseBranchActivity()
            ' </snippet146>
            '<snippet147>
            Me.CompensateOrder = New System.Workflow.ComponentModel.CompensationHandlerActivity()
            '</snippet147>
            ' </snippet143>
            '<snippet148>
            Me.OrderScope = New System.Workflow.ComponentModel.CompensatableTransactionScopeActivity()
            '</snippet148>
            '<snippet149>
            Me.CompensateRefund.TargetActivityName = "OrderScope"
            '</snippet149>
            ' <snippet150> 
            '<snippet151>
            Me.NoProductFault.FaultType = GetType(DiscontinuedProductException)
            '</snippet151>
            Me.NoProductFault.Name = "NoProductFault"
            Me.NoProductFault.SetBinding(System.Workflow.ComponentModel.ThrowActivity.FaultProperty, activitybind1)
            ' </snippet150>

            ' <snippet152> 
            Me.NoProductFaultHandler.Activities.Add(Me.DiscontinuedProduct)
            Me.NoProductFaultHandler.Activities.Add(Me.CompensateRefund)
            Me.NoProductFaultHandler.FaultType = GetType(DiscontinuedProductException)
            Me.NoProductFaultHandler.Name = "NoProductFaultHandler"
            ' </snippet152>

            ' <snippet153>
            Me.Available.Activities.Add(Me.Ship)
            AddHandler codecondition1.Condition, AddressOf ProductCheckHandler
            Me.Available.Condition = codecondition1
            Me.Available.Name = "Available"
            ' </snippet153>

            '<snippet154>
            Me.OrderScope.TransactionOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable
            '</snippet154>

            ' <snippet155> 
            Me.ReceiverOrder.Name = "ReceiverOrder"
            AddHandler Me.ReceiverOrder.ExecuteCode, AddressOf Me.ReceiveOrderHandler
            ' </snippet155>
        End Sub
        Shared Sub OnWorkflowAborted(ByVal sender As Object, ByVal e As WorkflowEventArgs)

        End Sub

        Shared Sub OnWorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)

        End Sub
        Class DiscontinuedProductException

        End Class
        Private Sub ProductCheckHandler(ByVal sender As Object, ByVal e As ConditionalEventArgs)

        End Sub
        Private Sub ReceiveOrderHandler(ByVal sender As Object, ByVal e As EventArgs)

        End Sub
    End Class
    '******************
    '* Snippets from Activities/SimpleCAG
    '***************
    Class Snippets12
        Inherits SequentialWorkflowActivity
        ' <snippet156>
        <System.Diagnostics.DebuggerNonUserCode()> _
                Private Sub InitializeComponent()

            ' <snippet157>
            ' <snippet158>
            Me.CanModifyActivities = True
            Dim codecondition1 As New System.Workflow.Activities.CodeCondition()
            Dim codecondition2 As New System.Workflow.Activities.CodeCondition()
            Me.BookingCag = New System.Workflow.Activities.ConditionedActivityGroup()
            Me.Car = New System.Workflow.Activities.CodeActivity()
            Me.Airline = New System.Workflow.Activities.CodeActivity()
            ' </snippet157>
            ' 
            ' BookingCag
            '
            ' <snippet159> 
            Me.BookingCag.Activities.Add(Me.Car)
            Me.BookingCag.Activities.Add(Me.Airline)
            Me.BookingCag.Name = "BookingCag"
            AddHandler codecondition1.Condition, AddressOf CarCondition
            ' </snippet159>
            ' 
            ' Car
            ' 
            ' <snippet160>
            Me.Car.Name = "Car"
            AddHandler Car.ExecuteCode, AddressOf Me.Car_ExecuteCode
            Me.Car.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, codecondition1)
            AddHandler codecondition2.Condition, AddressOf Me.AirlineCondition
            ' </snippet158>
            ' </snippet160>
            ' 
            ' Airline
            ' 
            Me.Airline.Name = "Airline"
            AddHandler Airline.ExecuteCode, AddressOf Me.Airline_ExecuteCode
            Me.Airline.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, codecondition2)
            ' 
            ' SimpleConditionedActivityGroupWorkflow
            ' 
            Me.Activities.Add(Me.BookingCag)
            Me.Name = "SimpleConditionedActivityGroupWorkflow"
            Me.CanModifyActivities = False

        End Sub
        ' </snippet156>

        Private BookingCag As ConditionedActivityGroup
        Private Car As CodeActivity
        Private Airline As CodeActivity
        Private Sub Airline_ExecuteCode(ByVal sender As Object, ByVal e As EventArgs)

        End Sub
        Private Sub Car_ExecuteCode(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub CarCondition(ByVal sender As Object, ByVal e As ConditionalEventArgs)

        End Sub

        Private Sub AirlineCondition(ByVal sender As Object, ByVal e As ConditionalEventArgs)

        End Sub
    End Class

    '*********************
    '* Snippets from Activities/NestedExceptions
    '***************
    Class Snippets13
        Inherits SequentialWorkflowActivity
        Dim workflowRuntime As New WorkflowRuntime()
        Private synchronizationScopeActivity As New SynchronizationScopeActivity()
        Private throwsException As New CodeActivity()
        Sub container1()

            '<snippet161>
            ' A workflow is always run asychronously the main thread waits on Me event so the program
            ' doesn't exit before the workflow completes
            WorkflowRuntime.AddService(New SqlWorkflowPersistenceService("Initial Catalog=SqlPersistenceServiceData Source=localhostIntegrated Security=SSPI"))
            '</snippet161>

            '<snippet162>
            Me.synchronizationScopeActivity = New System.Workflow.ComponentModel.SynchronizationScopeActivity()
            '</snippet162>

            '<snippet163>
            Me.synchronizationScopeActivity.Activities.Add(Me.throwsException)
            Me.synchronizationScopeActivity.Name = "synchronizationScopeActivity"
            Me.synchronizationScopeActivity.SynchronizationHandles = Nothing
            '</snippet163>
        End Sub
    End Class
    '**********************
    '* Snippet from AdvancedPolicy
    '***************
    ' <snippet164>
    Partial Public NotInheritable Class DiscountPolicyWorkflow

        <System.Diagnostics.DebuggerNonUserCode()> _
                    Private Sub InitializeComponent()

            Me.CanModifyActivities = True
            Dim rulesetreference1 As New System.Workflow.Activities.Rules.RuleSetReference()
            Me.advancedDiscountPolicy = New System.Workflow.Activities.PolicyActivity()
            ' 
            ' advancedDiscountPolicy
            ' 
            Me.advancedDiscountPolicy.Name = "advancedDiscountPolicy"
            rulesetreference1.RuleSetName = "DiscountRuleSet"
            Me.advancedDiscountPolicy.RuleSetReference = rulesetreference1
            ' 
            ' DiscountPolicyWorkflow
            ' 
            Me.Activities.Add(Me.advancedDiscountPolicy)
            Me.Name = "DiscountPolicyWorkflow"
            AddHandler Me.Completed, AddressOf Me.WorkflowCompleted
            Me.CanModifyActivities = False

        End Sub

        Private advancedDiscountPolicy As PolicyActivity
    End Class
    ' </snippet164>
    Partial Public NotInheritable Class DiscountPolicyWorkflow
        Inherits SequentialWorkflowActivity
        Private Sub WorkflowCompleted(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
    End Class
    '*********************
    '* Snippets from SimpleReplicator
    '***************

    ' <snippet165>

    Partial Public NotInheritable Class SimpleReplicatorWorkflow
        Inherits SequentialWorkflowActivity
        <System.Diagnostics.DebuggerNonUserCode()> _
                    Private Sub InitializeComponent()

            Me.CanModifyActivities = True
            ' <snippet166>
            Dim activityBind1 As New System.Workflow.ComponentModel.ActivityBind()
            Me.SampleReplicatorChildActivity1 = New SampleReplicatorChildActivity()
            Me.ReplicatorWork = New System.Workflow.Activities.ReplicatorActivity()
            ' 
            ' SampleReplicatorChildActivity1
            ' 
            Me.SampleReplicatorChildActivity1.InstanceData = Nothing
            Me.SampleReplicatorChildActivity1.Name = "SampleReplicatorChildActivity1"
            activityBind1.Name = "SimpleReplicatorWorkflow"
            activityBind1.Path = "ChildData"
            ' 
            ' ReplicatorWork
            ' 
            ' <snippet167>
            Me.ReplicatorWork.Activities.Add(Me.SampleReplicatorChildActivity1)
            '<snippet168>
            Me.ReplicatorWork.ExecutionType = System.Workflow.Activities.ExecutionType.Sequence
            '</snippet168>
            Me.ReplicatorWork.Name = "ReplicatorWork"
            AddHandler Me.ReplicatorWork.ChildInitialized, AddressOf Me.ChildInitializer
            Me.ReplicatorWork.SetBinding(System.Workflow.Activities.ReplicatorActivity.InitialChildDataProperty, activityBind1)
            ' </snippet167>
            ' </snippet166>
            ' 
            ' SimpleReplicatorWorkflow
            ' 
            Me.Activities.Add(Me.ReplicatorWork)
            Me.Name = "SimpleReplicatorWorkflow"
            Me.CanModifyActivities = False

        End Sub

        Private SampleReplicatorChildActivity1 As SampleReplicatorChildActivity
        Private ReplicatorWork As ReplicatorActivity
    End Class

    ' </snippet165>
    Class SampleReplicatorChildActivity
        Inherits Activity
        Public InstanceData As String = ""
    End Class
    Partial Public Class SimpleReplicatorWorkflow
        Inherits SequentialWorkflowActivity
        Private Sub ChildInitializer(ByVal sender As Object, ByVal args As ReplicatorChildEventArgs)
        End Sub
    End Class

    '***********************
    '* Snippets from StateInitialization
    '***************
    Class Snippets15

        Dim stateInitialization As New StateInitializationActivity()
        Sub container1()

            '<snippet169>
            Me.stateInitialization = New System.Workflow.Activities.StateInitializationActivity()
            '</snippet169>
        End Sub
    End Class
            '*******************
            '* Snippets from SuspendAndTerminate
            '***************
    class Snippets16 
        Inherits SequentialWorkflowActivity

        Shared waitHandle As New AutoResetEvent(False)
        Dim workflowRuntime As New WorkflowRuntime()
        Dim workflowSuspended As Boolean = True
        Dim workflowInstance As WorkflowInstance
        Private suspend As New SuspendActivity()
        Private consoleMessage As New CodeActivity()
        Private terminate As New TerminateActivity()
        Private Sub OnConsoleMessage(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
        sub container1()

            ' Load the workflow type.
            Dim type As Type = GetType(SuspendAndTerminateWorkflow)
            WorkflowInstance = WorkflowRuntime.CreateWorkflow(Type)

            '<snippet170>
            AddHandler workflowRuntime.WorkflowSuspended, AddressOf OnWorkflowSuspend
            '</snippet170>
            '<snippet171>
            AddHandler workflowRuntime.WorkflowResumed, AddressOf OnWorkflowResume
            '</snippet171>


            '<snippet172>
            If workflowSuspended Then
                Console.WriteLine("\r\nResuming Workflow Instance")
                workflowInstance.Resume()
                waitHandle.WaitOne()
            End If
            '</snippet172>
        End Sub
        ' <snippet173>
        <System.Diagnostics.DebuggerNonUserCode()> _
                                    Private Sub InitializeComponent()

            ' <snippet174>
            Me.CanModifyActivities = True
            Me.suspend = New System.Workflow.ComponentModel.SuspendActivity()
            Me.consoleMessage = New System.Workflow.Activities.CodeActivity()
            Me.terminate = New System.Workflow.ComponentModel.TerminateActivity()
            ' </snippet174>
            ' <snippet175>
            ' 
            ' suspend
            ' 
            Me.suspend.Error = Nothing
            Me.suspend.Name = "suspend"
            ' 
            ' ConsoleMessage
            ' 
            Me.consoleMessage.Name = "consoleMessage"
            AddHandler Me.consoleMessage.ExecuteCode, AddressOf Me.OnConsoleMessage
            ' 
            ' terminate
            ' 
            '<snippet176>
            Me.terminate.Error = Nothing
            '</snippet176>
            Me.terminate.Name = "terminate"
            ' </snippet175>
            ' 
            ' SuspendAndTerminateWorkflow
            ' 
            Me.Activities.Add(Me.suspend)
            Me.Activities.Add(Me.consoleMessage)
            Me.Activities.Add(Me.terminate)
            Me.Name = "SuspendAndTerminateWorkflow"
            Me.CanModifyActivities = False
        End Sub

        ' </snippet173>
        Shared Sub OnWorkflowSuspend(ByVal sender As Object, ByVal instance As WorkflowSuspendedEventArgs)

        End Sub
        Shared Sub OnWorkflowResume(ByVal sender As Object, ByVal instance As WorkflowEventArgs)

        End Sub

        Shared Sub OnWorkflowTerminate(ByVal sender As Object, ByVal instance As WorkflowTerminatedEventArgs)

        End Sub
    End Class

    Class SuspendAndTerminateWorkflow
        Inherits SequentialWorkflowActivity
    End Class
    '******************
    '* Snippets from Synchronized
    '***************
    Class Snippets17

        Dim workflowRuntime As New WorkflowRuntime()
        Sub container1()


            '<snippet177>
            AddHandler workflowRuntime.ServicesExceptionNotHandled, AddressOf OnExceptionNotHandled
            '</snippet177>
        End Sub
        Shared Sub OnExceptionNotHandled(ByVal sender As Object, ByVal e As ServicesExceptionNotHandledEventArgs)
        End Sub
    End Class
    '***********************
    '* Snippets from Throw
    '***************
    ' <snippet178>
    Partial Public NotInheritable Class ThrowWorkflow
        Inherits SequentialWorkflowActivity

        <System.Diagnostics.DebuggerNonUserCode()> _
                                            Private Sub InitializeComponent()

            ' <snippet179>
            Me.CanModifyActivities = True
            Dim activitybind1 As New System.Workflow.ComponentModel.ActivityBind()
            Me.throwActivity1 = New System.Workflow.ComponentModel.ThrowActivity()
            activitybind1.Name = "ThrowWorkflow"
            activitybind1.Path = "ThrownException"
            ' 
            ' throwActivity1
            ' 
            Me.throwActivity1.Name = "throwActivity1"
            Me.throwActivity1.SetBinding(System.Workflow.ComponentModel.ThrowActivity.FaultProperty, activitybind1)
            ' 
            ' ThrowWorkflow
            ' 
            Me.Activities.Add(Me.throwActivity1)
            Me.Name = "ThrowWorkflow"
            Me.CanModifyActivities = False
            ' </snippet179>

        End Sub

        Private thrownExceptionValue As New System.Exception("My Exception Message.")

        Public Property ThrownException() As Exception
            Get
                Return thrownExceptionValue
            End Get
            Set(ByVal value As Exception)
                thrownExceptionValue = value
            End Set
        End Property

        Private throwActivity1 As ThrowActivity

    End Class
    ' </snippet178>

    '*********************
    '* Snippets from WhileAndParallel
    '***************
    Class Snippets18
        Inherits SequentialWorkflowActivity


        Private Sub WhileCondition(ByVal sender As Object, ByVal e As ConditionalEventArgs)

        End Sub

        Private WhileLoop As New WhileActivity()
        Private Parallel As New ParallelActivity()
        Private Sequence1 As New SequenceActivity()
        Private ConsoleMessage1 As New CodeActivity()
        Private Sequence2 As New SequenceActivity()
        Private ConsoleMessage2 As New CodeActivity()
        Sub Container1()

            Dim codecondition1 As New System.Workflow.Activities.CodeCondition()

            ' <snippet180>
            ' <snippet181>
            ' <snippet182>
            Me.WhileLoop = New System.Workflow.Activities.WhileActivity()
            Me.Parallel = New System.Workflow.Activities.ParallelActivity()
            Me.Sequence1 = New System.Workflow.Activities.SequenceActivity()
            Me.Sequence2 = New System.Workflow.Activities.SequenceActivity()
            Me.ConsoleMessage1 = New System.Workflow.Activities.CodeActivity()
            Me.ConsoleMessage2 = New System.Workflow.Activities.CodeActivity()
            ' 
            ' WhileLoop
            ' 
            Me.WhileLoop.Activities.Add(Me.Parallel)
            AddHandler codecondition1.Condition, AddressOf Me.WhileCondition
            Me.WhileLoop.Condition = codecondition1
            Me.WhileLoop.Name = "WhileLoop"
            ' </snippet182>
            ' 
            ' Parallel
            ' 
            Me.Parallel.Activities.Add(Me.Sequence1)
            Me.Parallel.Activities.Add(Me.Sequence2)
            Me.Parallel.Name = "Parallel"
            ' </snippet181>
            ' 
            ' Sequence1
            ' 
            Me.Sequence1.Activities.Add(Me.ConsoleMessage1)
            Me.Sequence1.Name = "Sequence1"
            ' 
            ' Sequence2
            ' 
            Me.Sequence2.Activities.Add(Me.ConsoleMessage2)
            Me.Sequence2.Name = "Sequence2"
            ' </snippet180>
        End Sub

    End Class
End Namespace
