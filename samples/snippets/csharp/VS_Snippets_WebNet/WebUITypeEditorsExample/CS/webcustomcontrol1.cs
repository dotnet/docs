using System;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace CDWebControl
{	
    //[DesignerAttribute(typeof(WebControlDesignerExample), typeof(IDesigner))]
	[DefaultProperty("Text"),
		ToolboxData("<{0}:WebCustomControl1 runat=server></{0}:WebCustomControl1>")]
	public class WebCustomControl1 : System.Web.UI.WebControls.WebControl
	{
		private string text;

        //<Snippet1>
        [EditorAttribute(typeof(System.Web.UI.Design.UrlEditor), typeof(UITypeEditor))]
        public string URL
        {
            get
            {
                return http_url;
            }
            set
            {
                http_url = value;
            }
        }

        private string http_url;
        //</Snippet1>

        //<Snippet2>
        [EditorAttribute(typeof(System.Web.UI.Design.XmlFileEditor), typeof(UITypeEditor))]
        public string XmlFile
        {
            get
            {
                return xml_;
            }
            set
            {
                xml_ = value;
            }
        }

        private string xml_;
        //</Snippet2>

        //<Snippet3>
        [EditorAttribute(typeof(System.Web.UI.Design.XmlUrlEditor), typeof(UITypeEditor))]
        public string XmlFileURL
        {
            get
            {
                return xmlURL;
            }
            set
            {
                xmlURL = value;
            }
        }

        private string xmlURL;
        //</Snippet3>

        //<Snippet4>
        [EditorAttribute(typeof(System.Web.UI.Design.XslUrlEditor), typeof(UITypeEditor))]
        public string XslFileURL
        {
            get
            {
                return xslURL;
            }
            set
            {
                xslURL = value;
            }
        }

        private string xslURL;
        //</Snippet4>

        //<Snippet5>
        [EditorAttribute(typeof(System.Web.UI.Design.ImageUrlEditor), typeof(UITypeEditor))]
        public string imageURL
        {
            get
            {
                return imgURL;
            }
            set
            {
                imgURL = value;
            }
        }

        private string imgURL;
        //</Snippet5>

        //<Snippet6>
        [EditorAttribute(typeof(System.Web.UI.Design.DataBindingCollectionEditor), typeof(UITypeEditor))]
        public DataBindingCollection TestDataBindings
        {
            get
            {
                return testBindings;
            }
            set
            {
                testBindings = value;
            }
        }

        private DataBindingCollection testBindings;
        //</Snippet6>

		[Bindable(true),
			Category("Appearance"),
			DefaultValue("")]
		public string Text
		{
			get
			{
				return text;
			}

			set
			{
				text = value;
			}
		}

		protected override void Render(HtmlTextWriter output)
		{
			output.Write(Text);
		}
	}
}