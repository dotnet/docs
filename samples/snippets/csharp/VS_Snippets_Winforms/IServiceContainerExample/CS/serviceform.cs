//<Snippet1>
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ServiceArchitectureExample
{
    // This sample contains a Form class that is configured to demonstrate 
    // the behavior of a network of linked service containers.   
    
    // Notes regarding this IServiceContainer and IServiceProvider 
    // implementation:
    //
    // When implementing the IServiceContainer interface, you may want to 
    // implement support for a linked service container system
    // which enables access to and sharing of services throughout a 
    // container tree or network.
    //
    // To effectively share a service, a GetService, AddService or 
    // RemoveService method must be able to locate a service 
    // that has been added to a shared service container tree or network.
    //        
    // One simple approach to sharing services, suitable for container networks 
    // where each container has one parent and the tree has
    // one parentless container, is to store services only at the top node 
    // (the root or grandparent) of a tree.
    //
    // To store services in the root node of a tree, two types of 
    // consistencies must be maintained in the implementation:        
    //
    //   >   The GetService, AddService and RemoveService implementations 
    //       must access the root through some mechanism.
    //         The ServiceContainerControl's implementations of these 
    //         standard IServiceContainer methods call 
    //         the same method of a parent container, if the container 
    //         has been parented, to route methods to the root.  
    //
    //   >   The services must be maintained at the root of the tree; 
    //       therefore, any new child's services should be copied to the root.                


    // ServiceContainerControl provides an example user control implmentation 
    // of the IServiceContainer interface. This implementation of 
    // IServiceContainer supports a root-node linked service distribution, 
    // access. and removal architecture.
    public class ServiceContainerControl : System.Windows.Forms.UserControl, IServiceContainer
    {                        
        // List of service instances sorted by key of service type's full name.
        private SortedList localServices;               
        // List that contains the Type for each service sorted by each 
        // service type's full name.
        private SortedList localServiceTypes;           

        // The parent IServiceContainer, or null.
        private IServiceContainer parentServiceContainer;   
        public IServiceContainer serviceParent              
        {
            get
            {
                return parentServiceContainer;
            }
            set
            {
                parentServiceContainer = value;
                // Move any services to parent.
                for( int i=0; i<localServices.Count; i++ )
                    parentServiceContainer.AddService(
                        (Type)localServiceTypes.GetByIndex(i), 
                        localServices.GetByIndex(i));
                localServices.Clear();
                localServiceTypes.Clear();
            }
        }
        
        // The current state of the control reflecting whether it has 
        // obtained or provided a text service.
        private TextServiceState state_;
        public TextServiceState state              
        {                                          
            get
            {
                return state_;
            }
            set
            {
                if( (TextServiceState)value == 
                        TextServiceState.ServiceProvided )
                    this.BackColor = Color.LightGreen;
                else if( (TextServiceState)value == 
                        TextServiceState.ServiceNotObtained )                
                    this.BackColor = Color.White;                                   
                else if( (TextServiceState)value == 
                        TextServiceState.ServiceObtained )
                    this.BackColor = Color.LightBlue;
                else if( (TextServiceState)value == 
                        TextServiceState.ServiceNotFound )                                    
                    this.BackColor = Color.SeaShell;                
                state_ = value;
            }
        }
        
        // Parent form reference for main program function access.
        private ServiceForm parent;                 
        // String for label displayed on the control to indicate 
        // the control's current service-related configuration state.
        public string label;  
        
        public ServiceContainerControl(Size size, Point location, 
            ServiceForm parent) : this(null, size, location, parent){}      
        public ServiceContainerControl(IServiceContainer ParentServiceContainer, 
            Size size, Point location, ServiceForm parent)
        {
            this.state_ = TextServiceState.ServiceNotObtained;
            localServices = new SortedList();
            localServiceTypes = new SortedList();

            this.BackColor = Color.Beige;            
            this.label = string.Empty;            
            this.Size = size;
            this.Location = location;
            this.parent = parent;
            this.serviceParent = ParentServiceContainer;
            
            // If a parent is specified, set the parent property of this 
            // linkable IServiceContainer implementation.
            if( ParentServiceContainer != null )
                serviceParent = ParentServiceContainer;
        }

        // IServiceProvider.GetService implementation for a linked 
        // service container architecture.
        public new object GetService(System.Type serviceType)
        {
            if( parentServiceContainer != null )
                return parentServiceContainer.GetService(serviceType);            

            object serviceInstance = localServices[serviceType.FullName];
            if( serviceInstance == null )
                return null;
            else if( serviceInstance.GetType() == typeof(ServiceCreatorCallback) )
            {
                // If service instance is a ServiceCreatorCallback, invoke 
                // it to create the service.
                return ((ServiceCreatorCallback)serviceInstance)(this, serviceType);                                
            }
            return serviceInstance;
        }
        
        // IServiceContainer.AddService implementation for a linked 
        // service container architecture.
        public void AddService(System.Type serviceType, 
            System.ComponentModel.Design.ServiceCreatorCallback callback, bool promote)
        {
            if( promote && parentServiceContainer != null )            
                parentServiceContainer.AddService(serviceType, callback, true);            
            else
            {
                localServiceTypes[serviceType.FullName] = serviceType;
                localServices[serviceType.FullName] = callback;
            }
        }
        
        // IServiceContainer.AddService implementation for a linked 
        // service container architecture.
        public void AddService(System.Type serviceType, 
            System.ComponentModel.Design.ServiceCreatorCallback callback)
        {
            AddService(serviceType, callback, true);
        }

        // IServiceContainer.AddService implementation for a linked 
        // service container architecture.
        public void AddService(System.Type serviceType, 
            object serviceInstance, bool promote)
        {
            if( promote && parentServiceContainer != null )            
                parentServiceContainer.AddService(serviceType, serviceInstance, true);            
            else
            {
                localServiceTypes[serviceType.FullName] = serviceType;
                localServices[serviceType.FullName] = serviceInstance;
            }
        }

        // IServiceContainer.AddService (defaults to promote service addition).
        public void AddService(System.Type serviceType, object serviceInstance)
        {
            AddService(serviceType, serviceInstance, true);
        }

        // IServiceContainer.RemoveService implementation for a linked 
        // service container architecture.
        public void RemoveService(System.Type serviceType, bool promote)
        {
            if( localServices[serviceType.FullName] != null )
            {
                localServices.Remove(serviceType.FullName);
                localServiceTypes.Remove(serviceType.FullName);
            }
            if( promote )
            {
                if( parentServiceContainer != null )
                    parentServiceContainer.RemoveService(serviceType);
            }
        }

        // IServiceContainer.RemoveService (defaults to promote 
        // service removal)
        public void RemoveService(System.Type serviceType)
        {
            RemoveService(serviceType, true);
        }

        // Paint method override draws the label string on the control.
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawString(label, new Font("Arial", 8), 
                new SolidBrush(Color.Black), 5, 5);            
        }

        // Process mouse-down behavior for click.
        protected override void OnMouseDown(
            System.Windows.Forms.MouseEventArgs e)
        {
            //  This example control responds to mouse clicks as follows:
            //
            //      Left click - control attempts to obtain a text service 
            //      and sets its label text to the text provided by the service
            //      Right click - if the control has already provided a text 
            //      service, this control does nothing. Otherwise, the control 
            //      shows a dialog box to specify text to provide as a new text 
            //      service, after clearing the tree's services.

            if( e.Button == MouseButtons.Left )
            {
                if( state_ != TextServiceState.ServiceProvided )
                {
                    // Attempt to update text from service, and set 
                    // color state accordingly.
                    TextService ts = 
                        (TextService)GetService(typeof(TextService));
                    if( ts != null )
                    {
                        this.label = ts.text;
                        state = TextServiceState.ServiceObtained;
                    }
                    else
                    {                    
                        this.label = "Service Not Found";                        
                        state = TextServiceState.ServiceNotFound;
                    }
                }
            }
            if( e.Button == MouseButtons.Right )
            {
                if( state_ == TextServiceState.ServiceProvided )
                {
                    // Remove the service if the container provided it.
                    if( GetService(typeof(TextService)) != null )
                    {
                        RemoveService(typeof(TextService), true);
                        state = TextServiceState.ServiceNotObtained; 
                        this.label = "Service Removed";                                                                   
                    }                    
                }
                else
                {
                    // Obtain string and provide text service.
                    using (StringInputDialog form =
                        new StringInputDialog("Test String"))
                    {
                        form.StartPosition = FormStartPosition.CenterParent;
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            if (GetService(typeof(TextService)) != null)
                                RemoveService(typeof(TextService), true);
                            parent.ResetServiceTree(this, new EventArgs());

                            AddService(typeof(TextService),
                                new TextService(form.inputTextBox.Text), true);

                            // The following commented method uses a service creator callback.
                            // AddService(typeof(TextService), 
                            //  new ServiceCreatorCallback(this.CreateTextService));                                                

                            state = TextServiceState.ServiceProvided;
                            this.label = "Provided Text: " + form.inputTextBox.Text;
                        }
                    }
                }
            }
            parent.UpdateServiceCoverage();
        }

        // Method accesses the TextService to test the visibility of the 
        // service from the control, and sets the UI state accordingly.
        public void ReflectServiceVisibility()
        {
            if( state_ == TextServiceState.ServiceObtained )
            {
                if( GetService(typeof(TextService)) == null )  
                    this.BackColor = Color.CadetBlue;
            }
            else if( state_ != TextServiceState.ServiceProvided )
            {
                if( GetService(typeof(TextService)) == null )
                {
                    this.BackColor = Color.White;
                    return;
                }

                // Service available.        
                if( state_ == TextServiceState.ServiceNotFound )                
                    this.BackColor = Color.Khaki;                
                else if( state_ == TextServiceState.ServiceNotObtained 
                         && label != "Service Removed" )
                    this.BackColor = Color.Khaki;       
            }
        }
        
        // ServiceCreatorCallback method creates a text service.
        private object CreateTextService(IServiceContainer container, 
            System.Type serviceType)
        {
            return new TextService("Test Callback");
        }
    }

    // Example form provides UI for demonstrating service sharing behavior 
    // of a network of IServiceContainer/IServiceProvider controls.
    public class ServiceForm : System.Windows.Forms.Form
    {
        // Root service container control for tree.
        private ServiceContainerControl root;                
        // Button for clearing any provided services and resetting tree states.
        private System.Windows.Forms.Button reset_button;   
        // Color list used to color code controls.
        private Color[] colorkeys;                       
        // Strings used to reflect text service.
        private string[] keystrings;                         

        public ServiceForm()
        {
        InitializeComponent();        
            colorkeys = new Color[] { Color.Beige, Color.SeaShell, Color.LightGreen, Color.LightBlue, Color.Khaki, Color.CadetBlue };
            keystrings = new string[] { "No service use", "Service not accessible", "Service provided", "Service obtained", "Service accessible", "No further access" };
            CreateServiceControlTree();                        
		}

        private void CreateServiceControlTree()
        {
            // Create root service control
            ServiceContainerControl control1 = new ServiceContainerControl(
                null, new Size(300, 40), new Point(10, 80), this);
            root = control1;
            // Create first tier - pass parent with service object control 1.
            ServiceContainerControl control2 = new ServiceContainerControl(
                control1, new Size(200, 30), new Point(50, 160), this);
            ServiceContainerControl control3 = new ServiceContainerControl(
                control1, new Size(200, 30), new Point(50, 240), this);
            // Create second tier A - pass parent with service object control 2.
            ServiceContainerControl control4 = new ServiceContainerControl(
                control2, new Size(180, 20), new Point(300, 145), this);
            ServiceContainerControl control5 = new ServiceContainerControl(
                control2, new Size(180, 20), new Point(300, 185), this);
            // Create second tier B - pass parent with service object control 3.
            ServiceContainerControl control6 = new ServiceContainerControl(
                control3, new Size(180, 20), new Point(300, 225), this);
            ServiceContainerControl control7 = new ServiceContainerControl(
                control3, new Size(180, 20), new Point(300, 265), this);
            // Add controls
            this.Controls.AddRange( new Control[] { control1, control2, 
                control3, control4, control5, control6, control7 } );
        }

        internal void ResetServiceTree(object sender, EventArgs e)
        {
            // Remove the service from the service tree.
            if( root.GetService(typeof(TextService)) != null )            
                root.RemoveService(typeof(TextService), true);

            // Set all controls to "not obtained" and clear their labels.
            for( int i=0; i<Controls.Count; i++ )
                if( !Controls[i].Equals(reset_button) ) 
                {
                    ((ServiceContainerControl)Controls[i]).state = 
                        TextServiceState.ServiceNotObtained;
                    ((ServiceContainerControl)Controls[i]).label = string.Empty;
                    ((ServiceContainerControl)Controls[i]).BackColor = 
                        Color.Beige;
                }
        }

        public void UpdateServiceCoverage()
        {
            // Have each control set state to reflect service availability.
            for( int i=0; i<Controls.Count; i++ )
                if( !Controls[i].Equals(reset_button) )                 
                    ((ServiceContainerControl)Controls[i]).ReflectServiceVisibility();                                 
        }

            #region Windows Form Designer generated code
            private void InitializeComponent()
            {
            this.reset_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reset_button
            // 
            this.reset_button.Location = new System.Drawing.Point(392, 88);
            this.reset_button.Name = "reset_button";
            this.reset_button.TabIndex = 0;
            this.reset_button.TabStop = false;
            this.reset_button.Text = "Reset";
            this.reset_button.Click += new System.EventHandler(this.ResetServiceTree);
            // 
            // ServiceForm
            // 
            this.ClientSize = new System.Drawing.Size(512, 373);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.reset_button});
            this.MinimumSize = new System.Drawing.Size(520, 400);
            this.Name = "ServiceForm";
            this.Text = "Service Container Architecture Example";
            this.ResumeLayout(false);

            }
            #endregion

            [STAThread]
            static void Main() 
            {
                Application.Run(new ServiceForm());
            }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {            
            e.Graphics.DrawString("The following tree diagram represents a "+
                "hierarchy of linked service containers in controls.", 
                new Font("Arial", 9), new SolidBrush(Color.Black), 4, 4);
            e.Graphics.DrawString("This example demonstrates the propagation "+
                "behavior of services through a linked service object tree.", 
                new Font("Arial", 8), new SolidBrush(Color.Black), 4, 26);            
            e.Graphics.DrawString("Right-click a component to add or replace a "+
                "text service, or to remove it if the component provided it.", 
                new Font("Arial", 8), new SolidBrush(Color.Black), 4, 38);
            e.Graphics.DrawString("Left-click a component to update text from "+
                "the text service if available.", new Font("Arial", 8), 
                new SolidBrush(Color.Black), 4, 50);

            // Draw lines to represent tree branches.
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 
                20, 125, 20, 258);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 
                21, 175, 45, 175);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 
                21, 258, 45, 258);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 
                255, 175, 285, 175);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 
                255, 258, 285, 258);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 
                285, 155, 285, 195);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 
                285, 238, 285, 278);            
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 
                285, 155, 290, 155);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 
                285, 195, 290, 195);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 
                285, 238, 290, 238);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 
                285, 278, 290, 278);

            // Draw color key.
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1), 20, 305, 410, 60);
            int y=0;
            for( int i=0; i<3; i++ )
            {
                e.Graphics.FillRectangle(new SolidBrush(colorkeys[y]), 
                    25+(i*140), 310, 20, 20);           
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1), 
                    25+(i*140), 310, 20, 20);     
                e.Graphics.DrawString(keystrings[y], new Font("Arial", 8), 
                    new SolidBrush(Color.Black), 50+(i*140), 315);
                y++;
                e.Graphics.FillRectangle(new SolidBrush(colorkeys[y]), 
                    25+(i*140), 340, 20, 20);           
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1), 
                    25+(i*140), 340, 20, 20);              
                e.Graphics.DrawString(keystrings[y], new Font("Arial", 8), 
                    new SolidBrush(Color.Black), 50+(i*140), 345);
                y++;
            }
        }
	}   
   
    // Example service type contains a text string, sufficient to 
    // demonstrate service sharing.
    public class TextService
    {
        public string text;

        public TextService() : this(string.Empty)
        {
        }

        public TextService(string text)
        {
            this.text = text;
        }
    }

    public enum TextServiceState
    {
        ServiceNotObtained,
        ServiceObtained,
        ServiceProvided,
        ServiceNotFound
    }

    // Example Form for entering a string.
    internal class StringInputDialog : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Button cancel_button;
        public System.Windows.Forms.TextBox inputTextBox;

        public StringInputDialog(string text)
        {
            InitializeComponent();
            inputTextBox.Text = text;
        }

        private void InitializeComponent()
        {
            this.ok_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            this.ok_button.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | 
                System.Windows.Forms.AnchorStyles.Right);
            this.ok_button.Location = new System.Drawing.Point(180, 43);
            this.ok_button.Name = "ok_button";
            this.ok_button.TabIndex = 1;
            this.ok_button.Text = "OK";      
            this.ok_button.DialogResult = System.Windows.Forms.DialogResult.OK;            
            this.cancel_button.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | 
                System.Windows.Forms.AnchorStyles.Right);
            this.cancel_button.Location = new System.Drawing.Point(260, 43);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.TabIndex = 2;
            this.cancel_button.Text = "Cancel";            
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.inputTextBox.Location = new System.Drawing.Point(6, 9);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(327, 20);
            this.inputTextBox.TabIndex = 0;
            this.inputTextBox.Text = "";            
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | 
                System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right);
            this.ClientSize = new System.Drawing.Size(342, 73);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.inputTextBox,
                                                                          this.cancel_button,
                                                                          this.ok_button});
            this.MinimumSize = new System.Drawing.Size(350, 100);
            this.Name = "StringInputDialog";
            this.Text = "Text Service Provide String Dialog";
            this.ResumeLayout(false);
        }
    }
}
//</Snippet1>