using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.Activities;
using System.Workflow.Runtime;
using System.Threading;
using System.Workflow.ComponentModel;
using System.ComponentModel;

namespace WF_Snippets
{
    /****************************
     * Snippets from Technologies/BasicWorkflows and Technologies/Communication
     */


    /****************
     * Snippets from BasicWorkflows/SimpleStateMachineWorkflow
     */

    //The StateMachineWorkflow class is now defined in Snippets38.cs

    // <snippet183>
    public partial class StateMachineWorkflow
    {
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            // <snippet184>
            this.CanModifyActivities = true;
            this.setCompletedState = new System.Workflow.Activities.SetStateActivity();
            this.code2 = new System.Workflow.Activities.CodeActivity();
            // <snippet185>
            this.state1Delay = new System.Workflow.Activities.DelayActivity();
            // </snippet185>
            // <snippet186>
            this.setState1 = new System.Workflow.Activities.SetStateActivity();
            // </snippet186>
            this.code1 = new System.Workflow.Activities.CodeActivity();
            this.startStateDelay = new System.Workflow.Activities.DelayActivity();
            this.eventDriven2 = new System.Workflow.Activities.EventDrivenActivity();
            // <snippet187>
            this.eventDriven1 = new System.Workflow.Activities.EventDrivenActivity();
            // </snippet187>
            this.CompletedState = new System.Workflow.Activities.StateActivity();
            this.state1 = new System.Workflow.Activities.StateActivity();
            // <snippet188>
            this.StartState = new System.Workflow.Activities.StateActivity();
            // </snippet188>
            // 
            // setCompletedState
            //
            // <snippet189> 
            this.setCompletedState.Name = "setCompletedState";
            this.setCompletedState.TargetStateName = "CompletedState";
            // </snippet189>
            // 
            // code2
            // 
            this.code2.Name = "code2";
            this.code2.ExecuteCode += new System.EventHandler(this.Code2Handler);
            // 
            // state1Delay
            //
            // <snippet190> 
            this.state1Delay.Name = "state1Delay";
            this.state1Delay.TimeoutDuration = System.TimeSpan.Parse("00:00:02");
            // </snippet190>
            // 
            // setState1
            // 
            this.setState1.Name = "setState1";
            this.setState1.TargetStateName = "state1";
            // 
            // code1
            // 
            this.code1.Name = "code1";
            this.code1.ExecuteCode += new System.EventHandler(this.Code1Handler);
            // 
            // startStateDelay
            // 
            this.startStateDelay.Name = "startStateDelay";
            this.startStateDelay.TimeoutDuration = System.TimeSpan.Parse("00:00:05");
            // 
            // eventDriven2
            // 
            this.eventDriven2.Activities.Add(this.state1Delay);
            this.eventDriven2.Activities.Add(this.code2);
            this.eventDriven2.Activities.Add(this.setCompletedState);
            this.eventDriven2.Name = "eventDriven2";
            // 
            // eventDriven1
            // 
            this.eventDriven1.Activities.Add(this.startStateDelay);
            this.eventDriven1.Activities.Add(this.code1);
            this.eventDriven1.Activities.Add(this.setState1);
            this.eventDriven1.Name = "eventDriven1";
            // 
            // CompletedState
            // 
            this.CompletedState.Name = "CompletedState";
            // </snippet184>
            // 
            // state1
            // 
            this.state1.Activities.Add(this.eventDriven2);
            this.state1.Name = "state1";
            // 
            // StartState
            // 
            this.StartState.Activities.Add(this.eventDriven1);
            this.StartState.Name = "StartState";
            // 
            // StateMachineWorkflow
            // 
            // <snippet191>
            this.Activities.Add(this.StartState);
            this.Activities.Add(this.state1);
            this.Activities.Add(this.CompletedState);
            this.CompletedStateName = "CompletedState";
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "StartState";
            this.Name = "StateMachineWorkflow";
            this.CanModifyActivities = false;
            // </snippet191>
        }
        private StateActivity StartState;
        private EventDrivenActivity eventDriven1;
        private SetStateActivity setState1;
        private StateActivity state1;
        private EventDrivenActivity eventDriven2;
        private DelayActivity state1Delay;
        private SetStateActivity setCompletedState;
        private CodeActivity code1;
        private CodeActivity code2;
        private DelayActivity startStateDelay;
        private StateActivity CompletedState;
    }
    // </snippet183>

    /***************************
     * Snippets from BasicWorkflows/WorkflowWithParameters
     */
    class Snippets19 : SequentialWorkflowActivity
    {
        private IfElseActivity ifElseActivity = new IfElseActivity();
        private IfElseBranchActivity approveIfElseBranch = new IfElseBranchActivity();
        private IfElseBranchActivity rejecteIfElseBranch = new IfElseBranchActivity();
        private CodeActivity approve = new CodeActivity();
        private CodeActivity reject = new CodeActivity();
        static AutoResetEvent waitHandle = new AutoResetEvent(false);

        // <snippet192>
        static void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            //The order status is stored in the "status" "out" parameter
            string orderStatus = e.OutputParameters["Status"].ToString();
            Console.WriteLine("Order was " + orderStatus);
            waitHandle.Set();
        }
        // </snippet192>

        // <snippet193>
        static void OnWorkflowTerminated(object sender, WorkflowTerminatedEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
            waitHandle.Set();
        }
        // </snippet193>
        void container1()
        {
            // <snippet194>
            this.CanModifyActivities = true;
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            this.ifElseActivity = new System.Workflow.Activities.IfElseActivity();
            this.approveIfElseBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.rejecteIfElseBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.approve = new System.Workflow.Activities.CodeActivity();
            this.reject = new System.Workflow.Activities.CodeActivity();
            // 
            // ifElseActivity
            // 
            this.ifElseActivity.Activities.Add(this.approveIfElseBranch);
            this.ifElseActivity.Activities.Add(this.rejecteIfElseBranch);
            this.ifElseActivity.Name = "ifElseActivity";
            // </snippet194>
        }
    }
    /*************************
     * Snippets from Communication/CorrelatedLocalService
     */
    
    

    class Snippets20 : SequentialWorkflowActivity
    {
        private void OnTaskCompleted(object sender, EventArgs e)
        { }
        private TaskCompleted taskCompleted1 = new TaskCompleted();
        private TaskCompleted taskCompleted2 = new TaskCompleted();
        private CreateTask createTask1 = new CreateTask();
        private CreateTask createTask2 = new CreateTask();
        void container1()
        {
            //<snippet195>
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            //</snippet195>
            System.Workflow.Runtime.CorrelationToken correlationtoken2 = new System.Workflow.Runtime.CorrelationToken();
            //<snippet196>
            correlationtoken1.Name = "c2";
            //</snippet196>
            //<snippet197>
            correlationtoken1.OwnerActivityName = "sequence2";
            //</snippet197>
            //<snippet198>
            this.taskCompleted2.CorrelationToken = correlationtoken1;
            //</snippet198>
            //<snippet199>
            this.taskCompleted2.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.OnTaskCompleted);
            //</snippet199>
            //<snippet200>
            this.createTask2.CorrelationToken = correlationtoken1;
            //</snippet200>
            //<snippet201>
            this.taskCompleted1.CorrelationToken = correlationtoken2;
            //</snippet201>
            //<snippet202>
            this.taskCompleted1.EventName = "TaskCompleted";
            //</snippet202>
            //<snippet203>
            this.taskCompleted1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.OnTaskCompleted);
            //</snippet203>
            //<snippet204>
            this.createTask1.CorrelationToken = correlationtoken2;
            //</snippet204>
        }
    }
    // <snippet205>
    public partial class CreateTask : System.Workflow.Activities.CallExternalMethodActivity
    {
        // Properties on the task
        public static DependencyProperty AssigneeProperty = DependencyProperty.Register("Assignee", typeof(System.String), typeof(CreateTask));
        public static DependencyProperty TaskIdProperty = DependencyProperty.Register("TaskId", typeof(System.String), typeof(CreateTask));
        public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(System.String), typeof(CreateTask));

        private void InitializeComponent()
        {

        }

        public CreateTask()
        {
            // <snippet206>
            this.InterfaceType = typeof(ITaskService);
            this.MethodName = "CreateTask";
            // </snippet206>
        }

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        public string Assignee
        {
            get
            {
                return ((string)(base.GetValue(CreateTask.AssigneeProperty)));
            }
            set
            {
                base.SetValue(CreateTask.AssigneeProperty, value);
            }
        }

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        public string TaskId
        {
            get
            {
                return ((string)(base.GetValue(CreateTask.TaskIdProperty)));
            }
            set
            {
                base.SetValue(CreateTask.TaskIdProperty, value);
            }
        }

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        public string Text
        {
            get
            {
                return ((string)(base.GetValue(CreateTask.TextProperty)));
            }
            set
            {
                base.SetValue(CreateTask.TextProperty, value);
            }
        }
        //<snippet207>
        protected override void OnMethodInvoking(EventArgs e)
        {
            this.ParameterBindings["taskId"].Value = this.TaskId;
            this.ParameterBindings["assignee"].Value = this.Assignee;
            this.ParameterBindings["text"].Value = this.Text;
        }
        //</snippet207>

    }
    // </snippet205>
    [ExternalDataExchange]
    [CorrelationParameter("taskId")]
    public interface ITaskService
    { }
    class TaskCompleted : HandleExternalEventActivity
    {
        public TaskEventArgs EventArgs;
        //<snippet208>
        protected override void OnInvoked(EventArgs e)
        {
            EventArgs = e as TaskEventArgs;
        }
        //</snippet208>
    }
    class TaskEventArgs : EventArgs { }

    /**********************
     * Snippets from Communications/Listen
     */
    interface IOrderService { }


    // <snippet209>
    class OrderServiceImpl : IOrderService
    {
        // <snippet210>
        string orderId;
        public WorkflowInstance instanceId;
        // </snippet210>

        // Called by the workflow to pass an order id
        public void CreateOrder(string Id)
        {
            Console.WriteLine("\nPurchase Order Created in System");
            orderId = Id;
        }

        // Called by the host to approve an order
        // <snippet211>
        public void ApproveOrder()
        {
            EventHandler<OrderEventArgs> orderApproved = this.OrderApproved;
            if (orderApproved != null)
                orderApproved(null, new OrderEventArgs(instanceId.InstanceId, orderId));
        }
        // </snippet211>

        // Called by the host to reject an order
        public void RejectOrder()
        {
            EventHandler<OrderEventArgs> orderRejected = this.OrderRejected;
            if (orderRejected != null)
                orderRejected(null, new OrderEventArgs(instanceId.InstanceId, orderId));
        }

        // Events that handled within a workflow by HandleExternalEventActivity activities
        public event EventHandler<OrderEventArgs> OrderApproved;
        public event EventHandler<OrderEventArgs> OrderRejected;
    }
    // </snippet209>

    // <snippet212>
    class Program
    {
        static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static OrderServiceImpl orderService;

        static void Main()
        {
            orderService = new OrderServiceImpl();

            // Start the workflow runtime engine.
            using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                ExternalDataExchangeService dataService = new ExternalDataExchangeService();
                workflowRuntime.AddService(dataService);
                dataService.AddService(orderService);

                workflowRuntime.StartRuntime();

                // Listen for the workflow events
                workflowRuntime.WorkflowCompleted += OnWorkflowCompleted;
                workflowRuntime.WorkflowTerminated += OnWorkflowTerminated;
                workflowRuntime.WorkflowIdled += OnWorkflowIdled;

                // Start the workflow and wait for it to complete
                Type type = typeof(PurchaseOrderWorkflow);
                workflowRuntime.CreateWorkflow(type).Start();

                waitHandle.WaitOne();

                // Stop the workflow runtime engine.
                workflowRuntime.StopRuntime();
            }
        }

        // This method will be called when a workflow instance is idled
        static void OnWorkflowIdled(object sender, WorkflowEventArgs e)
        {
            orderService.instanceId = e.WorkflowInstance;

            // Randomly approve, reject or timeout purchase orders
            Random randGen = new Random();

            int pick = randGen.Next(1, 100) % 3;
            switch (pick)
            {
                case 0:
                    orderService.ApproveOrder();
                    break;
                case 1:
                    orderService.RejectOrder();
                    break;
                case 2:
                    // timeout
                    break;
            }
        }

        // This method will be called when a workflow instance is completed
        // waitHandle is set so the main thread can continue
        static void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            waitHandle.Set();
        }

        // This method is called when the workflow terminates and does not complete
        // This should not occur in this sample; however, it is good practice to include a
        // handler for this event so the host application can manage workflows that are
        // unexpectedly terminated (e.g. unhandled workflow exception).
        // waitHandle is set so the main thread can continue
        static void OnWorkflowTerminated(object sender, WorkflowTerminatedEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
            waitHandle.Set();
        }
    }
    // </snippet212>

    class PurchaseOrderWorkflow: SequentialWorkflowActivity
    {
        private void OnTimeout(object sender, EventArgs e)
        { }
        private void OnRejectPO(object sender, ExternalDataEventArgs e)
        { }
        private void OnApprovePO(object sender, ExternalDataEventArgs e)
        { }
        private void OnBeforeCreateOrder(object sender, EventArgs e)
        { }

    // <snippet213>
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            // <snippet214>
            this.CanModifyActivities = true;
            this.Timeout = new System.Workflow.Activities.CodeActivity();
            this.Delay = new System.Workflow.Activities.DelayActivity();
            this.RejectPO = new System.Workflow.Activities.HandleExternalEventActivity();
            this.ApprovePO = new System.Workflow.Activities.HandleExternalEventActivity();
            this.OnTimeoutEventDriven = new System.Workflow.Activities.EventDrivenActivity();
            this.OnOrderRejectedEventDriven = new System.Workflow.Activities.EventDrivenActivity();
            this.OnOrderApprovedEventDriven = new System.Workflow.Activities.EventDrivenActivity();
            this.POStatusListen = new System.Workflow.Activities.ListenActivity();
            this.CreatePO = new System.Workflow.Activities.CallExternalMethodActivity();
            // </snippet214>
            // 
            // Timeout
            // 
            this.Timeout.Name = "Timeout";
            this.Timeout.ExecuteCode += new System.EventHandler(this.OnTimeout);
            // 
            // Delay
            // 
            // <snippet215>
            this.Delay.Name = "Delay";
            this.Delay.TimeoutDuration = System.TimeSpan.Parse("00:00:05");
            // </snippet215>
            // 
            // RejectPO
            // 
            this.RejectPO.EventName = "OrderRejected";
            this.RejectPO.InterfaceType = typeof(IOrderService);
            this.RejectPO.Name = "RejectPO";
            this.RejectPO.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.OnRejectPO);
            // 
            // ApprovePO
            // 
            // <snippet216>
            this.ApprovePO.EventName = "OrderApproved";
            this.ApprovePO.InterfaceType = typeof(IOrderService);
            this.ApprovePO.Name = "ApprovePO";
            this.ApprovePO.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.OnApprovePO);
            // </snippet216> 
            // 
            // OnTimeoutEventDriven
            // 
            this.OnTimeoutEventDriven.Activities.Add(this.Delay);
            this.OnTimeoutEventDriven.Activities.Add(this.Timeout);
            this.OnTimeoutEventDriven.Name = "OnTimeoutEventDriven";
            // 
            // OnOrderRejectedEventDriven
            // 
            this.OnOrderRejectedEventDriven.Activities.Add(this.RejectPO);
            this.OnOrderRejectedEventDriven.Name = "OnOrderRejectedEventDriven";
            // 
            // OnOrderApprovedEventDriven
            // 
            this.OnOrderApprovedEventDriven.Activities.Add(this.ApprovePO);
            this.OnOrderApprovedEventDriven.Name = "OnOrderApprovedEventDriven";
            // 
            // POStatusListen
            // 
            this.POStatusListen.Activities.Add(this.OnOrderApprovedEventDriven);
            this.POStatusListen.Activities.Add(this.OnOrderRejectedEventDriven);
            this.POStatusListen.Activities.Add(this.OnTimeoutEventDriven);
            this.POStatusListen.Name = "POStatusListen";
            // 
            // CreatePO
            // 
            // <snippet217>
            this.CreatePO.InterfaceType = typeof(IOrderService);
            this.CreatePO.MethodName = "CreateOrder";
            this.CreatePO.Name = "CreatePO";
            this.CreatePO.MethodInvoking += new System.EventHandler(this.OnBeforeCreateOrder);
            // </snippet217>
            // 
            // PurchaseOrderWorkflow
            // 
            this.Activities.Add(this.CreatePO);
            this.Activities.Add(this.POStatusListen);
            this.Name = "PurchaseOrderWorkflow";
            this.CanModifyActivities = false;

        }
        // </snippet213>

        private HandleExternalEventActivity ApprovePO;
        private ListenActivity POStatusListen;
        private EventDrivenActivity OnOrderApprovedEventDriven;
        private EventDrivenActivity OnOrderRejectedEventDriven;
        private HandleExternalEventActivity RejectPO;
        private EventDrivenActivity OnTimeoutEventDriven;
        private DelayActivity Delay;
        private CodeActivity Timeout;
        private CallExternalMethodActivity CreatePO;
    }
    // <snippet218>
    [Serializable]
    public class OrderEventArgs1 : ExternalDataEventArgs
    {
        private string id;

        public OrderEventArgs1(Guid instanceId, string id)
            : base(instanceId)
        {
            this.id = id;
        }

        // Gets or sets an order id value
        // Sets by the workflow to pass an order id
        public string OrderId
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
    }
    // </snippet218>

    /**********************
     * Snippets from Communication/SimpleInput
     */

    public class Snippets22
    {
        //<snippet219>
        static void Submit(WorkflowInstance instance, string input)
        {
            instance.EnqueueItem("Queue", input, null, null);
        }
        //</snippet219>
    }

    /*************************
     * Snippets from Communication/WebService
     */

    public class Snippets23 : SequentialWorkflowActivity
    {
        private CodeActivity code1 = new CodeActivity();
        private InvokeWebServiceActivity invokeWebService1 = new InvokeWebServiceActivity();
        void container1()
        {
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            
            // <snippet220>
            this.invokeWebService1.MethodName = "CreateOrder";
            this.invokeWebService1.Name = "invokeWebService1";
            activitybind1.Name = "WebServiceInvokeWorkflow";
            activitybind1.Path = "POStatus";
            workflowparameterbinding1.ParameterName = "(ReturnValue)";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            activitybind2.Name = "WebServiceInvokeWorkflow";
            activitybind2.Path = "PurchaseOrderId";
            workflowparameterbinding2.ParameterName = "id";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.invokeWebService1.ParameterBindings.Add(workflowparameterbinding1);
            this.invokeWebService1.ParameterBindings.Add(workflowparameterbinding2);
            this.invokeWebService1.ProxyClass = typeof(WebServicePublishWorkflow_WebService);
            this.invokeWebService1.Invoking += new System.EventHandler<System.Workflow.Activities.InvokeWebServiceEventArgs>(this.OnWebServiceInvoking);
            // </snippet220>
        }
        private void OnWebServiceInvoking(object sender, EventArgs e)
        { }
    }
    public partial class WebServicePublishWorkflow_WebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
    }


}
