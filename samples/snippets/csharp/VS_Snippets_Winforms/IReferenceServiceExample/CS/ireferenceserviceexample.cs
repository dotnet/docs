//<Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace IReferenceServiceExample
{
    // This control displays the name and type of the primary selection 
    // component in design mode, if there is one,
    // and uses the IReferenceService interface to display the names of 
    // any components of the type of the primary selected component.    
    // This control uses the IComponentChangeService to monitor for 
    // selection changed events.
    public class IReferenceServiceControl : System.Windows.Forms.UserControl
	{
            // Indicates the name of the type of the selected component, or "None selected.".
            private string selected_typename;
            // Indicates the name of the base type of the selected component, or "None selected."
            private string selected_basetypename;
            // Indicates the name of the selected component.
            private string selected_componentname;
            // Contains the names of components of the type of the selected 
            // component in design mode.
            private string[] typeComponents;
            // Contains the names of components of the base type of the selected component in design mode.
            private string[] basetypeComponents;
            // Reference to the IComponentChangeService for the current component.
            private ISelectionService selectionService;
        
            public IReferenceServiceControl()
            {
                // Initializes the control properties.
                this.BackColor = Color.White;
                this.SetStyle(ControlStyles.ResizeRedraw, true);
                this.Name = "IReferenceServiceControl";
                this.Size = new System.Drawing.Size(500, 250);			                        
                // Initializes the data properties.
                typeComponents = new string[0];
                basetypeComponents = new string[0];
                selected_typename = "None selected.";
                selected_basetypename = "None selected.";
                selected_componentname = "None selected.";
                selectionService = null;
            }

            // Registers and unregisters design-mode services when 
            // the component is sited and unsited.
            public override System.ComponentModel.ISite Site
            {
                get
                {
                    // Returns the site for the control.
                    return base.Site;
                }
                set
                {
                    // The site is set to null when a component is cut or 
                    // removed from a design-mode site.

                    // If an event handler has already been linked with 
                    // an ISelectionService, remove the handler.
                    if(selectionService != null)
                        selectionService.SelectionChanged -= new EventHandler(this.OnSelectionChanged);

                    // Sites the control.
                    base.Site = value;
                
                    // Obtains an ISelectionService interface to register 
                    // the selection changed event handler with.
                    selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
                    if( selectionService!= null )
                    {
                        selectionService.SelectionChanged += new EventHandler(this.OnSelectionChanged);
                        // Updates the display for the current selection, if any.
                        DisplayComponentsOfSelectedComponentType();
                    }
                }
            }

            // Updates the display according to the primary selected component, 
            // if any, and the names of design-mode components that the 
            // IReferenceService returns references for when queried for 
            // references to components of the primary selected component's 
            // type and base type.
            private void DisplayComponentsOfSelectedComponentType()
            {
                // If a component is selected...
                if( selectionService.PrimarySelection != null )
                {              
                    // Sets the selected type name and selected component name to the type and name of the primary selected component.
                    selected_typename = selectionService.PrimarySelection.GetType().FullName;
                    selected_basetypename = selectionService.PrimarySelection.GetType().BaseType.FullName;
                    selected_componentname = ((IComponent)selectionService.PrimarySelection).Site.Name;                

                    // Obtain an IReferenceService and obtain references to 
                    // each component in the design-mode project
                    // of the selected component's type and base type.
                    IReferenceService rs = (IReferenceService)this.GetService(typeof(IReferenceService));
                    if( rs != null )
                    {
                        // Get references to design-mode components of the 
                        // primary selected component's type.
                        object[] comps = (object[])rs.GetReferences( selectionService.PrimarySelection.GetType() );
                        typeComponents = new string[comps.Length];
                        for(int i=0; i<comps.Length; i++)
                            typeComponents[i] = ((IComponent)comps[i]).Site.Name;
   
                        // Get references to design-mode components with a base type 
                        // of the primary selected component's base type.
                        comps = (object[])rs.GetReferences( selectionService.PrimarySelection.GetType().BaseType );
                        basetypeComponents = new string[comps.Length];
                        for(int i=0; i<comps.Length; i++)
                            basetypeComponents[i] = ((IComponent)comps[i]).Site.Name;
                    }
                }
                else
                {
                    selected_typename = "None selected.";
                    selected_basetypename = "None selected.";
                    selected_componentname = "None selected.";
                    typeComponents = new string[0];
                    basetypeComponents = new string[0];
                }
                this.Refresh();
            }

            private void OnSelectionChanged(object sender, EventArgs e)
            {
                DisplayComponentsOfSelectedComponentType();
            }

            protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
            {
                e.Graphics.DrawString("IReferenceService Example Control", new Font(FontFamily.GenericMonospace, 9), new SolidBrush(Color.Blue), 5, 5);

                e.Graphics.DrawString("Primary Selected Component from IComponentChangeService:", new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Red), 5, 20);
                e.Graphics.DrawString("Name:      "+selected_componentname, new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Black), 10, 32);
                e.Graphics.DrawString("Type:      "+selected_typename, new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Black), 10, 44);
                e.Graphics.DrawString("Base Type: "+selected_basetypename, new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Black), 10, 56);
                e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 5, 77, this.Width-5, 77);
            
                e.Graphics.DrawString("Components of Type from IReferenceService:", new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Red), 5, 85);                        
                if( selected_typename != "None selected." )
                    for(int i=0; i<typeComponents.Length; i++)
                        e.Graphics.DrawString(typeComponents[i], new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Black), 20, 97+(i*12));
            
                e.Graphics.DrawString("Components of Base Type from IReferenceService:", new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Red), 5, 109+(typeComponents.Length*12));
                if( selected_typename != "None selected." )
                    for(int i=0; i<basetypeComponents.Length; i++)
                        e.Graphics.DrawString(basetypeComponents[i], new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Black), 20, 121+(typeComponents.Length*12)+(i*12));
            }
	}
}
//</Snippet1>