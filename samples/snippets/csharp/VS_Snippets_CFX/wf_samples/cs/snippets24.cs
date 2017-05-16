using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.IO;
using System.Workflow.ComponentModel.Compiler;
using System.ComponentModel;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;
using System.Workflow.ComponentModel.Design;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Workflow.Activities.Rules;
using System.CodeDom;
using System.Workflow.Runtime.Hosting;
using System.Threading;
using System.Collections.ObjectModel;
using System.Workflow.Runtime.Tracking;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;

namespace WF_Snippets
{
    /****************************
     * Snippets from Technologies/CustomActivities, Technologies/DesignerHosting, 
     * Technologies/DynamicUpdate, Technologies/Hosting, Technologies/Roles,
     * Technologies/Tracking
     */ 

    /*****************************
     * Snippets from CustomActivities/FileWatcher
     */

    class FileSystemEvent : Activity, IEventActivity, IActivityEventListener<QueueEventArgs>
    {
        private Guid subscriptionId = Guid.Empty;
        private IComparable queueName;
        public string Path;
        public NotifyFilters NotifyFilter;
        public bool IncludeSubdirectories;
        public string Filter;

        public static DependencyProperty FileWatcherEventHandlerEvent = DependencyProperty.Register("FileWatcherEventHandler", typeof(EventHandler<FileWatcherEventArgs>), typeof(FileSystemEvent));
        

        // <snippet221>
        void IEventActivity.Subscribe(ActivityExecutionContext parentContext, IActivityEventListener<QueueEventArgs> parentEventHandler)
        {
            Console.WriteLine("Subscribe");
            DoSubscribe(parentContext, parentEventHandler);
        }
        // </snippet221>
        // <snippet222>
        void IEventActivity.Unsubscribe(ActivityExecutionContext parentContext, IActivityEventListener<QueueEventArgs> parentEventHandler)
        {
            Console.WriteLine("Unsubscribe");
            DoUnsubscribe(parentContext, parentEventHandler);
        }
        // </snippet222>

        // <snippet223>
        private WorkflowQueue CreateQueue(ActivityExecutionContext context)
        {
            Console.WriteLine("CreateQueue");
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();

            if (!qService.Exists(this.QueueName))
            {
                qService.CreateWorkflowQueue(this.QueueName, true);
            }

            return qService.GetWorkflowQueue(this.QueueName);
        }
        // </snippet223>

        // <snippet224>
        private void DeleteQueue(ActivityExecutionContext context)
        {
            Console.WriteLine("DeleteQueue");
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            qService.DeleteWorkflowQueue(this.QueueName);
        }
        // </snippet224>

        // <snippet225>
        private Boolean DoSubscribe(ActivityExecutionContext context, IActivityEventListener<QueueEventArgs> listener)
        {
            WorkflowQueue queue = CreateQueue(context);
            queue.RegisterForQueueItemAvailable(listener);

            FileWatcherService fileService = context.GetService<FileWatcherService>();
            this.subscriptionId = fileService.RegisterListener(this.QueueName, this.Path, this.Filter, this.NotifyFilter, this.IncludeSubdirectories);
            return (subscriptionId != Guid.Empty);
        }
        // </snippet225>

        // <snippet226>
        private void DoUnsubscribe(ActivityExecutionContext context, IActivityEventListener<QueueEventArgs> listener)
        {
            if (!this.subscriptionId.Equals(Guid.Empty))
            {
                FileWatcherService fileService = context.GetService<FileWatcherService>();
                fileService.UnregisterListener(this.subscriptionId);
                this.subscriptionId = Guid.Empty;
            }

            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            WorkflowQueue queue = qService.GetWorkflowQueue(this.QueueName);

            queue.UnregisterForQueueItemAvailable(listener);
        }
        // </snippet226>
        // <snippet227>
        private bool ProcessQueueItem(ActivityExecutionContext context)
        {
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            if (!qService.Exists(this.QueueName))
            {
                return false;
            }

            WorkflowQueue queue = qService.GetWorkflowQueue(this.QueueName);

            // If the queue has messages, then process the first one
            if (queue.Count == 0)
            {
                return false;
            }

            FileWatcherEventArgs e = (FileWatcherEventArgs)queue.Dequeue();

            // Raise the FileSystemEvent
            base.RaiseGenericEvent<FileWatcherEventArgs>(FileSystemEvent.FileWatcherEventHandlerEvent, this, e);

            DoUnsubscribe(context, this);
            DeleteQueue(context);
            return true;
        }
        // </snippet227>

        #region IEventActivity Members

        public IComparable QueueName
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion

        #region IActivityEventListener<QueueEventArgs> Members

        public void OnEvent(object sender, QueueEventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
    public class FileWatcherService 
    {
        public Guid RegisterListener(IComparable queueName, string path, string filter, NotifyFilters notifyFilter, bool includeSubdirectories)
        { return Guid.NewGuid(); }
        public void UnregisterListener(Guid subscriptionId)
        { }
    }
    public class FileWatcherEventArgs : EventArgs
    { }

    /**********************
     * Snippets from CustomActivites/SendEmail
     */
    public partial class SendEmailActivity : Activity
    {
        private void InitializeComponent()
        {
        }
    }
    // <snippet228>
    [ActivityValidator(typeof(SendEmailValidator))]
    [ToolboxBitmap(typeof(SendEmailActivity), "Resources.EmailMessage.png")]
    [DefaultEvent("SendingEmail")]
    [DefaultProperty("To")]
    public partial class SendEmailActivity : System.Workflow.ComponentModel.Activity
    {

        // <snippet229>
        // <snippet230>
        // Define the DependencyProperty objects for all of the Properties 
        // ...and Events exposed by this activity
        public static DependencyProperty FromProperty = DependencyProperty.Register("From", typeof(string), typeof(SendEmailActivity), new PropertyMetadata("someone@example.com"));
        public static DependencyProperty ToProperty = DependencyProperty.Register("To", typeof(string), typeof(SendEmailActivity), new PropertyMetadata("someone@example.com"));
        // </snippet230>
        public static DependencyProperty BodyProperty = DependencyProperty.Register("Body", typeof(string), typeof(SendEmailActivity));
        public static DependencyProperty SubjectProperty = DependencyProperty.Register("Subject", typeof(string), typeof(SendEmailActivity));
        public static DependencyProperty HtmlBodyProperty = DependencyProperty.Register("HtmlBody", typeof(bool), typeof(SendEmailActivity), new PropertyMetadata(false));
        public static DependencyProperty CCProperty = DependencyProperty.Register("CC", typeof(string), typeof(SendEmailActivity));
        public static DependencyProperty BccProperty = DependencyProperty.Register("Bcc", typeof(string), typeof(SendEmailActivity));
        public static DependencyProperty PortProperty = DependencyProperty.Register("Port", typeof(int), typeof(SendEmailActivity), new PropertyMetadata(25));
        public static DependencyProperty SmtpHostProperty = DependencyProperty.Register("SmtpHost", typeof(string), typeof(SendEmailActivity), new PropertyMetadata("localhost"));
        public static DependencyProperty ReplyToProperty = DependencyProperty.Register("ReplyTo", typeof(string), typeof(SendEmailActivity));

        public static DependencyProperty SendingEmailEvent = DependencyProperty.Register("SendingEmail", typeof(EventHandler), typeof(SendEmailActivity), new PropertyMetadata(null));
        public static DependencyProperty SentEmailEvent = DependencyProperty.Register("SentEmail", typeof(EventHandler), typeof(SendEmailActivity), new PropertyMetadata(null));

        // </snippet229>

        // Define constant values for the Property categories.  
        private const string MessagePropertiesCategory = "Email Message";
        private const string SMTPPropertiesCategory = "Email Server";
        private const string EventsCategory = "Handlers";

        public SendEmailActivity()
        {
            InitializeComponent();
        }


        #region Email Message Properties

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [DescriptionAttribute("The To property is used to specify the receipient's email address.")]
        [CategoryAttribute(MessagePropertiesCategory)]
        // <snippet231>
        public string To
        {
            get
            {
                return ((string)(base.GetValue(SendEmailActivity.ToProperty)));
            }
            set
            {
                base.SetValue(SendEmailActivity.ToProperty, value);
            }
        }


        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [DescriptionAttribute("The Subject property is used to specify the subject of the Email message.")]
        [CategoryAttribute(MessagePropertiesCategory)]
        public string Subject
        {
            get
            {
                return ((string)(base.GetValue(SendEmailActivity.SubjectProperty)));
            }
            set
            {
                base.SetValue(SendEmailActivity.SubjectProperty, value);
            }
        }


        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [DescriptionAttribute("The From property is used to specify the From (Sender's) address for the email mesage.")]
        [CategoryAttribute(MessagePropertiesCategory)]
        public string From
        {
            get
            {
                return ((string)(base.GetValue(SendEmailActivity.FromProperty)));
            }
            set
            {
                base.SetValue(SendEmailActivity.FromProperty, value);
            }
        }


        // </snippet231>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [DescriptionAttribute("The Body property is used to specify the Body of the email message.")]
        [CategoryAttribute(MessagePropertiesCategory)]
        public string Body
        {

            get
            {
                return (string)base.GetValue(SendEmailActivity.BodyProperty);
            }
            set
            {

                base.SetValue(SendEmailActivity.BodyProperty, value);
            }

        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The HTMLBody property is used to specify whether the Body is formatted as HTML (True) or not (False)")]
        [Category(MessagePropertiesCategory)]
        [Browsable(true)]
        [DefaultValue(false)]
        public bool HtmlBody
        {
            get
            {
                return ((bool)(base.GetValue(SendEmailActivity.HtmlBodyProperty)));
            }
            set
            {
                base.SetValue(SendEmailActivity.HtmlBodyProperty, value);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The CC property is used to set the CC recipients for the email message.")]
        [Category(MessagePropertiesCategory)]
        [Browsable(true)]
        public string CC
        {
            get
            {
                return ((string)(base.GetValue(SendEmailActivity.CCProperty)));
            }
            set
            {
                base.SetValue(SendEmailActivity.CCProperty, value);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The Bcc property is used to set the Bcc recipients for the email message.")]
        [Category(MessagePropertiesCategory)]
        [Browsable(true)]
        public string Bcc
        {
            get
            {
                return ((string)(base.GetValue(SendEmailActivity.BccProperty)));
            }
            set
            {
                base.SetValue(SendEmailActivity.BccProperty, value);
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The email address that should be used for reply messages.")]
        [Category(MessagePropertiesCategory)]
        [Browsable(true)]
        public string ReplyTo
        {
            get
            {
                return ((string)(base.GetValue(SendEmailActivity.ReplyToProperty)));
            }
            set
            {
                base.SetValue(SendEmailActivity.ReplyToProperty, value);
            }
        }

        #endregion

        #region SMTP Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The SMTP host is the machine running SMTP that will send the email.  The default is 'localhost'")]
        [Category(SMTPPropertiesCategory)]
        [Browsable(true)]
        public string SmtpHost
        {
            get
            {
                return ((string)(base.GetValue(SendEmailActivity.SmtpHostProperty)));
            }
            set
            {
                base.SetValue(SendEmailActivity.SmtpHostProperty, value);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Specify the Port used for SMTP.  The default is 25.")]
        [Category(SMTPPropertiesCategory)]
        [Browsable(true)]
        public int Port
        {
            get
            {
                return ((int)(base.GetValue(SendEmailActivity.PortProperty)));
            }
            set
            {
                base.SetValue(SendEmailActivity.PortProperty, value);
            }
        }

        #endregion

        // <snippet232>
        #region Public Events

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The SendingEmail event is raised before an email is sent through SMTP.")]
        [Category(EventsCategory)]
        [Browsable(true)]
        public event EventHandler SendingEmail
        {
            add
            {
                base.AddHandler(SendEmailActivity.SendingEmailEvent, value);
            }
            remove
            {
                base.RemoveHandler(SendEmailActivity.SendingEmailEvent, value);
            }
        }

        // </snippet232>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The SentEmail event is raised after an email is sent through SMTP.")]
        [Category(EventsCategory)]
        [Browsable(true)]
        public event EventHandler SentEmail
        {
            add
            {
                base.AddHandler(SendEmailActivity.SentEmailEvent, value);
            }
            remove
            {
                base.RemoveHandler(SendEmailActivity.SentEmailEvent, value);
            }
        }
        #endregion

        #region Activity Execution Logic


        ///    During execution the SendEmail activity should create and send the email using SMTP.  

        // <snippet233>
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
        {
            try
            {
                // Raise the SendingEmail event to the parent workflow or activity
                base.RaiseEvent(SendEmailActivity.SendingEmailEvent, this, EventArgs.Empty);


                // Send the email now
                this.SendEmailUsingSmtp();


                // Raise the SentEmail event to the parent workflow or activity
                base.RaiseEvent(SendEmailActivity.SentEmailEvent, this, EventArgs.Empty);

                // Return the closed status indicating that this activity is complete.
                return ActivityExecutionStatus.Closed;
            }
            catch
            {
                // An unhandled exception occurred.  Throw it back to the WorkflowRuntime.
                throw;
            }
        }

        // </snippet233>

        private void SendEmailUsingSmtp()
        {

            // Create a new SmtpClient for sending the email
            SmtpClient client = new SmtpClient();

            // Use the properties of the activity to construct a new MailMessage
            MailMessage message = new MailMessage();
            message.From = new MailAddress(this.From);
            message.To.Add(this.To);


            // Assign the message values if they are valid.
            if (!String.IsNullOrEmpty(this.CC))
            {
                message.CC.Add(this.CC);
            }

            if (!String.IsNullOrEmpty(this.Bcc))
            {
                message.Bcc.Add(this.Bcc);
            }

            if (!String.IsNullOrEmpty(this.Subject))
            {
                message.Subject = this.Subject;
            }

            if (!String.IsNullOrEmpty(this.Body))
            {
                message.Body = this.Body;
            }

            if (!String.IsNullOrEmpty(this.ReplyTo))
            {
                message.ReplyTo = new MailAddress(this.ReplyTo);
            }

            message.IsBodyHtml = this.HtmlBody;


            // Set the SMTP host and send the mail
            client.Host = this.SmtpHost;
            client.Port = this.Port;
            client.Send(message);
        }

        
        #endregion

    }
    // </snippet228>
    // <snippet234>
    public class SendEmailValidator : System.Workflow.ComponentModel.Compiler.ActivityValidator
    {
        // Define private constants for the Validation Errors 
        private const int InvalidToAddress = 1;
        private const int InvalidFromAddress = 2;
        private const int InvalidSMTPPort = 3;

        //customizing the default activity validation
        public override ValidationErrorCollection ValidateProperties(ValidationManager manager, object obj)
        {

            // Create a new collection for storing the validation errors
            ValidationErrorCollection validationErrors = base.ValidateProperties(manager, obj);


            SendEmailActivity activity = obj as SendEmailActivity;
            if (activity != null)
            {
                // Validate the Email and SMTP Properties
                this.ValidateEmailProperties(validationErrors, activity);
                this.ValidateSMTPProperties(validationErrors, activity);
            }
            return validationErrors;
        }

        // </snippet234>
        // <snippet235>
        private void ValidateEmailProperties(ValidationErrorCollection validationErrors, SendEmailActivity activity)
        {
            // Validate the To property
            if (String.IsNullOrEmpty(activity.To))
            {
                validationErrors.Add(ValidationError.GetNotSetValidationError(SendEmailActivity.ToProperty.Name));

            }
            else if (!activity.To.Contains("@"))
            {
                validationErrors.Add(new ValidationError("Invalid To e-mail address", InvalidToAddress, false, SendEmailActivity.ToProperty.Name));

            }

            // Validate the From property
            if (String.IsNullOrEmpty(activity.From))
            {
                validationErrors.Add(ValidationError.GetNotSetValidationError(SendEmailActivity.FromProperty.Name));
            }
            else if (!activity.From.Contains("@"))
            {
                validationErrors.Add(new ValidationError("Invalid From e-mail address", InvalidFromAddress, false, SendEmailActivity.FromProperty.Name));

            }
        }
        // </snippet235>


        private void ValidateSMTPProperties(ValidationErrorCollection validationErrors, SendEmailActivity activity)
        {
            // Validate the SMTPHost property
            if (String.IsNullOrEmpty(activity.SmtpHost))
            {
                validationErrors.Add(ValidationError.GetNotSetValidationError(SendEmailActivity.SmtpHostProperty.Name));
            }

            // Validate the Port property
            if (activity.Port == 0)
            {
                validationErrors.Add(ValidationError.GetNotSetValidationError(SendEmailActivity.PortProperty.Name));
            }
            else if (activity.Port < 1)
            {
                validationErrors.Add(new ValidationError("Invalid Port Number",
                    InvalidSMTPPort, false, SendEmailActivity.PortProperty.Name));
            }
        }

    }

    /**************************
     * Snippets from DesignerHosting
     */
    internal sealed class WorkflowDesignSurface : DesignSurface
    {
    }
    public sealed class WorkflowViewPanel : Panel, IServiceProvider
    {
        WorkflowView workflowView = new WorkflowView();
        
        public bool OnCodeActivityAdded()
        { return true;  }
        public WorkflowView GetWorkflowView()
        {
            return this.workflowView;
        }

        #region IServiceProvider Members

        

        #endregion



        #region IServiceProvider Members

        public object GetService(Type serviceType)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }

    class Snippets24 : Form
    {
        private WorkflowViewPanel workflowPanel;

        // <snippet236>
        private void addButton_Click(object sender, EventArgs e)
        {
            SequentialWorkflowRootDesigner rootDesigner = this.workflowPanel.GetWorkflowView().RootDesigner as SequentialWorkflowRootDesigner;
            int viewId = rootDesigner.ActiveView.ViewId;
            if (viewId == 1)
            {
                this.workflowPanel.OnCodeActivityAdded();
            }
            else
            {
                DialogResult resultBox = MessageBox.Show("This sample supports adding a code activity only in workflow view");
            }
        }
        // </snippet236>
    }
    // <snippet237>
    internal sealed class CustomMessageFilter : WorkflowDesignerMessageFilter
    {
        #region Members and Constructor

        private bool mouseDown;
        private IServiceProvider serviceProvider;
        private WorkflowView workflowView;
        private WorkflowDesignerLoader loader;

        public CustomMessageFilter(IServiceProvider provider, WorkflowView workflowView, WorkflowDesignerLoader loader)
        {
            this.serviceProvider = provider;
            this.workflowView = workflowView;
            this.loader = loader;
        }

        #endregion

        #region MessageFilter Overridables

        // <snippet238>
        protected override bool OnMouseDown(MouseEventArgs eventArgs)
        {
            //Allow other components to process this event by not returning true.
            this.mouseDown = true;
            return false;
        }
        // </snippet238>

        // <snippet239>
        protected override bool OnMouseMove(MouseEventArgs eventArgs)
        {
            //Allow other components to process this event by not returning true.
            if (mouseDown)
            {
                workflowView.ScrollPosition = new Point(eventArgs.X, eventArgs.Y);
            }
            return false;
        }
        // </snippet239>

        // <snippet240>
        protected override bool OnMouseUp(MouseEventArgs eventArgs)
        {
            //Allow other components to process this event by not returning true.
            mouseDown = false;
            return false;
        }
        // </snippet240>

        // <snippet241>
        protected override bool OnMouseDoubleClick(MouseEventArgs eventArgs)
        {
            mouseDown = false;
            return true;
        }
        // </snippet241>

        // <snippet242>
        protected override bool OnMouseEnter(MouseEventArgs eventArgs)
        {
            //Allow other components to process this event by not returning true.
            mouseDown = false;
            return false;
        }
        // </snippet242>

        // <snippet243>
        protected override bool OnMouseHover(MouseEventArgs eventArgs)
        {
            //Allow other components to process this event by not returning true.
            mouseDown = false;
            return false;
        }
        // </snippet243>

        // <snippet244>
        protected override bool OnMouseLeave()
        {
            //Allow other components to process this event by not returning true.
            mouseDown = false;
            return false;
        }
        // </snippet244>

        // <snippet245>
        protected override bool OnMouseWheel(MouseEventArgs eventArgs)
        {
            mouseDown = false;
            return true;
        }
        // </snippet245>

        // <snippet246>
        protected override bool OnMouseCaptureChanged()
        {
            //Allow other components to process this event by not returning true.
            mouseDown = false;
            return false;
        }
        // </snippet246>

        // <snippet247>
        protected override bool OnDragEnter(DragEventArgs eventArgs)
        {
            return true;
        }
        // </snippet247>

        // <snippet248>
        protected override bool OnDragOver(DragEventArgs eventArgs)
        {
            return true;
        }
        // </snippet248>

        // <snippet249>
        protected override bool OnDragLeave()
        {
            return true;
        }
        // </snippet249>

        // <snippet250>
        protected override bool OnDragDrop(DragEventArgs eventArgs)
        {
            return true;
        }
        // </snippet250>

        // <snippet251>
        protected override bool OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
        {
            return true;
        }
        // </snippet251>

        // <snippet252>
        protected override bool OnQueryContinueDrag(QueryContinueDragEventArgs qcdevent)
        {
            return true;
        }
        // </snippet252>

        // <snippet253>
        protected override bool OnKeyDown(KeyEventArgs eventArgs)
        {
            if (eventArgs.KeyCode == Keys.Delete)
            {
                ISelectionService selectionService = (ISelectionService)serviceProvider.GetService(typeof(ISelectionService));
                if (selectionService != null && selectionService.PrimarySelection is CodeActivity)
                {
                    CodeActivity codeActivityComponent = (CodeActivity)selectionService.PrimarySelection;
                    CompositeActivity parentActivity = codeActivityComponent.Parent;
                    if (parentActivity != null)
                    {
                        parentActivity.Activities.Remove(codeActivityComponent);
                        this.ParentView.Update();
                    }
                    loader.RemoveActivityFromDesigner(codeActivityComponent);

                }
            }
            return true;
        }
        // </snippet253>

        // <snippet254>
        protected override bool OnKeyUp(KeyEventArgs eventArgs)
        {
            return true;
        }
        // </snippet254>

        // <snippet255>
        protected override bool OnShowContextMenu(Point menuPoint)
        {
            return true;
        }
        // </snippet255>

        #endregion
    }
    // </snippet237>
    class Snippets25 : WorkflowDesignerLoader
    {
        void container1()
        {
            IDesignerLoaderHost host = LoaderHost;
            // <snippet256>
                TypeProvider typeProvider = new TypeProvider(host);
                typeProvider.AddAssemblyReference(typeof(string).Assembly.Location);
            // </snippet256>
        }

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

    /*********************
     * Snippets from DynamicUpdate/ChangingRules
     */

    class Snippets26
    {
        static void OnWorkflowIdle(object sender, WorkflowEventArgs e)
        {
            Int32 newAmount = 15000;
            WorkflowInstance workflowInstance = e.WorkflowInstance;
            // <snippet257>
            WorkflowChanges workflowchanges = new WorkflowChanges(workflowInstance.GetWorkflowDefinition());

            CompositeActivity transient = workflowchanges.TransientWorkflow;
            RuleDefinitions ruleDefinitions = (RuleDefinitions)transient.GetValue(RuleDefinitions.RuleDefinitionsProperty);
            RuleConditionCollection conditions = ruleDefinitions.Conditions;
            RuleExpressionCondition condition1 = (RuleExpressionCondition)conditions["Check"];
            (condition1.Expression as CodeBinaryOperatorExpression).Right = new CodePrimitiveExpression(newAmount);

            workflowInstance.ApplyWorkflowChanges(workflowchanges);
            // </snippet257>
        }
    }

    /******************
     * Snippets from Hosting/CancelWorkflow
     */

    class Snippets27
    {
        static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static ExpenseReportServiceImpl expenseService = new ExpenseReportServiceImpl();
        
        static void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
        }

        static void OnWorkflowTerminated(object sender, WorkflowTerminatedEventArgs e)
        {
        }

        static void OnWorkflowAborted(object sender, WorkflowEventArgs e)
        {
        }
        //<snippet258>
        //<snippet259>
        static void Main()
        {
            string connectionString = "Initial Catalog=SqlPersistenceService;Data Source=localhost;Integrated Security=SSPI;";

            using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                ExternalDataExchangeService dataService = new ExternalDataExchangeService();
                workflowRuntime.AddService(dataService);
                dataService.AddService(expenseService);

                workflowRuntime.AddService(new SqlWorkflowPersistenceService(connectionString));
                workflowRuntime.StartRuntime();

                workflowRuntime.WorkflowCompleted += OnWorkflowCompleted;
                workflowRuntime.WorkflowTerminated += OnWorkflowTerminated;
                workflowRuntime.WorkflowIdled += OnWorkflowIdled;
                workflowRuntime.WorkflowAborted += OnWorkflowAborted;

                // <snippet260>
                Type type = typeof(SampleWorkflow1);
                WorkflowInstance workflowInstance = workflowRuntime.CreateWorkflow(type);
                workflowInstance.Start();
                // </snippet260>

                waitHandle.WaitOne();

                workflowRuntime.StopRuntime();
            }
        }
        //</snippet259>
        //</snippet258>

        // <snippet261>
        static void OnWorkflowIdled(object sender, WorkflowEventArgs e)
        {
            WorkflowInstance workflow = e.WorkflowInstance;

            Console.WriteLine("\n...waiting for 3 seconds... \n");
            Thread.Sleep(3000);

            // what activity is blocking the workflow
            ReadOnlyCollection<WorkflowQueueInfo> wqi = workflow.GetWorkflowQueueData();
            foreach (WorkflowQueueInfo q in wqi)
            {
                EventQueueName eq = q.QueueName as EventQueueName;
                if (eq != null)
                {
                    // get activity that is waiting for event
                    ReadOnlyCollection<string> blockedActivity = q.SubscribedActivityNames;
                    Console.WriteLine("Host: Workflow is blocked on " + blockedActivity[0]);

                    // this event is never going to arrive eg. employee left the company
                    // lets send an exception to this queue
                    // it will either be handled by exception handler that was modeled in workflow
                    // or the runtime will unwind running compensation handlers and exit the workflow
                    Console.WriteLine("Host: This event is not going to arrive");
                    Console.WriteLine("Host: Cancel workflow with unhandled exception");
                    workflow.EnqueueItem(q.QueueName, new Exception("ExitWorkflowException"), null, null);
                }
            }
        }
        // </snippet261>
    }
    public partial class SampleWorkflow1 : SequentialWorkflowActivity
    {
        void submitExpense_MethodInvoking(object sender, EventArgs e)
        { }
        void expenseApproval_Executing(object sender, ActivityExecutionStatusChangedEventArgs e)
        { }
    }
    // <snippet262>
    public partial class SampleWorkflow1 : SequentialWorkflowActivity
    {
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            CanModifyActivities = true;
            this.submitExpense = new CallExternalMethodActivity();
            this.expenseApproval = new HandleExternalEventActivity();

            this.submitExpense.Name = "submitExpense";
            this.submitExpense.InterfaceType = typeof(IExpenseReportService);
            this.submitExpense.MethodName = "SubmitExpense";
            this.submitExpense.MethodInvoking += new EventHandler(submitExpense_MethodInvoking);

            this.expenseApproval.Name = "expenseApproval";
            this.expenseApproval.InterfaceType = typeof(IExpenseReportService);
            this.expenseApproval.EventName = "ExpenseApproval";
            this.expenseApproval.Executing += new EventHandler<ActivityExecutionStatusChangedEventArgs>(expenseApproval_Executing);

            this.Activities.Add(this.submitExpense);
            this.Activities.Add(this.expenseApproval);
            this.Name = "SampleWorkflow";
            CanModifyActivities = false;
        }
        private CallExternalMethodActivity submitExpense;
        private HandleExternalEventActivity expenseApproval;
    }
    // </snippet262>
    // Interface for the event and method to be invoked
    [ExternalDataExchange]
    public interface IExpenseReportService
    {
        void SubmitExpense(string id);
        event EventHandler<ExpenseReportEventArgs> ExpenseApproval;
    }
    public class ExpenseReportEventArgs : ExternalDataEventArgs
    {
        private string approvalValue;
        public ExpenseReportEventArgs(Guid instanceId, string id)
            : base(instanceId)
        {
            this.approvalValue = id;
        }
    }
    class ExpenseReportServiceImpl : IExpenseReportService
    {
        string expenseId;

        // Expense report is created in the system 
        // This method is invoked by the SubmitExpense activity
        public void SubmitExpense(string Id)
        {
            Console.WriteLine("Host: expense report sent");
            expenseId = Id;
        }

        // This method corresponds to the event being raised to approve the order
        public void ApprovalResult(WorkflowInstance workflow, string approval)
        {
            EventHandler<ExpenseReportEventArgs> expenseApproval = this.ExpenseApproval;
            if (expenseApproval != null)
                expenseApproval(workflow, new ExpenseReportEventArgs(workflow.InstanceId, approval));
        }

        public event EventHandler<ExpenseReportEventArgs> ExpenseApproval;
    }

    /***********************
     * Snippets from Hosting/CustomPersistenceService
     */

    // <snippet263>
    public class FilePersistenceService : WorkflowPersistenceService
    {
        private bool unloadOnIdle = false;

        public FilePersistenceService(bool unloadOnIdle)
        {
            this.unloadOnIdle = unloadOnIdle;
        }

        // <snippet264>
        // Save the workflow instance state at the point of persistence with option of locking the instance state if it is shared
        // across multiple runtimes or multiple phase instance updates
        protected override void SaveWorkflowInstanceState(Activity rootActivity, bool unlock)
        {
            // Save the workflow
            Guid contextGuid = (Guid)rootActivity.GetValue(Activity.ActivityContextGuidProperty);
            Console.WriteLine("Saving instance: {0}\n", contextGuid);
            SerializeToFile(
                WorkflowPersistenceService.GetDefaultSerializedForm(rootActivity), contextGuid);

            // See when the next timer (Delay activity) for this workflow will expire
            TimerEventSubscriptionCollection timers = (TimerEventSubscriptionCollection)rootActivity.GetValue(TimerEventSubscriptionCollection.TimerCollectionProperty);
            TimerEventSubscription subscription = timers.Peek();
            if (subscription != null)
            {
                // Set a system timer to automatically reload this workflow when its next timer expires
                TimerCallback callback = new TimerCallback(ReloadWorkflow);
                TimeSpan timeDifference = subscription.ExpiresAt - DateTime.UtcNow;
                System.Threading.Timer timer = new System.Threading.Timer(
                    callback,
                    subscription.WorkflowInstanceId,
                    timeDifference < TimeSpan.Zero ? TimeSpan.Zero : timeDifference,
                    new TimeSpan(-1));
            }
        }
        // </snippet264>

        // <snippet265>
        private void ReloadWorkflow(object id)
        {
            // Reload the workflow so that it will continue processing
            this.Runtime.GetWorkflow((Guid)id).Load();
        }
        // </snippet265>

        // <snippet266>
        // Load workflow instance state.
        protected override Activity LoadWorkflowInstanceState(Guid instanceId)
        {
            Console.WriteLine("Loading instance: {0}\n", instanceId);
            byte[] workflowBytes = DeserializeFromFile(instanceId);
            return WorkflowPersistenceService.RestoreFromDefaultSerializedForm(workflowBytes, null);
        }
        // </snippet266>

        // <snippet267>
        // Unlock the workflow instance state.  
        // Instance state locking is necessary when multiple runtimes share instance persistence store
        protected override void UnlockWorkflowInstanceState(Activity state)
        {
            //File locking is not supported in this sample
        }
        // </snippet267>

        // <snippet268>
        // Save the completed activity state.
        protected override void SaveCompletedContextActivity(Activity activity)
        {
            Guid contextGuid = (Guid)activity.GetValue(Activity.ActivityContextGuidProperty);
            Console.WriteLine("Saving completed activity context: {0}", contextGuid);
            SerializeToFile(
                WorkflowPersistenceService.GetDefaultSerializedForm(activity), contextGuid);
        }
        // </snippet268>

        // <snippet269>
        // Load the completed activity state.
        protected override Activity LoadCompletedContextActivity(Guid activityId, Activity outerActivity)
        {
            Console.WriteLine("Loading completed activity context: {0}", activityId);
            byte[] workflowBytes = DeserializeFromFile(activityId);
            Activity deserializedActivities = WorkflowPersistenceService.RestoreFromDefaultSerializedForm(workflowBytes, outerActivity);
            return deserializedActivities;

        }
        // </snippet269>

        // <snippet270>
        protected override bool UnloadOnIdle(Activity activity)
        {
            return unloadOnIdle;
        }
        // </snippet270>
        

        // Serialize the activity instance state to file
        private void SerializeToFile(byte[] workflowBytes, Guid id)
        {
            String filename = id.ToString();
            FileStream fileStream = null;
            try
            {
                if (File.Exists(filename))
                    File.Delete(filename);

                fileStream = new FileStream(filename, FileMode.CreateNew, FileAccess.Write, FileShare.None);

                // Get the serialized form
                fileStream.Write(workflowBytes, 0, workflowBytes.Length);
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }
        }

        // Deserialize the instance state from the file given the instance id 
        private byte[] DeserializeFromFile(Guid id)
        {
            String filename = id.ToString();
            FileStream fileStream = null;
            try
            {
                // File opened for shared reads but no writes by anyone
                fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                fileStream.Seek(0, SeekOrigin.Begin);
                byte[] workflowBytes = new byte[fileStream.Length];

                // Get the serialized form
                fileStream.Read(workflowBytes, 0, workflowBytes.Length);

                return workflowBytes;
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
    class Snippets28
    {

        static AutoResetEvent waitHandle = new AutoResetEvent(false);

        // <snippet271>
        static void Main()
        {
            using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                try
                {
                    // engine will unload workflow instance when it is idle
                    //<snippet272>
                    workflowRuntime.AddService(new FilePersistenceService(true));
                    //</snippet272>

                    //<snippet273>
                    workflowRuntime.WorkflowCreated += OnWorkflowCreated;
                    //</snippet273>
                    workflowRuntime.WorkflowCompleted += OnWorkflowCompleted;
                    //<snippet274>
                    workflowRuntime.WorkflowIdled += OnWorkflowIdle;
                    //</snippet274>
                    //<snippet275>
                    workflowRuntime.WorkflowUnloaded += OnWorkflowUnload;
                    //</snippet275>
                    //<snippet276>
                    workflowRuntime.WorkflowLoaded += OnWorkflowLoad;
                    //</snippet276>
                    workflowRuntime.WorkflowTerminated += OnWorkflowTerminated;
                    workflowRuntime.ServicesExceptionNotHandled += OnExceptionNotHandled;

                    workflowRuntime.CreateWorkflow(typeof(PersistenceServiceWorkflow)).Start();

                    waitHandle.WaitOne();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception \n\t Source: {0} \n\t Message: {1}", e.Source, e.Message);
                }
                finally
                {
                    workflowRuntime.StopRuntime();
                    Console.WriteLine("Workflow runtime stopped, program exiting... \n");
                }
            }
        }
        // </snippet271>

        // <snippet277>
        static void OnExceptionNotHandled(object sender, ServicesExceptionNotHandledEventArgs e)
        {
            Console.WriteLine("Unhandled Workflow Exception ");
            Console.WriteLine("  Type: " + e.GetType().ToString());
            Console.WriteLine("  Message: " + e.Exception.Message);
        }
        // </snippet277>
        static void OnWorkflowCreated(object sender, WorkflowEventArgs e)
        { }

        static void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        { }

        static void OnWorkflowIdle(object sender, WorkflowEventArgs e)
        { }

        static void OnWorkflowUnload(object sender, WorkflowEventArgs e)
        { }

        static void OnWorkflowLoad(object sender, WorkflowEventArgs e)
        { }

        static void OnWorkflowTerminated(object sender, WorkflowTerminatedEventArgs e)
        { }

    }
    //</snippet263>
    public partial class PersistenceServiceWorkflow : SequentialWorkflowActivity
    { }

    /****************************************
     * Snippets from Hosting/PersistenceHost
     */

    class Snippets29
    {
        private CallExternalMethodActivity SendDocument = new CallExternalMethodActivity();
        void Container1()
        {
            //<snippet278>
            this.SendDocument = new System.Workflow.Activities.CallExternalMethodActivity();
            //</snippet278>
        }
    }

    /************************************************
     * Snippets from Hosting/PersistenceServices
     */
    class Snippets30
    {
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        void container1()
        {
            //<snippet279>
            workflowRuntime.WorkflowPersisted += OnWorkflowPersisted;
            //</snippet279>
        }
        //<snippet280>
        //Called when the workflow is idle - in this sample this occurs when the workflow is waiting on the
        // delay1 activity to expire
        static void OnWorkflowIdled(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("Workflow is idle.");
            e.WorkflowInstance.TryUnload();
        }
        //</snippet280>
        static void OnWorkflowPersisted(object sender, WorkflowEventArgs e)
        {
        }
    }
    /*********************************
     * Snippets from Hosting/RaiseEventToLoadWorkflow
     */
    class Snippets31
    {
        HandleExternalEventActivity documentApproved;
        void container1()
        {
            // <snippet281>
            this.documentApproved = new HandleExternalEventActivity();
            this.documentApproved.Name = "documentApproved";
            this.documentApproved.InterfaceType = typeof(IDocumentApproval);
            this.documentApproved.EventName = "DocumentApproved";
            this.documentApproved.Roles = null;
            this.documentApproved.Invoked += documentApprovedInvoked;
            // </snippet281>
        }
        public interface IDocumentApproval
        {
        }
        void documentApprovedInvoked(object sender, EventArgs e)
        {
        }
    }

    /***************************************
     * Snippets from Hosting/WorkflowThreading
     */

    class Snippets32
    {
        static WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        static AutoResetEvent readyHandle = new AutoResetEvent(false);
        static WorkflowInstance workflowInstance;
        static void SetReloadWorkflowTimer()
        { }
        void container1(string[] args)
        {
            //<snippet282>
            ManualWorkflowSchedulerService scheduler = null;
            if (args[0].ToString().Equals("Single", StringComparison.OrdinalIgnoreCase))
            {
                scheduler = new ManualWorkflowSchedulerService();
                workflowRuntime.AddService(scheduler);
            }
            //</snippet282>

            //<snippet283>
            if (workflowRuntime.GetService<ManualWorkflowSchedulerService>() != null)
            {
                // Set a system timer to reload this workflow when its next timer expires
                SetReloadWorkflowTimer();
            }
            else
            {
                readyHandle.Set();
            }
            //</snippet283>
        }
        //<snippet284>
        static void ReloadWorkflow(object state)
        {
            if (workflowInstance.GetWorkflowNextTimerExpiration() > DateTime.UtcNow)
            {
                SetReloadWorkflowTimer();
            }
            else
            {
                readyHandle.Set();
            }
        }
        //</snippet284>
    }
    /************************
     * Snippets from Roles/ActiveDirectoryRoles
     */

    // <snippet285>
    [ExternalDataExchangeAttribute()]
    public interface IStartPurchaseOrder
    {
        event EventHandler<InitiatePOEventArgs> InitiatePurchaseOrder;
    }
    // </snippet285>

    public class InitiatePOEventArgs : ExternalDataEventArgs
    {
        public InitiatePOEventArgs()
            : base(Guid.NewGuid())
        {
        }
    }

    /*****************************
     * Snippets from Tracking/EventArgsTrackingSample
     */

    class Snippets33
    {
        // <snippet286>
        // Manipulating and Writing Information to Console
        static void WriteEventDescriptionAndArgs(string eventDescription, object argData, DateTime eventDateTime)
        {
            // checking the type and the corresponding event
            if (argData is TrackingWorkflowSuspendedEventArgs)
            {
                WriteSuspendedEventArgs(eventDescription, (TrackingWorkflowSuspendedEventArgs)argData, eventDateTime);
            }
            if (argData is TrackingWorkflowTerminatedEventArgs)
            {
                WriteTerminatedEventArgs(eventDescription, (TrackingWorkflowTerminatedEventArgs)argData, eventDateTime);
            }
            if (argData is TrackingWorkflowExceptionEventArgs)
            {
                WriteExceptionEventArgs(eventDescription, (TrackingWorkflowExceptionEventArgs)argData, eventDateTime);
            }
        }
        // </snippet286>

        // <snippet287>
        static void WriteSuspendedEventArgs(string eventDescription, TrackingWorkflowSuspendedEventArgs suspendedEventArgs, DateTime eventDataTime)
        {
            Console.WriteLine("\nSuspended Event Arguments Read From Tracking Database:\n");
            Console.WriteLine("EventDataTime: " + eventDataTime.ToString());
            Console.WriteLine("EventDescription: " + eventDescription);
            Console.WriteLine("SuspendedEventArgs Info: " + suspendedEventArgs.Error);
        }
        // </snippet287>

        // <snippet288>
        static void WriteTerminatedEventArgs(string eventDescription, TrackingWorkflowTerminatedEventArgs terminatedEventArgs, DateTime eventDataTime)
        {
            Console.WriteLine("\nTerminated Event Arguments Read From Tracking Database:\n");
            Console.WriteLine("EventDataTime: " + eventDataTime.ToString());
            Console.WriteLine("EventDescription: " + eventDescription);
            if (null != terminatedEventArgs.Exception)
            {
                Console.WriteLine("TerminatedEventArgs Exception Message: " + terminatedEventArgs.Exception.Message.ToString());
            }
        }
        // </snippet288>

        // <snippet289>
        static void WriteExceptionEventArgs(string eventDescription, TrackingWorkflowExceptionEventArgs exceptionEventArgs, DateTime eventDataTime)
        {
            Console.WriteLine("\nException Event Arguments Read From Tracking Database:\n");
            Console.WriteLine("EventDataTime: " + eventDataTime.ToString());
            Console.WriteLine("EventDescription: " + eventDescription);
            if (null != exceptionEventArgs.Exception)
            {
                Console.WriteLine("ExceptionEventArgs Exception Message: " + exceptionEventArgs.Exception.Message.ToString());
            }
            Console.WriteLine("ExceptionEventArgs Original Activity Path: " + exceptionEventArgs.OriginalActivityPath.ToString());
        }
        // </snippet289>
    }
    /**********************
     * Snippets from Tracking/QueryUsingSqlTrackingService
     */

    class Snippets34
    {
        private static AutoResetEvent waitHandle;
        private const string connectionString = "Initial Catalog=Tracking;Data Source=localhost;Integrated Security=SSPI;";
        private static Version version;

        private static Version GetTrackingProfileVersion(Version version)
        {
            return new Version();
        }
        private static void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs instance)
        { }
        private static void OutputActivityTrackingEvents(Guid instanceId)
        { }
        private static void InsertTrackingProfile(string profile)
        { }
        public partial class SimpleWorkflow : SequentialWorkflowActivity
        { }
        // <snippet290>
        static void Main()
        {
            try
            {
                waitHandle = new AutoResetEvent(false);
                version = GetTrackingProfileVersion(new Version("3.0.0.0"));
                CreateAndInsertTrackingProfile();
                using (WorkflowRuntime runtime = new WorkflowRuntime())
                {
                    SqlTrackingService trackingService = new SqlTrackingService(connectionString);
                    runtime.AddService(trackingService);
                    runtime.StartRuntime();
                    runtime.WorkflowCompleted += OnWorkflowCompleted;
                    runtime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                    {
                        Console.WriteLine(e.Exception.Message);
                        waitHandle.Set();
                    };

                    WorkflowInstance instance = runtime.CreateWorkflow(typeof(SimpleWorkflow));
                    instance.Start();
                    waitHandle.WaitOne();

                    runtime.StopRuntime();
                    OutputWorkflowTrackingEvents(instance.InstanceId);
                    OutputActivityTrackingEvents(instance.InstanceId);
                    Console.WriteLine("\nDone running the workflow.");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.Message);
                else
                    Console.WriteLine(ex.Message);
            }
        }
        // </snippet290>

        // <snippet291>
        private static void CreateAndInsertTrackingProfile()
        {
            TrackingProfile profile = new TrackingProfile();
            ActivityTrackPoint activityTrack = new ActivityTrackPoint();
            ActivityTrackingLocation activityLocation = new ActivityTrackingLocation(typeof(Activity));
            activityLocation.MatchDerivedTypes = true;
            IEnumerable<ActivityExecutionStatus> statuses = Enum.GetValues(typeof(ActivityExecutionStatus)) as IEnumerable<ActivityExecutionStatus>;
            foreach (ActivityExecutionStatus status in statuses)
            {
                activityLocation.ExecutionStatusEvents.Add(status);
            }

            activityTrack.MatchingLocations.Add(activityLocation);
            profile.ActivityTrackPoints.Add(activityTrack);
            profile.Version = version;

            WorkflowTrackPoint workflowTrack = new WorkflowTrackPoint();
            WorkflowTrackingLocation workflowLocation = new WorkflowTrackingLocation();
            IEnumerable<TrackingWorkflowEvent> eventStatuses = Enum.GetValues(typeof(TrackingWorkflowEvent)) as IEnumerable<TrackingWorkflowEvent>;
            foreach (TrackingWorkflowEvent status in eventStatuses)
            {
                workflowLocation.Events.Add(status);
            }

            workflowTrack.MatchingLocation = workflowLocation;
            profile.WorkflowTrackPoints.Add(workflowTrack);

            TrackingProfileSerializer serializer = new TrackingProfileSerializer();
            StringWriter writer = new StringWriter(new StringBuilder(), CultureInfo.InvariantCulture);
            serializer.Serialize(writer, profile);
            String trackingprofile = writer.ToString();
            InsertTrackingProfile(trackingprofile);
        }
        // </snippet291>

        // <snippet292>
        private static void OutputWorkflowTrackingEvents(Guid instanceId)
        {
            SqlTrackingQuery sqlTrackingQuery = new SqlTrackingQuery(connectionString);

            SqlTrackingWorkflowInstance sqlTrackingWorkflowInstance;
            if (sqlTrackingQuery.TryGetWorkflow(instanceId, out sqlTrackingWorkflowInstance))
            {
                Console.WriteLine("\nInstance Level Events:\n");

                foreach (WorkflowTrackingRecord workflowTrackingRecord in sqlTrackingWorkflowInstance.WorkflowEvents)
                {
                    Console.WriteLine("EventDescription : {0}  DateTime : {1}", workflowTrackingRecord.TrackingWorkflowEvent, workflowTrackingRecord.EventDateTime);
                }
            }
        }
        // </snippet292>
    }

    /***************************************
     * Snippets from Tracking/RuleActionTrackingEventSample
     */

    class Snippets35 : SequentialWorkflowActivity
    {
        private static void WriteTitle(string title)
        { }

        // <snippet293>
        private static void WriteUserTrackingRecord(UserTrackingRecord userTrackingRecord)
        {
            WriteTitle("User Activity Record");
            Console.WriteLine("EventDataTime: " + userTrackingRecord.EventDateTime.ToString());
            Console.WriteLine("QualifiedId: " + userTrackingRecord.QualifiedName.ToString());
            Console.WriteLine("ActivityType: " + userTrackingRecord.ActivityType.FullName.ToString());
            if (userTrackingRecord.UserData is RuleActionTrackingEvent)
            {
                WriteRuleActionTrackingEvent((RuleActionTrackingEvent)userTrackingRecord.UserData);
            }
        }

        private static void WriteRuleActionTrackingEvent(RuleActionTrackingEvent ruleActionTrackingEvent)
        {
            Console.WriteLine("RuleActionTrackingEvent");
            Console.WriteLine("***********************");
            Console.WriteLine("RuleName: " + ruleActionTrackingEvent.RuleName.ToString());
            Console.WriteLine("ConditionResult: " + ruleActionTrackingEvent.ConditionResult.ToString());
        }
        // </snippet293>
        void container1()
        {
            // <snippet294>
            this.CanModifyActivities = true;
            System.Workflow.Activities.Rules.RuleSetReference rulesetreference1 = new System.Workflow.Activities.Rules.RuleSetReference();
            this.simpleDiscountPolicy = new System.Workflow.Activities.PolicyActivity();
            // 
            // simpleDiscountPolicy
            // 
            this.simpleDiscountPolicy.Name = "simpleDiscountPolicy";
            rulesetreference1.RuleSetName = "DiscountRuleSet";
            this.simpleDiscountPolicy.RuleSetReference = rulesetreference1;
            // 
            // SimplePolicyWorkflow
            // 
            this.Activities.Add(this.simpleDiscountPolicy);
            this.Name = "SimplePolicyWorkflow";
            this.Completed += new System.EventHandler(this.WorkflowCompleted);
            this.CanModifyActivities = false;
            // </snippet294>
        }

        private PolicyActivity simpleDiscountPolicy;
        private void WorkflowCompleted(object sender, EventArgs e)
        { }
    }

    /**************************
     * Snippets from Tracking/SimpleTrackingSample
     */

    class Snippets36
    {
        void container1()
        {
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();
            //<snippet295>
            WorkflowInstance workflowInstance = workflowRuntime.CreateWorkflow(typeof(SimpleTrackingWorkflow));
            Guid instanceId = workflowInstance.InstanceId;
            //</snippet295>
        }
        class SimpleTrackingWorkflow { }
    }

    /***********************************************
     * Snippets from SqlDataMaintenance
     */

    class Snippets37
    {
        internal const string connectionString = "Initial Catalog=Tracking;Data Source=localhost;Integrated Security=SSPI;";

        // <snippet296>
        internal static void SetPartitionInterval(Char interval)
        {
            // Valid values are 'd' (daily), 'm' (monthly), and 'y' (yearly).  The default is 'm'.
            using (SqlCommand command = new SqlCommand("dbo.SetPartitionInterval"))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = new SqlConnection(connectionString);

                SqlParameter intervalParameter = new SqlParameter("@Interval", SqlDbType.Char);
                intervalParameter.SqlValue = interval;
                command.Parameters.Add(intervalParameter);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
        // </snippet296>
    }






}
