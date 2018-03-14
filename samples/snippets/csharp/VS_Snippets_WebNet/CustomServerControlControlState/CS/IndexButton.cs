// <Snippet1>
// IndexButton.cs
using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Samples.AspNet.CS.Controls
{
    [
    AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal),
    AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level=AspNetHostingPermissionLevel.Minimal),
    ToolboxData("<{0}:IndexButton runat=\"server\"> </{0}:IndexButton>")
    ]
    public class IndexButton : Button
    {
        private int indexValue;

        [
        Bindable(true),
        Category("Behavior"),
        DefaultValue(0),
        Description("The index stored in control state.")
        ]
        public int Index
        {
            get
            {
                return indexValue;
            }
            set
            {
                indexValue = value;
            }
        }

        [
        Bindable(true),
        Category("Behavior"),
        DefaultValue(0),
        Description("The index stored in view state.")
        ]
        public int IndexInViewState
        {
            get
            {
                object obj = ViewState["IndexInViewState"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                ViewState["IndexInViewState"] = value;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }

        protected override object SaveControlState()
        {
            // Invoke the base class's method and
            // get the contribution to control state
            // from the base class.
            // If the indexValue field is not zero
            // and the base class's control state is not null,
            // use Pair as a convenient data structure
            // to efficiently save 
            // (and restore in LoadControlState)
            // the two-part control state
            // and restore it in LoadControlState.

            object obj = base.SaveControlState();

            if (indexValue != 0)
            {
                if (obj != null)
                {
                    return new Pair(obj, indexValue);
                }
                else
                {
                    return (indexValue);
                }
            }
            else
            {
                return obj;
            }
        }

        protected override void LoadControlState(object state)
        {
            if (state != null)
            {
                Pair p = state as Pair;
                if (p != null)
                {
                    base.LoadControlState(p.First);
                    indexValue = (int)p.Second;
                }
                else
                {
                    if (state is int)
                    {
                        indexValue = (int)state;
                    }
                    else
                    {
                        base.LoadControlState(state);
                    }
                }
            }
        }

    }
}
// </Snippet1>
