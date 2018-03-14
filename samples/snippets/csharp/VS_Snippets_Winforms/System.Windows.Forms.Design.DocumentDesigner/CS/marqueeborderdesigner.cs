// <snippet410>
// <snippet420>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.Design;
// </snippet420>

// <snippet430>
namespace MarqueeControlLibrary.Design
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
    public class MarqueeBorderDesigner : ParentControlDesigner
    {
        // </snippet430>

        public MarqueeBorderDesigner()
        {
            Trace.WriteLine("MarqueeBorderDesigner");
        }

        // <snippet440>
        public bool Visible
        {
            get
            {
                return (bool)ShadowProperties["Visible"];
            }
            set
            {
                this.ShadowProperties["Visible"] = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return (bool)ShadowProperties["Enabled"];
            }
            set
            {
                this.ShadowProperties["Enabled"] = value;
            }
        }
        // </snippet440>

        // <snippet450>
        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);
            
            if (properties.Contains("Padding"))
            {
                properties.Remove("Padding");
            }

            properties["Visible"] = TypeDescriptor.CreateProperty(
                typeof(MarqueeBorderDesigner),
                (PropertyDescriptor)properties["Visible"],
                new Attribute[0]);

            properties["Enabled"] = TypeDescriptor.CreateProperty(
                typeof(MarqueeBorderDesigner),
                (PropertyDescriptor)properties["Enabled"],
                new Attribute[0]);
        }
        // </snippet450>

        // <snippet460>
        private void OnVerbRunTest(object sender, EventArgs e)
        {
            IMarqueeWidget widget = this.Control as IMarqueeWidget;

            widget.StartMarquee();
        }

        private void OnVerbStopTest(object sender, EventArgs e)
        {
            IMarqueeWidget widget = this.Control as IMarqueeWidget;

            widget.StopMarquee();
        }
        // </snippet460>
    }
}
// </snippet410>