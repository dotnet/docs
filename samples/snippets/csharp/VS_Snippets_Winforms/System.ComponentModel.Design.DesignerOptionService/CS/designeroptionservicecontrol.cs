//<snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DesignerOptionServiceExample
{
    // This control demonstrates retrieving the standard 
    // designer option service values in design mode.
    public class DesignerOptionServiceControl : System.Windows.Forms.UserControl
    {		
        private DesignerOptionService designerOptionSvc;

        public DesignerOptionServiceControl()
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

                // If siting component, attempt to obtain an DesignerOptionService.
                if( base.Site != null )                            
                    designerOptionSvc = (DesignerOptionService)this.GetService(typeof(DesignerOptionService));                                   
            }
        }

        // Displays control information and current DesignerOptionService 
        // values, if available.
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawString("DesignerOptionServiceControl", 
                new Font("Arial", 9), 
                new SolidBrush(Color.Blue), 4, 4);

            if( this.DesignMode )
                e.Graphics.DrawString("Currently in design mode", 
                    new Font("Arial", 8), 
                    new SolidBrush(Color.Black), 4, 18);
            else
                e.Graphics.DrawString("Not in design mode. Cannot access DesignerOptionService.", 
                    new Font("Arial", 8), 
                    new SolidBrush(Color.Red), 4, 18);
            
            if( base.Site != null && designerOptionSvc != null )
            {
                e.Graphics.DrawString("DesignerOptionService provides access to the table of option values listed when", 
                    new Font("Arial", 8), 
                    new SolidBrush(Color.Black), 4, 38);

                e.Graphics.DrawString("the Windows Forms Designer\\General tab of the Tools\\Options menu is selected.", 
                    new Font("Arial", 8), 
                    new SolidBrush(Color.Black), 4, 50);                
                
                e.Graphics.DrawString("Table of standard value names and current values", 
                    new Font("Arial", 8), 
                    new SolidBrush(Color.Red), 4, 76);
                
                // Displays a table of the standard value names and current values.
                int ypos = 90;

                // <snippet2>
                // <snippet3>
                // Obtains and shows the size of the standard design-mode grid square.
                PropertyDescriptor pd;
                pd = designerOptionSvc.Options.Properties["GridSize"];
                e.Graphics.DrawString("GridSize", 
                    new Font("Arial", 8), 
                    new SolidBrush(Color.Black), 4, ypos);
                e.Graphics.DrawString(pd.GetValue(null).ToString(), 
                    new Font("Arial", 8), 
                    new SolidBrush(Color.Black), 200, ypos);
                ypos += 12;
                // </snippet2>

                // Uncomment the following code to demonstrate that this
                // alternate syntax works the same as the previous syntax.

                //pd = designerOptionSvc.Options["WindowsFormsDesigner"].Properties["GridSize"];
                //e.Graphics.DrawString("GridSize",
                //    new Font("Arial", 8),
                //    new SolidBrush(Color.Black), 4, ypos);
                //e.Graphics.DrawString(pd.GetValue(null).ToString(),
                //    new Font("Arial", 8),
                //    new SolidBrush(Color.Black), 200, ypos);
                //ypos += 12;

                //pd = designerOptionSvc.Options["WindowsFormsDesigner"]["General"].Properties["GridSize"];
                //e.Graphics.DrawString("GridSize",
                //    new Font("Arial", 8),
                //    new SolidBrush(Color.Black), 4, ypos);
                //e.Graphics.DrawString(pd.GetValue(null).ToString(),
                //    new Font("Arial", 8),
                //    new SolidBrush(Color.Black), 200, ypos);
                //ypos += 12;
                // </snippet3>
                
                // Obtains and shows whether the design mode surface grid is enabled.
                pd = designerOptionSvc.Options.Properties["ShowGrid"];
                e.Graphics.DrawString("ShowGrid", 
                    new Font("Arial", 8), 
                    new SolidBrush(Color.Black), 4, ypos);
                e.Graphics.DrawString(pd.GetValue(null).ToString(), 
                    new Font("Arial", 8), 
                    new SolidBrush(Color.Black), 200, ypos);
                ypos+=12;
                
                // Obtains and shows whether components should be aligned with the surface grid.
                pd = designerOptionSvc.Options.Properties["SnapToGrid"];
                e.Graphics.DrawString("SnapToGrid", 
                    new Font("Arial", 8), 
                    new SolidBrush(Color.Black), 4, ypos);
                e.Graphics.DrawString(pd.GetValue(null).ToString(), 
                    new Font("Arial", 8), 
                    new SolidBrush(Color.Black), 200, ypos);
                ypos += 12;

                // Obtains and shows which layout mode is selected.
                pd = designerOptionSvc.Options.Properties["LayoutMode"];
                e.Graphics.DrawString("LayoutMode",
                    new Font("Arial", 8),
                    new SolidBrush(Color.Black), 4, ypos);
                e.Graphics.DrawString(pd.GetValue(null).ToString(),
                    new Font("Arial", 8),
                    new SolidBrush(Color.Black), 200, ypos);
                ypos += 12;

                // Obtains and shows whether the Toolbox is automatoically
                // populated with custom controls and components.
                pd = designerOptionSvc.Options.Properties["AutoToolboxPopulate"];
                e.Graphics.DrawString("AutoToolboxPopulate",
                    new Font("Arial", 8),
                    new SolidBrush(Color.Black), 4, ypos);
                e.Graphics.DrawString(pd.GetValue(null).ToString(),
                    new Font("Arial", 8),
                    new SolidBrush(Color.Black), 200, ypos);
                ypos += 12;

                // Obtains and shows whether the component cache is used.
                pd = designerOptionSvc.Options.Properties["UseOptimizedCodeGeneration"];
                e.Graphics.DrawString("Optimized Code Generation",
                    new Font("Arial", 8),
                    new SolidBrush(Color.Black), 4, ypos);
                e.Graphics.DrawString(pd.GetValue(null).ToString(),
                    new Font("Arial", 8),
                    new SolidBrush(Color.Black), 200, ypos);
                ypos += 12;

                // Obtains and shows whether smart tags are automatically opened.
                pd = designerOptionSvc.Options.Properties["ObjectBoundSmartTagAutoShow"];
                e.Graphics.DrawString("Automatically Open Smart Tags",
                    new Font("Arial", 8),
                    new SolidBrush(Color.Black), 4, ypos);
                e.Graphics.DrawString(pd.GetValue(null).ToString(),
                    new Font("Arial", 8),
                    new SolidBrush(Color.Black), 200, ypos);
            }
        }
    }
}
//</snippet1>
