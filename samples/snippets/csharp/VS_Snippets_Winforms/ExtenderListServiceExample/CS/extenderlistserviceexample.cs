//<Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ExtenderListServiceExample
{
    // This control lists any active extender providers.
    public class ExtenderListServiceControl : System.Windows.Forms.UserControl
    {		
        private IExtenderListService extenderListService;
        private string[] extenderNames;

        public ExtenderListServiceControl()
        {			
            extenderNames = new string[0];
            this.Width = 600;
        }

        // Queries the IExtenderListService when the control is sited 
        // in design mode.
        public override System.ComponentModel.ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {
                base.Site = value;
                if( this.DesignMode )
                {
                    extenderListService = (IExtenderListService)this.GetService(typeof(IExtenderListService));
                    if( extenderListService != null )
                    {
                        IExtenderProvider[] extenders = extenderListService.GetExtenderProviders();
                        extenderNames = new string[extenders.Length];
                        for( int i=0; i<extenders.Length; i++ )
                            extenderNames[i] = "ExtenderProvider #"+i.ToString()+":  "+extenders[i].GetType().FullName;
                    }
                }
                else
                {
                    extenderListService = null;
                    extenderNames = new string[0];
                }
            }
        }

        // Draws a list of any active extender providers
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if( extenderNames.Length == 0 )
                e.Graphics.DrawString("No active extender providers", new Font("Arial", 9), new SolidBrush(Color.Black), 10, 10);
            else
                e.Graphics.DrawString("List of types of active extender providers", new Font("Arial", 9), new SolidBrush(Color.Black), 10, 10);
            for(int i=0; i<extenderNames.Length; i++)
                e.Graphics.DrawString(extenderNames[i], new Font("Arial", 8), new SolidBrush(Color.Black), 10, 25+(i*10));
        }		
    }
}
//</Snippet1>