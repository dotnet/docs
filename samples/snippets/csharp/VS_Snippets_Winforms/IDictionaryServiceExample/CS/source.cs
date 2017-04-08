//<Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace IDictionaryServiceControl
{
    // This example control works with the IDictionaryServiceDesigner to demonstrate
    // using the IDictionaryService for storing data provided by a designer, and
    // accessing it from a control. The IDictionaryService provides a Site-specific 
    // key-based dictionary. An IDictionaryServiceDesigner sets an ArrayList of strings 
    // to the dictionary with a "DesignerData" key, and its contents are accessed and
    // displayed once the Update box is clicked at design time.
    [DesignerAttribute(typeof(IDictionaryServiceDesigner), typeof(IDesigner))]
    public class IDictionaryServiceControl : System.Windows.Forms.UserControl
    {
        public ArrayList al;

        public IDictionaryServiceControl()
        {            
            // Initializes the example control.
            al = new ArrayList();
            this.Size = new Size(344, 88);
            this.BackColor = Color.White;
        }

        // Draws the instructions and user interface, and any strings contained 
        // in a local ArrayList.
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if( this.DesignMode )
            {
                e.Graphics.DrawString("IDictionaryServiceDesigner Control", new Font(FontFamily.GenericMonospace, 9), new SolidBrush(Color.Blue), 5, 4);                         
                e.Graphics.DrawString("Click the Update box to update display strings", new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.DarkGreen), 5, 17);
                e.Graphics.DrawString("from the IDictionaryService.", new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.DarkGreen), 5, 29);                 
                
                e.Graphics.FillRectangle(new SolidBrush(Color.Beige), 270, 7, 60, 10);
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1), 270, 7, 60, 10);
                e.Graphics.DrawString("Update", new Font(FontFamily.GenericMonospace, 7), new SolidBrush(Color.Black), 282, 7);

                for( int i=0; i<al.Count; i++ )            
                    e.Graphics.DrawString((string)al[i], new Font(FontFamily.GenericMonospace, 8), new SolidBrush(Color.Black), 5, 44+(i*12));            
            }
        }

        // On mouse down, this method attempts to access the IDictionaryService and 
        // obtain an ArrayList with a key of "DesignerData" in the dictionary.
        // If successful, this ArrayList is set to the local ArrayList.
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
	//<Snippet2>
            // Attempts to obtain the IDictionaryService using the Control.GetService method.
            IDictionaryService ds = (IDictionaryService)GetService(typeof(IDictionaryService));
            // If the service was obtained...
            if( ds != null )
            {
                // Attempts to retrieve a list with a key of "DesignerData".
                ArrayList list = (ArrayList)ds.GetValue( "DesignerData" );
	//</Snippet2>
                // If the list exists, sets the list obtained by the 
                // IDictionaryService to the local list.
                if( list != null )
                    this.al = list;
                this.Refresh();
            }
        }
    }

    // This designer uses the IDictionaryService to store an ArrayList of
    // information strings that the associated control can access and 
    // display. The IDictionaryService creates a new dictionary for each Site.
    public class IDictionaryServiceDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        public IDictionaryServiceDesigner()
        {
        }

        // On designer initialization, this method attempts to obtain 
        // the IDictionaryService, and populates an ArrayList
        // associated with a "DesignerData" key in the dictionary with 
        // designer- and control-related information strings.
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);            
            IDictionaryService ds = (IDictionaryService)component.Site.GetService(typeof(IDictionaryService));
            if( ds != null )
            {
                // If the dictionary service does not contain a 
                // DesignerData key, adds an ArrayList for that key.
                if( ds.GetValue( "DesignerData" ) == null )           
                {
                    ds.SetValue( "DesignerData", new ArrayList() );
                       ds.SetValue( "DesignerData", new ArrayList() );
                }

                // Obtains the ArrayList with the "DesignerData" key 
                // from the dictionary service.
                ArrayList al = (ArrayList)ds.GetValue( "DesignerData" );
                if( al != null )
                {
                    al.Clear();
                    // Populates the array list with designer and 
                    // control information strings.
                    al.Add( "Designer type: "+this.GetType().Name );
                    al.Add( "Control type:  "+this.Control.GetType().Name );
                    al.Add( "Control name:  "+this.Control.Name );                    
                }
            }
        }

        protected override bool GetHitTest(System.Drawing.Point point)
        {
            // Translates the point to client coordinates and passes the 
            // messages to the control while over the click box.
            Point translated = this.Control.PointToClient(point);
            if( translated.X > 269 && translated.X < 331 
                && translated.Y > 7 && translated.Y < 18 )
                return true;
            else
                return base.GetHitTest(point);
        }
    }
}
//</Snippet1>