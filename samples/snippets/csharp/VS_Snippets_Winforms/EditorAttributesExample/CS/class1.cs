using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace EditorAttributeExamples
{
    public class Class1 : System.ComponentModel.Component
    {
        // System.ComponentModel.Design.CollectionEditor EditorAttribute example
        //<Snippet1>
        [EditorAttribute(typeof(System.ComponentModel.Design.CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ICollection testCollection
        {
            get
            {
                return Icollection;
            }
            set
            {
                Icollection = value;
            }
        }
        private ICollection Icollection;
        //</Snippet1>

        // System.Drawing.Design.FontEditor EditorAttribute example
        //<Snippet2>
        [EditorAttribute(typeof(System.Drawing.Design.FontEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Font testFont
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
            }
        }
        private Font font;
        //</Snippet2>

        // System.Drawing.Design.ImageEditor EditorAttribute example
        //<Snippet3>
        [EditorAttribute(typeof(System.Drawing.Design.ImageEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Image testImage
        {
            get
            {
                return testImg;
            }
            set
            {
                testImg = value;
            }
        }
        private Image testImg;                
        //</Snippet3>

        // System.Windows.Forms.Design.AnchorEditor EditorAttribute example
        //<Snippet4>
        [EditorAttribute(typeof(System.Windows.Forms.Design.AnchorEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public System.Windows.Forms.AnchorStyles testAnchor
        {
            get
            {
                return anchor;
            }
            set
            {
                anchor = value;
            }
        }
        private AnchorStyles anchor;       
        //</Snippet4>

        // System.Windows.Forms.Design.FileNameEditor EditorAttribute example
        //<Snippet5>
        [EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string testFilename
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
            }
        }
        private string filename;       
        //</Snippet5>

        public Class1()
        {
            // Initialize collections for design-mode editor testing.
            Icollection = new int[] { 0, 2, 4, 6, 8, 12, 14 };
            font = new Font("Arial", 8);           
            testAnchor = AnchorStyles.None;
            filename = string.Empty;
        }
    }
}
