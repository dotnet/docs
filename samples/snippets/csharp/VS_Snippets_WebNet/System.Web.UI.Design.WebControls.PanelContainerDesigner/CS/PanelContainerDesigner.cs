// PanelContainerDesigner.cs
// <snippet1>
using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.Design.WebControls;
using System.ComponentModel;
using System.Security.Permissions;

namespace Examples.CS.WebControls.Design
{
    // <snippet2>
    // The MyPanelContainer is a copy of the Panel.
    [AspNetHostingPermission(SecurityAction.Demand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(Examples.CS.WebControls.Design.MyPanelContainerDesigner))]
    public class MyPanelContainer : Panel
    {
    } // MyPanelContainer
    // </snippet2>

    // Override members of the PanelContainerDesigner.
    public class MyPanelContainerDesigner : PanelContainerDesigner
    {
        // <snippet3>
        // Provide a design-time caption for the panel.
        public override string FrameCaption 
        {
            get
            {
                // If the FrameCaption is empty, use the panel control ID.
                string localCaption = base.FrameCaption;
                if (localCaption == null || localCaption == "")
                    localCaption = ((Panel)Component).ID.ToString();

                return localCaption;
            }
        } // FrameCaption
        // </snippet3>

        // <snippet4>
        // Provide a design-time border style for the panel.
        public override Style FrameStyle
        {
            get
            {
                Style styleOfFrame = base.FrameStyle;

                // If no border style is defined, define one.
                if (styleOfFrame.BorderStyle == BorderStyle.NotSet ||
                    styleOfFrame.BorderStyle == BorderStyle.None)
                    styleOfFrame.BorderStyle = BorderStyle.Outset;

                return styleOfFrame;
            }
        } // FrameStyle
        // </snippet4>

        // <snippet5>
        // Initialize the designer.
        public override void Initialize(IComponent component)
        {
            // Ensure that only a MyPanelContainer can be created 
            // in this designer.
            if (!(component is MyPanelContainer))
                throw new ArgumentException();
            
            base.Initialize(component);

        } // Initialize
        // </snippet5>
    } // MyPanelContainerDesigner
} // Examples.CS.WebControls.Design
// </snippet1>

