using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.Runtime;
using System.Workflow.ComponentModel;
using System.Workflow.Activities;
using System.Workflow.Runtime.Hosting;
using System.Threading;

namespace WF_Snippets
{
    /*******************
     * Snippets taken from Technology/Activities samples
     *******************/

    class snippets11
    {
        /*********************
         * Snippets from Activities/Compensation
         */

        private CompensateActivity CompensateRefund;
        private FaultHandlerActivity NoProductFaultHandler;
        private IfElseBranchActivity Available;
        private IfElseBranchActivity Discontinued;
        private CompensationHandlerActivity CompensateOrder;
        private CompensatableTransactionScopeActivity OrderScope;
        private ThrowActivity NoProductFault = new ThrowActivity();
        private CodeActivity DiscontinuedProduct = new CodeActivity();
        private CodeActivity Ship= new CodeActivity();
        private CodeActivity ReceiverOrder= new CodeActivity();

        void container1()
        {
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();
            //<snippet140>
            workflowRuntime.WorkflowCompleted += OnWorkflowCompleted;
            //</snippet140>
            
            //<snippet141>
            workflowRuntime.WorkflowAborted += OnWorkflowAborted;
            //</snippet141>
            //<snippet142>
            workflowRuntime.StopRuntime();
            //</snippet142>

            // <snippet143>
            //<snippet144>
            this.CompensateRefund = new System.Workflow.ComponentModel.CompensateActivity();
            //</snippet144>
            //<snippet145>
            this.NoProductFaultHandler = new System.Workflow.ComponentModel.FaultHandlerActivity();
            //</snippet145>
            // <snippet146>
            this.Discontinued = new System.Workflow.Activities.IfElseBranchActivity();
            this.Available = new System.Workflow.Activities.IfElseBranchActivity();
            // </snippet146>
            //<snippet147>
            this.CompensateOrder = new System.Workflow.ComponentModel.CompensationHandlerActivity();
            //</snippet147>
            // </snippet143>
            //<snippet148>
            this.OrderScope = new System.Workflow.ComponentModel.CompensatableTransactionScopeActivity();
            //</snippet148>
            //<snippet149>
            this.CompensateRefund.TargetActivityName = "OrderScope";
            //</snippet149>
            // <snippet150> 
            //<snippet151>
            this.NoProductFault.FaultType = typeof(DiscontinuedProductException);
            //</snippet151>
            this.NoProductFault.Name = "NoProductFault";
            this.NoProductFault.SetBinding(System.Workflow.ComponentModel.ThrowActivity.FaultProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // </snippet150>

            // <snippet152> 
            this.NoProductFaultHandler.Activities.Add(this.DiscontinuedProduct);
            this.NoProductFaultHandler.Activities.Add(this.CompensateRefund);
            this.NoProductFaultHandler.FaultType = typeof(DiscontinuedProductException);
            this.NoProductFaultHandler.Name = "NoProductFaultHandler";
            // </snippet152>

            // <snippet153>
            this.Available.Activities.Add(this.Ship);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.ProductCheckHandler);
            this.Available.Condition = codecondition1;
            this.Available.Name = "Available";
            // </snippet153>

            //<snippet154>
            this.OrderScope.TransactionOptions.IsolationLevel = System.Transactions.IsolationLevel.Serializable;
            //</snippet154>

            // <snippet155> 
            this.ReceiverOrder.Name = "ReceiverOrder";
            this.ReceiverOrder.ExecuteCode += new System.EventHandler(this.ReceiveOrderHandler);
            // </snippet155>
        }
        static void OnWorkflowAborted(object sender, WorkflowEventArgs e)
        {
        }

        static void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
        }
        class DiscontinuedProductException { }
        private void ProductCheckHandler(object sender, ConditionalEventArgs e)
        {
        }
        private void ReceiveOrderHandler(object sender, EventArgs e)
        {
        }
    }
    /*******************
     * Snippets from Activities/SimpleCAG
     */
    class Snippets12 : SequentialWorkflowActivity
    {
        // <snippet156>
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            // <snippet157>
            // <snippet158>
            this.CanModifyActivities = true;
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition2 = new System.Workflow.Activities.CodeCondition();
            this.BookingCag = new System.Workflow.Activities.ConditionedActivityGroup();
            this.Car = new System.Workflow.Activities.CodeActivity();
            this.Airline = new System.Workflow.Activities.CodeActivity();
            // </snippet157>
            // 
            // BookingCag
            //
            // <snippet159> 
            this.BookingCag.Activities.Add(this.Car);
            this.BookingCag.Activities.Add(this.Airline);
            this.BookingCag.Name = "BookingCag";
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.CarCondition);
            // </snippet159>
            // 
            // Car
            // 
            // <snippet160>
            this.Car.Name = "Car";
            this.Car.ExecuteCode += new System.EventHandler(this.Car_ExecuteCode);
            this.Car.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, codecondition1);
            codecondition2.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.AirlineCondition);
            // </snippet158>
            // </snippet160>
            // 
            // Airline
            // 
            this.Airline.Name = "Airline";
            this.Airline.ExecuteCode += new System.EventHandler(this.Airline_ExecuteCode);
            this.Airline.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, codecondition2);
            // 
            // SimpleConditionedActivityGroupWorkflow
            // 
            this.Activities.Add(this.BookingCag);
            this.Name = "SimpleConditionedActivityGroupWorkflow";
            this.CanModifyActivities = false;

        }
        // </snippet156>

        private ConditionedActivityGroup BookingCag;
        private CodeActivity Car;
        private CodeActivity Airline;
        private void Airline_ExecuteCode(object sender, EventArgs e)
        {
        }
        private void Car_ExecuteCode(object sender, EventArgs e)
        { }

        private void CarCondition(object sender, ConditionalEventArgs e)
        {
        }

        private void AirlineCondition(object sender, ConditionalEventArgs e)
        {
        }
    }

    /**********************
     * Snippets from Activities/NestedExceptions
     */
    class Snippets13 : SequentialWorkflowActivity
    {
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        private SynchronizationScopeActivity synchronizationScopeActivity = new SynchronizationScopeActivity();
        private CodeActivity throwsException = new CodeActivity();
        void container1()
        {
            //<snippet161>
            // A workflow is always run asychronously; the main thread waits on this event so the program
            // doesn't exit before the workflow completes
            workflowRuntime.AddService(new SqlWorkflowPersistenceService("Initial Catalog=SqlPersistenceService;Data Source=localhost;Integrated Security=SSPI;"));
            //</snippet161>

            //<snippet162>
            this.synchronizationScopeActivity = new System.Workflow.ComponentModel.SynchronizationScopeActivity();
            //</snippet162>

            //<snippet163>
            this.synchronizationScopeActivity.Activities.Add(this.throwsException);
            this.synchronizationScopeActivity.Name = "synchronizationScopeActivity";
            this.synchronizationScopeActivity.SynchronizationHandles = null;
            //</snippet163>
        }
    }
    /***********************
     * Snippet from AdvancedPolicy
     */
    // <snippet164>
    public sealed partial class DiscountPolicyWorkflow
    {
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.Activities.Rules.RuleSetReference rulesetreference1 = new System.Workflow.Activities.Rules.RuleSetReference();
            this.advancedDiscountPolicy = new System.Workflow.Activities.PolicyActivity();
            // 
            // advancedDiscountPolicy
            // 
            this.advancedDiscountPolicy.Name = "advancedDiscountPolicy";
            rulesetreference1.RuleSetName = "DiscountRuleSet";
            this.advancedDiscountPolicy.RuleSetReference = rulesetreference1;
            // 
            // DiscountPolicyWorkflow
            // 
            this.Activities.Add(this.advancedDiscountPolicy);
            this.Name = "DiscountPolicyWorkflow";
            this.Completed += new System.EventHandler(this.WorkflowCompleted);
            this.CanModifyActivities = false;

        }

        private PolicyActivity advancedDiscountPolicy;
    }
    // </snippet164>
    public sealed partial class DiscountPolicyWorkflow : SequentialWorkflowActivity
    {
        private void WorkflowCompleted(object sender, EventArgs e)
        { }
    }
    /**********************
     * Snippets from SimpleReplicator
     */

    // <snippet165>

    public sealed partial class SimpleReplicatorWorkflow : SequentialWorkflowActivity
    {
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            // <snippet166>
            System.Workflow.ComponentModel.ActivityBind activityBind1 = new System.Workflow.ComponentModel.ActivityBind();
            this.SampleReplicatorChildActivity1 = new SampleReplicatorChildActivity();
            this.ReplicatorWork = new System.Workflow.Activities.ReplicatorActivity();
            // 
            // SampleReplicatorChildActivity1
            // 
            this.SampleReplicatorChildActivity1.InstanceData = null;
            this.SampleReplicatorChildActivity1.Name = "SampleReplicatorChildActivity1";
            activityBind1.Name = "SimpleReplicatorWorkflow";
            activityBind1.Path = "ChildData";
            // 
            // ReplicatorWork
            // 
            // <snippet167>
            this.ReplicatorWork.Activities.Add(this.SampleReplicatorChildActivity1);
            //<snippet168>
            this.ReplicatorWork.ExecutionType = System.Workflow.Activities.ExecutionType.Sequence;
            //</snippet168>
            this.ReplicatorWork.Name = "ReplicatorWork";
            this.ReplicatorWork.ChildInitialized += new System.EventHandler<System.Workflow.Activities.ReplicatorChildEventArgs>(this.ChildInitializer);
            this.ReplicatorWork.SetBinding(System.Workflow.Activities.ReplicatorActivity.InitialChildDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activityBind1)));
            // </snippet167>
            // </snippet166>
            // 
            // SimpleReplicatorWorkflow
            // 
            this.Activities.Add(this.ReplicatorWork);
            this.Name = "SimpleReplicatorWorkflow";
            this.CanModifyActivities = false;

        }

        private SampleReplicatorChildActivity SampleReplicatorChildActivity1;
        private ReplicatorActivity ReplicatorWork;
    }

// </snippet165>
    class SampleReplicatorChildActivity : Activity 
    {
        public string InstanceData = "";
    }
    public partial class SimpleReplicatorWorkflow : SequentialWorkflowActivity
    {
        private void ChildInitializer(object sender, ReplicatorChildEventArgs args)
        { }
    }

    /************************
     * Snippets from StateInitialization
     */
    class Snippets15
    {
        StateInitializationActivity stateInitialization = new StateInitializationActivity();
        void container1()
        {
            //<snippet169>
            this.stateInitialization = new System.Workflow.Activities.StateInitializationActivity();
            //</snippet169>
        }
    }
    /********************
     * Snippets from SuspendAndTerminate
     */
    class Snippets16 : SequentialWorkflowActivity
    {
        static AutoResetEvent waitHandle = new AutoResetEvent(false);
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        bool workflowSuspended = true;
        WorkflowInstance workflowInstance;
        private SuspendActivity suspend = new SuspendActivity();
        private CodeActivity consoleMessage = new CodeActivity();
        private TerminateActivity terminate = new TerminateActivity();
        private void OnConsoleMessage(object sender, EventArgs e)
        { }
        void container1()
        {
            // Load the workflow type.
            Type type = typeof(SuspendAndTerminateWorkflow);
            workflowInstance = workflowRuntime.CreateWorkflow(type);

            //<snippet170>
            workflowRuntime.WorkflowSuspended += OnWorkflowSuspend;
            //</snippet170>
            //<snippet171>
            workflowRuntime.WorkflowResumed += OnWorkflowResume;
            //</snippet171>
            

            //<snippet172>
            if (workflowSuspended)
            {
                Console.WriteLine("\r\nResuming Workflow Instance");
                workflowInstance.Resume();
                waitHandle.WaitOne();
            }
            //</snippet172>
        }
        // <snippet173>
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            // <snippet174>
            this.CanModifyActivities = true;
            this.suspend = new System.Workflow.ComponentModel.SuspendActivity();
            this.consoleMessage = new System.Workflow.Activities.CodeActivity();
            this.terminate = new System.Workflow.ComponentModel.TerminateActivity();
            // </snippet174>
            // <snippet175>
            // 
            // suspend
            // 
            this.suspend.Error = null;
            this.suspend.Name = "suspend";
            // 
            // ConsoleMessage
            // 
            this.consoleMessage.Name = "consoleMessage";
            this.consoleMessage.ExecuteCode += new System.EventHandler(this.OnConsoleMessage);
            // 
            // terminate
            // 
            //<snippet176>
            this.terminate.Error = null;
            //</snippet176>
            this.terminate.Name = "terminate";
            // </snippet175>
            // 
            // SuspendAndTerminateWorkflow
            // 
            this.Activities.Add(this.suspend);
            this.Activities.Add(this.consoleMessage);
            this.Activities.Add(this.terminate);
            this.Name = "SuspendAndTerminateWorkflow";
            this.CanModifyActivities = false;
        }

        // </snippet173>
        static void OnWorkflowSuspend(object sender, WorkflowSuspendedEventArgs instance)
        {
        }
        static void OnWorkflowResume(object sender, WorkflowEventArgs instance)
        {
        }

        static void OnWorkflowTerminate(object sender, WorkflowTerminatedEventArgs instance)
        {
        }
    }
    class SuspendAndTerminateWorkflow : SequentialWorkflowActivity { }
    /*******************
     * Snippets from Synchronized
     */
    class Snippets17
    {
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        void container1()
        {

            //<snippet177>
            workflowRuntime.ServicesExceptionNotHandled += OnExceptionNotHandled;
            //</snippet177>
        }
        static void OnExceptionNotHandled(object sender, ServicesExceptionNotHandledEventArgs e)
        { }
    }
    /************************
     * Snippets from Throw
     */
    // <snippet178>
    public sealed partial class ThrowWorkflow : SequentialWorkflowActivity
    {
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            // <snippet179>
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            this.throwActivity1 = new System.Workflow.ComponentModel.ThrowActivity();
            activitybind1.Name = "ThrowWorkflow";
            activitybind1.Path = "ThrownException";
            // 
            // throwActivity1
            // 
            this.throwActivity1.Name = "throwActivity1";
            this.throwActivity1.SetBinding(System.Workflow.ComponentModel.ThrowActivity.FaultProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // ThrowWorkflow
            // 
            this.Activities.Add(this.throwActivity1);
            this.Name = "ThrowWorkflow";
            this.CanModifyActivities = false;
            // </snippet179>

        }

        private Exception thrownExceptionValue = new System.Exception("My Exception Message.");

        public Exception ThrownException
        {
            get { return thrownExceptionValue; }
            set { thrownExceptionValue = value; }
        }

        private ThrowActivity throwActivity1;

    }
    // </snippet178>

    /**********************
     * Snippets from WhileAndParallel
     */
    class Snippets18 : SequentialWorkflowActivity
    {
        private void WhileCondition(object sender, ConditionalEventArgs e)
        { }
        private WhileActivity WhileLoop = new WhileActivity();
        private ParallelActivity Parallel = new ParallelActivity();
        private SequenceActivity Sequence1 = new SequenceActivity();
        private CodeActivity ConsoleMessage1 = new CodeActivity();
        private SequenceActivity Sequence2 = new SequenceActivity();
        private CodeActivity ConsoleMessage2 = new CodeActivity();
        void Container1()
        {
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            
            // <snippet180>
            // <snippet181>
            // <snippet182>
            this.WhileLoop = new System.Workflow.Activities.WhileActivity();
            this.Parallel = new System.Workflow.Activities.ParallelActivity();
            this.Sequence1 = new System.Workflow.Activities.SequenceActivity();
            this.Sequence2 = new System.Workflow.Activities.SequenceActivity();
            this.ConsoleMessage1 = new System.Workflow.Activities.CodeActivity();
            this.ConsoleMessage2 = new System.Workflow.Activities.CodeActivity();
            // 
            // WhileLoop
            // 
            this.WhileLoop.Activities.Add(this.Parallel);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.WhileCondition);
            this.WhileLoop.Condition = codecondition1;
            this.WhileLoop.Name = "WhileLoop";
            // </snippet182>
            // 
            // Parallel
            // 
            this.Parallel.Activities.Add(this.Sequence1);
            this.Parallel.Activities.Add(this.Sequence2);
            this.Parallel.Name = "Parallel";
            // </snippet181>
            // 
            // Sequence1
            // 
            this.Sequence1.Activities.Add(this.ConsoleMessage1);
            this.Sequence1.Name = "Sequence1";
            // 
            // Sequence2
            // 
            this.Sequence2.Activities.Add(this.ConsoleMessage2);
            this.Sequence2.Name = "Sequence2";
            // </snippet180>
        }

    }
}
