// <snippet510>
// <snippet520>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
// </snippet520>

// <snippet530>
namespace MarqueeControlLibrary.Design
{
    [ToolboxItemFilter("MarqueeControlLibrary.MarqueeBorder", ToolboxItemFilterType.Require)]
    [ToolboxItemFilter("MarqueeControlLibrary.MarqueeText", ToolboxItemFilterType.Require)]
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
    public class MarqueeControlRootDesigner : DocumentDesigner
    {
        // </snippet530>

        // <snippet540>
        public MarqueeControlRootDesigner()
        {
            Trace.WriteLine("MarqueeControlRootDesigner ctor");
        }
        // </snippet540>

        // <snippet550>
        public override void Initialize(IComponent component)
        {
            // <snippet580>
            base.Initialize(component);

            IComponentChangeService cs =
                GetService(typeof(IComponentChangeService)) 
                as IComponentChangeService;

            if (cs != null)
            {
                cs.ComponentChanged +=
                    new ComponentChangedEventHandler(OnComponentChanged);
            }
            // </snippet580>

            // <snippet590>
            this.Verbs.Add(
                new DesignerVerb("Run Test",
                new EventHandler(OnVerbRunTest))
                );

            this.Verbs.Add(
                new DesignerVerb("Stop Test",
                new EventHandler(OnVerbStopTest))
                );
            // </snippet590>
        }
        // </snippet550>

        // <snippet560>
        private void OnComponentChanged(
            object sender,
            ComponentChangedEventArgs e)
        {
            if (e.Component is IMarqueeWidget)
            {
                this.Control.Refresh();
            }
        }
        // </snippet560>

        // <snippet570>
        private void OnVerbRunTest(object sender, EventArgs e)
        {
            MarqueeControl c = this.Control as MarqueeControl;

            c.Start();
        }

        private void OnVerbStopTest(object sender, EventArgs e)
        {
            MarqueeControl c = this.Control as MarqueeControl;

            c.Stop();
        }
        // </snippet570>
    }
}
// </snippet510>