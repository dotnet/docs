using System;

using System.Collections.ObjectModel;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel.Compiler;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Core;
using System.Xml;
using System.IO;
using System.ComponentModel.Design;
using System.Workflow.ComponentModel.Design;
using System.Drawing;
using System.Workflow.Runtime.Tracking;
using System.Threading;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;




namespace WF_Snippets
{
    //Snippets1.cs:  New home for snippets taken from Workflow Application Samples for Windows Workflow Foundation API pages
    /*
     * Snippets from OrderingStateMachine
     */

    class snippets1
    {

        private HandleExternalEventActivity handleExternalEventActivity1;
        private SetStateActivity setOrderOpenState;
        System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();

        WorkflowRuntime runtime;
        private void StartWorkflowRuntime()
        {
            
            OrderService orderService;
            //<snippet81>
            // Create a new Workflow Runtime for this application
            runtime = new WorkflowRuntime();
            //</snippet81>
            // Create EventHandlers for the WorkflowRuntime
            runtime.WorkflowTerminated += new EventHandler<WorkflowTerminatedEventArgs>(Runtime_WorkflowTerminated);
            runtime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(Runtime_WorkflowCompleted);
            runtime.WorkflowIdled += new EventHandler<WorkflowEventArgs>(Runtime_WorkflowIdled);
            //<snippet82>
            // Add the External Data Exchange Service
            ExternalDataExchangeService dataExchangeService = new ExternalDataExchangeService();
            runtime.AddService(dataExchangeService);

            // Add a new instance of the OrderService to the External Data Exchange Service
            orderService = new OrderService();
            dataExchangeService.AddService(orderService);
            //</snippet82>

            // Start the Workflow services
            runtime.StartRuntime();
        }
        public class OrderService { }
        void Runtime_WorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
        }

        void Runtime_WorkflowTerminated(object sender, WorkflowTerminatedEventArgs e)
        {
        }
        void Runtime_WorkflowIdled(object sender, WorkflowEventArgs e)
        {
        }
        public class Workflow1 : SequentialWorkflowActivity { }

        void Container1()
        {
            Type workflowType = typeof(Workflow1);
            WorkflowInstance instance = runtime.CreateWorkflow(workflowType);

            //<snippet83>
            StateMachineWorkflowInstance stateMachineInstance = new StateMachineWorkflowInstance(runtime, instance.InstanceId);
            //</snippet83>
            //<snippet84>
            instance.Start();
            //</snippet84>
            
            //<snippet85>
            ReadOnlyCollection<WorkflowQueueInfo> subActivities = stateMachineInstance.WorkflowInstance.GetWorkflowQueueData();
            //</snippet85>

            //<snippet86>
            // Get a reference to the root activity for the workflow
            Activity root = instance.GetWorkflowDefinition();
            //</snippet86>

            //<snippet87>
            //<snippet88>
            // Create a new instance of the WorkflowChanges class for managing
            // the in-memory changes to the workflow
            WorkflowChanges changes = new WorkflowChanges(root);
            //</snippet87>

            // Create a new State activity to the workflow
            StateActivity orderOnHoldState = new StateActivity();
            orderOnHoldState.Name = "OrderOnHoldState";

            // Add a new EventDriven activity to the State
            EventDrivenActivity eventDrivenDelay = new EventDrivenActivity();
            eventDrivenDelay.Name = "DelayOrderEvent";
            orderOnHoldState.Activities.Add(eventDrivenDelay);

            // Add a new Delay, initialized to 5 seconds
            DelayActivity delayOrder = new DelayActivity();
            delayOrder.Name = "delayOrder";
            delayOrder.TimeoutDuration = new TimeSpan(0, 0, 5);
            eventDrivenDelay.Activities.Add(delayOrder);

            // Add a new SetState to the OrderOpenState
            SetStateActivity setStateOrderOpen = new SetStateActivity();
            setStateOrderOpen.TargetStateName = "OrderOpenState";
            eventDrivenDelay.Activities.Add(setStateOrderOpen);

            // Add the OnHoldState to the workflow
            changes.TransientWorkflow.Activities.Add(orderOnHoldState);
            //</snippet88>

            //<snippet89>
            // Apply the changes to the workflow instance
            try
            {
                instance.ApplyWorkflowChanges(changes);
            }
            catch (WorkflowValidationFailedException)
            {
                // New state has already been added
                MessageBox.Show("On Hold state has already been added to this workflow.");
            }
            //</snippet89>

            //<snippet90>
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            //</snippet90>

            //<snippet91>
            this.handleExternalEventActivity1 = new System.Workflow.Activities.HandleExternalEventActivity();
            //</snippet91>

            //<snippet92>
            this.setOrderOpenState = new System.Workflow.Activities.SetStateActivity();
            //</snippet92>

            //<snippet93>
            this.handleExternalEventActivity1.InterfaceType = typeof(IOrderService);
            //</snippet93>

            //<snippet94>
            workflowparameterbinding1.ParameterName = "sender";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.handleExternalEventActivity1.ParameterBindings.Add(workflowparameterbinding1);
            //</snippet94>

        }
    }
    public sealed class SampleWorkflow : StateMachineWorkflowActivity
    {
        public SampleWorkflow()
        {
            //<snippet95>
            this.DynamicUpdateCondition = null;
            //</snippet95>
        }
    }
    //<snippet96>
    public class OrderEventArgs : ExternalDataEventArgs
    {
        private string orderIdValue;

        public OrderEventArgs(Guid instanceId, string orderId)
            : base(instanceId)
        {
            orderIdValue = orderId;
        }

        public string OrderId
        {
            get { return orderIdValue; }
            set { orderIdValue = value; }
        }
    }
    //</snippet96>

    /******************
     * Snippets from OutlookWorkflowWizard
     */

    public class snippets2
    {
        string xamlFile = "";
        void Container2()
        {
            string xamlFile = string.Empty;
            Activity service = new Activity();
            using (XmlWriter writer = XmlWriter.Create(this.xamlFile))
            {
                // <snippet97>
                WorkflowMarkupSerializer xamlSerializer = new WorkflowMarkupSerializer();
                xamlSerializer.Serialize(writer, service);
                // </snippet97>
            }
        }
    }
    public partial class AutoReplyEmail : Activity
    {
        //<snippet98>
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
        {
            // Create an Outlook Application object. 
            Outlook.Application outlookApp = new Outlook.Application();

            Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
            oMailItem.To = outlookApp.Session.CurrentUser.Address;
            oMailItem.Subject = "Auto-Reply";
            oMailItem.Body = "Out of Office";

            //adds it to the outbox  
            if (this.Parent.Parent is ParallelActivity)
            {
                if ((this.Parent.Parent.Parent.Activities[1] as DummyActivity).TitleProperty != "")
                {
                    MessageBox.Show("Process Auto-Reply for Email");
                    oMailItem.Send();
                }
            }
            else if (this.Parent.Parent is SequentialWorkflowActivity)
            {
                if ((this.Parent.Parent.Activities[1] as DummyActivity).TitleProperty != "")
                {
                    MessageBox.Show("Process Auto-Reply for Email");
                    oMailItem.Send();
                }
            }
            return ActivityExecutionStatus.Closed;
        }
        //</snippet98>
        public class DummyActivity : Activity
        {
            public string TitleProperty;
        }
        string xamlFile = "";
        WorkflowCompilerResults results;
        void Container2()
        {
            // <snippet99>
            // Compile the workflow
            String[] assemblyNames = { "ReadEmailActivity.dll" };
            WorkflowCompiler compiler = new WorkflowCompiler();
            WorkflowCompilerParameters parameters = new WorkflowCompilerParameters(assemblyNames);
            parameters.LibraryPaths.Add(Path.GetDirectoryName(typeof(BaseMailbox).Assembly.Location));
            parameters.OutputAssembly = "CustomOutlookWorkflow" + Guid.NewGuid().ToString() + ".dll";
            results = compiler.Compile(parameters, this.xamlFile);
            // </snippet99>
        }
        public class BaseMailbox { }
        void Container3()
        {
            //<snippet100>
            // Start the runtime engine
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();
            workflowRuntime.StartRuntime();
            //</snippet100>
            // Add workflow event handlers
            workflowRuntime.WorkflowCompleted += OnWorkflowCompleted;
            //<snippet101>
            // Start the workflow
            workflowRuntime.CreateWorkflow(results.CompiledAssembly.GetType(this.GetType().Namespace + ".CustomOutlookWorkflow")).Start();
            //</snippet101>
        }
        private void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs e) { }
    }
    public class WorkflowViewWrapper : System.Windows.Forms.Panel
    {
        private Loader loader;
        private DesignSurface surface;
        internal IDesignerHost Host;
        internal SequentialWorkflowActivity SequentialWorkflow;
        private WorkflowView workflowView;

        // <snippet102>
        public WorkflowViewWrapper()
        {
            // <snippet103>
            this.loader = new Loader();

            // Create a Workflow Design Surface
            this.surface = new DesignSurface();
            this.surface.BeginLoad(this.loader);

            // Get the Workflow Designer Host
            this.Host = this.surface.GetService(typeof(IDesignerHost)) as IDesignerHost;

            if (this.Host == null)
                return;

            // Create a Sequential Workflow by using the Workflow Designer Host
            SequentialWorkflow = (SequentialWorkflowActivity)Host.CreateComponent(typeof(SequentialWorkflowActivity));
            SequentialWorkflow.Name = "CustomOutlookWorkflow";

            // Create a Workflow View on the Workflow Design Surface
            this.workflowView = new WorkflowView(this.surface as IServiceProvider);
            // </snippet103>

            // Add a message filter to the workflow view, to support panning
            MessageFilter filter = new MessageFilter(this.surface as IServiceProvider, this.workflowView);
            this.workflowView.AddDesignerMessageFilter(filter);

            // Activate the Workflow View
            this.Host.Activate();

            this.workflowView.Dock = DockStyle.Fill;
            this.Controls.Add(workflowView);
            this.Dock = DockStyle.Fill;
        }
        // </snippet102>
        public class Loader : WorkflowDesignerLoader 
        {
            public override TextReader GetFileReader(string file)
            {
                return null;
            }
            public override TextWriter GetFileWriter(string file)
            {
                return null;
            }
            private string xamlFile = string.Empty;

            public override string FileName
            {
                get
                {
                    return this.xamlFile;
                }
            }
        }
        // <snippet104>
        internal sealed class MessageFilter : WorkflowDesignerMessageFilter
        {
            private bool mouseDown;
            private IServiceProvider serviceProvider;
            private WorkflowView workflowView;

            public MessageFilter(IServiceProvider provider, WorkflowView view)
            {
                this.serviceProvider = provider;
                this.workflowView = view;
            }

            protected override bool OnMouseDown(MouseEventArgs eventArgs)
            {
                // Allow other components to process this event by not returning true.
                this.mouseDown = true;
                return false;
            }
            //<snippet105>
            protected override bool OnMouseMove(MouseEventArgs eventArgs)
            {
                // Allow other components to process this event by not returning true.
                if (this.mouseDown)
                {
                    this.workflowView.ScrollPosition = new Point(eventArgs.X, eventArgs.Y);
                }
                return false;
            }
            //</snippet105>
            protected override bool OnMouseUp(MouseEventArgs eventArgs)
            {
                // Allow other components to process this event by not returning true.
                this.mouseDown = false;
                return false;
            }

            protected override bool OnMouseDoubleClick(MouseEventArgs eventArgs)
            {
                this.mouseDown = false;
                return true;
            }

            protected override bool OnMouseEnter(MouseEventArgs eventArgs)
            {
                // Allow other components to process this event by not returning true.
                this.mouseDown = false;
                return false;
            }

            protected override bool OnMouseHover(MouseEventArgs eventArgs)
            {
                // Allow other components to process this event by not returning true.
                this.mouseDown = false;
                return false;
            }

            protected override bool OnMouseLeave()
            {
                // Allow other components to process this event by not returning true.
                this.mouseDown = false;
                return false;
            }

            protected override bool OnMouseWheel(MouseEventArgs eventArgs)
            {
                this.mouseDown = false;
                return true;
            }

            protected override bool OnMouseCaptureChanged()
            {
                // Allow other components to process this event by not returning true.
                this.mouseDown = false;
                return false;
            }

            protected override bool OnDragEnter(DragEventArgs eventArgs)
            {
                return true;
            }

            protected override bool OnDragOver(DragEventArgs eventArgs)
            {
                return true;
            }

            protected override bool OnDragLeave()
            {
                return true;
            }

            protected override bool OnDragDrop(DragEventArgs eventArgs)
            {
                return true;
            }

            protected override bool OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
            {
                return true;
            }

            protected override bool OnQueryContinueDrag(QueryContinueDragEventArgs qcdevent)
            {
                return true;
            }

            protected override bool OnKeyUp(KeyEventArgs eventArgs)
            {
                return true;
            }

            protected override bool OnShowContextMenu(Point menuPoint)
            {
                return true;
            }

            protected override bool OnKeyDown(KeyEventArgs eventArgs)
            {
                if (eventArgs.KeyCode == Keys.Delete)
                {
                    ISelectionService selectionService = (ISelectionService)this.serviceProvider.GetService(typeof(ISelectionService));
                    if (selectionService != null && selectionService.PrimarySelection is CodeActivity)
                    {
                        CodeActivity codeActivityComponent = (CodeActivity)selectionService.PrimarySelection;
                        CompositeActivity parentActivity = codeActivityComponent.Parent;
                        if (parentActivity != null)
                        {
                            parentActivity.Activities.Remove(codeActivityComponent);
                            this.ParentView.Update();
                        }
                    }
                }
                return true;
            }
        }
        // </snippet104>
    }

    /********************
     * Snippets from SpeechApplication
     */

    class Snippets3 
    {
        private CallExternalMethodActivity sequentialSubMenu_SendSequentialTextToMenu = new CallExternalMethodActivity();
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        void Container1()
        {
            //<snippet106>
            // Create EventHandlers for the WorkflowRuntime
            workflowRuntime.WorkflowTerminated += new EventHandler<WorkflowTerminatedEventArgs>(WorkflowRuntime_WorkflowTerminated);
            //</snippet106>

            //<snippet107>
            // Add an instance of the External Data Exchange Service
            ExternalDataExchangeService externalDataExchangeService = new ExternalDataExchangeService();
            workflowRuntime.AddService(externalDataExchangeService);
            //</snippet107>
        }
        //<snippet108>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.workflowRuntime.Dispose();
        }
        //</snippet108>
        void Container2()
        {
            //<snippet109>
            this.sequentialSubMenu_SendSequentialTextToMenu.InterfaceType = typeof(Microsoft.Samples.Workflow.SpeechApplication.ISpeechService);
            //</snippet109>
            //<snippet110>
            this.sequentialSubMenu_SendSequentialTextToMenu.MethodName = "SendMenuText";
            //</snippet110>
        }
        void WorkflowRuntime_WorkflowTerminated(object sender, WorkflowTerminatedEventArgs e)
        {
        }
    }
    /***********************
     * Snippets from TerminationTrackingService
     */

    class Snippets4 //Snippets from TerminationTrackingService
    {
        const string eventSource = "TerminationTrackingService";
        void Container1()
        {
            //<snippet111>
            using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("EventSource", eventSource);

                workflowRuntime.AddService(new TerminationTrackingService(parameters));
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) { waitHandle.Set(); };
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };

                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(SampleWorkflow));
                instance.Start();

                waitHandle.WaitOne();
            }
            //</snippet111>
        }
    }

    
    class TerminationTrackingService : TrackingService 
    {
        private string source = "TerminationTrackingService";
        public TerminationTrackingService(NameValueCollection parameters)
        {
        }
        private void ValidateEventLogSource(string source)
        {
        }
       
        //<snippet112>
        protected override void Start()
        {
            base.Start();
            //
            // This will throw if we are invalid to inform the host immediately
            ValidateEventLogSource(source);
        }
        //</snippet112>

        //<snippet113>
        /// <summary>
        /// Returns a tracking channel that will receive instnce terminated events.
        /// </summary>
        protected override TrackingChannel GetTrackingChannel(TrackingParameters parameters)
        {
            return new TerminationTrackingChannel(parameters, source);
        }
        //</snippet113>

        //<snippet114>
        /// <summary>
        /// Returns a static tracking profile that only tracks instance terminated events.
        /// </summary>
        protected override bool TryGetProfile(Type workflowType, out TrackingProfile profile)
        {
            profile = GetProfile();
            return true;
        }
        //</snippet114>

        //<snippet115>
        /// <summary>
        /// Returns a static tracking profile that only tracks instance terminated events.
        /// </summary>
        protected override TrackingProfile GetProfile(Guid workflowInstanceId)
        {
            return GetProfile();
        }
        private volatile static TrackingProfile profile = null;
        private bool sourceExists = false;
        private TrackingProfile GetProfile()
        {
            //
            // We shouldn't hit this point without the host ignoring an earlier exception.
            // However if we're here and the source doesn't exist we can't function.
            // Throwing an exception from here will block instance creation
            // but that is better than failing silently on termination 
            // and having the admin think everything is OK because the event log is clear.
            if (!sourceExists)
                throw new InvalidOperationException(string.Format(System.Globalization.CultureInfo.InvariantCulture, "EventLog Source with the name '{0}' does not exist", source));

            //
            // The profile for this instance will never change
            if (null == profile)
            {
                lock (typeof(TerminationTrackingService))
                {
                    if (null == profile)
                    {
                        profile = new TrackingProfile();
                        profile.Version = new Version("3.0.0.0");
                        WorkflowTrackPoint point = new WorkflowTrackPoint();
                        point.MatchingLocation = new WorkflowTrackingLocation();
                        point.MatchingLocation.Events.Add(TrackingWorkflowEvent.Terminated);
                        profile.WorkflowTrackPoints.Add(point);
                    }
                }
            }
            return profile;
        }
        //</snippet115>
        //<snippet116>
        /// <summary>
        /// Always returns false; this tracking service has no need to reload its tracking profile for a running instance.
        /// </summary>
        /// <param name="workflowType"></param>
        /// <param name="workflowInstanceId"></param>
        /// <param name="profile"></param>
        /// <returns></returns>
        protected override bool TryReloadProfile(Type workflowType, Guid workflowInstanceId, out TrackingProfile profile)
        {
            //
            // There is no reason for this service to ever reload a profile
            profile = null;
            return false;
        }
        //</snippet116>


        protected override TrackingProfile GetProfile(Type workflowType, Version profileVersionId)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
    public class TerminationTrackingChannel : TrackingChannel
    {
        public TerminationTrackingChannel(TrackingParameters parameters, string source)
        {
        }
        private string sourceValue = null;
        private TrackingParameters parametersValue = null;
        //<snippet117>
        /// <summary>
        /// Receives tracking events.  Instance terminated events are written to the event log.
        /// </summary>
        protected override void Send(TrackingRecord record)
        {
            WorkflowTrackingRecord instanceTrackingRecord = record as WorkflowTrackingRecord;

            if ((null == instanceTrackingRecord) || (TrackingWorkflowEvent.Terminated != instanceTrackingRecord.TrackingWorkflowEvent))
                return;

            // Create an EventLog instance and assign its source.
            EventLog log = new EventLog();
            log.Source = sourceValue;

            // Write an informational entry to the event log.  
            TrackingWorkflowTerminatedEventArgs terminatedEventArgs = instanceTrackingRecord.EventArgs as TrackingWorkflowTerminatedEventArgs;

            StringBuilder message = new StringBuilder(512);
            message.AppendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Workflow instance {0} has been terminated.", parametersValue.InstanceId.ToString()));
            message.AppendLine();

            if (null != terminatedEventArgs.Exception)
                message.AppendLine(terminatedEventArgs.Exception.ToString());

            log.WriteEntry(message.ToString(), EventLogEntryType.Warning);
        }
        //</snippet117>


        protected override void InstanceCompletedOrTerminated()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        //<snippet118>
        private void Track_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Calling TrackData from workflow");
            this.TrackData("Hello - this is a UserTrackPoint");
        }
        //</snippet118>
        private void TrackData(string p)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

    /*********************
     * Snippets from TrackingProfileDesigner
     * *****************/

    //<snippet119>
    /// <summary>
    /// This glyph shows that the activity's track point is not correctly configured
    /// </summary>
    internal sealed class ErrorActivityGlyph : DesignerGlyph
    {
        static Bitmap image = Resources.error;
        string errorMessage;

        internal ErrorActivityGlyph(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }

        public override bool CanBeActivated
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Display an error message when this glyph is clicked
        /// </summary>
        /// <param name="designer"></param>
        protected override void OnActivate(ActivityDesigner designer)
        {
            MessageBox.Show(errorMessage);
        }

        public override Rectangle GetBounds(ActivityDesigner designer, bool activated)
        {
            Rectangle imageBounds = new Rectangle();
            if (image != null)
            {
                imageBounds.Size = image.Size;
                imageBounds.Location = new Point(designer.Bounds.Right - imageBounds.Size.Width / 4, designer.Bounds.Top - imageBounds.Size.Height / 2);

            }
            return imageBounds;
        }

        protected override void OnPaint(Graphics graphics, bool activated, AmbientTheme ambientTheme, ActivityDesigner designer)
        {
            image.MakeTransparent(Color.FromArgb(255, 255, 255));
            if (image != null)
            {
                graphics.DrawImage(image, GetBounds(designer, activated), new Rectangle(Point.Empty, image.Size), GraphicsUnit.Pixel);
            }
        }
    }
    //</snippet119>

    public class Snippets6
    {
        //<snippet120>
        /// <summary>
        /// Saves a tracking condition for an activity
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <param name="op"></param>
        /// <param name="value"></param>
        internal void SaveTrackingCondition(Activity activity, ref ActivityTrackingCondition key, string member, ComparisonOperator op, string value)
        {
            ActivityTrackPoint trackPoint = GetTrackPointForActivity(activity);
            if (trackPoint != null)
            {
                if (key == null)
                {
                    key = new ActivityTrackingCondition();
                    trackPoint.MatchingLocations[0].Conditions.Add(key);
                }
                key.Member = member;
                key.Value = value;
                key.Operator = op;
            }
        }
        //</snippet120>
        private ActivityTrackPoint GetTrackPointForActivity(Activity activity)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
    internal sealed class Snippets7 : WorkflowDesignerLoader
    {
        //<snippet121>
        public override void Dispose()
        {
            try
            {
                IDesignerLoaderHost host = LoaderHost;
                if (host != null)
                {
                    host.RemoveService(typeof(IIdentifierCreationService));
                    host.RemoveService(typeof(IMenuCommandService));
                    host.RemoveService(typeof(IToolboxService));
                    host.RemoveService(typeof(ITypeProvider), true);
                    host.RemoveService(typeof(IWorkflowCompilerOptionsService));
                    host.RemoveService(typeof(IEventBindingService));
                }
            }
            finally
            {
                base.Dispose();
            }
        }
        //</snippet121>
        public override string FileName
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override TextReader GetFileReader(string filePath)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override TextWriter GetFileWriter(string filePath)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
    internal class Snippets8 : IWorkflowCompilerOptionsService
    {

        //<snippet122>
        string IWorkflowCompilerOptionsService.RootNamespace
        {
            get
            {
                return String.Empty;
            }
        }
        //</snippet122>

        //<snippet123>
        string IWorkflowCompilerOptionsService.Language
        {
            get
            {
                return "CSharp";
            }
        }
        //</snippet123>

        #region IWorkflowCompilerOptionsService Members

        public bool CheckTypes
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion

    }
    public class WorkflowDesignerControl
    {
        //<snippet124>
		// <snippet125>
        public WorkflowDesignerControl()
        {
            InitializeComponent();
            
            WorkflowTheme.CurrentTheme.ReadOnly = false;
            WorkflowTheme.CurrentTheme.AmbientTheme.ShowConfigErrors = false;
            WorkflowTheme.CurrentTheme.ReadOnly = true;            
        }


		// </snippet125>
        //</snippet124>
        private void InitializeComponent()
        {
            throw new Exception("The method or operation is not implemented.");
        }
        private DesignSurface designSurface;
        private WorkflowLoader loader;
        private WorkflowView workflowView;
        private System.Windows.Forms.Panel panel1 = new Panel();    

        void container1()
        {
            DesignSurface designSurface = new DesignSurface();
            WorkflowLoader loader = new WorkflowLoader();
            // <snippet126>
            IDesignerHost designerHost = designSurface.GetService(typeof(IDesignerHost)) as IDesignerHost;
            if (designerHost != null && designerHost.RootComponent != null)
            {
                IRootDesigner rootDesigner = designerHost.GetDesigner(designerHost.RootComponent) as IRootDesigner;
                if (rootDesigner != null)
                {
                    UnloadWorkflow();

                    this.designSurface = designSurface;
                    this.loader = loader;
                    this.workflowView = rootDesigner.GetView(ViewTechnology.Default) as WorkflowView;
                    this.panel1.Controls.Add(this.workflowView);
                    this.workflowView.Dock = DockStyle.Fill;
                    this.workflowView.TabIndex = 1;
                    this.workflowView.TabStop = true;
                    this.workflowView.HScrollBar.TabStop = false;
                    this.workflowView.VScrollBar.TabStop = false;
                    this.workflowView.Focus();
                    this.workflowView.FitToScreenSize();
                }
            }
            // </snippet126>
        }
        class WorkflowLoader { }
        private void UnloadWorkflow()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

    /******************
     * * WorkflowMonitor snippets
     */

    class Snippets9
    {
        private string connectionString = "";
        // <snippet127>
        internal List<SqlTrackingWorkflowInstance> GetWorkflows(string workflowEvent, DateTime from, DateTime until, TrackingDataItemValue trackingDataItemValue)
        {
            //<snippet128>
            try
            {
                List<SqlTrackingWorkflowInstance> queriedWorkflows = new List<SqlTrackingWorkflowInstance>();
                SqlTrackingQuery sqlTrackingQuery = new SqlTrackingQuery(connectionString);
                SqlTrackingQueryOptions sqlTrackingQueryOptions = new SqlTrackingQueryOptions();
                sqlTrackingQueryOptions.StatusMinDateTime = from.ToUniversalTime();
                sqlTrackingQueryOptions.StatusMaxDateTime = until.ToUniversalTime();
                // If QualifiedName, FieldName, or DataValue is not supplied, we will not query since they are all required to match
                if (!((string.Empty == trackingDataItemValue.QualifiedName) || (string.Empty == trackingDataItemValue.FieldName) || ((string.Empty == trackingDataItemValue.DataValue))))
                    sqlTrackingQueryOptions.TrackingDataItems.Add(trackingDataItemValue);

                queriedWorkflows.Clear();

                if ("created" == workflowEvent.ToLower(CultureInfo.InvariantCulture))
                {
                    sqlTrackingQueryOptions.WorkflowStatus = WorkflowStatus.Created;
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions));
                }
                else if ("completed" == workflowEvent.ToLower(CultureInfo.InvariantCulture))
                {
                    sqlTrackingQueryOptions.WorkflowStatus = WorkflowStatus.Completed;
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions));
                }
                else if ("running" == workflowEvent.ToLower(CultureInfo.InvariantCulture))
                {
                    sqlTrackingQueryOptions.WorkflowStatus = WorkflowStatus.Running;
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions));
                }
                else if ("suspended" == workflowEvent.ToLower(CultureInfo.InvariantCulture))
                {
                    sqlTrackingQueryOptions.WorkflowStatus = WorkflowStatus.Suspended;
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions));
                }
                else if ("terminated" == workflowEvent.ToLower(CultureInfo.InvariantCulture))
                {
                    sqlTrackingQueryOptions.WorkflowStatus = WorkflowStatus.Terminated;
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions));
                }
                else if (("all" == workflowEvent.ToLower(CultureInfo.InvariantCulture)) || (string.Empty == workflowEvent) || (null == workflowEvent))
                {
                    sqlTrackingQueryOptions.WorkflowStatus = WorkflowStatus.Created;
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions));

                    sqlTrackingQueryOptions.WorkflowStatus = WorkflowStatus.Completed;
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions));

                    sqlTrackingQueryOptions.WorkflowStatus = WorkflowStatus.Running;
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions));

                    sqlTrackingQueryOptions.WorkflowStatus = WorkflowStatus.Suspended;
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions));

                    sqlTrackingQueryOptions.WorkflowStatus = WorkflowStatus.Terminated;
                    queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions));

                }
                return queriedWorkflows;

            }
            catch (Exception exception)
            {
                throw new Exception("Exception in GetWorkflows", exception);
            }
            //</snippet128>
        }
        // </snippet127>

        // <snippet129>
        internal bool TryGetWorkflow(Guid workflowInstanceId, out SqlTrackingWorkflowInstance sqlTrackingWorkflowInstance)
        {
            SqlTrackingQuery sqlTrackingQuery = new SqlTrackingQuery(connectionString);
            return sqlTrackingQuery.TryGetWorkflow(workflowInstanceId, out sqlTrackingWorkflowInstance);
        }
        // </snippet129>
    }
    // <snippet130>
    //Custom glyphprovider used to draw the monitor glyphs on the designer surface
    internal class WorkflowMonitorDesignerGlyphProvider : IDesignerGlyphProvider
    {
        private Dictionary<string, ActivityStatusInfo> activityStatusList;

        internal WorkflowMonitorDesignerGlyphProvider(Dictionary<string, ActivityStatusInfo> activityStatusList)
        {
            this.activityStatusList = activityStatusList;
        }

        // <snippet131>
        ActivityDesignerGlyphCollection IDesignerGlyphProvider.GetGlyphs(ActivityDesigner activityDesigner)
        {
            ActivityDesignerGlyphCollection glyphList = new ActivityDesignerGlyphCollection();

            //Walk all of the activities and use the 'CompletedGlyph' for all activities that are not 'closed'
            foreach (ActivityStatusInfo activityStatus in activityStatusList.Values)
            {
                if (activityStatus.Name == activityDesigner.Activity.QualifiedName)
                {
                    if (activityStatus.Status == "Closed")
                        glyphList.Add(new CompletedGlyph());
                    else
                        glyphList.Add(new ExecutingGlyph());
                }
            }

            return glyphList;
        }
        // </snippet131>
    }
    // </snippet130>

    // <snippet132>
    //Define a glyph to show an activity is executing, i.e. not 'closed'
    internal sealed class ExecutingGlyph : DesignerGlyph
    {
        internal ExecutingGlyph()
        {
        }

        // <snippet133>
        public override Rectangle GetBounds(ActivityDesigner designer, bool activated)
        {
            Rectangle imageBounds = Rectangle.Empty;
            Image image = Resources.Executing;
            if (image != null)
            {
                Size glyphSize = WorkflowTheme.CurrentTheme.AmbientTheme.GlyphSize;
                imageBounds.Location = new Point(designer.Bounds.Right - glyphSize.Width / 2, designer.Bounds.Top - glyphSize.Height / 2);
                imageBounds.Size = glyphSize;
            }
            return imageBounds;
        }
        // </snippet133>

        // <snippet134>
        protected override void OnPaint(Graphics graphics, bool activated, AmbientTheme ambientTheme, ActivityDesigner designer)
        {
            Bitmap bitmap = Resources.Executing;
            bitmap.MakeTransparent(Color.FromArgb(0, 255, 255));
            if (bitmap != null)
                graphics.DrawImage(bitmap, GetBounds(designer, activated), new Rectangle(Point.Empty, bitmap.Size), GraphicsUnit.Pixel);
        }
        // </snippet134>
    }
    // </snippet132>
    internal class ActivityStatusInfo
    {
        public string Name = "";
        public string Status = "";
    }
    internal class CompletedGlyph : DesignerGlyph
    {
        protected override void OnPaint(Graphics graphics, bool activated, AmbientTheme ambientTheme, ActivityDesigner designer)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
    public class Snippets10
    {
        private WorkflowDesignSurface surface = null;
        private WorkflowView workflowViewValue = null;
        private Mainform parentValue = new Mainform();
        // <snippet135>
        internal void Expand(bool expand)
        {
            IDesignerHost host = GetService(typeof(IDesignerHost)) as IDesignerHost;
            if (host == null)
                return;

            this.SuspendLayout();

            CompositeActivity root = host.RootComponent as CompositeActivity;
            foreach (Activity activity in root.Activities)
            {
                CompositeActivityDesigner compositeActivityDesigner = host.GetDesigner((IComponent)activity) as CompositeActivityDesigner;
                if (compositeActivityDesigner != null)
                {
                    compositeActivityDesigner.Expanded = expand;
                }
            }

            this.ResumeLayout(true);
        }
        // </snippet135>
        private IDesignerHost GetService(Type type)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        private void SuspendLayout()
        {
            throw new Exception("The method or operation is not implemented.");
        }
        private void ResumeLayout(bool p)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void workflowViewValue_ZoomChanged(object sender, EventArgs e)
        {
         
        }

        void container1()
        {
            // <snippet136>
            this.workflowViewValue = new WorkflowView(this.surface);
            this.workflowViewValue.ZoomChanged += new EventHandler(workflowViewValue_ZoomChanged);
            // </snippet136>
        }
        internal sealed class WorkflowDesignSurface : DesignSurface
        {
        }
        internal class Mainform : Form
        {
            private Dictionary<string, ActivityStatusInfo> activityStatusListValue = null;
            internal Dictionary<string, ActivityStatusInfo> ActivityStatusList
            {
                get { return activityStatusListValue; }
            }
        }

        List<SqlTrackingWorkflowInstance> displayedWorkflows = null;
        private System.Windows.Forms.ListView listViewWorkflows = new ListView();
        private Dictionary<string, WorkflowStatusInfo> workflowStatusList = null;
        void container2()
        {
            // <snippet137>
            // For every workflow instance create a new WorkflowStatusInfo object and store in the workflowStatusList
            // Also populate the workflow ListView
            foreach (SqlTrackingWorkflowInstance sqlTrackingWorkflowInstance in displayedWorkflows)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] {
                        sqlTrackingWorkflowInstance.WorkflowInstanceInternalId.ToString(),
                        sqlTrackingWorkflowInstance.WorkflowType.ToString(),
                        sqlTrackingWorkflowInstance.Status.ToString()}, -1);

                listViewWorkflows.Items.Add(listViewItem);

                workflowStatusList.Add(sqlTrackingWorkflowInstance.WorkflowInstanceInternalId.ToString(),
                        new WorkflowStatusInfo(
                            sqlTrackingWorkflowInstance.WorkflowInstanceInternalId.ToString(),
                            sqlTrackingWorkflowInstance.WorkflowType.ToString(),
                            sqlTrackingWorkflowInstance.Status.ToString(),
                            sqlTrackingWorkflowInstance.Initialized.ToString(),
                            sqlTrackingWorkflowInstance.WorkflowInstanceId,
                            listViewItem));
            }
            // </snippet137>
        }
        internal class WorkflowStatusInfo
        {
            internal WorkflowStatusInfo(string id, string name, string status, string createdDateTime, Guid instanceId, ListViewItem listViewItem)
            {
            }
        }
        private ToolStripComboBox toolStripComboBoxZoom = new ToolStripComboBox();
        private ViewHost workflowViewHost = new ViewHost();
        internal class ViewHost : Control, IMemberCreationService
        {
            public WorkflowView WorkflowView = new WorkflowView();
            #region IMemberCreationService Members

            public void CreateEvent(string className, string eventName, Type eventType, AttributeInfo[] attributes, bool emitDependencyProperty)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public void CreateField(string className, string fieldName, Type fieldType, Type[] genericParameterTypes, System.CodeDom.MemberAttributes attributes, System.CodeDom.CodeSnippetExpression initializationExpression, bool overwriteExisting)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public void CreateProperty(string className, string propertyName, Type propertyType, AttributeInfo[] attributes, bool emitDependencyProperty, bool isMetaProperty, bool isAttached, Type ownerType, bool isReadOnly)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public void RemoveEvent(string className, string eventName, Type eventType)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public void RemoveProperty(string className, string propertyName, Type propertyType)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public void ShowCode()
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public void ShowCode(Activity activity, string methodName, Type delegateType)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public void UpdateBaseType(string className, Type baseType)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public void UpdateEvent(string className, string oldEventName, Type oldEventType, string newEventName, Type newEventType, AttributeInfo[] attributes, bool emitDependencyProperty, bool isMetaProperty)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public void UpdateProperty(string className, string oldPropertyName, Type oldPropertyType, string newPropertyName, Type newPropertyType, AttributeInfo[] attributes, bool emitDependencyProperty, bool isMetaProperty)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public void UpdateTypeName(string oldClassName, string newClassName)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            #endregion
        }
        // <snippet138>
        private void ToolStripComboBoxZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (workflowViewHost.WorkflowView == null) return;
            //Parse the value and set the WorkflowView zoom - set to 100% if invalid
            string newZoom = this.toolStripComboBoxZoom.Text.Trim();
            if (newZoom.EndsWith("%"))
                newZoom = newZoom.Substring(0, newZoom.Length - 1);

            if (newZoom.Length > 0)
            {
                try
                {
                    this.workflowViewHost.WorkflowView.Zoom = Convert.ToInt32(newZoom);
                }
                catch
                {
                    this.workflowViewHost.WorkflowView.Zoom = 100;
                }
            }
            else
                this.workflowViewHost.WorkflowView.Zoom = 100;
        }
        // </snippet138>
        ToolStripTextBox toolStripTextBoxArtifactQualifiedId = new ToolStripTextBox();
        ToolStripTextBox toolStripTextBoxArtifactKeyName = new ToolStripTextBox();
        ToolStripTextBox toolStripTextBoxArtifactKeyValue = new ToolStripTextBox();
       
        void container3()
        {
            TrackingDataItemValue trackingDataItemValue = new TrackingDataItemValue(string.Empty, string.Empty, string.Empty);

            //<snippet139>
            trackingDataItemValue = new TrackingDataItemValue(string.Empty, string.Empty, string.Empty);
            trackingDataItemValue.QualifiedName = this.toolStripTextBoxArtifactQualifiedId.Text.ToString();
            trackingDataItemValue.FieldName = this.toolStripTextBoxArtifactKeyName.Text.ToString();
            trackingDataItemValue.DataValue = this.toolStripTextBoxArtifactKeyValue.Text.ToString();
            //</snippet139>

        }


    }

    public class Resources     //another hack- just a custom class to avoid solution properties
    {
        public static Bitmap draft = new Bitmap(0,0);
        public static Bitmap ToolboxImage = new Bitmap(0, 0);
        public static Bitmap error = new Bitmap(0, 0);
        public static Bitmap Executing = new Bitmap(0, 0);

    }
  



}

