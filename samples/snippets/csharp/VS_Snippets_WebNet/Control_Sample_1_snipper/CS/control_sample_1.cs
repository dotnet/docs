// System.Web.UI.Control.OnPreRender;
// System.Web.UI.Control.PreRender;
/* The following example demontrates implementation of 'PreRender' event and 
   'OnPreRender' method of 'System.Web.UI.Control' class.   
   This program creates a custom control 'ParentControl' by inheriting from 
   'Control' Class. Method 'OnPreRender' is overridden to call 'PreRender' 
   event. Custom handler written for PreRender event renders custom controls
   to web client. 
*/

using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RenderChildrenSample
{

    public class ParentControl : Control
    {
        private string _message = "Parent";
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
            }
        }

        // Call base class constructor.
        public ParentControl()
            : base()
        {
            // Attach new handler to PreRender Event.
            PreRender += new System.EventHandler(PreRender_Handler);
        }


        protected override void CreateChildControls()
        {
            // Creates a new ControlCollection. 
            this.CreateControlCollection();

            ChildControl firstControl = new ChildControl();
            firstControl.Message = "FirstChildControl";
            ChildControl secondControl = new ChildControl();
            secondControl.Message = "SecondChildControl";

            Controls.Add(firstControl);
            Controls.Add(secondControl);

            // Prevent child controls from being created again.
            ChildControlsCreated = true;
        }

        // <Snippet2>
        // <Snippet1>
        // Override the OnPreRender method to set _message to
        // a default value if it is null.
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (_message == null)
                _message = "Here is some default text.";
        }
        // </Snippet1>

        private void PreRender_Handler(object sender, System.EventArgs e)
        {
            _message = "Parent Text was changed by PreRender method";
        }

        // </Snippet2>

        protected override void Render(HtmlTextWriter output)
        {
            output.Write("<br>Message : " + _message);
        }
        public class ChildControl : Control
        {
            private string _message = "Child";
            public string Message
            {
                get
                {
                    return _message;
                }
                set
                {
                    _message = value;
                }
            }

            protected override void Render(HtmlTextWriter output)
            {
                output.Write("<br>Message from Control : " + Message);
            }
        }
    }
}
