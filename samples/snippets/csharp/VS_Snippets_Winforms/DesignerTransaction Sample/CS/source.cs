//<Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

/*
    This sample demonstrates how to perform a series of actions in a designer 
    transaction, how to change values of properties of a component from a 
    designer, and how to complete transactions without being interrupted 
    by other activities.

    To run this sample, add this code to a class library project and compile. 
    Create a new Windows Forms project or load a form in the designer. Add a 
    reference to the class library that was compiled in the first step.
    Right-click the Toolbox in design mode and click Customize Toolbox.  
    Browse to the class library that was compiled in the first step and 
    select OK until the DTComponent item appears in the Toolbox.  Add an 
    instance of this component to the form.  
	
    When the component is created and added to the component tray for your
    design project, the Initialize method of the designer is called. 
    This method displays a message box informing you that designer transaction
    event handlers will be registered unless you click Cancel. When you set 
    properties in the properties window, each change will be encapsulated in 
    a designer transaction, allowing the change to be undone later.  
	
    When you right-click the component,	the shortcut menu for the component 
    is displayed. The designer constructs this menu according to whether 
    designer transaction notifications are enabled, and offers the option
    of enabling or disabling the notifications, depending on the current 
    mode. The shortcut menu also presents a Perform Example Transaction 
    item, which will set the values of the component's StringProperty and 
    CountProperty properties. You can undo the last designer transaction using 
    the Undo command provided by the Visual Studio development environment.
*/

namespace DesignerTransactionSample
{
    // Associate the DTDesigner with this component
    [DesignerAttribute(typeof(DTDesigner))]
    public class DTComponent : System.ComponentModel.Component
    {
    	private string m_String;
	private int m_Count;
			
	public string StringProperty
	{
	    get
            { return m_String; }
	    set
	    { m_String = value; }
	}
			
	public int CountProperty
	{
	    get
	    { return m_Count; }
	    set
	    { m_Count = value; }
	}

	private void InitializeComponent()
	{
	    m_String = "Initial Value";
	    m_Count = 0;
	}
    }
	
    internal class DTDesigner : ComponentDesigner
    {
	private bool notification_mode = false;
	private int count = 10;
		
	// The Verbs property is overridden from ComponentDesigner
	public override DesignerVerbCollection Verbs
	{
	    get
	    {				
	        DesignerVerbCollection dvc = new DesignerVerbCollection();				
		dvc.Add( new DesignerVerb("Perform Example Transaction", new EventHandler(this.DoTransaction)) );
		if(notification_mode)
		    dvc.Add(new DesignerVerb("End Designer Transaction Notifications", new EventHandler(this.UnlinkDTNotifications)));
		else
		    dvc.Add(new DesignerVerb("Show Designer Transaction Notifications", new EventHandler(this.LinkDTNotifications)));				return dvc;
	    }
	}
		
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);

            IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));			
            if(host == null)
            {
                MessageBox.Show("The IDesignerHost service interface could not be obtained.");
                return;
            }

            if( MessageBox.Show("Press the Yes button to display notification message boxes for the designer transaction opened and closed notifications.","Link DesignerTransaction Notifications?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.Yes )
            {							
	        host.TransactionOpened += new EventHandler(OnDesignerTransactionOpened);
    	        host.TransactionClosed += new DesignerTransactionCloseEventHandler(OnDesignerTransactionClosed);
                notification_mode = true;
            }
        }
		
        private void LinkDTNotifications(object sender, EventArgs e)
        {
            if(notification_mode == false)
            {
	        IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));							
                if(host != null)
	        {
		    notification_mode = true;
                   host.TransactionOpened += new EventHandler(OnDesignerTransactionOpened);
                   host.TransactionClosed += new DesignerTransactionCloseEventHandler(OnDesignerTransactionClosed);
	        }
	    }
        }

        private void UnlinkDTNotifications(object sender, EventArgs e)
        {
	    if(notification_mode)
    	    {
    	        IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));							
	        if(host != null)
                {				
		    notification_mode = false;
                    host.TransactionOpened -= new EventHandler(OnDesignerTransactionOpened);
                    host.TransactionClosed -= new DesignerTransactionCloseEventHandler(OnDesignerTransactionClosed);
                }
            }
        }

        private void OnDesignerTransactionOpened(object sender, EventArgs e)
        {			
	    System.Windows.Forms.MessageBox.Show("A Designer Transaction was started. (TransactionOpened)");
        }

        private void OnDesignerTransactionClosed(object sender, DesignerTransactionCloseEventArgs e)
        {			
	    System.Windows.Forms.MessageBox.Show("A Designer Transaction was completed. (TransactionClosed)");
        }   

        private void DoTransaction(object sender, EventArgs e) 
        {			
    	    IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));			
            DesignerTransaction t = host.CreateTransaction("Change Text and Size");

            /* The code within the using statement is considered to be a single transaction.
	       When the user selects Undo, the system will undo everything executed in this code block. */
            using (t)
            {
	        if(notification_mode)
	            System.Windows.Forms.MessageBox.Show("Entering a Designer-Initiated Designer Transaction");
				
                // The .NET Framework automatically associates the TypeDescriptor with the correct component
	        PropertyDescriptor someText = TypeDescriptor.GetProperties(Component)["StringProperty"];
                someText.SetValue(Component, "This text was set by the designer for this component.");

                PropertyDescriptor anInteger = TypeDescriptor.GetProperties(Component)["CountProperty"];
	        anInteger.SetValue(Component, count);
	        count++;

                // Complete the designer transaction.
	        t.Commit();
				
	        if(notification_mode)
	            System.Windows.Forms.MessageBox.Show("Designer-Initiated Designer Transaction Completed");
            }
        }
		
	protected override void Dispose(bool disposing)
	{
	    UnlinkDTNotifications(this, new EventArgs());
	    base.Dispose(disposing);
	}
    }
}
//</Snippet1>