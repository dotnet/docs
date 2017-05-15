//<snippet1>
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Data;

/*  This sample illustrates how to use the ISelectionService
    interface to handle selection change events.  The ComponentClass
    control attaches event handlers when it is sited in a document
    that displays a message when a component is selected or deselected.

    To run this sample, add the ComponentClass control to a Form and
    then select and deselect the component to see the behavior of the
    component change event handlers. */

namespace ISelectionServiceExample 
{
    public class ComponentClass : System.Windows.Forms.UserControl {
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.ListBox listBox1;
        private ISelectionService m_selectionService;
 
        public ComponentClass() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            // listBox1
            this.listBox1.Location = new System.Drawing.Point(24, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(560, 251);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.
                        EventHandler(this.listBox1_SelectedIndexChanged);

            // ComponentClass
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                        this.listBox1});
            this.Name = "ComponentClass";
            this.Size = new System.Drawing.Size(608, 296);
            this.Load += new System.EventHandler(this.ComponentClass_Load);
            this.ResumeLayout(false);
        }

        public override ISite Site {
            get {
                return base.Site;
            }
            set {
                // This value will always be null when not in design mode
                m_selectionService = (ISelectionService)GetService(typeof(ISelectionService));

                /* The Selection Service works in design mode only, and only after the component is sited.
                    So add our services at this time */
                if (m_selectionService != null) 
                {
                    // We are about to be re-sited.  Clear our old selection change events.
                    m_selectionService.SelectionChanged -= new EventHandler(OnSelectionChanged);
                    m_selectionService.SelectionChanging -= new EventHandler(OnSelectionChanging);
                }

                base.Site = value;
                // This value will always be null when not in design mode
                m_selectionService = (ISelectionService)GetService(typeof(ISelectionService));

                /* The Selection Service works in design mode only, and only after the component is sited.
                    So add our services at this time */
                if (m_selectionService != null) 
                {
//<snippet2>
                    // Add SelectionChanged event handler to event
                    m_selectionService.SelectionChanged += new EventHandler(OnSelectionChanged);
//</snippet2>
//<snippet4>
                    // Add SelectionChanging event handler to event
                    m_selectionService.SelectionChanging += new EventHandler(OnSelectionChanging);
//</snippet4>
                }
            } // end set
        } // end ISite

        // Clean up any resources being used.
        protected override void Dispose( bool disposing ) {
            if( disposing ) {
                if(components != null) {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

//<snippet3> 
        /* This is the OnSelectionChanged handler method.  This method calls
            OnUserChange to display a message that indicates the name of the
            handler that made the call and the type of the event argument. */
        private void OnSelectionChanged(object sender, EventArgs args) 
        {
            OnUserChange("OnSelectionChanged", args.ToString());
        }
//</snippet3>
//<snippet5>
        /* This is the OnSelectionChanging handler method.  This method calls
            OnUserChange to display a message that indicates the name of the
            handler that made the call and the type of the event argument. */
        private void OnSelectionChanging(object sender, EventArgs args) 
        {
            OnUserChange("OnSelectionChanging", args.ToString());
        }
//</snippet5>

        // In this sample, all event handlers call this method
        private void OnUserChange(string text1,string text2) 
        {
            listBox1.Items.Add("Called " + text1 + " using " + text2 + ".");
        }

        private void ComponentClass_Load(object sender, System.EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }
 	}
} // end namespace
//</snippet1>
