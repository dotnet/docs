using System;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Workflow.ComponentModel;

namespace WF_Snippets
{
    class Snippets38 : SequentialWorkflowActivity
    {
        void Container0()
        {
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();
            //Snippets from HostCommunication (missed in initial pass)
            //<snippet297>
            workflowRuntime.WorkflowStarted += OnWorkflowStarted;
            //</snippet297>
        }
        static void OnWorkflowStarted(object sender, WorkflowEventArgs e)
        { }
        // <snippet298>
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.createBallotCallExternalMethodActivity = new System.Workflow.Activities.CallExternalMethodActivity();
            this.waitForResponseListenActivity = new System.Workflow.Activities.ListenActivity();
            this.waitForApprovalEventDrivenActivity = new System.Workflow.Activities.EventDrivenActivity();
            this.waitForRejectionEventDrivenActivity = new System.Workflow.Activities.EventDrivenActivity();
            // <snippet299>
            this.approvedHandleExternalEventActivity = new System.Workflow.Activities.HandleExternalEventActivity();
            this.rejectedHandleExternalEventActivity = new System.Workflow.Activities.HandleExternalEventActivity();
            // </snippet299>
            // 
            // createBallotCallExternalMethodActivity
            // 
            this.createBallotCallExternalMethodActivity.InterfaceType = typeof(IVotingService);
            this.createBallotCallExternalMethodActivity.MethodName = "CreateBallot";
            this.createBallotCallExternalMethodActivity.Name = "createBallotCallExternalMethodActivity";
            activitybind1.Name = "VotingServiceWorkflow";
            activitybind1.Path = "Alias";
            workflowparameterbinding1.ParameterName = "alias";
            //<snippet300>
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            //</snippet300>
            //<snippet301>
            this.createBallotCallExternalMethodActivity.ParameterBindings.Add(workflowparameterbinding1);
            //</snippet301>
            // 
            // waitForResponseListenActivity
            // 
            this.waitForResponseListenActivity.Activities.Add(this.waitForApprovalEventDrivenActivity);
            this.waitForResponseListenActivity.Activities.Add(this.waitForRejectionEventDrivenActivity);
            this.waitForResponseListenActivity.Name = "waitForResponseListenActivity";
            // 
            // waitForApprovalEventDrivenActivity
            // 
            this.waitForApprovalEventDrivenActivity.Activities.Add(this.approvedHandleExternalEventActivity);
            this.waitForApprovalEventDrivenActivity.Name = "waitForApprovalEventDrivenActivity";
            // 
            // waitForRejectionEventDrivenActivity
            // 
            this.waitForRejectionEventDrivenActivity.Activities.Add(this.rejectedHandleExternalEventActivity);
            this.waitForRejectionEventDrivenActivity.Name = "waitForRejectionEventDrivenActivity";
            // 
            // approvedHandleExternalEventActivity
            // 
            // <snippet302>
            this.approvedHandleExternalEventActivity.EventName = "ApprovedProposal";
            this.approvedHandleExternalEventActivity.InterfaceType = typeof(IVotingService);
            this.approvedHandleExternalEventActivity.Name = "approvedHandleExternalEventActivity";
            //<snippet303>
            this.approvedHandleExternalEventActivity.Roles = null;
            //</snippet303>
            this.approvedHandleExternalEventActivity.Invoked += new System.EventHandler<ExternalDataEventArgs>(this.OnApproved);
            // </snippet302>
            // 
            // rejectedHandleExternalEventActivity
            // 
            // <snippet304>
            this.rejectedHandleExternalEventActivity.EventName = "RejectedProposal";
            this.rejectedHandleExternalEventActivity.InterfaceType = typeof(IVotingService);
            this.rejectedHandleExternalEventActivity.Name = "rejectedHandleExternalEventActivity";
            this.rejectedHandleExternalEventActivity.Roles = null;
            this.rejectedHandleExternalEventActivity.Invoked += new System.EventHandler<ExternalDataEventArgs>(this.OnRejected);
            // </snippet304>
            // 
            // VotingServiceWorkflow
            // 
            this.Activities.Add(this.createBallotCallExternalMethodActivity);
            this.Activities.Add(this.waitForResponseListenActivity);
            this.Name = "VotingServiceWorkflow";
            this.CanModifyActivities = false;
        }
        // </snippet298>
        private CallExternalMethodActivity createBallotCallExternalMethodActivity;
        private ListenActivity waitForResponseListenActivity;
        private EventDrivenActivity waitForApprovalEventDrivenActivity;
        private EventDrivenActivity waitForRejectionEventDrivenActivity;
        private HandleExternalEventActivity approvedHandleExternalEventActivity;
        private HandleExternalEventActivity rejectedHandleExternalEventActivity;

        internal interface IVotingService
        {
        }
        private void OnApproved(object sender, ExternalDataEventArgs e)
        { }
        private void OnRejected(object sender, ExternalDataEventArgs e)
        { }
        
        

        // <snippet305>
        [ExternalDataExchange]
        [CorrelationParameter("taskId")]
        public interface ITaskService
        {
            [CorrelationInitializer]
            void CreateTask(string taskId, string assignee, string text);

            [CorrelationAlias("taskId", "e.Id")]
            event EventHandler<TaskEventArgs> TaskCompleted;
        }
        // </snippet305>

        

        public class HelperClass {
            public int SomeProperty;    
        }

       
       // <snippet307>
       [RuleRead("helper/SomeProperty", RuleAttributeTarget.Parameter)]
       public void DoSomething(HelperClass helper)
       {
           int SomeInteger;
           SomeInteger = helper.SomeProperty;
       }
       // </snippet307>

       //Placeholder for the API_REFERENCE snippet I need to write
       //This one appears in  System.Workflow.Activities.Rules.RuleSet 
       int Boglot302 = 5; 
       

               
        //The HelperClass class is declared just above snippet 307     
        // <snippet309>
        [RuleWrite("helper/SomeProperty", RuleAttributeTarget.Parameter)]
        public void DoSomethingElse(HelperClass helper)
        {
            helper.SomeProperty = 3;
        }
        // </snippet309>
        
        
              
        [System.Diagnostics.DebuggerNonUserCode()]
        private void SecondInitializeComponent()
        {
            this.CanModifyActivities = true;
        // <snippet311>
            this.DiscontinuedProduct = new System.Workflow.Activities.CodeActivity();
                       
            this.DiscontinuedProduct.Name = "DiscontinuedProduct";
            this.DiscontinuedProduct.ExecuteCode += new System.EventHandler(this.DiscountedProductHandler);
        // </snippet311>
        }
                
        private CodeActivity DiscontinuedProduct;
        private void DiscountedProductHandler(object sender, EventArgs e)
        {
            Console.WriteLine("The product has been discontinued.");
        }

        // <snippet312>
        [ExternalDataExchange]
        [CorrelationParameter("taskId")]
        public interface ITaskService2
        {
            [CorrelationInitializer]
            void CreateTask(string taskId, string assignee, string text);

            [CorrelationAlias("taskId", "e.Id")]
            event EventHandler<TaskEventArgs> TaskCompleted;
        }
        // </snippet312>

    }

    // <snippet310>
    public partial class StateMachineWorkflow : StateMachineWorkflowActivity
    {
        public StateMachineWorkflow()
        {
            InitializeComponent();
        }

        private void Code1Handler(object sender, EventArgs e)
        {
            Console.WriteLine("In Start State. Transitioning to State 1");
        }

        private void Code2Handler(object sender, EventArgs e)
        {
            Console.WriteLine("In State 1. Transitioning to Completed State");
        }
    }
    // </snippet310>


}
