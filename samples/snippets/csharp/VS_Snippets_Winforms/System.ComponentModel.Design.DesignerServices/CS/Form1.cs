// <snippet1>
// <snippet2>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;
// </snippet2>

public class Form1 : Form
{
	private DemoControl demoControl1;

    private System.ComponentModel.IContainer components = null;

    public Form1()
    {
        InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
		this.demoControl1 = new DemoControl();
		this.SuspendLayout();
		// 
		// demoControl1
		// 
		this.demoControl1.AutoSize = true;
		this.demoControl1.BackColor = System.Drawing.Color.Chartreuse;
		this.demoControl1.Location = new System.Drawing.Point(0, 0);
		this.demoControl1.Name = "demoControl1";
		this.demoControl1.Size = new System.Drawing.Size(232, 14);
		this.demoControl1.TabIndex = 0;
		this.demoControl1.Text = "This text was set by CreateComponentsCore.";
		// 
		// Form1
		// 
		this.ClientSize = new System.Drawing.Size(492, 482);
		this.Controls.Add(this.demoControl1);
		this.Name = "Form1";
		this.Text = "r";
		this.ResumeLayout(false);
		this.PerformLayout();

	}

    #endregion

}

// <snippet20>
// This control is derived from UserControl, with only a little
// added logic for the Toolbox interaction.
//
// All of the custom designer code is implemented in the
// DemoControlDesigner class.

// <snippet21>
[DesignerAttribute(typeof(DemoControlDesigner))]
[ToolboxItem(typeof(DemoToolboxItem))]
public class DemoControl : Label
{
	// </snippet21>

    private System.ComponentModel.IContainer components = null;

    public DemoControl()
    {
        InitializeComponent();

        MessageBox.Show("DemoControl", "Constructor");
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        // 
        // DemoControl
        // 
        this.Name = "DemoControl";
    }

	// <snippet22>
	// Toolbox items must be serializable.
	[Serializable]
    [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.InheritanceDemand, Name="FullTrust")]
    [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.LinkDemand, Name="FullTrust")]
	class DemoToolboxItem : ToolboxItem
	{
		// The add components dialog in VS looks for a public
		// ctor that takes a type.
		public DemoToolboxItem(Type toolType)
			: base(toolType)
		{
		}

		// And you must provide this special constructor for serialization.
		// If you add additional data to MyToolboxItem that you
		// want to serialize, you may override Deserialize and
		// Serialize methods to add that data.  
		DemoToolboxItem(SerializationInfo info, StreamingContext context)
		{
			Deserialize(info, context);
		}

		// This implementation sets the new control's Text and 
		// AutoSize properties.
		protected override IComponent[] CreateComponentsCore(
			IDesignerHost host, 
			IDictionary defaultValues)
		{

			IComponent[] comps = base.CreateComponentsCore(host, defaultValues);

			// The returned IComponent array contains a single 
			// component, which is an instance of DemoControl.
			((DemoControl)comps[0]).Text = "This text was set by CreateComponentsCore.";
			((DemoControl)comps[0]).AutoSize = true;

			return comps;
		}
	}
	// </snippet22>
}
// </snippet20>

// This class demonstrates a designer that attaches to various 
// services and changes the properties exposed by the control
// being designed.
[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
public class DemoControlDesigner : ControlDesigner
{
    // This member backs the Locked property.
    private bool lockedValue = false;

    // This is the collection of DesignerActionLists that
    // defines the smart tags offered on the control. 
    private DesignerActionListCollection actionLists = null;

    // This Timer is created when you select the Create Timer
    // smart tag item.
    private Timer createdTimer = null;

    // <snippet3>
    // These are the services which DemoControlDesigner will use.
    private DesignerActionService actionService = null;
	private DesignerActionUIService actionUiService = null;
    private IComponentChangeService changeService = null;
    private IDesignerEventService eventService = null;
    private IDesignerHost host = null;
    private IDesignerOptionService optionService = null;
    private IEventBindingService eventBindingService = null;
    private IExtenderListService listService = null;
    private IReferenceService referenceService = null;
    private ISelectionService selectionService = null;
    private ITypeResolutionService typeResService = null;
    private IComponentDiscoveryService componentDiscoveryService = null;
    private IToolboxService toolboxService = null;
    private UndoEngine undoEng = null;
    // </snippet3>

    public DemoControlDesigner()
    {
        MessageBox.Show("DemoControlDesigner", "Constructor");
    }

    // <snippet4>
    // The Dispose method override is implemented so event handlers
    // can be removed. This prevents objects from lingering in 
    // memory beyond the desired lifespan.
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (this.changeService != null)
            {
                // Unhook event handlers.
                this.changeService.ComponentChanged -=
                    new ComponentChangedEventHandler(
                    ChangeService_ComponentChanged);

                this.changeService.ComponentAdded -=
                    new ComponentEventHandler(
                    ChangeService_ComponentAdded);

                this.changeService.ComponentRemoved -=
                    new ComponentEventHandler(
                    changeService_ComponentRemoved);
            }

            if (this.eventService != null)
            {
                this.eventService.ActiveDesignerChanged -=
                    new ActiveDesignerEventHandler(
                    eventService_ActiveDesignerChanged);
            }

            if (this.selectionService != null)
            {
                this.selectionService.SelectionChanged -=
                    new EventHandler(
                    selectionService_SelectionChanged);
            }

        }

        base.Dispose(disposing);
    }
    // </snippet4>

    // <snippet5>
    // This method initializes the designer.
    public override void Initialize(IComponent component)
    {
        base.Initialize(component);

        // Connect to various designer services.
        InitializeServices();

        // Set up the BackColor value that will be serialized.
        // This is the shadowed property on the designer.
        this.BackColor = Color.Chartreuse;

        // Set up the BackColor value that will be displayed.
        this.Control.BackColor = Color.AliceBlue;

    }
    // </snippet5>

    // <snippet6>
    // This method creates the DesignerActionList on demand, causing
    // smart tags to appear on the control being designed.
    public override DesignerActionListCollection ActionLists
    {
        get
        {
            if (null == actionLists)
            {
                actionLists = new DesignerActionListCollection();
                actionLists.Add(
                    new DemoActionList(this.Component));
            }

            return actionLists;
        }
    }
    // </snippet6>

    // <snippet7>
    // This utility method connects the designer to various
    // services it will use. 
    private void InitializeServices()
    {
        // Acquire a reference to DesignerActionService.
        this.actionService =
            GetService(typeof(DesignerActionService))
            as DesignerActionService;

		// Acquire a reference to DesignerActionUIService.
		this.actionUiService =
			GetService(typeof(DesignerActionUIService))
			as DesignerActionUIService;

        // Acquire a reference to IComponentChangeService.
        this.changeService =
            GetService(typeof(IComponentChangeService))
            as IComponentChangeService;

        // <snippet14>
        // Hook the IComponentChangeService events.
        if (this.changeService != null)
        {
            this.changeService.ComponentChanged +=
                new ComponentChangedEventHandler(
                ChangeService_ComponentChanged);

            this.changeService.ComponentAdded +=
                new ComponentEventHandler(
                ChangeService_ComponentAdded);

            this.changeService.ComponentRemoved +=
                new ComponentEventHandler(
                changeService_ComponentRemoved);
        }
        // </snippet14>

        // Acquire a reference to ISelectionService.
        this.selectionService =
            GetService(typeof(ISelectionService))
            as ISelectionService;

        // Hook the SelectionChanged event.
        if (this.selectionService != null)
        {
            this.selectionService.SelectionChanged +=
                new EventHandler(selectionService_SelectionChanged);
        }

        // Acquire a reference to IDesignerEventService.
        this.eventService =
            GetService(typeof(IDesignerEventService))
            as IDesignerEventService;

        if (this.eventService != null)
        {
            this.eventService.ActiveDesignerChanged +=
                new ActiveDesignerEventHandler(
                eventService_ActiveDesignerChanged);
        }

        // Acquire a reference to IDesignerHost.
        this.host =
            GetService(typeof(IDesignerHost))
            as IDesignerHost;

        // Acquire a reference to IDesignerOptionService.
        this.optionService =
            GetService(typeof(IDesignerOptionService))
            as IDesignerOptionService;

        // Acquire a reference to IEventBindingService.
        this.eventBindingService =
            GetService(typeof(IEventBindingService))
            as IEventBindingService;

        // Acquire a reference to IExtenderListService.
        this.listService =
            GetService(typeof(IExtenderListService))
            as IExtenderListService;

        // Acquire a reference to IReferenceService.
        this.referenceService =
            GetService(typeof(IReferenceService))
            as IReferenceService;

        // Acquire a reference to ITypeResolutionService.
        this.typeResService =
            GetService(typeof(ITypeResolutionService))
            as ITypeResolutionService;

        // Acquire a reference to IComponentDiscoveryService.
        this.componentDiscoveryService =
            GetService(typeof(IComponentDiscoveryService))
            as IComponentDiscoveryService;

        // Acquire a reference to IToolboxService.
        this.toolboxService =
            GetService(typeof(IToolboxService))
            as IToolboxService;

        // Acquire a reference to UndoEngine.
        this.undoEng =
            GetService(typeof(UndoEngine))
            as UndoEngine;

        if (this.undoEng != null)
        {
            MessageBox.Show("UndoEngine");
        }
    }
    // </snippet7>

    // <snippet8>
    // This is the shadowed property on the designer.
    // This value will be serialized instead of the 
    // value of the control's property.
    public Color BackColor
    {
        get
        {
            return (Color)ShadowProperties["BackColor"];
        }
        set
        {
            if (this.changeService != null)
            {
                PropertyDescriptor backColorDesc =
                    TypeDescriptor.GetProperties(this.Control)["BackColor"];

                this.changeService.OnComponentChanging(
                    this.Control,
                    backColorDesc);

                this.ShadowProperties["BackColor"] = value;

                this.changeService.OnComponentChanged(
                    this.Control,
                    backColorDesc,
                    null,
                    null);
            }
        }
    }
    // </snippet8>

    // <snippet9>
    // This is the property added by the designer in the
    // PreFilterProperties method.
    private bool Locked
    {
        get
        {
            return lockedValue;
        }
        set
        {
            lockedValue = value;
        }
    }
    // </snippet9>

    // <snippet10>
    // The PreFilterProperties method is where you can add or remove
    // properties from the component being designed. 
    //
    // In this implementation, the Visible property is removed,
    // the BackColor property is shadowed by the designer, and
    // the a new property, called Locked, is added.
    protected override void PreFilterProperties(IDictionary properties)
    {
        // Always call the base PreFilterProperties implementation 
        // before you modify the properties collection.
        base.PreFilterProperties(properties);

        // Remove the visible property.
        properties.Remove("Visible");

        // Shadow the BackColor property.
        PropertyDescriptor propertyDesc = TypeDescriptor.CreateProperty(
            typeof(DemoControlDesigner),
            (PropertyDescriptor)properties["BackColor"],
            new Attribute[0]);
        properties["BackColor"] = propertyDesc;

        // Create the Locked property.
        properties["Locked"] = TypeDescriptor.CreateProperty(
                 typeof(DemoControlDesigner),
                 "Locked",
                 typeof(bool),
                 CategoryAttribute.Design,
                 DesignOnlyAttribute.Yes);
    }
    // </snippet10>

    // <snippet11>
    // The PostFilterProperties method is where you modify existing
    // properties. You must only use this method to modify existing 
    // items. Do not add or remove items here. Also, be sure to 
    // call base.PostFilterProperties(properties) after your filtering
    // logic.
    //
    // In this implementation, the Enabled property is hidden from
    // any PropertyGrid or Properties window. This is done by 
    // creating a copy of the existing PropertyDescriptor and
    // attaching two new Attributes: Browsable and EditorBrowsable.

    protected override void PostFilterProperties(IDictionary properties)
    {
        PropertyDescriptor pd =
            properties["Enabled"] as PropertyDescriptor;

        pd = TypeDescriptor.CreateProperty(
            pd.ComponentType,
            pd,
            new Attribute[2] { 
                new BrowsableAttribute(false),
                new EditorBrowsableAttribute(EditorBrowsableState.Never)});

        properties[pd.Name] = pd;

        // Always call the base PostFilterProperties implementation 
        // after you modify the properties collection.
        base.PostFilterProperties(properties);
    }
    // </snippet11>

    #region Event Handlers

    // <snippet12>
    void eventService_ActiveDesignerChanged(
        object sender,
        ActiveDesignerEventArgs e)
    {
        if (e.NewDesigner != null)
        {
            MessageBox.Show(
                e.NewDesigner.ToString(),
                "ActiveDesignerChanged");
        }
    }


    // <snippet15>
    void ChangeService_ComponentChanged(
        object sender,
        ComponentChangedEventArgs e)
    {
        string msg = String.Format(
            "{0}, {1}", e.Component, e.Member);

        MessageBox.Show(msg, "ComponentChanged");
    }

    void ChangeService_ComponentAdded(
        object sender,
        ComponentEventArgs e)
    {
        MessageBox.Show(
            e.Component.ToString(),
            "ComponentAdded");
    }

    void changeService_ComponentRemoved(
        object sender,
        ComponentEventArgs e)
    {
        MessageBox.Show(
            e.Component.ToString(),
            "ComponentRemoved");
    }
    // </snippet15>

    void selectionService_SelectionChanged(
        object sender,
        EventArgs e)
    {
        if (this.selectionService != null)
        {
            if (this.selectionService.PrimarySelection == this.Control)
            {
                MessageBox.Show(
                    this.Control.ToString(),
                    "SelectionChanged");
            }
        }
    }
    // </snippet12>

    #endregion

    // <snippet13>
    // This class defines the smart tags that appear on the control
    // that is being designed.
    internal class DemoActionList :
          System.ComponentModel.Design.DesignerActionList
    {
        // Cache a reference to the designer host.
        private IDesignerHost host = null;

        // Cache a reference to the control.
        private DemoControl relatedControl = null;

        // Cache a reference to the designer.
        private DemoControlDesigner relatedDesigner = null;

        //The constructor associates the control 
        //with the smart tag list.
        public DemoActionList(IComponent component)
            : base(component)
        {
            this.relatedControl = component as DemoControl;

            this.host =
                this.Component.Site.GetService(typeof(IDesignerHost))
                as IDesignerHost;

            IDesigner dcd = host.GetDesigner(this.Component);
            this.relatedDesigner = dcd as DemoControlDesigner;
        }

        // This method creates and populates the 
        // DesignerActionItemCollection which is used to 
        // display smart tag items.
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items =
                new DesignerActionItemCollection();

            // If the Timer component has not been created, show the
            // "Create Timer" DesignerAction item.
            //
            // If the Timer component exists, show the timer-related
            // options.

            if (this.relatedDesigner.createdTimer == null)
            {
                items.Add(new DesignerActionMethodItem(
                    this,
                    "CreateTimer",
                    "Create Timer",
                    true));
            }
            else
            {   
                items.Add(new DesignerActionMethodItem(
                    this,
                    "ShowEventHandlerCode",
                    "Show Event Handler Code",
                    true));

                items.Add(new DesignerActionMethodItem(
                    this,
                    "RemoveTimer",
                    "Remove Timer",
                    true));
            }

            items.Add(new DesignerActionMethodItem(
               this,
               "GetExtenderProviders",
               "Get Extender Providers",
               true));

            items.Add(new DesignerActionMethodItem(
              this,
              "GetDemoControlReferences",
              "Get DemoControl References",
              true));

            items.Add(new DesignerActionMethodItem(
              this,
              "GetPathOfAssembly",
              "Get Path of Executing Assembly",
              true));

            items.Add(new DesignerActionMethodItem(
              this,
              "GetComponentTypes",
              "Get ScrollableControl Types",
              true));

            items.Add(new DesignerActionMethodItem(
                this,
                "GetToolboxCategories",
                "Get Toolbox Categories",
                true));

            items.Add(new DesignerActionMethodItem(
                this,
                "SetBackColor",
                "Set Back Color",
                true));

            return items;
        }

        // <snippet17>
        // This method creates a Timer component using the 
        // IDesignerHost.CreateComponent method. It also 
        // creates an event handler for the Timer component's
        // tick event.
        private void CreateTimer()
        {
            if (this.host != null)
            {
                if (this.relatedDesigner.createdTimer == null)
                {
                    // Create and configure the Timer object.
                    this.relatedDesigner.createdTimer =
                        this.host.CreateComponent(typeof(Timer)) as Timer;
                    Timer t = this.relatedDesigner.createdTimer;
                    t.Interval = 1000;
                    t.Enabled = true;

                    EventDescriptorCollection eventColl =
                        TypeDescriptor.GetEvents(t, new Attribute[0]);

                    if (eventColl != null)
                    {
                        EventDescriptor ed =
                            eventColl["Tick"] as EventDescriptor;
                        if (ed != null)
                        {
                            PropertyDescriptor epd =
                                this.relatedDesigner.eventBindingService.GetEventProperty(ed);

                            epd.SetValue(t, "timer_Tick");
                        }
                    }

					this.relatedDesigner.actionUiService.Refresh(this.relatedControl);
                }
            }
        }
        // </snippet17>

        // <snippet18>
        // This method uses the IEventBindingService.ShowCode
        // method to start the Code Editor. It places the caret
        // in the timer_tick method created by the CreateTimer method.
        private void ShowEventHandlerCode()
        {
            Timer t = this.relatedDesigner.createdTimer;

            if (t != null)
            {
                EventDescriptorCollection eventColl =
                    TypeDescriptor.GetEvents(t, new Attribute[0]);
                if (eventColl != null)
                {
                    EventDescriptor ed =
                        eventColl["Tick"] as EventDescriptor;
                    if (ed != null)
                    {
                        this.relatedDesigner.eventBindingService.ShowCode(t, ed);
                    }
                }
            }
        }
        // </snippet18>

        // <snippet19>
        // This method uses the IDesignerHost.DestroyComponent method
        // to remove the Timer component from the design environment.
        private void RemoveTimer()
        {
            if (this.host != null)
            {
                if (this.relatedDesigner.createdTimer != null)
                {
                    this.host.DestroyComponent(
                        this.relatedDesigner.createdTimer);

                    this.relatedDesigner.createdTimer = null;

					this.relatedDesigner.actionUiService.Refresh(
                        this.relatedControl);
                }
            }
        }
        // </snippet19>

        // <snippet16>
        // This method uses IExtenderListService.GetExtenderProviders
        // to enumerate all the extender providers and display them 
        // in a MessageBox.
        private void GetExtenderProviders()
        {
            if (this.relatedDesigner.listService != null)
            {
                StringBuilder sb = new StringBuilder();

                IExtenderProvider[] providers =
                    this.relatedDesigner.listService.GetExtenderProviders();

                for (int i = 0; i < providers.Length; i++)
                {
                    sb.Append(providers[i].ToString());
                    sb.Append("\r\n");
                }

                MessageBox.Show(
                    sb.ToString(), 
                    "Extender Providers");
            }
        }
        // </snippet16>

        // This method uses the IReferenceService.GetReferences method
        // to enumerate all the instances of DemoControl on the 
        // design surface.
        private void GetDemoControlReferences()
        {
            if (this.relatedDesigner.referenceService != null)
            {
                StringBuilder sb = new StringBuilder();

                object[] refs = this.relatedDesigner.referenceService.GetReferences(typeof(DemoControl));

                for (int i = 0; i < refs.Length; i++)
                {
                    sb.Append(refs[i].ToString());
                    sb.Append("\r\n");
                }

                MessageBox.Show(
                    sb.ToString(), 
                    "DemoControl References");
            }
        }


        // This method uses the ITypeResolutionService.GetPathOfAssembly
        // method to display the path of the executing assembly.
        private void GetPathOfAssembly()
        {
            if (this.relatedDesigner.typeResService != null)
            {
                System.Reflection.AssemblyName name =
                    System.Reflection.Assembly.GetExecutingAssembly().GetName();

                MessageBox.Show(
                    this.relatedDesigner.typeResService.GetPathOfAssembly(name),
                    "Path of executing assembly");
            }
        }

        // This method uses the IComponentDiscoveryService.GetComponentTypes 
        // method to find all the types that derive from 
        // ScrollableControl.
        private void GetComponentTypes()
        {
            if (this.relatedDesigner.componentDiscoveryService != null)
            {
                ICollection components = this.relatedDesigner.componentDiscoveryService.GetComponentTypes(host, typeof(ScrollableControl));

                if (components != null)
                {
                    if (components.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();

                        IEnumerator e = components.GetEnumerator();

                        while (e.MoveNext())
                        {
                            sb.Append(e.Current.ToString());
                            sb.Append("\r\n");

                        }

                        MessageBox.Show(
                            sb.ToString(), 
                            "Controls derived from ScrollableControl");
                    }
                }
            }
        }

        // This method uses the IToolboxService.CategoryNames
        // method to enumerate all the categories that appear
        // in the Toolbox.
        private void GetToolboxCategories()
        {
            if (this.relatedDesigner.toolboxService != null)
            {
                StringBuilder sb = new StringBuilder();

                CategoryNameCollection names = this.relatedDesigner.toolboxService.CategoryNames;

                foreach (string name in names)
                {
                    sb.Append(name.ToString());
                    sb.Append("\r\n");
                }

                MessageBox.Show(sb.ToString(), "Toolbox Categories");
            }
        }

        // This method sets the shadowed BackColor property on the 
        // designer. This is the value that is serialized by the 
        // design environment.
        private void SetBackColor()
        {
            ColorDialog d = new ColorDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                this.relatedDesigner.BackColor = d.Color;
            }
        }
    }
    // </snippet13>
}
// </snippet1>