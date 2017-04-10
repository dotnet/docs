//<Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

// This example demonstrates adding localization support to a component hierarchy from a 
// custom IRootDesigner using the LocalizationExtenderProvider class.
namespace LocalizationExtenderProviderExample
{	
    // RootViewDesignerComponent is a component associated with the SampleRootDesigner
    // IRootDesigner that provides LocalizationExtenderProvider localization support.
    // This derived class is included at the top of this example to enable 
    // easy launching of designer view without having to put the class in its own file.
    public class RootViewDesignerComponent : RootDesignedComponent
    {  
        public RootViewDesignerComponent()
        {            
        }
    }

    // The following attribute associates the RootDesignedComponent with the RootDesignedComponent component.
    [Designer(typeof(SampleRootDesigner), typeof(IRootDesigner))]
    public class RootDesignedComponent : Component
    {
        public RootDesignedComponent()
        {
        }    
    }

    // Example IRootDesigner implementation demonstrates LocalizationExtenderProvider support.
    internal class SampleRootDesigner : IRootDesigner
    {
        // RootDesignerView Control provides a full region designer view for this root designer's associated component.
        private RootDesignerView m_view;			
        // Stores reference to the LocalizationExtenderProvider this designer adds, in order to remove it on Dispose.
        private LocalizationExtenderProvider extender;        
        // Internally stores the IDesigner's component reference
        private IComponent component;                
        
        // Adds a LocalizationExtenderProvider for the component this designer is initialized to support.
        public void Initialize(System.ComponentModel.IComponent component)
        {
           this.component = component;
            
            // If no extender from this designer is active...
            if( extender == null )
            {
                //<Snippet2>
                // Adds a LocalizationExtenderProvider that provides localization support properties to the specified component.
                extender = new LocalizationExtenderProvider(this.component.Site, this.component);
                //</Snippet2>
            }
        }

        // Provides a RootDesignerView object that supports ViewTechnology.WindowsForms.
        object IRootDesigner.GetView(ViewTechnology technology) 
        {
            if (technology != ViewTechnology.WindowsForms)
            {
                throw new ArgumentException("Not a supported view technology", "technology");
            }
            if (m_view == null )
            {
                // Create the view control. In this example, a Control of type RootDesignerView is used.
                // A WindowsForms ViewTechnology view provider requires a class that inherits from Control.
                m_view = new RootDesignerView(this, this.Component);
            }
            return m_view;
        }

        // This designer supports the WindowsForms view technology.
        ViewTechnology[] IRootDesigner.SupportedTechnologies 
        {
            get
            {
                return new ViewTechnology[] {ViewTechnology.WindowsForms};
            }
        }
        
        // If a LocalizationExtenderProvider has been added, removes the extender provider.
        protected void Dispose(bool disposing)
        {            
            // If an extender has been added, remove it
            if( extender != null  )  
            {
                // Disposes of the extender provider.  The extender 
                // provider removes itself from the extender provider
                // service when it is disposed.
                extender.Dispose();
                extender = null;                
            }            
        }

        // Empty IDesigner interface property and method implementations
        public System.ComponentModel.Design.DesignerVerbCollection Verbs
        {
            get
            {
                return null;
            }
        }

        public System.ComponentModel.IComponent Component
        {
            get
            {
                return this.component;
            }
        }

        public void DoDefaultAction()
        {            
        }

        public void Dispose()
        {        
        }
        
        // RootDesignerView is a simple control that will be displayed in the designer window.
        private class RootDesignerView : Control
        {
            private SampleRootDesigner m_designer;   
            private IComponent comp;
            
            public RootDesignerView(SampleRootDesigner designer, IComponent component)
            {
                m_designer = designer;                        
                this.comp = component;      
                BackColor = Color.Blue;
                Font = new Font(FontFamily.GenericMonospace, 12);
            }

            // Displays the name of the component and the name of the assembly of the component 
            // that this root designer is providing support for.
            protected override void OnPaint(PaintEventArgs pe)
            {
                base.OnPaint(pe);

                if( m_designer != null && comp != null )
                {
                    // Draws the name of the component in large letters.
                    pe.Graphics.DrawString("Root Designer View", Font, Brushes.Yellow, 8, 4);                    
                    pe.Graphics.DrawString("Design Name  : "+comp.Site.Name, new Font("Arial", 10), Brushes.Yellow, 8, 28);                    
                    pe.Graphics.DrawString("Assembly    : "+comp.GetType().AssemblyQualifiedName, new Font("Arial", 10), Brushes.Yellow, new Rectangle(new Point(8, 44), new Size(ClientRectangle.Width-8, ClientRectangle.Height-44)));                   

                    // Uses the site of the component to acquire an ISelectionService and sets the property grid focus to the component.
                    ISelectionService selectionService = (ISelectionService)comp.Site.GetService(typeof(ISelectionService));
                    if( selectionService != null )                
                        selectionService.SetSelectedComponents( new IComponent[] { m_designer.component } );             
                }
            }
        }
    }
}
//</Snippet1>