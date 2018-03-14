//<Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace IToolboxServiceExample
{	
    // Provides an example control that functions in design mode to 
    // demonstrate use of the IToolboxService to list and select toolbox 
    // categories and items, and to add components or controls 
    // to the parent form using code.
    [DesignerAttribute(typeof(WindowMessageDesigner), typeof(IDesigner))]
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
    public class IToolboxServiceControl : System.Windows.Forms.UserControl
    {		
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private IToolboxService toolboxService = null;
        private ToolboxItemCollection tools;
        private int controlSpacingMultiplier;

        public IToolboxServiceControl()
        {
            InitializeComponent();
            listBox2.DoubleClick += new EventHandler(this.CreateComponent);
            controlSpacingMultiplier = 0;
        }
        
        // Obtain or reset IToolboxService reference on each siting of control.
        public override System.ComponentModel.ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {     
                base.Site = value;

                // If the component was sited, attempt to obtain 
                // an IToolboxService instance.
                if( base.Site != null )
                {
                    toolboxService = (IToolboxService)this.GetService(typeof(IToolboxService));
                    // If an IToolboxService was located, update the 
                    // category list.
                    if( toolboxService != null )
                        UpdateLists();                    
                }
                else
                    toolboxService = null;
            }
        }

        // Updates the list of categories and the list of items in the 
        // selected category.
        private void UpdateLists()
        {
            if( toolboxService != null )
            {
                this.listBox1.SelectedIndexChanged -= new System.EventHandler(this.UpdateSelectedCategory);
                this.listBox2.SelectedIndexChanged -= new System.EventHandler(this.UpdateSelectedItem);
                listBox1.Items.Clear();
                for( int i=0; i<toolboxService.CategoryNames.Count; i++ )
                {
                    listBox1.Items.Add( toolboxService.CategoryNames[i] );
                    if( toolboxService.CategoryNames[i] == toolboxService.SelectedCategory )
                    {
                        listBox1.SelectedIndex = i;                        
                        tools = toolboxService.GetToolboxItems( toolboxService.SelectedCategory );
                        listBox2.Items.Clear();
                        for( int j=0; j<tools.Count; j++ )
                            listBox2.Items.Add( tools[j].DisplayName );
                    }
                }
                this.listBox1.SelectedIndexChanged += new System.EventHandler(this.UpdateSelectedCategory);
                this.listBox2.SelectedIndexChanged += new System.EventHandler(this.UpdateSelectedItem);
            }
        }

        // Sets the selected category when a category is clicked in the 
        // category list.
        private void UpdateSelectedCategory(object sender, System.EventArgs e)
        {
            if( toolboxService != null )
            {
                toolboxService.SelectedCategory = (string)listBox1.SelectedItem;
                UpdateLists();
            }
        }

        // Sets the selected item when an item is clicked in the item list.
        private void UpdateSelectedItem(object sender, System.EventArgs e)
        {
            if( toolboxService != null )      
            {
                if( listBox1.SelectedIndex != -1 )
                {
                    if( (string)listBox1.SelectedItem == toolboxService.SelectedCategory )
                        toolboxService.SetSelectedToolboxItem(tools[listBox2.SelectedIndex]);  
                    else
                        UpdateLists();
                }
            }            
        }   

        // Creates a control from a double-clicked toolbox item and adds 
        // it to the parent form.
        private void CreateComponent(object sender, EventArgs e)
        {
            // Obtains an IDesignerHost service from design environment.
            IDesignerHost host = (IDesignerHost)this.GetService(typeof(IDesignerHost));

            // Get the project components container (Windows Forms control 
            // containment depends on controls collections).
            IContainer container = host.Container;
                        
            // Identifies the parent Form.
            System.Windows.Forms.Form parentForm = this.FindForm();

            // Retrieves the parent Form's designer host.
            IDesignerHost parentHost = (IDesignerHost)parentForm.Site.GetService(typeof(IDesignerHost));

            // Create the components.
            IComponent[] comps = null;
            try
            {
                 comps = toolboxService.GetSelectedToolboxItem().CreateComponents(parentHost);
            }
            catch(Exception ex)
            {
                // Catch and show any exceptions to prevent disabling 
                // the control's UI.
                MessageBox.Show(ex.ToString(), "Exception message");
            }
            if( comps == null )
                return;

            // Add any created controls to the parent form's controls 
            // collection. Note: components are added from the 
            // ToolboxItem.CreateComponents(IDesignerHost) method.
            for( int i=0; i<comps.Length; i++ )            
            {
                if( parentForm!= null && comps[i].GetType().IsSubclassOf(typeof(System.Windows.Forms.Control)) )
                {                    
                    ((System.Windows.Forms.Control)comps[i]).Location = new Point(20*controlSpacingMultiplier, 20*controlSpacingMultiplier);
                    if( controlSpacingMultiplier > 10 )
                        controlSpacingMultiplier = 0;
                    else
                        controlSpacingMultiplier++;
                    parentForm.Controls.Add( (System.Windows.Forms.Control)comps[i] );
                }
            }
        }

        // Displays labels.
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawString("IToolboxService Control", new Font("Arial", 14), new SolidBrush(Color.Black), 6, 4);
            e.Graphics.DrawString("Category List", new Font("Arial", 8), new SolidBrush(Color.Black), 8, 26);
            e.Graphics.DrawString("Items in Category", new Font("Arial", 8), new SolidBrush(Color.Black), 208, 26);
            e.Graphics.DrawString("(Double-click item to add to parent form)", new Font("Arial", 7), new SolidBrush(Color.Black), 232, 12);
        }  

        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left);
            this.listBox1.Location = new System.Drawing.Point(8, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(192, 368);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.UpdateSelectedCategory);
            this.listBox2.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right);
            this.listBox2.Location = new System.Drawing.Point(208, 41);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(228, 368);
            this.listBox2.TabIndex = 3;
            this.BackColor = System.Drawing.Color.Beige;
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.listBox2,
                                                                          this.listBox1});
            this.Location = new System.Drawing.Point(500, 400);
            this.Name = "IToolboxServiceControl";
            this.Size = new System.Drawing.Size(442, 422);
            this.ResumeLayout(false);
        }		
    }
    
    // This designer passes window messages to the controls at design time.    
    public class WindowMessageDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        public WindowMessageDesigner()
        {
        }
        
        // Window procedure override passes events to control.
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {   
            if( m.HWnd == this.Control.Handle )
                base.WndProc(ref m);            
            else            
                this.DefWndProc(ref m);            
        }        
    }
}
//</Snippet1>
