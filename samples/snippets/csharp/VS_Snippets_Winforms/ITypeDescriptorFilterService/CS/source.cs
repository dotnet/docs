//<Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ITypeDescriptorFilterSample
{	
    // Component to host the ButtonDesignerFilterComponentDesigner that loads the 
    // ButtonDesignerFilterService ITypeDescriptorFilterService.
    [Designer(typeof(ButtonDesignerFilterComponentDesigner))]
    public class ButtonDesignerFilterComponent : System.ComponentModel.Component
    {		
        public ButtonDesignerFilterComponent(System.ComponentModel.IContainer container)
        {
            container.Add(this);
        }

        public ButtonDesignerFilterComponent()
        {}
    }

    // Provides a designer that can add a ColorCycleButtonDesigner to each 
    // button in a design time project using the ButtonDesignerFilterService 
    // ITypeDescriptorFilterService.
    public class ButtonDesignerFilterComponentDesigner : System.ComponentModel.Design.ComponentDesigner
    {
        // Indicates whether the service has been loaded.
        private bool serviceloaded = false;		
        // Stores any old ITypeDescriptorFilterService to restore later.
        private ITypeDescriptorFilterService oldservice = null;
        
        public ButtonDesignerFilterComponentDesigner()
        {}
        
        // Loads the new ITypeDescriptorFilterService and reloads the 
        // designers for each button.
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            
            // Loads the custom service if it has not been loaded already
            LoadService();
            
            // Build list of buttons from Container.Components.
            ArrayList buttons = new ArrayList();
            foreach(IComponent c in this.Component.Site.Container.Components)
                if(c.GetType() == typeof(System.Windows.Forms.Button))
                    buttons.Add((System.Windows.Forms.Button)c);
            if(buttons.Count > 0)
            {		
                // Tests each Button for an existing 
                // ColorCycleButtonDesigner;
                // if it has no designer of type 
                // ColorCycleButtonDesigner, adds a designer.
                foreach(System.Windows.Forms.Button b in buttons)
                {
                    bool loaddesigner = true;
                    // Gets the attributes for each button.
                    AttributeCollection ac = TypeDescriptor.GetAttributes(b);
                    for(int i=0; i<ac.Count; i++)
                    {
                        // If designer attribute is not for a 
                        // ColorCycleButtonDesigner, adds a new 
                        // ColorCycleButtonDesigner.
                        if( ac[i] is DesignerAttribute )
                        {
                            DesignerAttribute da = (DesignerAttribute)ac[i];
                            if( da.DesignerTypeName.Substring(da.DesignerTypeName.LastIndexOf(".")+1) == "ColorCycleButtonDesigner" )
                                loaddesigner = false;
                        }
                    }
                    if(loaddesigner)
                    {
                        // Saves the button location so that it 
                        // can be repositioned.
                        Point p = b.Location;	
                    
                        // Gets an IMenuCommandService to cut and 
                        // paste control in order to register with 
                        // selection and movement interface after 
                        // designer is changed without reloading.
                        IMenuCommandService imcs = (IMenuCommandService)this.GetService(typeof(IMenuCommandService));
                        if( imcs == null )
                            throw new Exception("Could not obtain IMenuCommandService interface.");							
                        // Gets an ISelectionService to select the 
                        // button so that it can be cut and pasted.
                        ISelectionService iss = (ISelectionService)this.GetService(typeof(ISelectionService));
                        if( iss == null)
                            throw new Exception("Could not obtain ISelectionService interface.");
                        iss.SetSelectedComponents(new IComponent[] { b }, SelectionTypes.Auto);						
                        // Invoke Cut and Paste.
                        imcs.GlobalInvoke(StandardCommands.Cut);
                        imcs.GlobalInvoke(StandardCommands.Paste);							
                        // Regains reference to button from 
                        // selection service.
                        System.Windows.Forms.Button b2 = (System.Windows.Forms.Button)iss.PrimarySelection;
                        iss.SetSelectedComponents(null);							
                        // Refreshes TypeDescriptor properties of 
                        // button to load new attributes from
                        // ButtonDesignerFilterService.
                        TypeDescriptor.Refresh(b2);							
                        b2.Location = p;
                        b2.Focus();
                    }
                }
            }
        }

        // Loads a ButtonDesignerFilterService ITypeDescriptorFilterService 
        // to add ColorCycleButtonDesigner designers to each button.
        private void LoadService()
        {
            // If no custom ITypeDescriptorFilterService is loaded, 
            // loads it now.
            if(!serviceloaded)
            {
                // Stores the current ITypeDescriptorFilterService 
                // to restore later.
                ITypeDescriptorFilterService tdfs = (ITypeDescriptorFilterService)this.Component.Site.GetService(typeof(ITypeDescriptorFilterService));
                if( tdfs != null )								
                    oldservice = tdfs;								
                // Retrieves an IDesignerHost interface to use to 
                // remove and add services.
                IDesignerHost dh = (IDesignerHost)this.Component.Site.GetService(typeof(IDesignerHost));
                if( dh == null )
                    throw new Exception("Could not obtain IDesignerHost interface.");				
                // Removes standard ITypeDescriptorFilterService.
                dh.RemoveService(typeof(ITypeDescriptorFilterService));
                // Adds new custom ITypeDescriptorFilterService.
                dh.AddService(typeof(ITypeDescriptorFilterService), new ButtonDesignerFilterService());				
                serviceloaded = true;
            }
        }
        
        // Removes the custom service and reloads any stored, 
        // preexisting service.
        private void RemoveService()
        {
            IDesignerHost dh = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if( dh == null )
                throw new Exception("Could not obtain IDesignerHost interface.");
            dh.RemoveService(typeof(ITypeDescriptorFilterService));
            if( oldservice != null )
                dh.AddService(typeof(ITypeDescriptorFilterService), oldservice);
            serviceloaded = false;
        }

        protected override void Dispose(bool disposing)
        {
            if(serviceloaded)
                RemoveService();
        }
    }

    // Provides a TypeDescriptorFilterService to add the 
    // ColorCycleButtonDesigner using a DesignerAttribute.
    public class ButtonDesignerFilterService : System.ComponentModel.Design.ITypeDescriptorFilterService
    {
        public ITypeDescriptorFilterService oldService = null;

        public ButtonDesignerFilterService()
        {}

        public ButtonDesignerFilterService(ITypeDescriptorFilterService oldService_)
        {
            // Stores any previous ITypeDescriptorFilterService to implement service chaining.
            this.oldService = oldService_;
        }

        public bool FilterAttributes(System.ComponentModel.IComponent component, System.Collections.IDictionary attributes)
        {
            if(oldService != null)
                oldService.FilterAttributes(component, attributes);
            
            // Creates a designer attribute to compare its TypeID with the TypeID of existing attributes of the component.
            DesignerAttribute da = new DesignerAttribute(typeof(ColorCycleButtonDesigner));
            // Adds the designer attribute if the attribute collection does not contain a DesignerAttribute of the same TypeID.
            if(component is System.Windows.Forms.Button && attributes.Contains(da.TypeId))
                attributes[da.TypeId]=da;
            return true;
        }

        public bool FilterEvents(System.ComponentModel.IComponent component, System.Collections.IDictionary events)
        {
            if(oldService != null)
                oldService.FilterEvents(component, events);
            return true;
        }

        public bool FilterProperties(System.ComponentModel.IComponent component, System.Collections.IDictionary properties)
        {
            if(oldService != null)
                oldService.FilterProperties(component, properties);
            return true;
        }
    }
    
    // Designer for a Button control which cycles the background color.
    public class ColorCycleButtonDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        private System.Windows.Forms.Timer timer1;
        private Color initial_bcolor, initial_fcolor;
        private int r, g, b;
        private bool ru, gu, bu, continue_;

        public ColorCycleButtonDesigner()
        {						
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 50;
            timer1.Tick += new EventHandler(this.Elapsed);
            ru = true;
            gu = false;
            bu = true;			
            continue_ = false;
            timer1.Start();
        }

        private void Elapsed(object sender, EventArgs e)
        {
            this.Control.BackColor = Color.FromArgb(r%255, g%255, b%255);
            this.Control.Refresh();

            // Updates color.		
            if(ru)
                r+=10;
            else if(r>10) 
                r-=10;
            if(gu)
                g+=10;
            else if(g>10)
                g-=10;
            if(bu)
                b+=10;
            else if(b>10)
                b-=10;

            // Randomly switches direction of color component values.
            Random rand = new Random();
            for(int i=0; i<4; i++)			
                switch(rand.Next(0, 2))
                {
                    case 0:
                        if(ru)
                            ru=false;
                        else
                            ru=true;
                        break;
                    case 1:
                        if(gu)
                            gu=false;
                        else
                            gu=true;
                        break;
                    case 2:
                        if(bu)
                            bu=false;
                        else
                            bu=true;
                        break;
                }

            this.Control.ForeColor = Color.FromArgb((this.Control.BackColor.R+128)%255, (this.Control.BackColor.G+128)%255, (this.Control.BackColor.B+128)%255);
        }

        protected override void OnMouseEnter()
        {
            if(!timer1.Enabled)
            {
                initial_bcolor = this.Control.BackColor;
                initial_fcolor = this.Control.ForeColor;
                r = initial_bcolor.R;
                g = initial_bcolor.G;
                b = initial_bcolor.B;			
                timer1.Start();
            }
        }

        protected override void OnMouseLeave()
        {
            if(!continue_)
            {
                continue_ = true;
                timer1.Stop();
            }
            else
                continue_ = false;
            
            this.Control.BackColor = initial_bcolor;
            this.Control.ForeColor = initial_fcolor;			
        }

        protected override void Dispose(bool disposing)
        {
            timer1.Stop();
            this.Control.BackColor = initial_bcolor;
            this.Control.ForeColor = initial_fcolor;
            base.Dispose(disposing);
        }
    }

    // System.Windows.Forms.Button associated with the ColorCycleButtonDesigner.
    [Designer(typeof(ColorCycleButtonDesigner))]
    public class ColorCycleButton : System.Windows.Forms.Button
    {
        public ColorCycleButton()
        {}
    }
}
//</Snippet1>