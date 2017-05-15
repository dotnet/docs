//<Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace IHelpServiceSample
{
    public class HelpDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        public HelpDesigner()
        {			
        }

        public override System.ComponentModel.Design.DesignerVerbCollection Verbs
        {
            get
            {
                return new DesignerVerbCollection( new DesignerVerb[] { 
                        new DesignerVerb("Add IHelpService Help Keyword", new EventHandler(this.addKeyword)),
                        new DesignerVerb("Remove IHelpService Help Keyword", new EventHandler(this.removeKeyword))
                } );
            }
        }
        
        private void addKeyword(object sender, EventArgs e)
        {
            IHelpService hs = (IHelpService) this.Control.Site.GetService(typeof(IHelpService));			
            hs.AddContextAttribute("keyword", "IHelpService", HelpKeywordType.F1Keyword);	
        }
        
        private void removeKeyword(object sender, EventArgs e)
        {
            IHelpService hs = (IHelpService) this.Control.Site.GetService(typeof(IHelpService));			
            hs.RemoveContextAttribute("keyword", "IHelpService");
        }
    }

    [Designer(typeof(HelpDesigner))]
    public class HelpTestControl : System.Windows.Forms.UserControl
    {
        public HelpTestControl()
        {
            this.Size = new Size(320, 100);
            this.BackColor = Color.White;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {			
            Brush brush = new SolidBrush(Color.Blue);
            e.Graphics.DrawString("IHelpService Example Designer Control", new Font( FontFamily.GenericMonospace, 10 ), brush, 5, 5);
            e.Graphics.DrawString("Right-click this component for", new Font( FontFamily.GenericMonospace, 8 ), brush, 5, 25);
            e.Graphics.DrawString("add/remove Help context keyword commands.", new Font( FontFamily.GenericMonospace, 8 ), brush, 5, 35);			
            e.Graphics.DrawString("Press F1 while this component is", new Font( FontFamily.GenericMonospace, 8 ), brush, 5, 55);
            e.Graphics.DrawString("selected to raise Help topics for", new Font( FontFamily.GenericMonospace, 8 ), brush, 5, 65);			
            e.Graphics.DrawString("the current keyword or keywords", new Font( FontFamily.GenericMonospace, 8 ), brush, 5, 75);			
        }		
    }
}
//</Snippet1>