//<Snippet1>
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

namespace Samples.CS
{
    //<Snippet12>
    public class SampleTextBox : TextBox, IScriptControl
    //</Snippet12>
    {
        private string _highlightCssClass;
        private string _noHighlightCssClass;
        private ScriptManager sm;

        public string HighlightCssClass
        {
            get { return _highlightCssClass; }
            set { _highlightCssClass = value; }
        }

        public string NoHighlightCssClass
        {
            get { return _noHighlightCssClass; }
            set { _noHighlightCssClass = value; }
        }

        //<Snippet3>
        protected override void OnPreRender(EventArgs e)
        {
            if (!this.DesignMode)
            {
                // Test for ScriptManager and register if it exists
                sm = ScriptManager.GetCurrent(Page);

                if (sm == null)
                    throw new HttpException("A ScriptManager control must exist on the current page.");

                sm.RegisterScriptControl(this);
            }

            base.OnPreRender(e);
        }
        
        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
                sm.RegisterScriptDescriptors(this);

            base.Render(writer);
        }
        //</Snippet3>

        //<Snippet4>
        protected virtual IEnumerable<ScriptReference> GetScriptReferences()
        {
            ScriptReference reference = new ScriptReference();
            reference.Path = ResolveClientUrl("SampleTextBox.js");

            return new ScriptReference[] { reference };
        }

        protected virtual IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            ScriptControlDescriptor descriptor = new ScriptControlDescriptor("Samples.SampleTextBox", this.ClientID);
            descriptor.AddProperty("highlightCssClass", this.HighlightCssClass);
            descriptor.AddProperty("nohighlightCssClass", this.NoHighlightCssClass);

            return new ScriptDescriptor[] { descriptor };
        }

        IEnumerable<ScriptReference> IScriptControl.GetScriptReferences()
        {
            return GetScriptReferences();
        }

        IEnumerable<ScriptDescriptor> IScriptControl.GetScriptDescriptors()
        {
            return GetScriptDescriptors();
        }
        //</Snippet4>
    }
}
//</Snippet1>
