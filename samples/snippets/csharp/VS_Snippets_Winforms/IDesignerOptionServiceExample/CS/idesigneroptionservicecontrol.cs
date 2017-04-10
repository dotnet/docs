//<Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace IDesignerOptionServiceExample
{
    // This control demonstrates retrieving the standard 
    // designer option service values in design mode.
    public class IDesignerOptionServiceControl : System.Windows.Forms.UserControl
    {		
        private IDesignerOptionService designerOptionService;

        public IDesignerOptionServiceControl()
        {
            this.BackColor = Color.Beige;
                    this.Size = new Size(404, 135);
        }
        
        public override System.ComponentModel.ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {
                base.Site = value;

                // If siting component, attempt to obtain an IDesignerOptionService.
                if( base.Site != null )                            
                    designerOptionService = (IDesignerOptionService)this.GetService(typeof(IDesignerOptionService));                                   
            }
        }

        // Displays control information and current IDesignerOptionService 
        // values, if available.
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawString("IDesignerOptionServiceControl", new Font("Arial", 9), new SolidBrush(Color.Blue), 4, 4);
            if( this.DesignMode )
                e.Graphics.DrawString("Currently in design mode", new Font("Arial", 8), new SolidBrush(Color.Black), 4, 18);
            else
                e.Graphics.DrawString("Not in design mode. Cannot access IDesignerOptionService.", new Font("Arial", 8), new SolidBrush(Color.Red), 4, 18);
            
            if( base.Site != null && designerOptionService != null )
            {
                e.Graphics.DrawString("IDesignerOptionService provides access to the table of option values listed when", new Font("Arial", 8), new SolidBrush(Color.Black), 4, 38);
                e.Graphics.DrawString("the Windows Forms Designer\\General tab of the Tools\\Options menu is selected.", new Font("Arial", 8), new SolidBrush(Color.Black), 4, 50);                
                
                e.Graphics.DrawString("Table of standard value names and current values", new Font("Arial", 8), new SolidBrush(Color.Red), 4, 76);
                
                // Displays a table of the standard value names and current values.
                int ypos = 90;

                // <snippet2>
                // Obtains and shows the size of the standard design-mode grid square.
                Size size = (Size)designerOptionService.GetOptionValue("WindowsFormsDesigner\\General", "GridSize");
                // </snippet2>
                e.Graphics.DrawString("GridSize", new Font("Arial", 8), new SolidBrush(Color.Black), 4, ypos);
                e.Graphics.DrawString(size.ToString(), new Font("Arial", 8), new SolidBrush(Color.Black), 100, ypos);
                ypos+=12;
                
                // Obtains and shows whether the design mode surface grid is enabled.
                bool showGrid = (bool)designerOptionService.GetOptionValue("WindowsFormsDesigner\\General", "ShowGrid");
                e.Graphics.DrawString("ShowGrid", new Font("Arial", 8), new SolidBrush(Color.Black), 4, ypos);
                e.Graphics.DrawString(showGrid.ToString(), new Font("Arial", 8), new SolidBrush(Color.Black), 100, ypos);
                ypos+=12;
                
                // Obtains and shows whether components should be aligned with the surface grid.
                bool snapToGrid = (bool)designerOptionService.GetOptionValue("WindowsFormsDesigner\\General", "SnapToGrid");
                e.Graphics.DrawString("SnapToGrid", new Font("Arial", 8), new SolidBrush(Color.Black), 4, ypos);
                e.Graphics.DrawString(snapToGrid.ToString(), new Font("Arial", 8), new SolidBrush(Color.Black), 100, ypos);                
            }
        }
    }
}
//</Snippet1>
