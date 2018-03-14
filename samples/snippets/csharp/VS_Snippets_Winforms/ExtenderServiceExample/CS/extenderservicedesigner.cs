//<Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ExtenderServiceExample
{    
    // This designer adds a ComponentExtender extender provider, 
    // and removes it when the designer is destroyed.
    public class ExtenderServiceDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        // A local reference to an obtained IExtenderProviderService.
        private IExtenderProviderService localExtenderServiceReference;
        // An IExtenderProvider that this designer supplies.
        private ComponentExtender extender;
        
        public ExtenderServiceDesigner()
        {
        }

        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);

            // Attempts to obtain an IExtenderProviderService.
            IExtenderProviderService extenderService = (IExtenderProviderService)component.Site.GetService(typeof(IExtenderProviderService));
            if( extenderService != null )
            {
                // If the service was obtained, adds a ComponentExtender 
                // that adds an "ExtenderIndex" integer property to the 
                // designer's component.
                extender = new ComponentExtender();                
                extenderService.AddExtenderProvider( extender );
                localExtenderServiceReference = extenderService;
            }
            else
                MessageBox.Show("Could not obtain an IExtenderProviderService.");
        }

        protected override void Dispose(bool disposing)
        {
            // Removes any previously added extender provider.
            if( localExtenderServiceReference != null )
            {
                localExtenderServiceReference.RemoveExtenderProvider( extender );
                localExtenderServiceReference = null;
            }            
        }
    }
    
    // IExtenderProviderImplementation that adds an integer property 
    // named "ExtenderIndex" to any design-mode document object.
    [ProvidePropertyAttribute("ExtenderIndex", typeof(IComponent))]
    public class ComponentExtender : System.ComponentModel.IExtenderProvider
    {
        // Stores the value of the property to extend a component with.
        public int index = 0;        
    
        public ComponentExtender()
        {
        }

        public bool CanExtend(object extendee)
        {         
            // Extends any type of object.
            return true;
        }

        public int GetExtenderIndex(IComponent component)
        {
            return index;
        }

        public void SetExtenderIndex(IComponent component, int index)
        {
            this.index = index;
        }
    }

    // Example UserControl associated with the ExtenderServiceDesigner.
    [DesignerAttribute(typeof(ExtenderServiceDesigner))]
    public class ExtenderServiceTestControl : System.Windows.Forms.UserControl
    {		
        public ExtenderServiceTestControl()
        {						
        }
    }
}
//</Snippet1>