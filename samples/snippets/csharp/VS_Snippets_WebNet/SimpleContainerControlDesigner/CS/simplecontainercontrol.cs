// <Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;
using System.Web.UI.WebControls;

namespace ControlDesignerSamples.CS
{
    // <Snippet2>
    // <Snippet3>

    // Define a simple composite control, derived from the 
    // System.Web.UI.WebControls.CompositeControl class.
    [
        Designer(typeof(SimpleContainerControlDesigner)) , 
        ParseChildren(false)
    ]
    public class SimpleContainerControl : CompositeControl
    {
    }

    // </Snippet3>
    // <Snippet4>

    // Define the designer for the simple composite control.
    // The designer derives from System.Web.UI.Design.ContainerControlDesigner.
    // The designer defines the style and caption for frame around the 
    // editable region in the design surface.
    public class SimpleContainerControlDesigner : ContainerControlDesigner
    {
        private Style _style = null;

        // Define the caption text for the frame in the design surface.
        public override string FrameCaption
        {
            get
            {
                return "= My simple container control =";
            }
        }

        // Define the style of the frame around the control in the design surface.
        public override Style FrameStyle
        {
            get
            {
                if (_style == null)
                {
                    _style = new Style();
                    _style.Font.Name = "Verdana";
                    _style.Font.Size = new FontUnit("XSmall");
                    _style.BackColor = Color.LavenderBlush;
                    _style.ForeColor = Color.DarkBlue;
                }

                return _style;
            }
        }
    }
    // </Snippet4>
    // </Snippet2>
}
// </Snippet1>