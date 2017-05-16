//<Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ITypeResolutionServiceExample
{	
    // This control provides an example design-time user interface to 
    // the ITypeResolutionService.
    [DesignerAttribute(typeof(WindowMessageDesigner), typeof(IDesigner))]
    public class ITypeResolutionServiceControl : System.Windows.Forms.UserControl
    {        
        // Reference to a type resolution service interface, or null 
        // if not obtained.
        private ITypeResolutionService rs;
        // Textbox for input of assembly and type names.
        private System.Windows.Forms.TextBox entryBox;
        // Textbox for output of assembly, type, and status information.
        private System.Windows.Forms.TextBox infoBox;
        // Panel to contain the radio buttons used to select the 
        // method to InvokeMethod.
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        // Label to display textbox entry information.
        private System.Windows.Forms.Label label1;
        // Button to InvokeMethod command.
        private System.Windows.Forms.Button button1;        

        public ITypeResolutionServiceControl()
        {
            InitializeComponent();
            rs = null;
            // Attaches event handlers for control clicked events.
            radioButton1.CheckedChanged += new EventHandler(this.GetAssembly);
            radioButton2.CheckedChanged += new EventHandler(this.GetPathToAssembly);
            radioButton3.CheckedChanged += new EventHandler(this.GetInstanceOfType);
            radioButton4.CheckedChanged += new EventHandler(this.ReferenceAssembly);
            button1.Click += new EventHandler(this.InvokeMethod);
            entryBox.KeyUp += new KeyEventHandler(this.InvokeOnEnterKeyHandler);
        }

        // Displays example control name and status information.
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawString("ITypeResolutionService Interface Control", new Font(FontFamily.GenericMonospace, 9), new SolidBrush(Color.Blue), 5, 5);
            if(this.DesignMode)
                e.Graphics.DrawString("Currently in Design Mode", new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.DarkGreen), 350, 2);
            else
                e.Graphics.DrawString("Requires Design Mode", new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Red), 350, 2);
            if( rs != null )
                e.Graphics.DrawString("Type Resolution Service Obtained", new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.DarkGreen), 350, 12);
            else
                e.Graphics.DrawString("Type Resolution Service Not Obtained", new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Red), 350, 12);
        }

        // InvokeMethods the currently selected method, if any, when 
        // the InvokeMethod button is pressed.
        private void InvokeMethod(object sender, EventArgs e)
        {
            // If the GetAssembly or GetPathofAssembly radio button 
            // is selected.
            if(this.radioButton1.Checked || this.radioButton2.Checked || this.radioButton4.Checked)
            {
                if(this.entryBox.Text.Length == 0)
                {
                    // If there is no assembly name specified, display status message.
                    this.infoBox.Text = "You must enter the name of the assembly to retrieve.";
                }
                else if( rs != null )
                {
                    // Create a System.Reflection.AssemblyName 
                    // for the entered text.
                    AssemblyName name = new AssemblyName();                               
                    name.Name = this.entryBox.Text.Trim();                    

                    // If the GetAssembly radio button is checked...
                    if(this.radioButton1.Checked)
                    {
                        // Use the ITypeResolutionService to attempt to 
                        // resolve an assembly reference.
                        Assembly a = rs.GetAssembly( name, false );
                        // If an assembly matching the specified name was not 
                        // located in the GAC or local project references, 
                        // display a message.
                        if( a == null )
                            this.infoBox.Text = "The "+this.entryBox.Text+" assembly could not be located.";
                        else
                        {
                            // An assembly matching the specified name was located.
                            // Builds a list of types.
                            Type[] types = a.GetTypes();
                            StringBuilder sb = new StringBuilder();
                            for(int i=0; i<types.Length; i++)                        
                                sb.Append(types[i].FullName+"\r\n");
                            string path = rs.GetPathOfAssembly(name);
                            // Displays assembly information and a list of types contained in the assembly.
                            this.infoBox.Text = "Assembly located:\r\n\r\n"+a.FullName+"\r\n  at: "+path+"\r\n\r\nAssembly types:\r\n\r\n"+sb.ToString();
                        }
                    }
                    else if(this.radioButton2.Checked)
                    {
                        string path = rs.GetPathOfAssembly(name);
                        if( path != null )                        
                            this.infoBox.Text = "Assembly located at:\r\n"+path;
                        else
                            this.infoBox.Text = "Assembly was not located.";
                    }
                    else if(this.radioButton4.Checked)
                    {
                        Assembly a = null;
                        try
                        {
                            // Add a reference to the assembly to the 
                            // current project.
                            rs.ReferenceAssembly(name);
                            // Use the ITypeResolutionService to attempt 
                            // to resolve an assembly reference.                        
                            a = rs.GetAssembly( name, false );
                        }
                        catch
                        {     
                            // Catch this exception so that the exception 
                            // does not interrupt control behavior.
                        }
                        // If an assembly matching the specified name was not 
                        // located in the GAC or local project references, 
                        // display a message.
                        if( a == null )
                            this.infoBox.Text = "The "+this.entryBox.Text+" assembly could not be located.";
                        else                        
                            this.infoBox.Text = "A reference to the "+a.FullName+" assembly has been added to the project's referenced assemblies.";                        
                    }
                }
            }
            else if(this.radioButton3.Checked)
            {
                if(this.entryBox.Text.Length == 0)
                {
                    // If there is no type name specified, display a 
                    // status message.
                    this.infoBox.Text = "You must enter the name of the type to retrieve.";
                }
                else if( rs != null )
                {
                    Type type = null;
                    try
                    {
                        type = rs.GetType(this.entryBox.Text, false, true);
                    }
                    catch
                    {                
                        // Consume exceptions raised during GetType call
                    }
                    if( type != null )
                    {
                        // Display type information.
                        this.infoBox.Text = "Type: "+type.FullName+" located.\r\n  Namespace: "+type.Namespace+"\r\n"+type.AssemblyQualifiedName;
                    }
                    else
                        this.infoBox.Text = "Type not located.";
                }                
            }
        }

        private void GetAssembly(object sender, EventArgs e)
        {
            if(this.radioButton1.Checked)            
                this.label1.Text = "Enter the assembly name:";            
        }

        private void GetPathToAssembly(object sender, EventArgs e)
        {
            if(this.radioButton2.Checked)            
                this.label1.Text = "Enter the assembly name:";            
        }

        private void GetInstanceOfType(object sender, EventArgs e)
        {
            if(this.radioButton3.Checked)
            this.label1.Text = "Enter the type name:";            
        }
    
        private void ReferenceAssembly(object sender, EventArgs e)
        {
            if(this.radioButton4.Checked)           
                this.label1.Text = "Enter the assembly name:";
        }

        private void InvokeOnEnterKeyHandler(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Enter )            
                this.InvokeMethod(sender, new EventArgs());            
        }

        public override System.ComponentModel.ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {
                base.Site = value;
            
                // Attempts to obtain ITypeResolutionService interface.
                rs = (ITypeResolutionService)this.GetService(typeof(ITypeResolutionService));
            }
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.entryBox = new System.Windows.Forms.TextBox();
            this.infoBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // entryBox
            this.entryBox.Location = new System.Drawing.Point(176, 80);
            this.entryBox.Name = "entryBox";
            this.entryBox.Size = new System.Drawing.Size(320, 20);
            this.entryBox.TabIndex = 0;
            this.entryBox.Text = "";
            // infoBox
            this.infoBox.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right);
            this.infoBox.Location = new System.Drawing.Point(16, 111);
            this.infoBox.Multiline = true;
            this.infoBox.Name = "infoBox";
            this.infoBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.infoBox.Size = new System.Drawing.Size(592, 305);
            this.infoBox.TabIndex = 1;
            this.infoBox.Text = "";
            // panel1
            this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                this.radioButton4,
                                                                            this.radioButton3,
                                                                                this.radioButton2,
                                                                                this.radioButton1});
            this.panel1.Location = new System.Drawing.Point(16, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 40);
            this.panel1.TabIndex = 2;
            // radioButton1
            this.radioButton1.Location = new System.Drawing.Point(8, 8);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(96, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "GetAssembly";
            // radioButton2
            this.radioButton2.Location = new System.Drawing.Point(112, 8);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(128, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "GetPathToAssembly";
            // radioButton3
            this.radioButton3.Location = new System.Drawing.Point(248, 8);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(80, 24);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "GetType";
            // radioButton4
            this.radioButton4.Location = new System.Drawing.Point(344, 8);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(128, 24);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "ReferenceAssembly";
            // label1
            this.label1.Location = new System.Drawing.Point(18, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 16);
            this.label1.TabIndex = 3;
            // button1
            this.button1.Location = new System.Drawing.Point(519, 41);
            this.button1.Name = "button1";
            this.button1.TabIndex = 4;
            this.button1.Text = "Invoke";
            // ITypeResolutionServiceControl
            this.BackColor = System.Drawing.Color.White;
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                        this.button1,
                                                                        this.label1,
                                                                        this.panel1,
                                                                        this.infoBox,
                                                                        this.entryBox});
            this.Name = "ITypeResolutionServiceControl";
            this.Size = new System.Drawing.Size(624, 432);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
    }

    // Since this example provides a control-based user interface 
    // in design mode, this designer passes window messages to the 
    // controls at design time.    
    public class WindowMessageDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        public WindowMessageDesigner()
        {                       
        }

        // Window procedure override passes events to the control.
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {   
            if( m.HWnd == this.Control.Handle )            
                base.WndProc(ref m);            
            else            
                this.DefWndProc(ref m);            
        }

        public override void DoDefaultAction()
        {        
        }
    }
}
//</Snippet1>
