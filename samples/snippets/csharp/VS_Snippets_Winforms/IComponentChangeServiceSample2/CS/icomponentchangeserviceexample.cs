//<Snippet1>
using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

/*  This sample illustrates how to use the IComponentChangeService interface 
    to handle component change events.  The ComponentClass control attaches 
    event handlers when it is sited in a document, and displays a message 
    when notification that a component has been added, removed, or changed
    is received from the IComponentChangeService.

    To run this sample, add the ComponentClass control to a Form and
    add, remove, or change components to see the behavior of the
    component change event handlers. */

namespace IComponentChangeServiceExample 
{
    public class ComponentClass : System.Windows.Forms.UserControl 
    {
        private System.ComponentModel.Container components = null;
	private System.Windows.Forms.ListBox listBox1;
	private IComponentChangeService m_changeService;
 
	public ComponentClass() 
	{
	    InitializeComponent();
	}

	private void InitializeComponent() 
	{
  	    this.listBox1 = new System.Windows.Forms.ListBox();
	    this.SuspendLayout();

 	    // listBox1.
	    this.listBox1.Location = new System.Drawing.Point(24, 16);
	    this.listBox1.Name = "listBox1";
	    this.listBox1.Size = new System.Drawing.Size(576, 277);
	    this.listBox1.TabIndex = 0;
		   
	    // ComponentClass.
	    this.Controls.AddRange(new System.Windows.Forms.Control[] {this.listBox1});
	    this.Name = "ComponentClass";
	    this.Size = new System.Drawing.Size(624, 320);

            this.ResumeLayout(false);
	}

	// This override allows the control to register event handlers for IComponentChangeService events
	// at the time the control is sited, which happens only in design mode.
	public override ISite Site 
	{
	    get 
	    {
		return base.Site;
	    }
	    set 
	    {		
		// Clear any component change event handlers.
		ClearChangeNotifications();		
				
		// Set the new Site value.
		base.Site = value;

		m_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));

		// Register event handlers for component change events.
		RegisterChangeNotifications();			
	    }
	}

	private void ClearChangeNotifications()
	{
	    // The m_changeService value is null when not in design mode, 
	    // as the IComponentChangeService is only available at design time.	
	    m_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));

 	    // Clear our the component change events to prepare for re-siting.				
	    if (m_changeService != null) 
	    {
	 	m_changeService.ComponentChanged -= new ComponentChangedEventHandler(OnComponentChanged);
		m_changeService.ComponentChanging -= new ComponentChangingEventHandler(OnComponentChanging);
		m_changeService.ComponentAdded -= new ComponentEventHandler(OnComponentAdded);
		m_changeService.ComponentAdding -= new ComponentEventHandler(OnComponentAdding);
		m_changeService.ComponentRemoved -= new ComponentEventHandler(OnComponentRemoved);
		m_changeService.ComponentRemoving -= new ComponentEventHandler(OnComponentRemoving);
		m_changeService.ComponentRename -= new ComponentRenameEventHandler(OnComponentRename);
	    }
	}

	private void RegisterChangeNotifications()
	{
	    // Register the event handlers for the IComponentChangeService events
	    if (m_changeService != null) 
	    {
		m_changeService.ComponentChanged += new ComponentChangedEventHandler(OnComponentChanged);
		m_changeService.ComponentChanging += new ComponentChangingEventHandler(OnComponentChanging);
		m_changeService.ComponentAdded += new ComponentEventHandler(OnComponentAdded);
		m_changeService.ComponentAdding += new ComponentEventHandler(OnComponentAdding);
		m_changeService.ComponentRemoved += new ComponentEventHandler(OnComponentRemoved);
		m_changeService.ComponentRemoving += new ComponentEventHandler(OnComponentRemoving);
		m_changeService.ComponentRename += new ComponentRenameEventHandler(OnComponentRename);
	    }
	}

	/* This method handles the OnComponentChanged event to display a notification. */
	private void OnComponentChanged(object sender, ComponentChangedEventArgs ce) 
	{
 	    if( ce.Component != null && ((IComponent)ce.Component).Site != null && ce.Member != null ) 
	    OnUserChange("The " + ce.Member.Name + " member of the " + ((IComponent)ce.Component).Site.Name + " component has been changed.");
	}

	/* This method handles the OnComponentChanging event to display a notification. */
	private void OnComponentChanging(object sender, ComponentChangingEventArgs ce) 
	{
	    if( ce.Component != null && ((IComponent)ce.Component).Site != null && ce.Member != null ) 
	    OnUserChange("The " + ce.Member.Name + " member of the " + ((IComponent)ce.Component).Site.Name + " component is being changed.");
	}

	/* This method handles the OnComponentAdded event to display a notification. */
	private void OnComponentAdded(object sender, ComponentEventArgs ce) 
	{			
	    OnUserChange("A component, " + ce.Component.Site.Name + ", has been added.");
	}

	/* This method handles the OnComponentAdding event to display a notification. */		
	private void OnComponentAdding(object sender, ComponentEventArgs ce) 
	{			
	    OnUserChange("A component of type " + ce.Component.GetType().FullName + " is being added.");
	}

	/* This method handles the OnComponentRemoved event to display a notification. */
	private void OnComponentRemoved(object sender, ComponentEventArgs ce) 
	{
	    OnUserChange("A component, " + ce.Component.Site.Name + ", has been removed.");
	}

	/* This method handles the OnComponentRemoving event to display a notification. */
	private void OnComponentRemoving(object sender, ComponentEventArgs ce) 
	{
	    OnUserChange("A component, " + ce.Component.Site.Name + ", is being removed.");
	}

	/* This method handles the OnComponentRename event to display a notification. */
	private void OnComponentRename(object sender, ComponentRenameEventArgs ce) 
	{
	    OnUserChange("A component, " + ce.OldName + ", was renamed to " + ce.NewName +".");
	}

	// This method adds a specified notification message to the control's listbox.
	private void OnUserChange(string text) 
	{
	    listBox1.Items.Add(text);
	}

	// Clean up any resources being used.
	protected override void Dispose( bool disposing ) 
	{
	    if( disposing ) 
	    {
		ClearChangeNotifications();
	        
		if(components != null) 
		{
		    components.Dispose();
		}
	    }
	    base.Dispose( disposing );
	}
    }
}
//</Snippet1>

