/*
//<Snippet13>
Compile the source for this as follows:
csc /r:System.dll /r:System.Design.dll /r:System.Drawing.dll /debug+ /r:System.Web.dll /t:library /out:SimpleControlDesignersCS.dll simplecontroldesigners.cs
//</Snippet13>
*/

//<Snippet1>
//<Snippet2>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;
using System.Web.UI.WebControls;

namespace Samples.AspNet.CS.Controls 
{
}
//</Snippet2>

namespace Samples.AspNet.CS.Brief.Controls
{
	//<Snippet3>
	public class SimpleCompositeControl : CompositeControl
	{
	}
	//</Snippet3>

	//<Snippet8>
	public class SimpleCompositeControl2 : SimpleCompositeControl
	{
	}
	//</Snippet8>

	//<Snippet10>
	public class SimpleContainerControl : WebControl, INamingContainer
	{
	}
	//</Snippet10>

}
namespace Samples.AspNet.CS.Controls 
{
	//<Snippet7>
    [Designer(typeof(SimpleCompositeControlDesigner))]
    public class SimpleCompositeControl : CompositeControl
	//</Snippet7>
    {
		//<Snippet4>
        private String _prompt = "Please enter your date of birth: ";
        public virtual String Prompt
        {
            get
            {
                object o = ViewState["Prompt"];
                return (o == null) ? _prompt : (string)o;
            }
            set
            {
                ViewState["Prompt"] = value;
            }
        }

        public virtual DateTime DOB
        {
            get
            {
                object o = ViewState["DOB"];
                return (o == null) ? DateTime.Now : (DateTime)o;
            }
            set
            {
                ViewState["DOB"] = value;
            }
        }

		//</Snippet4>

		//<Snippet5>
        protected override void CreateChildControls() 
        {
            Label lab = new Label();

            lab.Text = Prompt;
            lab.ForeColor = System.Drawing.Color.Red;
            this.Controls.Add(lab);

            Literal lit = new Literal();
            lit.Text = "<br />";
            this.Controls.Add(lit);

            TextBox tb = new TextBox();
            tb.ID = "tb1";
            tb.Text = DOB.ToString();
            this.Controls.Add(tb);

            base.CreateChildControls();
        }
		//</Snippet5>
    }

	//<Snippet6>
    public class SimpleCompositeControlDesigner : CompositeControlDesigner
    {
        // Set this property to prevent the designer from being resized.
        public override bool AllowResize 
        {
            get { return false; }
        }
    }
	//</Snippet6>

	//<Snippet9>
    [Designer(typeof(CompositeControlDesigner))]
    public class SimpleCompositeControl2 : SimpleCompositeControl
    {
    }
	//</Snippet9>

	//<Snippet12>
    [Designer (typeof(SimpleContainerControlDesigner))]
    [ParseChildren (false)]
    public class SimpleContainerControl : WebControl, INamingContainer
    {
    }
	//</Snippet12>

	//<Snippet11>
    public class SimpleContainerControlDesigner : ContainerControlDesigner
    {
        private Style _style = null;

        // Add the caption by default. Note that the caption 
        // will only appear if the Web server control 
        // allows child controls rather than properties. 
        public override string FrameCaption
        {
            get
            {
                return "A Simple ContainerControlDesigner";
            }
        }

        public override Style FrameStyle
        {
            get
            {
                if (_style == null)
                {
                    _style = new Style ();
                    _style.Font.Name = "Verdana";
                    _style.Font.Size = new FontUnit ("XSmall");
                    _style.BackColor = Color.LightBlue;
                    _style.ForeColor = Color.Black;
                }

                return _style;
            }
        }
    }
	//</Snippet11>

}
//</Snippet1>
