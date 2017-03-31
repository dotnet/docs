//<snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ControlDesignerExample
{
    // ExampleControlDesigner is an example control designer that 
    // demonstrates basic functions of a ControlDesigner.
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
    public class ExampleControlDesigner  : System.Windows.Forms.Design.ControlDesigner
    {
        // This boolean state reflects whether the mouse is over the control.
        private bool mouseover = false;
        // This color is a private field for the OutlineColor property.
        private Color lineColor = Color.White;

        // This color is used to outline the control when the mouse is 
        // over the control.
        public Color OutlineColor
        {
            get
            {
                return lineColor;
            }
            set
            {
                lineColor = value;
            }
        }

        public ExampleControlDesigner()
        {
        }

        // Sets a value and refreshes the control's display when the 
        // mouse position enters the area of the control.
        protected override void OnMouseEnter()
        {
            this.mouseover = true;
            this.Control.Refresh();
        }    

        // Sets a value and refreshes the control's display when the 
        // mouse position enters the area of the control.        
        protected override void OnMouseLeave()
        {
            this.mouseover = false;            
            this.Control.Refresh();
        }        
        
        // Draws an outline around the control when the mouse is 
        // over the control.    
        protected override void OnPaintAdornments(System.Windows.Forms.PaintEventArgs pe)
        {
            if (this.mouseover)
            {
                pe.Graphics.DrawRectangle(
                    new Pen(new SolidBrush(this.lineColor), 6), 
                    0, 
                    0, 
                    this.Control.Size.Width, 
                    this.Control.Size.Height);
            }
        }

        //<snippet2>
        // Adds a property to this designer's control at design time 
        // that indicates the outline color to use. 
        // The DesignOnlyAttribute ensures that the OutlineColor
        // property is not serialized by the designer.
        protected override void PreFilterProperties(System.Collections.IDictionary properties)
        {
            PropertyDescriptor pd = TypeDescriptor.CreateProperty(
                typeof(ExampleControlDesigner), 
                "OutlineColor",
                typeof(System.Drawing.Color),
                new Attribute[] { new DesignOnlyAttribute(true) });

            properties.Add("OutlineColor", pd);
        }
        //</snippet2>
    }

    // This example control demonstrates the ExampleControlDesigner.
    [DesignerAttribute(typeof(ExampleControlDesigner))]
    public class ExampleControl : System.Windows.Forms.UserControl
    {        
        private System.ComponentModel.Container components = null;

        public ExampleControl()
        {
            components = new System.ComponentModel.Container();
        }

        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if( components != null )
                components.Dispose();
            }
            base.Dispose( disposing );
        }
    }
}
//</snippet1>