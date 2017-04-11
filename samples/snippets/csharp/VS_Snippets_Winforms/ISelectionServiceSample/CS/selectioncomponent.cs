//<Snippet1>
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

/*  This sample demonstrates using the ISelectionService
    interface to receive notification of selection change events.  
    The SelectionComponent control attempts to retrieve an instance 
    of the ISelectionService when it is sited. If it can, it attaches 
    event handlers for events provided by the service that display
    a message when a component is selected or deselected.

    To run this sample, add the SelectionComponent control to a Form and
    then select or deselect components in design mode to see the behavior 
    of the component change event handlers. */

namespace ISelectionServiceExample 
{
    public class SelectionComponent : System.Windows.Forms.UserControl 
    {		
        private System.Windows.Forms.TextBox tbox1;
        private ISelectionService selectionService;
        
        public SelectionComponent() 
        {
            // Initialize control
            this.SuspendLayout();			
            this.Name = "SelectionComponent";
            this.Size = new System.Drawing.Size(608, 296);									
            this.tbox1 = new System.Windows.Forms.TextBox();			
            this.tbox1.Location = new System.Drawing.Point(24, 16);
            this.tbox1.Name = "listBox1";
            this.tbox1.Multiline = true;
            this.tbox1.Size = new System.Drawing.Size(560, 251);
            this.tbox1.TabIndex = 0;
            this.Controls.Add(this.tbox1);
            this.ResumeLayout();
        }
        
        public override ISite Site 
        {
            get 
            {
                return base.Site;
            }
            set 
            {
                // The ISelectionService is available in design mode 
                // only, and only after the component is sited.
                if (selectionService != null) 
                {
                    // Because the selection service has been 
                    // previously obtained, the component may be in 
                    // the process of being resited. 
                    // Detatch the previous selection change event 
                    // handlers in case the new selection
                    // service is a new service instance belonging to 
                    // another design mode service host.
                    selectionService.SelectionChanged -= new EventHandler(OnSelectionChanged);
                    selectionService.SelectionChanging -= new EventHandler(OnSelectionChanging);
                }

                // Establish the new site for the component.
                base.Site = value;				

                if( base.Site == null )
                    return;

                // The selection service is not available outside of 
                // design mode. A call requesting the service 
                // using GetService while not in design mode will 
                // return null.
                selectionService = (ISelectionService)this.Site.GetService(typeof(ISelectionService));

                // If an instance of the ISelectionService was obtained, 
                // attach event handlers for the selection 
                // changing and selection changed events.
                if (selectionService != null)
                {
                    // Add an event handler for the SelectionChanging 
                    // and SelectionChanged events.
                    selectionService.SelectionChanging += new EventHandler(OnSelectionChanging);					
                    selectionService.SelectionChanged += new EventHandler(OnSelectionChanged);	
                }
            }
        }
        
        private void OnSelectionChanged(object sender, EventArgs args)
        {						
            tbox1.AppendText("The selected component was changed.  Selected components:\r\n    " + GetSelectedComponents() + "\r\n");
        }
        
        private void OnSelectionChanging(object sender, EventArgs args)
        {
            tbox1.AppendText("The selected component is changing. Selected components:\r\n    " + GetSelectedComponents() + "\r\n");			
        }
        
        private string GetSelectedComponents()
        {
            string selectedString = String.Empty;
            object[] components = new object[((ICollection)selectionService.GetSelectedComponents()).Count];
            ((ICollection)selectionService.GetSelectedComponents()).CopyTo(components, 0);

            for(int i=0; i<components.Length; i++)
            {
                if( i != 0 )
                    selectedString += "&& ";
                if( ((IComponent)selectionService.PrimarySelection) == ((IComponent)components[i]) )
                    selectedString += "PrimarySelection:";				
                selectedString += ((IComponent)components[i]).Site.Name+" ";
            }
            return selectedString;
        }
        
        // Clean up any resources being used.
        protected override void Dispose( bool disposing )
        {
            // Detatch the event handlers for the selection service.
            if( selectionService != null )
            {
                selectionService.SelectionChanging -= new EventHandler(this.OnSelectionChanging);
                selectionService.SelectionChanged -= new EventHandler(this.OnSelectionChanged);
            }

            base.Dispose( disposing );
        }
    }
}
//</Snippet1>