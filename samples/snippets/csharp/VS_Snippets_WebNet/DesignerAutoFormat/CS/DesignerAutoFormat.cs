//<Snippet1>
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;
using System.Web.UI.WebControls;

namespace CustomControls.Design.CS
{
	// A custom Label control whose contents can be indented
    [Designer(typeof(IndentLabelDesigner)), 
        ToolboxData("<{0}:IndentLabel Runat=\"server\"></{0}:IndentLabel>")]
    public class IndentLabel : Label
    {
        private int _indent = 0;

        // Property to indent all text within the label
        [Category("Appearance"), DefaultValue(0), 
            PersistenceMode(PersistenceMode.Attribute)]
        public int Indent
        {
            get { return _indent; }
            set
            {
                _indent = value;
                // Get the number of pixels to indent
                int ind = value * 8;

                //  Add the indent style to the control
                if (ind > 0)
                    this.Style.Add(HtmlTextWriterStyle.MarginLeft, ind.ToString() + "px");
                else
                    this.Style.Remove(HtmlTextWriterStyle.MarginLeft);
            }
        }
    }


	// A design-time ControlDesigner for the IndentLabel control
    [SupportsPreviewControl(true)]
    public class IndentLabelDesigner : LabelDesigner
    {
        private DesignerAutoFormatCollection _autoFormats = null;

        //<Snippet2>
		// The collection of AutoFormat objects for the IndentLabel object
        public override DesignerAutoFormatCollection AutoFormats
        {
            get
            {
                if (_autoFormats == null)
                {
					// Create the collection
                    _autoFormats = new DesignerAutoFormatCollection();

					// Create and add each AutoFormat object
                    _autoFormats.Add(new IndentLabelAutoFormat("MyClassic"));
                    _autoFormats.Add(new IndentLabelAutoFormat("MyBright"));
                    _autoFormats.Add(new IndentLabelAutoFormat("Default"));
                }
                return _autoFormats;
            }
        }
        //</Snippet2>

	    // An AutoFormat object for the IndentLabel control
        private class IndentLabelAutoFormat : DesignerAutoFormat
        {
		    public IndentLabelAutoFormat(string name) : base(name)
		    { }

            //<Snippet3>
		    // Applies styles based on the Name of the AutoFormat
            public override void Apply(Control inLabel)
            {
                if (inLabel is IndentLabel)
                {
                    IndentLabel ctl = (IndentLabel)inLabel;

				    // Apply formatting according to the Name
                    if (this.Name == "MyClassic")
                    {
					    // For MyClassic, apply style elements directly to the control
                        ctl.ForeColor = Color.Gray;
                        ctl.BackColor = Color.LightGray;
                        ctl.Font.Size = FontUnit.XSmall;
                        ctl.Font.Name = "Verdana,Geneva,Sans-Serif";
                    }
                    else if (this.Name == "MyBright")
                    {
					    // For MyBright, apply style elements to the Style property
                        this.Style.ForeColor = Color.Maroon;
					    this.Style.BackColor = Color.Yellow;
					    this.Style.Font.Size = FontUnit.Medium;

					    // Merge the AutoFormat style with the control's style
					    ctl.MergeStyle(this.Style);
                    }
                    else
                    {
					    // For the Default format, apply style elements to the control
                        ctl.ForeColor = Color.Black;
                        ctl.BackColor = Color.Empty;
                        ctl.Font.Size = FontUnit.XSmall;
                    }
                }
            }
            //</Snippet3>
        }
    }
}
//</Snippet1>