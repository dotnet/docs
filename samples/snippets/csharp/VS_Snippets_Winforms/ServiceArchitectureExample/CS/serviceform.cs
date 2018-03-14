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
    // Example form provides UI for demonstrating service sharing behavior 
    // of a network of IServiceContainer/IServiceProvider controls.
	public class ServiceForm : System.Windows.Forms.Form
	{                
        // Root service container control for tree.
        private ServiceObjectControl root;         
             
        // Button for clearing any provided services and resetting tree states.
        private System.Windows.Forms.Button reset_button;       

        // Color list used to color code controls.
        private Color[] colorkeys;                              

        // Strings used to reflect text service.
        private string[] keystrings;                            

		public ServiceForm()
		{
			InitializeComponent();
            CreateServiceControlTree();
            colorkeys = new Color[] { Color.Beige, Color.SeaShell, Color.LightGreen, Color.LightBlue, Color.Khaki, Color.CadetBlue };
            keystrings = new string[] { "No service use", "Service not accessible", "Service provided", "Service obtained", "Service accessible", "No further access" };
		}

        private void CreateServiceControlTree()
        {
            // Create root service control.
            ServiceObjectControl control1 = new ServiceObjectControl(null, new Size(300, 40), new Point(10, 80), this);
            root = control1;
            // Create first tier - pass parent with service object control 1
            ServiceObjectControl control2 = new ServiceObjectControl(control1, new Size(200, 30), new Point(50, 160), this);
            ServiceObjectControl control3 = new ServiceObjectControl(control1, new Size(200, 30), new Point(50, 240), this);
            // Create second tier A - pass parent with service object control 2
            ServiceObjectControl control4 = new ServiceObjectControl(control2, new Size(180, 20), new Point(300, 145), this);
            ServiceObjectControl control5 = new ServiceObjectControl(control2, new Size(180, 20), new Point(300, 185), this);
            // Create second tier B - pass parent with service object control 3
            ServiceObjectControl control6 = new ServiceObjectControl(control3, new Size(180, 20), new Point(300, 225), this);
            ServiceObjectControl control7 = new ServiceObjectControl(control3, new Size(180, 20), new Point(300, 265), this);
            // Add controls.
            this.Controls.AddRange( new Control[] { control1, control2, control3, control4, control5, control6, control7 } );
        }

        internal void ResetServiceTree(object sender, EventArgs e)
        {
            // Remove the service from the service tree.
            if( root.serviceContainer.GetService(typeof(TextService)) != null )            
                root.serviceContainer.RemoveService(typeof(TextService), true);

            // Set all controls to "not obtained" and clear their labels.
            for( int i=0; i<Controls.Count; i++ )
                if( !Controls[i].Equals(reset_button) ) 
                {
                    ((ServiceObjectControl)Controls[i]).state = TextServiceState.ServiceNotObtained;
                    ((ServiceObjectControl)Controls[i]).label = string.Empty;
                    ((ServiceObjectControl)Controls[i]).BackColor = Color.Beige;
                }
        }

        public void UpdateServiceCoverage()
        {
            // Have each control set state to reflect service availability.
            for( int i=0; i<Controls.Count; i++ )
                if( !Controls[i].Equals(reset_button) )                 
                    ((ServiceObjectControl)Controls[i]).ReflectServiceVisibility();                                 
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
            e.Graphics.DrawString("The following tree diagram represents a hierarchy of linked service containers in controls.", new Font("Arial", 9), new SolidBrush(Color.Black), 4, 4);
            e.Graphics.DrawString("This example demonstrates the propagation behavior of services through a linked service object tree.", new Font("Arial", 8), new SolidBrush(Color.Black), 4, 26);            
            e.Graphics.DrawString("Right-click a component to add or replace a text service, or to remove it if the component provided it.", new Font("Arial", 8), new SolidBrush(Color.Black), 4, 38);
            e.Graphics.DrawString("Left-click a component to update text from the text service if available.", new Font("Arial", 8), new SolidBrush(Color.Black), 4, 50);

            // Draw lines to represent tree branches.
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 20, 125, 20, 258);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 21, 175, 45, 175);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 21, 258, 45, 258);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 255, 175, 285, 175);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 255, 258, 285, 258);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 285, 155, 285, 195);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 285, 238, 285, 278);            
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 285, 155, 290, 155);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 285, 195, 290, 195);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 285, 238, 290, 238);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 285, 278, 290, 278);

            // Draw color key.
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1), 20, 305, 410, 60);
            int y=0;
            for( int i=0; i<3; i++ )
            {
                e.Graphics.FillRectangle(new SolidBrush(colorkeys[y]), 25+(i*140), 310, 20, 20);           
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1), 25+(i*140), 310, 20, 20);     
                e.Graphics.DrawString(keystrings[y], new Font("Arial", 8), new SolidBrush(Color.Black), 50+(i*140), 315);
                y++;
                e.Graphics.FillRectangle(new SolidBrush(colorkeys[y]), 25+(i*140), 340, 20, 20);           
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1), 25+(i*140), 340, 20, 20);              
                e.Graphics.DrawString(keystrings[y], new Font("Arial", 8), new SolidBrush(Color.Black), 50+(i*140), 345);
                y++;
            }
        }
	}

    // An example user control that uses ServiceContainer to add, remove,
    // and access services through a linkable service container network.
    public class ServiceObjectControl : System.Windows.Forms.UserControl
    {
        // This example user control implementation provides a wrapper for 
        // ServiceContainer, supporting a linked service container network.    
        public ServiceContainer serviceContainer;        
        // Parent form reference for main program function access.
        private ServiceForm parent;                  
        // String for label displayed on the control to indicate the 
        // control's current service-related configuration state.
        public string label;               
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
                if( (TextServiceState)value == TextServiceState.ServiceProvided )
                    this.BackColor = Color.LightGreen;
                else if( (TextServiceState)value == TextServiceState.ServiceNotObtained )                
                    this.BackColor = Color.White;                                   
                else if( (TextServiceState)value == TextServiceState.ServiceObtained )
                    this.BackColor = Color.LightBlue;
                else if( (TextServiceState)value == TextServiceState.ServiceNotFound )                                    
                    this.BackColor = Color.SeaShell;                
                state_ = value;
            }
        }        
        
        public ServiceObjectControl(ServiceObjectControl serviceContainerParent, Size size, Point location, ServiceForm parent)
        {
            this.state_ = TextServiceState.ServiceNotObtained;
            this.BackColor = Color.Beige;            
            this.label = string.Empty;            
            this.Size = size;
            this.Location = location;
            this.parent = parent;            
            if( serviceContainerParent == null )
                serviceContainer = new ServiceContainer();
            else
                serviceContainer = new ServiceContainer(serviceContainerParent.serviceContainer);
        }

        // Paint method override draws the label string on the control.
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawString(label, new Font("Arial", 8), new SolidBrush(Color.Black), 5, 5);            
        }

        // Process mouse-down behavior for click.
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if( e.Button == MouseButtons.Left )
            {
                if( state_ != TextServiceState.ServiceProvided )
                {
                    // Attempt to update text from service, and set color 
                    // state accordingly.
                    TextService ts = (TextService)serviceContainer.GetService(typeof(TextService));
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
                    // Remove service if the container provided it.
                    if( serviceContainer.GetService(typeof(TextService)) != null )
                    {
                        serviceContainer.RemoveService(typeof(TextService), true);
                        state = TextServiceState.ServiceNotObtained; 
                        this.label = "Service Removed";                                                                   
                    }                    
                }
                else
                {
                    // Obtain string and provide text service.
                    using (StringInputDialog form = new StringInputDialog("Test String"))
                    {
                        form.StartPosition = FormStartPosition.CenterParent;
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            if (serviceContainer.GetService(typeof(TextService)) != null)
                                serviceContainer.RemoveService(typeof(TextService), true);
                            parent.ResetServiceTree(this, new EventArgs());
                            serviceContainer.AddService(typeof(TextService), new TextService(form.inputTextBox.Text), true);
                            state = TextServiceState.ServiceProvided;
                            this.label = "Provided Text: " + form.inputTextBox.Text;
                        }
                    }
                }
            }
            parent.UpdateServiceCoverage();
        }

        // Method accesses the TextService to test the visibility of the service 
        // from the control, and sets the UI state accordingly.
        public void ReflectServiceVisibility()
        {
            if( state_ == TextServiceState.ServiceObtained )
            {
                if( serviceContainer.GetService(typeof(TextService)) == null )  
                    this.BackColor = Color.CadetBlue;
            }
            else if( state_ != TextServiceState.ServiceProvided )
            {
                if( serviceContainer.GetService(typeof(TextService)) == null )
                {
                    this.BackColor = Color.White;
                    return;
                }

                // Service available.                  
                if( state_ == TextServiceState.ServiceNotFound )                
                    this.BackColor = Color.Khaki;                
                else if( state_ == TextServiceState.ServiceNotObtained && label != "Service Removed" )
                    this.BackColor = Color.Khaki;       
            }            
        }
    }

    // Example service type contains a text string, sufficient 
    // to demonstrate service sharing.
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
            this.ok_button.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.ok_button.Location = new System.Drawing.Point(180, 43);
            this.ok_button.Name = "ok_button";
            this.ok_button.TabIndex = 1;
            this.ok_button.Text = "OK";      
            this.ok_button.DialogResult = System.Windows.Forms.DialogResult.OK;            
            this.cancel_button.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
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
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
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