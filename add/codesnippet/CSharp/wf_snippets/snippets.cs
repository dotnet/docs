
using System;

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;

using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using System.IO;

using System.Runtime.Serialization;

using System.Text;

using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Runtime.Tracking;

using System.Xml;

using System.Windows.Forms;
using WF_Snippets;

//Snippets:  New home for custom snippets created for Windows Workflow Foundation API pages
class snippets
{
    //<snippet0>
    //Implementation of the abstract WorkflowCommitWorkBatchService class
    class DefaultCommitWorkBatchService : WorkflowCommitWorkBatchService
    {
        protected override void CommitWorkBatch(CommitWorkBatchCallback commitWorkBatchCallback)
        {
            // Call base implementation
            try
            {
                base.CommitWorkBatch(commitWorkBatchCallback);
            }
            catch (Exception e)
            {
                // Report work batch commit failures
                Console.WriteLine("Work batch failed: " + e.Message.ToString());
                throw;
            }
        }
    }
    //</snippet0>

    public partial class CustomExternalMethodActivity : CallExternalMethodActivity
    {
        //<snippet1>
        protected override void OnMethodInvoked(EventArgs e)
        {
            base.OnMethodInvoked(e);
            Console.WriteLine("External Method Invoked.");
        }
        //</snippet1>
    }

    public void Container0()
    {
        //<snippet2>
        // Create a new Correlation Property object
        CorrelationProperty correlationProperty = new CorrelationProperty("taskName", "reportBalance");
        // Read the property name
        String taskName = correlationProperty.Name;
        // Read the property value
        Object taskValue = correlationProperty.Value;
        //</snippet2>

        //<snippet3>
        // Create a new Correlation Token
        CorrelationToken subscriptionToken = new CorrelationToken();
        // Assign the token name
        subscriptionToken.Name = "Operation";
        //</snippet3>

        //<snippet4>
        // Create a new Correlation Token
        CorrelationToken testToken = new CorrelationToken();
        // Read the Initialized value
        Boolean tokenInitialized = testToken.Initialized;
        //</snippet4>

        //<snippet5>
        // Create a new Correlation Token
        CorrelationToken propertiedToken = new CorrelationToken();
        // Fetch a list of the correlation token properties
        List<CorrelationProperty> tokenProperties = (List<CorrelationProperty>)propertiedToken.Properties;
        //</snippet5>

        //<snippet6>
        // Create a new workflow runtime
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        // Obtain the type of the TrackingService abstract class
        Type serviceType = typeof(TrackingService);
        // Create a services collection
        ReadOnlyCollection<TrackingService> services;
        // Fetch a collection of all services that match the given type
        services = workflowRuntime.GetAllServices<TrackingService>();
        //</snippet6>

        //<snippet7>
        // Create the main workflow runtime
        WorkflowRuntime runtime = new WorkflowRuntime();
        // Create a workflow instance
        WorkflowInstance workflowInstance = runtime.CreateWorkflow(typeof(Workflow1));
        // Obtain a reference to the instance's parent runtime
        WorkflowRuntime runtime2 = workflowInstance.WorkflowRuntime;
        //</snippet7>

        
    }

    public void Container1()
    {
        //<snippet8>
        // Create a workflow runtime
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        // Create a workflow instance
        WorkflowInstance workflowInstance = workflowRuntime.CreateWorkflow(typeof(Workflow1));
        // Start the workflow
        workflowInstance.Start();
        // Terminate the workflow, passing in a message
        workflowInstance.Terminate("Workflow manually terminated");
        //</snippet8>
    }

    public void Container2()
    {
        //<snippet9>
        // Create a workflow runtime
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        // Create a workflow instance
        WorkflowInstance workflowInstance = workflowRuntime.CreateWorkflow(typeof(Workflow1));
        // Start the workflow
        workflowInstance.Start();
        // Suspend the workflow, passing in a message
        workflowInstance.Suspend("Workflow manually suspended");
        //</snippet9>
    }

    public void Container3()
    {
        //<snippet10>
        //<snippet11>
        // Create a WorkflowRuntime object
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        // Create a new instance of the out-of-box SqlWorkflowPersistenceService
        SqlWorkflowPersistenceService persistenceService =
           new SqlWorkflowPersistenceService(
           "Initial Catalog=SqlPersistenceService;Data Source=localhost;Integrated Security=SSPI;");
        // Add the service to the runtime
        workflowRuntime.AddService(persistenceService);
        // Create a WorkflowInstance object
        WorkflowInstance workflowInstance = workflowRuntime.CreateWorkflow(typeof(Workflow1));
        // Start the workflow instance
        workflowInstance.Start();
        //Unload the instance
        workflowInstance.Unload();
        //</snippet11>
        //Reload the previously unloaded instance
        workflowInstance.Load();
        //</snippet10>
    }

    public void Container4()
    {
        //<snippet12>
        // Create a workflow runtime environment
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        // Create a new instance of the out-of-box SqlWorkflowPersistenceService.
        // Use the non-locking constructor, since we're only creating a single Workflow Runtime.
        NameValueCollection parameters = new NameValueCollection();
        parameters.Add("ConnectionString",
            "Initial Catalog=SqlPersistenceService;Data Source=localhost;Integrated Security=SSPI;");
        //Set UnloadOnIdle to true, so that the service will persist the workflow
        parameters.Add("UnloadOnIdle", "true");
        SqlWorkflowPersistenceService persistenceService =
           new SqlWorkflowPersistenceService(parameters);

        // Add the service to the runtime
        workflowRuntime.AddService(persistenceService);
        // Create a WorkflowInstance object
        WorkflowInstance workflowInstance = workflowRuntime.CreateWorkflow(typeof(Workflow1));
        // Start the instance
        workflowInstance.Start();
        // Create an instance of a class that implements IPendingWork for notification
        PendingService pendingWork = new PendingService();
        // Send the workflow the message
        workflowInstance.EnqueueItemOnIdle("ActionQueue", "StartWork", pendingWork, "ActionItem");
        //</snippet12>
    }

    public void Container5()
    {
        //<snippet13>
        //Create a workflow runtime
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        //Create a workflow instance
        WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(Workflow1));
        //Start the instance
        instance.Start();
        //Abort the instance
        instance.Abort();
        //</snippet13>
    }

    public void Container6()
    {
        //<snippet14>
        // Create a new workflow runtime
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        // Add an anonymous method as the event handler for the Stopped event.
        workflowRuntime.Stopped += new EventHandler<WorkflowRuntimeEventArgs>(
            delegate { Console.WriteLine("Workflow runtime stopped."); });
        //</snippet14>
    }
    public void Container7()
    {
        //<snippet15>
        // Create a new workflow runtime
        WorkflowRuntime startingRuntime = new WorkflowRuntime();
        // Add an anonymous method as the event handler for the Started event.
        startingRuntime.Started += new EventHandler<WorkflowRuntimeEventArgs>(
            delegate { Console.WriteLine("Workflow runtime started."); });
        //</snippet15>
    }

    public void Container8()
    {
        //<snippet16>
        // Create a new workflow runtime
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        // Create a new instance of the out-of-box SqlWorkflowPersistenceService
        SqlWorkflowPersistenceService persistenceService =
           new SqlWorkflowPersistenceService(
           "Initial Catalog=SqlPersistenceService;Data Source=localhost;Integrated Security=SSPI;");
        // Add the service to the runtime
        workflowRuntime.AddService(persistenceService);
        // Start the runtime
        workflowRuntime.StartRuntime();
        // Stop the runtime
        workflowRuntime.StopRuntime();
        // Remove the service from the runtime
        workflowRuntime.RemoveService(persistenceService);
        //</snippet16>
    }
    public void Container9()
    {
        //<snippet17>
        // Create a new workflow runtime
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        // Create a new instance of the out-of-box SqlWorkflowPersistenceService.  
        // A persistence service is necessary in order to get workflows from the runtime.
        SqlWorkflowPersistenceService persistenceService =
            new SqlWorkflowPersistenceService(
            "Initial Catalog=SqlPersistenceService;Data Source=localhost;Integrated Security=SSPI;");
        // Add the service to the runtime
        workflowRuntime.AddService(persistenceService);
        // Start the runtime
        workflowRuntime.StartRuntime();

        // Create a new workflow instance
        WorkflowInstance workflowInstance = workflowRuntime.CreateWorkflow(typeof(Workflow1));
        // Start the workflow
        workflowInstance.Start();

        // Fetch the instance ID of the workflow
        Guid workflowId = workflowInstance.InstanceId;

        // Fetch a reference to the workflow using the GetWorkflow method.
        WorkflowInstance workflowReference = workflowRuntime.GetWorkflow(workflowId);
        //</snippet17>
    }
    public void Container10()
    {
        //<snippet18>
        // Create a new workflow runtime
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        // Start the runtime
        workflowRuntime.StartRuntime();
        // Create a collection of workflow instances
        ReadOnlyCollection<WorkflowInstance> workflows;
        // Populate the collection of workflow instances
        workflows = workflowRuntime.GetLoadedWorkflows();
        //</snippet18>
    }
    public void Container11()
    {
        //<snippet19>
        // Create a new workflow runtime
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        // Obtain the type of the TrackingService abstract class
        Type serviceType = typeof(TrackingService);
        // Create a services collection
        ReadOnlyCollection<object> services;
        // Fetch a collection of all services that match the given type
        services = workflowRuntime.GetAllServices(serviceType);
        //</snippet19>
    }
    public void Container12()
    {
        //<snippet20>
        // Create a new WorkflowRuntime
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        // Assign a name to the runtime
        workflowRuntime.Name = "Main Runtime";
        //</snippet20>
    }
    public void Container13()
    {
        //<snippet21>
        // Create a new workflow runtime
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();
        // Start the runtime
        workflowRuntime.StartRuntime();
        // If the runtime is started, report to the console.
        if (workflowRuntime.IsStarted)
            Console.WriteLine("Runtime is started.");
        //</snippet21>
    }
    //<snippet22>
    class WorkflowLoaderServiceExample
    {
        public static void CreateRuntime()
        {
            //Create the workflow runtime to host the custom loader service
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();
            //Create an instance of the default implementation of the WorkflowLoaderService
            CustomWorkflowLoaderService loaderService = new CustomWorkflowLoaderService();
            workflowRuntime.AddService(loaderService);

            //Dispose of the runtime properly
            workflowRuntime.Dispose();
        }
        public class CustomWorkflowLoaderService : WorkflowLoaderService
        {
            protected override Activity CreateInstance(XmlReader workflowDefinitionReader, XmlReader rulesReader)
            {
                //For the purpose of this sample, return a blank SequentialWorkflowActivity.
                return new SequentialWorkflowActivity();

            }

            protected override Activity CreateInstance(Type workflowType)
            {
                //For the purpose of this sample, return a blank SequentialWorkflowActivity.
                return new SequentialWorkflowActivity();
            }
        }
    }
    //</snippet22>

    public class ParallelIfBranchDesigner : SequentialActivityDesigner
    {
        // <snippet23>
        public override bool CanBeParentedTo(CompositeActivityDesigner parentActivityDesigner)
        {
            if (null == parentActivityDesigner)
                throw new ArgumentNullException("parentActivityDesigner");

            if (!(parentActivityDesigner.Activity is ParallelIfActivity))
                return false;
            else
                return base.CanBeParentedTo(parentActivityDesigner);
        }
        // </snippet23>
    }

    // <snippet24>
    [ActivityDesignerTheme(typeof(ParallelIfTheme))]
    public class ParallelIfDesigner : ParallelActivityDesigner
    // </snippet24>
    {
        // <snippet25>
        public override bool CanInsertActivities(HitTestInfo insertLocation, ReadOnlyCollection<Activity> activitiesToInsert)
        {
            return false;
        }
        // </snippet25>

        // <snippet26>
        public override bool CanMoveActivities(HitTestInfo moveLocation, ReadOnlyCollection<Activity> activitiesToMove)
        {
            return false;
        }
        // </snippet26>

        // <snippet27>
        public override bool CanRemoveActivities(ReadOnlyCollection<Activity> activitiesToRemove)
        {
            return true;
        }
        // </snippet27>

        // <snippet28>
        // <snippet29>
        protected override CompositeActivity OnCreateNewBranch()
        {
            return new ParallelIfBranch();
        }
        // </snippet29>

        private void OnAddBranch(object sender, EventArgs e)
        {
            CompositeActivity activity1 = this.OnCreateNewBranch();
            CompositeActivity activity2 = base.Activity as CompositeActivity;

            if ((activity2 != null) && (activity1 != null))
            {
                int num1 = this.ContainedDesigners.Count;
                Activity[] activityArray1 = new Activity[] { activity1 };

                if (CanInsertActivities(new ConnectorHitTestInfo(this, HitTestLocations.Designer, activity2.Activities.Count),
                    new List<Activity>(activityArray1).AsReadOnly()))
                {
                    CompositeActivityDesigner.InsertActivities(this,
                        new ConnectorHitTestInfo(this, HitTestLocations.Designer, activity2.Activities.Count),
                        new List<Activity>(activityArray1).AsReadOnly(),
                        string.Format("Adding branch {0}", activity1.GetType().Name));

                    if ((this.ContainedDesigners.Count > num1) && (this.ContainedDesigners.Count > 0))
                    {
                        this.ContainedDesigners[this.ContainedDesigners.Count - 1].EnsureVisible();
                    }
                }
            }
        }
        // </snippet28>

        protected override void OnExecuteDesignerAction(DesignerAction designerAction)
        {            
        }
    }
    // <snippet30>
    public class ParallelIfTheme : CompositeDesignerTheme
    {
        public ParallelIfTheme(WorkflowTheme theme)
            : base(theme)
        {
            this.ShowDropShadow = true;
            this.ConnectorStartCap = LineAnchor.None;
            this.ConnectorEndCap = LineAnchor.None;
            this.BorderStyle = DashStyle.Dash;
            this.WatermarkImagePath = @"parallelIfWatermark.png";
            this.WatermarkAlignment = DesignerContentAlignment.Fill;
        }
    }
    // </snippet30>
    public class WorkflowLoader : WorkflowDesignerLoader
    {
        internal static void DestroyObjectGraphFromDesignerHost(IDesignerHost designerHost, Activity activity)
        {
        }
        // <snippet31>
        protected override void Initialize()
        {
            base.Initialize();

            IDesignerLoaderHost host = this.LoaderHost;
            if (host != null)
            {
                host.RemoveService(typeof(IIdentifierCreationService));
                host.AddService(typeof(IIdentifierCreationService), new IdentifierCreationService(host));
                host.AddService(typeof(IMenuCommandService), new WorkflowMenuCommandService(host));
                host.AddService(typeof(IToolboxService), new Toolbox(host));
                TypeProvider typeProvider = new TypeProvider(host);
                typeProvider.AddAssemblyReference(typeof(string).Assembly.Location);
                host.AddService(typeof(ITypeProvider), typeProvider, true);
                host.AddService(typeof(IEventBindingService), new EventBindingService());
            }
        }
        // </snippet31>

        // <snippet32>
        public override string FileName
        {
            // return path of workflow file
            get
            {
                return this.xomlFile;
            }
        }
        // </snippet32>

        private string xoml;
        public string Xoml
        {
            get { return xoml; }
            set { xoml = value;  }
        }

        private string xomlFile = string.Empty;

        public string XomlFile
        {
            get
            {
                return this.xomlFile;
            }
            set
            {
                this.xomlFile = value;
            }
        }
        // <snippet33>
        public override TextReader GetFileReader(string filePath)
        {
            return new StreamReader(new FileStream(filePath, FileMode.OpenOrCreate));
        }
        // </snippet33>

        // <snippet34>
        public override TextWriter GetFileWriter(string filePath)
        {
            return new StreamWriter(new FileStream(filePath, FileMode.OpenOrCreate));
        }
        // </snippet34>

        // <snippet35>
        public override void Flush()
        {
            this.PerformFlush(null);
        }

        protected override void PerformFlush(IDesignerSerializationManager manager)
        {
            IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));

            if (host != null && host.RootComponent != null)
            {
                Activity service = host.RootComponent as Activity;

                if (service != null)
                {
                    using (XmlWriter writer = XmlWriter.Create(this.xomlFile))
                    {
                        WorkflowMarkupSerializer xomlSerializer = new WorkflowMarkupSerializer();
                        if (manager == null)
                        {
                            xomlSerializer.Serialize(writer, service);
                        }
                        else
                        {
                            xomlSerializer.Serialize(manager, writer, service);
                        }
                    }
                }
            }
        }
        // </snippet35>

        // <snippet36>
        protected override void OnEndLoad(bool successful, ICollection errors)
        {
            base.OnEndLoad(successful, errors);

            if (!successful && errors != null)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder("Errors\r\n");
                foreach (string error in errors)
                {
                    sb.Append(error + "\r\n");
                }

                MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // </snippet36>

        // <snippet37>
        protected override void PerformLoad(IDesignerSerializationManager serializationManager)
        {
            IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
            Activity rootActivity = null;

            // If a WorkflowType already exists, create an instance instead of reading from file
            if (WorkflowType != null)
            {
                rootActivity = (Activity)Activator.CreateInstance(WorkflowType);
            }
            else
            {
                // Create a text reader out of the doc data
                TextReader reader = new StringReader(this.xoml);
                try
                {
                    using (XmlReader xmlReader = XmlReader.Create(reader))
                    {
                        WorkflowMarkupSerializer xomlSerializer = new WorkflowMarkupSerializer();
                        rootActivity = xomlSerializer.Deserialize(xmlReader) as Activity;
                    }
                }
                finally
                {
                    reader.Close();
                }
            }

            if (rootActivity != null && designerHost != null)
            {
                AddObjectGraphToDesignerHost(designerHost, rootActivity);
            }
        }

        private static void AddObjectGraphToDesignerHost(IDesignerHost designerHost, Activity activity)
        {
            Guid Definitions_Class = new Guid("3FA84B23-B15B-4161-8EB8-37A54EFEEFC7");

            if (designerHost == null)
                throw new ArgumentNullException("designerHost");
            if (activity == null)
                throw new ArgumentNullException("activity");

            string rootSiteName = activity.QualifiedName;
            if (activity.Parent == null)
            {
                string fullClassName = activity.UserData[Definitions_Class] as string;
                if (fullClassName == null)
                    fullClassName = activity.GetType().FullName;
                rootSiteName = (fullClassName.LastIndexOf('.') != -1) ? fullClassName.Substring(fullClassName.LastIndexOf('.') + 1) : fullClassName;
                designerHost.Container.Add(activity, rootSiteName);
            }
            else
            {
                designerHost.Container.Add(activity, activity.QualifiedName);
            }

            if (activity is CompositeActivity)
            {
                foreach (Activity activity2 in GetNestedActivities(activity as CompositeActivity))
                    designerHost.Container.Add(activity2, activity2.QualifiedName);
            }
        }

        private static Activity[] GetNestedActivities(CompositeActivity compositeActivity)
        {
            if (compositeActivity == null)
                throw new ArgumentNullException("compositeActivity");

            IList<Activity> childActivities = null;
            ArrayList nestedActivities = new ArrayList();
            Queue compositeActivities = new Queue();
            compositeActivities.Enqueue(compositeActivity);
            while (compositeActivities.Count > 0)
            {
                CompositeActivity compositeActivity2 = (CompositeActivity)compositeActivities.Dequeue();
                childActivities = compositeActivity2.Activities;

                foreach (Activity activity in childActivities)
                {
                    nestedActivities.Add(activity);
                    if (activity is CompositeActivity)
                        compositeActivities.Enqueue(activity);
                }
            }
            return (Activity[])nestedActivities.ToArray(typeof(Activity));
        }
        // </snippet37>

        private Type workflowType = null;

        public Type WorkflowType
        {
            get { return workflowType; }
            set { workflowType = value; }
        }

        // <snippet38>
        public void SaveLayout()
        {
            using (XmlWriter writer = XmlWriter.Create("wfInstanceId.designer.xml"))
            {
                IList layoutSaveErrors = new ArrayList() as IList;
                IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));
                ActivityDesigner rootDesigner = host.GetDesigner(host.RootComponent) as ActivityDesigner;
                this.SaveDesignerLayout(writer, rootDesigner, out layoutSaveErrors);

                if (layoutSaveErrors.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder("Errors:\r\n");
                    foreach (WorkflowMarkupSerializationException error in layoutSaveErrors)
                    {
                        sb.Append(error.Message + "\r\n");
                    }
                    MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // </snippet38>

        // <snippet39>
        public void LoadLayout()
        {
            using (XmlReader reader = XmlReader.Create("wfInstanceId.designer.xml"))
            {
                IList layoutLoadErrors = new ArrayList() as IList;
                this.LoadDesignerLayout(reader, out layoutLoadErrors);

                if (layoutLoadErrors.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder("Errors:\r\n");
                    foreach (WorkflowMarkupSerializationException error in layoutLoadErrors)
                    {
                        sb.Append(error.Message + "\r\n");
                    }
                    MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // </snippet39>

        // <snippet40>
        public void RemoveLastChildActivity()
        {
            IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
            CompositeActivity rootActivity = designerHost.RootComponent as CompositeActivity;

            if (rootActivity.Activities.Count > 0)
            {
                Activity activityToRemove = rootActivity.Activities[rootActivity.Activities.Count - 1];
                rootActivity.Activities.Remove(activityToRemove);
                this.RemoveActivityFromDesigner(activityToRemove);
            }
        }
        // </snippet40>
    }

    // <snippet41>
    internal sealed class IdentifierCreationService : IIdentifierCreationService
    {
        private IServiceProvider serviceProvider = null;

        internal IdentifierCreationService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        // <snippet42>
        void IIdentifierCreationService.ValidateIdentifier(Activity activity, string identifier)
        {
            if (identifier == null)
                throw new ArgumentNullException("identifier");
            if (activity == null)
                throw new ArgumentNullException("activity");

            if (activity.Name.ToLower().Equals(identifier.ToLower()))
                return;

            ArrayList identifiers = new ArrayList();
            Activity rootActivity = GetRootActivity(activity);
            identifiers.AddRange(GetIdentifiersInCompositeActivity(rootActivity as CompositeActivity));
            identifiers.Sort();
            if (identifiers.BinarySearch(identifier.ToLower(), StringComparer.OrdinalIgnoreCase) >= 0)
                throw new ArgumentException(string.Format("Duplicate Component Identifier {0}", identifier));
        }
        // </snippet42>

        // <snippet43>
        void IIdentifierCreationService.EnsureUniqueIdentifiers(CompositeActivity parentActivity, ICollection childActivities)
        {
            if (parentActivity == null)
                throw new ArgumentNullException("parentActivity");
            if (childActivities == null)
                throw new ArgumentNullException("childActivities");

            List<Activity> allActivities = new List<Activity>();

            Queue activities = new Queue(childActivities);
            while (activities.Count > 0)
            {
                Activity activity = (Activity)activities.Dequeue();
                if (activity is CompositeActivity)
                {
                    foreach (Activity child in ((CompositeActivity)activity).Activities)
                        activities.Enqueue(child);
                }

                //If we are moving activities, we need not regenerate their identifiers
                if (((IComponent)activity).Site != null)
                    continue;

                allActivities.Add(activity);
            }

            // get the root activity
            CompositeActivity rootActivity = GetRootActivity(parentActivity) as CompositeActivity;
            ArrayList identifiers = new ArrayList(); // all the identifiers in the workflow
            identifiers.AddRange(GetIdentifiersInCompositeActivity(rootActivity));

            foreach (Activity activity in allActivities)
            {
                string finalIdentifier = activity.Name;

                // now loop until we find a identifier that hasn't been used.
                string baseIdentifier = GetBaseIdentifier(activity);
                int index = 0;

                identifiers.Sort();
                while (finalIdentifier == null || finalIdentifier.Length == 0 || identifiers.BinarySearch(finalIdentifier.ToLower(), StringComparer.OrdinalIgnoreCase) >= 0)
                {
                    finalIdentifier = string.Format("{0}{1}", baseIdentifier, ++index);
                }

                // add new identifier to collection 
                identifiers.Add(finalIdentifier);
                activity.Name = finalIdentifier;
            }
        }

        private static IList GetIdentifiersInCompositeActivity(CompositeActivity compositeActivity)
        {
            ArrayList identifiers = new ArrayList();
            if (compositeActivity != null)
            {
                identifiers.Add(compositeActivity.Name);
                IList<Activity> allChildren = GetAllNestedActivities(compositeActivity);
                foreach (Activity activity in allChildren)
                    identifiers.Add(activity.Name);
            }
            return ArrayList.ReadOnly(identifiers);
        }

        private static string GetBaseIdentifier(Activity activity)
        {
            string baseIdentifier = activity.GetType().Name;
            StringBuilder b = new StringBuilder(baseIdentifier.Length);
            for (int i = 0; i < baseIdentifier.Length; i++)
            {
                if (Char.IsUpper(baseIdentifier[i]) && (i == 0 || i == baseIdentifier.Length - 1 || Char.IsUpper(baseIdentifier[i + 1])))
                {
                    b.Append(Char.ToLower(baseIdentifier[i]));
                }
                else
                {
                    b.Append(baseIdentifier.Substring(i));
                    break;
                }
            }
            return b.ToString();
        }

        private static Activity GetRootActivity(Activity activity)
        {
            if (activity == null)
                throw new ArgumentException("activity");

            while (activity.Parent != null)
                activity = activity.Parent;

            return activity;
        }

        private static Activity[] GetAllNestedActivities(CompositeActivity compositeActivity)
        {
            if (compositeActivity == null)
                throw new ArgumentNullException("compositeActivity");

            ArrayList nestedActivities = new ArrayList();
            Queue compositeActivities = new Queue();
            compositeActivities.Enqueue(compositeActivity);
            while (compositeActivities.Count > 0)
            {
                CompositeActivity compositeActivity2 = (CompositeActivity)compositeActivities.Dequeue();

                foreach (Activity activity in compositeActivity2.Activities)
                {
                    nestedActivities.Add(activity);
                    if (activity is CompositeActivity)
                        compositeActivities.Enqueue(activity);
                }

                foreach (Activity activity in compositeActivity2.EnabledActivities)
                {
                    if (!nestedActivities.Contains(activity))
                    {
                        nestedActivities.Add(activity);
                        if (activity is CompositeActivity)
                            compositeActivities.Enqueue(activity);
                    }
                }
            }
            return (Activity[])nestedActivities.ToArray(typeof(Activity));
        }
        // </snippet43>
    }
    // </snippet41>

    // <snippet44>
    internal sealed class WorkflowMenuCommandService : MenuCommandService
    {
        public WorkflowMenuCommandService(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        // <snippet45>
        public override void ShowContextMenu(CommandID menuID, int x, int y)
        {
            if (menuID == WorkflowMenuCommands.SelectionMenu)
            {
                ContextMenu contextMenu = new ContextMenu();

                foreach (DesignerVerb verb in Verbs)
                {
                    MenuItem menuItem = new MenuItem(verb.Text, new EventHandler(OnMenuClicked));
                    menuItem.Tag = verb;
                    contextMenu.MenuItems.Add(menuItem);
                }

                MenuItem[] items = GetSelectionMenuItems();
                if (items.Length > 0)
                {
                    contextMenu.MenuItems.Add(new MenuItem("-"));
                    foreach (MenuItem item in items)
                        contextMenu.MenuItems.Add(item);
                }

                WorkflowView workflowView = GetService(typeof(WorkflowView)) as WorkflowView;
                if (workflowView != null)
                    contextMenu.Show(workflowView, workflowView.PointToClient(new Point(x, y)));
            }
            // </snippet45>
        }

        // <snippet46>
        private MenuItem[] GetSelectionMenuItems()
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            bool addMenuItems = true;
            ISelectionService selectionService = GetService(typeof(ISelectionService)) as ISelectionService;
            if (selectionService != null)
            {
                foreach (object obj in selectionService.GetSelectedComponents())
                {
                    if (!(obj is Activity))
                    {
                        addMenuItems = false;
                        break;
                    }
                }
            }

            if (addMenuItems)
            {
                Dictionary<CommandID, string> selectionCommands = new Dictionary<CommandID, string>();
                selectionCommands.Add(WorkflowMenuCommands.Cut, "Cut");
                selectionCommands.Add(WorkflowMenuCommands.Copy, "Copy");
                selectionCommands.Add(WorkflowMenuCommands.Paste, "Paste");
                selectionCommands.Add(WorkflowMenuCommands.Delete, "Delete");
                selectionCommands.Add(WorkflowMenuCommands.Collapse, "Collapse");
                selectionCommands.Add(WorkflowMenuCommands.Expand, "Expand");
                selectionCommands.Add(WorkflowMenuCommands.Disable, "Disable");
                selectionCommands.Add(WorkflowMenuCommands.Enable, "Enable");

                foreach (CommandID id in selectionCommands.Keys)
                {
                    MenuCommand command = FindCommand(id);
                    if (command != null)
                    {
                        MenuItem menuItem = new MenuItem(selectionCommands[id], new EventHandler(OnMenuClicked));
                        menuItem.Tag = command;
                        menuItems.Add(menuItem);
                    }
                }
            }

            return menuItems.ToArray();
        }

        private void OnMenuClicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null && menuItem.Tag is MenuCommand)
            {
                MenuCommand command = menuItem.Tag as MenuCommand;
                command.Invoke();
            }
        }
        // </snippet46>
    }
    // </snippet44>

    public partial class WFPadWorkflowDesignerControl : UserControl, IDisposable, IServiceProvider
    {
        private WorkflowView workflowView;
        private DesignSurface designSurface;
        private WorkflowLoader loader;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton btnAutoSynch;
        private System.Windows.Forms.TextBox xomlView;

        public WFPadWorkflowDesignerControl()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnAutoSynch = new ToolStripButton();
            this.xomlView = new TextBox();
        }
        private void OnSelectionChanged(object sender, EventArgs e)
        {
        }
        void changeService_ComponentAdded(object sender, ComponentEventArgs e)
        {
        }
        void changeService_ComponentChanged(object sender, ComponentChangedEventArgs e)
        {
        }
        void changeService_ComponentRemoved(object sender, ComponentEventArgs e)
        {
        }
        void changeService_ComponentRename(object sender, ComponentRenameEventArgs e)
        { 
        }
        public string GetCurrentXoml()
        {
            return "";
        }

        new public object GetService(Type serviceType)
        {
            return (this.workflowView != null) ? ((IServiceProvider)this.workflowView).GetService(serviceType) : null;
        }

        public string XomlFile
        {
            get
            {
                return String.Empty;
            }
            set
            {
            }
        }

        // <snippet47>
        private ICollection LoadWorkflow(Type workflowType)
        {
            WorkflowLoader loader = new WorkflowLoader();
            loader.WorkflowType = workflowType;

            return LoadWorkflow(loader);
        }

        private ICollection LoadWorkflow(WorkflowLoader loader)
        {
            SuspendLayout();

            DesignSurface designSurface = new DesignSurface();
            designSurface.BeginLoad(loader);
            if (designSurface.LoadErrors.Count > 0)
                return designSurface.LoadErrors;

            // <snippet48>
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
                    this.splitContainer1.Panel1.Controls.Add(this.workflowView);
                    this.workflowView.Dock = DockStyle.Fill;
                    this.workflowView.TabIndex = 1;
                    this.workflowView.TabStop = true;
                    this.workflowView.HScrollBar.TabStop = false;
                    this.workflowView.VScrollBar.TabStop = false;
                    this.workflowView.ShadowDepth = 0;
                    this.workflowView.EnableFitToScreen = true;
                    this.workflowView.Focus();

                    ISelectionService selectionService = GetService(typeof(ISelectionService)) as ISelectionService;
                    IComponentChangeService changeService = GetService(typeof(IComponentChangeService)) as IComponentChangeService;

                    if (selectionService != null)
                    {
                        selectionService.SelectionChanged += new EventHandler(OnSelectionChanged);
                    }

                    if (changeService != null)
                    {
                        changeService.ComponentAdded += new ComponentEventHandler(changeService_ComponentAdded);
                        changeService.ComponentChanged += new ComponentChangedEventHandler(changeService_ComponentChanged);
                        changeService.ComponentRemoved += new ComponentEventHandler(changeService_ComponentRemoved);
                        changeService.ComponentRename += new ComponentRenameEventHandler(changeService_ComponentRename);
                    }
                }
            }
            // </snippet48>

            ResumeLayout(true);

            if (btnAutoSynch.Checked == true)
            {
                this.xomlView.Text = GetCurrentXoml();
            }

            return null;
        }
        // </snippet47>

        // <snippet49>
        private void UnloadWorkflow()
        {
            IDesignerHost designerHost = GetService(typeof(IDesignerHost)) as IDesignerHost;
            if (designerHost != null && designerHost.Container.Components.Count > 0)
                WorkflowLoader.DestroyObjectGraphFromDesignerHost(designerHost, designerHost.RootComponent as Activity);

            if (this.designSurface != null)
            {
                this.designSurface.Dispose();
                this.designSurface = null;
            }

            if (this.workflowView != null)
            {
                Controls.Remove(this.workflowView);
                this.workflowView.Dispose();
                this.workflowView = null;
            }
        }
        // </snippet49>

        // <snippet50>
        public void EnableFitToScreen()
        {
            IDesignerHost designerHost = GetService(typeof(IDesignerHost)) as IDesignerHost;
            WorkflowView workflowView =
                designerHost.RootComponent.Site.GetService(typeof(WorkflowView)) as WorkflowView;

            if (workflowView != null)
            {
                workflowView.EnableFitToScreen = true;
                workflowView.FitToScreenSize();
            }
        }
        // </snippet50>

        // <snippet51>
        public void FitToPage()
        {
            this.workflowView.FitToScreenSize();
            this.workflowView.Update();
        }
        // </snippet51>

        // <snippet52>
        public void ProcessZoom(int zoomFactor)
        {
            this.workflowView.Zoom = zoomFactor;
        }
        // </snippet52>

        // <snippet53>
        internal void SaveExistingWorkflow(string filePath)
        {
            if (this.designSurface != null && this.loader != null)
            {
                this.XomlFile = filePath;
                this.loader.Flush();
            }
        }
        // </snippet53>

        // <snippet54>
        public bool IsDesignerLocked
        {
            get
            {
                WorkflowDesignerLoader loader = GetService(typeof(WorkflowDesignerLoader)) as WorkflowDesignerLoader;
                if (loader != null && loader.InDebugMode)
                    return true;

                return false;
            }
        }
        // </snippet54>

        // <snippet55>
        public void AddCodeActivityToDesigner()
        {
            WorkflowDesignerLoader loader = GetService(typeof(WorkflowDesignerLoader)) as WorkflowDesignerLoader;
            if (loader == null)
                return;

            IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
            CompositeActivity rootActivity = designerHost.RootComponent as CompositeActivity;

            CodeActivity codeActivity = new CodeActivity();
            rootActivity.Activities.Add(codeActivity);
            loader.AddActivityToDesigner(codeActivity);
            return;
        }
        // </snippet55>

        // <snippet56>
        public void Print()
        {
            System.Drawing.Printing.PrintDocument doc = this.workflowView.PrintDocument;
            PrintDialog dlg = new PrintDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                doc.PrinterSettings = dlg.PrinterSettings;
                doc.Print();
            }
        }
        // </snippet56>

        // <snippet57>
        public void PrintPreview(bool enablePrintPreview)
        {
            this.workflowView.PrintPreviewMode = enablePrintPreview;
        }
        // </snippet57>

        // <snippet58>
        void workflowView_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = this.workflowView.CreateGraphics())
            {
                Bitmap draftImage = Resources.draft;
                draftImage.MakeTransparent(Color.Magenta);
                g.DrawImage(draftImage, this.workflowView.ViewPortRectangle);
            }

            base.OnPaint(e);
        }
        // </snippet58>

        // <snippet59>
        public void SaveViewState()
        {
            using (FileStream fs = new FileStream(@"viewstate.bin", FileMode.Create))
            {
                this.workflowView.SaveViewState(fs);
            }
        }
        // </snippet59>

        // <snippet60>
        public void LoadViewState()
        {
            using (FileStream fs = new FileStream(@"viewstate.bin", FileMode.Open))
            {
                this.workflowView.LoadViewState(fs);
            }
        }
        // </snippet60>

        // <snippet61>
        public void CopyWorkflowImage()
        {
            this.workflowView.SaveWorkflowImageToClipboard();
        }
        // </snippet61>

        // <snippet62>
        public void SaveWorkflowImage()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap Files|*.bmp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.workflowView.SaveWorkflowImage(saveFileDialog.FileName, ImageFormat.Bmp);
            }
        }
        // </snippet62>

        // <snippet63>
        public void SaveWorkflowImageUsingStream()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap Files|*.bmp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    this.workflowView.SaveWorkflowImage(fileStream, ImageFormat.Bmp);
                }
            }
        }
        // </snippet63>

        // <snippet64>
        public void FindSelection()
        {
            ISelectionService selectionService;
            selectionService = ((IServiceProvider)this.workflowView).GetService(typeof(ISelectionService))
                as ISelectionService;

            if (selectionService != null)
                this.workflowView.EnsureVisible(selectionService.PrimarySelection);
        }
        // </snippet64>

        // <snippet65>
        public void DisplayFullWorkflowView()
        {
            IDesignerHost designerHost = designSurface.GetService(typeof(IDesignerHost)) as IDesignerHost;
            if (designerHost != null && designerHost.RootComponent != null)
            {
                WorkflowView workflowView = designerHost.RootComponent.Site.GetService(typeof(WorkflowView)) as WorkflowView;
                if (workflowView != null)
                {
                    workflowView.Dock = DockStyle.Fill;
                    workflowView.TabIndex = 1;
                    workflowView.TabStop = true;
                    workflowView.HScrollBar.TabStop = false;
                    workflowView.VScrollBar.TabStop = false;
                    workflowView.Focus();
                    workflowView.FitToWorkflowSize();
                }
            }
        }
        // </snippet65>
    }

    private class CustomWorkflowViewMessageFilter : WorkflowDesignerMessageFilter
    {
        #region Members and Contructor/Destruction

        private bool mouseDown;
        private IServiceProvider _serviceProvider;
        private WorkflowView _workflowView;

        public CustomWorkflowViewMessageFilter(IServiceProvider provider, WorkflowView workflowView)
        {
            mouseDown = false;
            _serviceProvider = provider;
            _workflowView = workflowView;
        }
        #endregion

        #region MessageFilter Overridables

        int positionXOld;
        int positionYOld;

        protected override bool OnMouseDown(MouseEventArgs eventArgs)
        {
            // Save mouse position and allow other components to process 
            // this event by not returning true.
            mouseDown = true;
            this.positionXOld = eventArgs.X;
            this.positionYOld = eventArgs.Y;
            return false;
        }

        protected override bool OnMouseMove(MouseEventArgs eventArgs)
        {
            //Allow other components to process this event by not returning true.
            if (this.mouseDown)
            {
                _workflowView.ScrollPosition = new Point(_workflowView.ScrollPosition.X - (eventArgs.X - positionXOld), _workflowView.ScrollPosition.Y - (eventArgs.Y - positionYOld));
                positionXOld = eventArgs.X;
                positionYOld = eventArgs.Y;
            }
            return false;
        }

        protected override bool OnMouseUp(MouseEventArgs eventArgs)
        {
            //Allow other components to process this event by not returning true.
            mouseDown = false;
            return false;
        }

        protected override bool OnMouseDoubleClick(MouseEventArgs eventArgs)
        {
            mouseDown = false;
            return true;
        }

        protected override bool OnMouseEnter(MouseEventArgs eventArgs)
        {
            //Allow other components to process this event by not returning true.
            mouseDown = false;
            return false;
        }

        protected override bool OnMouseHover(MouseEventArgs eventArgs)
        {
            //Allow other components to process this event by not returning true.
            mouseDown = false;
            return false;
        }

        protected override bool OnMouseLeave()
        {
            //Allow other components to process this event by not returning true.
            mouseDown = false;
            return false;
        }

        // <snippet66>
        protected override bool OnMouseWheel(MouseEventArgs eventArgs)
        {
            if (eventArgs.Delta < 0)
            {
                this._workflowView.Zoom = this._workflowView.Zoom - 10;
            }
            else
            {
                this._workflowView.Zoom = this._workflowView.Zoom + 10;
            }
            mouseDown = false;
            return true;
        }
        // </snippet66>

        protected override bool OnMouseCaptureChanged()
        {
            //Allow other components to process this event by not returning true.
            mouseDown = false;
            return false;
        }

        protected override bool OnDragEnter(DragEventArgs eventArgs)
        {
            return false;
        }

        protected override bool OnDragOver(DragEventArgs eventArgs)
        {
            return false;
        }

        protected override bool OnDragLeave()
        {
            return false;
        }

        protected override bool OnDragDrop(DragEventArgs eventArgs)
        {
            return false;
        }

        protected override bool OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
        {
            return false;
        }

        protected override bool OnQueryContinueDrag(QueryContinueDragEventArgs qcdevent)
        {
            return false;
        }

        protected override bool OnKeyUp(KeyEventArgs eventArgs)
        {
            return true;
        }

        protected override bool OnShowContextMenu(Point menuPoint)
        {
            return true;
        }

        #endregion
    }
    // <snippet67>
    [ToolboxItem(typeof(CustomActivityToolboxItem))]
    [ActivityValidator(typeof(CustomActivityValidator))]
    public partial class CustomActivity : System.Workflow.ComponentModel.CompositeActivity
    // </snippet67>
    {
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            this.Name = "Activity1";
        }

        public CustomActivity()
        {
            InitializeComponent();
        }

        public static DependencyProperty MyPropertyProperty = System.Workflow.ComponentModel.DependencyProperty.Register("MyProperty", typeof(string), typeof(CustomActivity));

        [Description("This is the description which appears in the Property Browser")]
        [Category("This is the category which will be displayed in the Property Browser")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string MyProperty
        {
            get
            {
                return ((string)(base.GetValue(CustomActivity.MyPropertyProperty)));
            }
            set
            {
                base.SetValue(CustomActivity.MyPropertyProperty, value);
            }
        }
    }

    // <snippet68>
    internal sealed class CustomActivityValidator : ActivityValidator
    {
        // <snippet69>
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection validationErrors = base.Validate(manager, obj);

            CustomActivity ca = obj as CustomActivity;
            if (ca == null)
                throw new ArgumentException("Activity instance is null", typeof(CustomActivity).FullName);

            Activity parent = ca.Parent;
            while (parent != null)
            {
                if (parent is ListenActivity)
                {
                    validationErrors.Add(new ValidationError("Cannot add custom activity to ListenActivity", 1));
                    break;
                }
                parent = parent.Parent;
            }
            return validationErrors;
        }
        // </snippet69>
    }
    // </snippet68>

    // <snippet70>
    [Serializable]
    internal sealed class CustomActivityToolboxItem : ActivityToolboxItem
    {
        public CustomActivityToolboxItem(Type type)
            : base(type)
        {
        }

        private CustomActivityToolboxItem(SerializationInfo info, StreamingContext context)
        {
            Deserialize(info, context);
        }

        // <snippet71>
        protected override IComponent[] CreateComponentsCore(IDesignerHost designerHost)
        {
            CompositeActivity parallel = new ParallelActivity();
            parallel.Activities.Add(new CustomActivity());
            parallel.Activities.Add(new CustomActivity());

            return new IComponent[] { parallel };
        }
        // </snippet71>
    }
    // </snippet70>

    // <snippet72>
    [ActivityDesignerTheme(typeof(CustomCompositeActivityDesignerTheme))]
    public class CustomActivityDesigner : ActivityDesigner
    {
        public override bool CanBeParentedTo(CompositeActivityDesigner parentActivityDesigner)
        {
            if (parentActivityDesigner.GetType().ToString() == "System.Workflow.Activities.IfElseBranchDesigner")
                return false;

            return true;
        }

        // <snippet73>
        private ActivityDesignerVerbCollection verbs = null;

        protected override ActivityDesignerVerbCollection Verbs
        {
            get
            {
                if (this.verbs == null)
                    CreateActivityVerbs();

                return this.verbs;
            }
        }

        private void CreateActivityVerbs()
        {
            this.verbs = new ActivityDesignerVerbCollection();

            ActivityDesignerVerb addBranchVerb = new ActivityDesignerVerb(this,
                DesignerVerbGroup.View, "Add New Parallel Branch", new EventHandler(OnAddParallelBranch));
            this.verbs.Clear();

            this.verbs.Add(addBranchVerb);
        }

        protected void OnAddParallelBranch(object sender, EventArgs e)
        {
            // Code for adding a new branch to the parallel activity goes here
        }
        // </snippet73>

        // <snippet74>
        protected override Rectangle ImageRectangle
        {
            get
            {
                Rectangle bounds = this.Bounds;
                Size sz = new Size(24, 24);

                Rectangle imageRect = new Rectangle();
                imageRect.X = bounds.Left + ((bounds.Width - sz.Width) / 2);
                imageRect.Y = bounds.Top + 4;
                imageRect.Size = sz;

                return imageRect;
            }
        }
        // </snippet74>

        // <snippet75>
        protected override Rectangle TextRectangle
        {
            get
            {
                return new Rectangle(
                    this.Bounds.Left + 2,
                    this.ImageRectangle.Bottom,
                    this.Bounds.Width - 4,
                    this.Bounds.Height - this.ImageRectangle.Height - 1);
            }
        }
        // </snippet75>

        // <snippet76>
        protected override void Initialize(Activity activity)
        {
            base.Initialize(activity);
            Bitmap bmp = Resources.ToolboxImage;
            bmp.MakeTransparent();
            this.Image = bmp;
        }
        // </snippet76>

        // <snippet77>
        readonly static Size BaseSize = new Size(64, 64);
        protected override Size OnLayoutSize(ActivityDesignerLayoutEventArgs e)
        {
            return BaseSize;
        }
        // </snippet77>

        // <snippet78>
        private bool expanded = true;
        private bool useBasePaint = false;

        public bool UseBasePaint
        {
            get { return this.useBasePaint; }
            set { this.useBasePaint = value; }
        }

        public bool Expanded
        {
            get { return this.expanded; }
            set { this.expanded = value; }
        }

        protected override void OnPaint(ActivityDesignerPaintEventArgs e)
        {
            if (this.UseBasePaint == true)
            {
                base.OnPaint(e);
                return;
            }

            DrawCustomActivity(e);
        }

        private void DrawCustomActivity(ActivityDesignerPaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            CompositeDesignerTheme compositeDesignerTheme = (CompositeDesignerTheme)e.DesignerTheme;

            ActivityDesignerPaint.DrawRoundedRectangle(graphics, compositeDesignerTheme.BorderPen, this.Bounds, compositeDesignerTheme.BorderWidth);

            string text = this.Text;
            Rectangle textRectangle = this.TextRectangle;
            if (!String.IsNullOrEmpty(text) && !textRectangle.IsEmpty)
            {
                ActivityDesignerPaint.DrawText(graphics, compositeDesignerTheme.Font, text, textRectangle, StringAlignment.Center, e.AmbientTheme.TextQuality, compositeDesignerTheme.ForegroundBrush);
            }

            System.Drawing.Image image = this.Image;
            Rectangle imageRectangle = this.ImageRectangle;
            if (image != null && !imageRectangle.IsEmpty)
            {
                ActivityDesignerPaint.DrawImage(graphics, image, imageRectangle, DesignerContentAlignment.Fill);
            }

            ActivityDesignerPaint.DrawExpandButton(graphics,
                new Rectangle(this.Location.X, this.Location.Y, 10, 10),
                this.Expanded,
                compositeDesignerTheme);
        }
        // </snippet78>
    }
    // </snippet72>

    public class CustomCompositeActivityDesignerTheme : CompositeDesignerTheme
    {
        public CustomCompositeActivityDesignerTheme(WorkflowTheme theme)
            : base(theme)
        {
            this.BorderStyle = DashStyle.Solid;
            this.BorderColor = Color.FromArgb(0, 0, 0);
            this.BackColorStart = Color.FromArgb(37, 15, 242);
            this.BackColorEnd = Color.FromArgb(189, 184, 254);
            this.BackgroundStyle = LinearGradientMode.Vertical;
            this.ForeColor = Color.Black;
        }
    }

    // <snippet79>
    [ActivityDesignerTheme(typeof(CustomActivityDesignerTheme))]
    public class CustomActivityDesigner2 : ActivityDesigner
    // </snippet79>
    {
    }

    // <snippet80>
    public class CustomActivityDesignerTheme : ActivityDesignerTheme
    {
        public CustomActivityDesignerTheme(WorkflowTheme theme)
            : base(theme)
        {
            base.Initialize();
            this.BorderStyle = DashStyle.Solid;
            this.BorderColor = Color.FromArgb(0, 0, 0);
            this.BackColorStart = Color.FromArgb(37, 15, 242);
            this.BackColorEnd = Color.FromArgb(189, 184, 254);
            this.BackgroundStyle = LinearGradientMode.Vertical;
            this.ForeColor = Color.Black;
        }
    }
    // </snippet80>
    

    #region dependent classes
    public class ParallelIfActivity : CompositeActivity, IActivityEventListener<ActivityExecutionStatusChangedEventArgs>
    {
        void IActivityEventListener<ActivityExecutionStatusChangedEventArgs>.OnEvent(object sender, ActivityExecutionStatusChangedEventArgs e)
        {
        }
    }
    public class ParallelIfBranch : SequenceActivity
    {
    }
    public sealed class Workflow1 : SequentialWorkflowActivity
    {
    }
    public class PendingService : IPendingWork
    {
        #region IPendingWork Members

        void IPendingWork.Commit(System.Transactions.Transaction transaction, ICollection items)
        {
        }

        void IPendingWork.Complete(bool succeeded, ICollection items)
        {
        }

        bool IPendingWork.MustCommit(ICollection items)
        {
            return true;
        }

        #endregion
    }
    public class Toolbox : Panel, IToolboxService
    {
        private IServiceProvider provider;

        public Toolbox(IServiceProvider provider)
        {
            this.provider = provider;
        }
        public void AddCreator(ToolboxItemCreatorCallback creator, string format)
        {
        }
        public void AddCreator(ToolboxItemCreatorCallback creator, string format, IDesignerHost host)
        {
        }

        public void AddLinkedToolboxItem(ToolboxItem toolboxItem, IDesignerHost host)
        {
        }

        public void AddLinkedToolboxItem(ToolboxItem toolboxItem, string category, IDesignerHost host)
        {
        }

        public virtual void AddToolboxItem(ToolboxItem toolboxItem)
        {
        }

        public virtual void AddToolboxItem(ToolboxItem toolboxItem, IDesignerHost host)
        {
        }

        public virtual void AddToolboxItem(ToolboxItem toolboxItem, string category)
        {
        }

        public virtual void AddToolboxItem(ToolboxItem toolboxItem, string category, IDesignerHost host)
        {
        }
        public ToolboxItem DeserializeToolboxItem(object dataObject)
        {
            return DeserializeToolboxItem(dataObject, null);
        }
        public ToolboxItem DeserializeToolboxItem(object data, IDesignerHost host)
        {
            return new ToolboxItem();
        }
        public ToolboxItemCollection GetToolboxItems()
        {
            return new ToolboxItemCollection(new ToolboxItem[0]);
        }

        public ToolboxItemCollection GetToolboxItems(IDesignerHost host)
        {
            return new ToolboxItemCollection(new ToolboxItem[0]);
        }

        public ToolboxItemCollection GetToolboxItems(string category)
        {
            return new ToolboxItemCollection(new ToolboxItem[0]);
        }

        public ToolboxItemCollection GetToolboxItems(string category, IDesignerHost host)
        {
            return new ToolboxItemCollection(new ToolboxItem[0]);
        }

        public bool IsSupported(object data, IDesignerHost host)
        {
            return true;
        }
        public bool IsSupported(object serializedObject, ICollection filterAttributes)
        {
            return true;
        }

        public bool IsToolboxItem(object dataObject)
        {
            return IsToolboxItem(dataObject, null);
        }

        public bool IsToolboxItem(object data, IDesignerHost host)
        {
            return false;
        }
        public virtual ToolboxItem GetSelectedToolboxItem()
        {
            return null;
        }

        public virtual ToolboxItem GetSelectedToolboxItem(IDesignerHost host)
        {
            return GetSelectedToolboxItem();
        }
        public void RemoveCreator(string format)
        {
            RemoveCreator(format, null);
        }

        public void RemoveCreator(string format, IDesignerHost host)
        {
        }
        public virtual void RemoveToolboxItem(ToolboxItem toolComponentClass)
        {
        }

        public virtual void RemoveToolboxItem(ToolboxItem componentClass, string category)
        {
        }
        public void SelectedToolboxItemUsed()
        {
        }
        public object SerializeToolboxItem(ToolboxItem toolboxItem)
        {
            IComponent[] components = toolboxItem.CreateComponents();
            Activity[] activities = new Activity[components.Length];
            components.CopyTo(activities, 0);

            return CompositeActivityDesigner.SerializeActivitiesToDataObject(this.provider, activities);
        }
        public virtual bool SetCursor()
        {
            return false;
        }
        public virtual void SetSelectedToolboxItem(ToolboxItem selectedToolClass)
        {
        }
        public CategoryNameCollection CategoryNames
        {
            get
            {
                return null;
            }
        }
        public string SelectedCategory
        {
            get
            {
                return null;
            }
            set
            {
            }
        }
    }

    internal class EventBindingService : IEventBindingService
    {
        public EventBindingService()
        {
        }

        public string CreateUniqueMethodName(IComponent component, EventDescriptor e)
        {
            return e.DisplayName;
        }

        public ICollection GetCompatibleMethods(EventDescriptor e)
        {
            return new ArrayList();
        }

        public EventDescriptor GetEvent(PropertyDescriptor property)
        {
            return (property is EventPropertyDescriptor) ? ((EventPropertyDescriptor)property).EventDescriptor : null;
        }

        public PropertyDescriptorCollection GetEventProperties(EventDescriptorCollection events)
        {
            return new PropertyDescriptorCollection(new PropertyDescriptor[] { }, true);
        }

        public PropertyDescriptor GetEventProperty(EventDescriptor e)
        {
            return new EventPropertyDescriptor(e);
        }

        public bool ShowCode()
        {
            return false;
        }

        public bool ShowCode(int lineNumber)
        {
            return false;
        }

        public bool ShowCode(IComponent component, EventDescriptor e)
        {
            return false;
        }

        private class EventPropertyDescriptor : PropertyDescriptor
        {
            private EventDescriptor eventDescriptor;

            public EventDescriptor EventDescriptor
            {
                get
                {
                    return this.eventDescriptor;
                }
            }

            public EventPropertyDescriptor(EventDescriptor eventDescriptor)
                : base(eventDescriptor, null)
            {
                this.eventDescriptor = eventDescriptor;
            }

            public override Type ComponentType
            {
                get
                {
                    return this.eventDescriptor.ComponentType;
                }
            }
            public override Type PropertyType
            {
                get
                {
                    return this.eventDescriptor.EventType;
                }
            }

            public override bool IsReadOnly
            {
                get
                {
                    return true;
                }
            }

            public override bool CanResetValue(object component)
            {
                return false;
            }

            public override object GetValue(object component)
            {
                return null;
            }

            public override void ResetValue(object component)
            {
            }

            public override void SetValue(object component, object value)
            {
            }

            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }
        }
    }

    #endregion


}

