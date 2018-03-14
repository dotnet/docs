//<Snippet1>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace AngleEditor
{
    // This UITypeEditor can be associated with Int32, Double and Single
    // properties to provide a design-mode angle selection interface.
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
    public class AngleEditor : System.Drawing.Design.UITypeEditor
    {        
        public AngleEditor()
        {
        }

        // Indicates whether the UITypeEditor provides a form-based (modal) dialog, 
        // drop down dialog, or no UI outside of the properties window.
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        // Displays the UI for value selection.
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {            
            // Return the value if the value is not of type Int32, Double and Single.
            if( value.GetType() != typeof(double) && value.GetType() != typeof(float) && value.GetType() != typeof(int) )
                return value;

            // Uses the IWindowsFormsEditorService to display a 
            // drop-down UI in the Properties window.
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if( edSvc != null )
            {
                // Display an angle selection control and retrieve the value.
                AngleControl angleControl = new AngleControl((double)value);
                edSvc.DropDownControl( angleControl );

                // Return the value in the appropraite data format.
                if( value.GetType() == typeof(double) )
                    return angleControl.angle;
                else if( value.GetType() == typeof(float) )
                    return (float)angleControl.angle;
                else if( value.GetType() == typeof(int) )
                    return (int)angleControl.angle;
            }
            return value;
        }

        // Draws a representation of the property's value.
        public override void PaintValue(System.Drawing.Design.PaintValueEventArgs e)
        {
            int normalX = (e.Bounds.Width/2);
            int normalY = (e.Bounds.Height/2);
            
            // Fill background and ellipse and center point.
            e.Graphics.FillRectangle(new SolidBrush(Color.DarkBlue), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);            
            e.Graphics.FillEllipse(new SolidBrush(Color.White), e.Bounds.X+1, e.Bounds.Y+1, e.Bounds.Width-3, e.Bounds.Height-3);
            e.Graphics.FillEllipse(new SolidBrush(Color.SlateGray), normalX+e.Bounds.X-1, normalY+e.Bounds.Y-1, 3, 3);
            
            // Draw line along the current angle.
            double radians = ((double)e.Value*Math.PI) / (double)180;
            e.Graphics.DrawLine( new Pen(new SolidBrush(Color.Red), 1), normalX+e.Bounds.X, normalY+e.Bounds.Y, 
                e.Bounds.X+ ( normalX + (int)( (double)normalX * Math.Cos( radians ) ) ),
                e.Bounds.Y+ ( normalY + (int)( (double)normalY * Math.Sin( radians ) ) ) );
        }
        
        // Indicates whether the UITypeEditor supports painting a 
        // representation of a property's value.
        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }
    }

    // Provides a user interface for adjusting an angle value.
    internal class AngleControl : System.Windows.Forms.UserControl
    {
        // Stores the angle.
        public double angle;
        // Stores the rotation offset.
        private int rotation = 0;
        // Control state tracking variables.
        private int dbx = -10;
        private int dby = -10;
        private int overButton = -1;
        
        public AngleControl(double initial_angle)
        {
            this.angle = initial_angle;                 
            this.SetStyle( ControlStyles.AllPaintingInWmPaint, true );
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            // Set angle origin point at center of control.
            int originX = (this.Width/2);
            int originY = (this.Height/2);            
            
            // Fill background and ellipse and center point.
            e.Graphics.FillRectangle(new SolidBrush(Color.DarkBlue), 0, 0, this.Width, this.Height);
            e.Graphics.FillEllipse(new SolidBrush(Color.White), 1, 1, this.Width-3, this.Height-3);            
            e.Graphics.FillEllipse(new SolidBrush(Color.SlateGray), originX-1, originY-1, 3, 3);
            
            // Draw angle markers.
            int startangle = (270-rotation)%360;
            e.Graphics.DrawString(startangle.ToString(), new Font("Arial", 8), new SolidBrush(Color.DarkGray), (this.Width/2)-10, 10);
            startangle = (startangle+90)%360;
            e.Graphics.DrawString(startangle.ToString(), new Font("Arial", 8), new SolidBrush(Color.DarkGray), this.Width-18, (this.Height/2)-6);
            startangle = (startangle+90)%360;
            e.Graphics.DrawString(startangle.ToString(), new Font("Arial", 8), new SolidBrush(Color.DarkGray), (this.Width/2)-6, this.Height-18);
            startangle = (startangle+90)%360;
            e.Graphics.DrawString(startangle.ToString(), new Font("Arial", 8), new SolidBrush(Color.DarkGray), 10, (this.Height/2)-6);

            // Draw line along the current angle.         
            double radians = ((((angle+rotation)+360)%360)*Math.PI) / (double)180;
            e.Graphics.DrawLine( new Pen(new SolidBrush(Color.Red), 1), originX, originY, 
                originX + (int)( (double)originX * (double)Math.Cos( radians )   ),
                originY + (int)( (double)originY * (double)Math.Sin( radians ) ) );
            
            // Output angle information.
            e.Graphics.FillRectangle(new SolidBrush(Color.Gray), this.Width-84, 3, 82, 13);
            e.Graphics.DrawString("Angle: "+angle.ToString("F4"), new Font("Arial", 8), new SolidBrush(Color.Yellow), this.Width-84, 2);
            // Draw square at mouse position of last angle adjustment.
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1), dbx-2, dby-2, 4, 4);
            // Draw rotation adjustment buttons.
            if( overButton == 1 )
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Green), this.Width-28, this.Height-14, 12, 12);
                e.Graphics.FillRectangle(new SolidBrush(Color.Gray), 2, this.Height-13, 110, 12);    
                e.Graphics.DrawString("Rotate 90 degrees left", new Font("Arial", 8), new SolidBrush(Color.White), 2, this.Height-14);
            }
            else            
                e.Graphics.FillRectangle(new SolidBrush(Color.DarkGreen), this.Width-28, this.Height-14, 12, 12);
            if( overButton == 2 )
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Green), this.Width-14, this.Height-14, 12, 12);
                e.Graphics.FillRectangle(new SolidBrush(Color.Gray), 2, this.Height-13, 116, 12);    
                e.Graphics.DrawString("Rotate 90 degrees right", new Font("Arial", 8), new SolidBrush(Color.White), 2, this.Height-14);
            }
            else
                e.Graphics.FillRectangle(new SolidBrush(Color.DarkGreen), this.Width-14, this.Height-14, 12, 12);
            e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.White), 1), this.Width-11, this.Height-11, 6, 6);
            e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.White), 1), this.Width-25, this.Height-11, 6, 6);
            if( overButton == 1 )
                e.Graphics.FillRectangle(new SolidBrush(Color.Green), this.Width-25, this.Height-6, 4, 4);
            else
                e.Graphics.FillRectangle(new SolidBrush(Color.DarkGreen), this.Width-25, this.Height-6, 4, 4);
            if( overButton == 2 )
                e.Graphics.FillRectangle(new SolidBrush(Color.Green), this.Width-8, this.Height-6, 4, 4);
            else
                e.Graphics.FillRectangle(new SolidBrush(Color.DarkGreen), this.Width-8, this.Height-6, 4, 4);
            e.Graphics.FillPolygon(new SolidBrush(Color.White), new Point[] { new Point(this.Width-7, this.Height-8), new Point(this.Width-3, this.Height-8), new Point(this.Width-5, this.Height-4) });
            e.Graphics.FillPolygon(new SolidBrush(Color.White), new Point[] { new Point(this.Width-26, this.Height-8), new Point(this.Width-21, this.Height-8), new Point(this.Width-25, this.Height-4) });            
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {            
            // Handle rotation adjustment button clicks.
            if( e.X >= this.Width-28 && e.X <= this.Width-2 && e.Y >= this.Height-14 && e.Y <= this.Height-2 )
            {
                if( e.X <= this.Width-16 )
                    rotation -= 90;
                else if( e.X >= this.Width-14 )
                    rotation += 90;
                if( rotation < 0 )
                    rotation += 360;
                rotation = rotation%360;
                dbx=-10;
                dby=-10;
            }
            else
                UpdateAngle(e.X, e.Y);                
            this.Refresh();        
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if( e.Button == MouseButtons.Left )
            {
                UpdateAngle(e.X, e.Y);                                        
                overButton = -1;                
            }
            else if( e.X >= this.Width-28 && e.X <= this.Width-16 && e.Y >= this.Height-14 && e.Y <= this.Height-2 )
                overButton = 1;
            else if( e.X >= this.Width-14 && e.X <= this.Width-2 && e.Y >= this.Height-14 && e.Y <= this.Height-2 )
                overButton = 2;
            else
                overButton = -1;
            this.Refresh();
        }

        private void UpdateAngle(int mx, int my)
        {
            // Store mouse coordinates.
            dbx = mx;
            dby = my;

            // Translate y coordinate input to GetAngle function to correct for ellipsoid distortion.
            double widthToHeightRatio =  (double)this.Width/(double)this.Height;                        
            int tmy;
            if( my == 0 )
                tmy = my;
            else if( my < this.Height/2 )
                tmy = (this.Height/2)-(int)(((this.Height/2)-my)*widthToHeightRatio);                
            else
                tmy = (this.Height/2)+(int)((double)(my-(this.Height/2))*widthToHeightRatio);
            
            // Retrieve updated angle based on rise over run.
            angle = (GetAngle(this.Width/2, this.Height/2, mx, tmy)-rotation)%360;                                    
        }

        private double GetAngle(int x1, int y1, int x2, int y2)
        {  
            double degrees;
           
            // Avoid divide by zero run values.
            if( x2-x1 == 0 )
            {
                if( y2 > y1 )
                    degrees = 90;
                else
                    degrees = 270;
            }
            else
            {
                // Calculate angle from offset.
                double riseoverrun = (double)(y2-y1)/(double)(x2-x1);
                double radians = Math.Atan( riseoverrun );
                degrees = radians * ((double)180/Math.PI);
                
                // Handle quadrant specific transformations.       
                if( (x2-x1) < 0 || (y2-y1) < 0 )
                    degrees += 180;
                if( (x2-x1) > 0 && (y2-y1) < 0 )
                    degrees -= 180;
                if( degrees < 0 )
                    degrees += 360;
            }
            return degrees;
        }
    }

    public class AngleEditorTestControl : System.Windows.Forms.UserControl
    {
        private double int_angle;

        [BrowsableAttribute(true)]
        [EditorAttribute(typeof(AngleEditor), typeof(System.Drawing.Design.UITypeEditor))]        
        public double Angle
        {
            get
            { return int_angle; }
            set
            { int_angle = value; }
        }        

        public AngleEditorTestControl()
        {
            int_angle = 90;
            this.Size = new Size(190, 42);
            this.BackColor = Color.Beige;			
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if( this.DesignMode )
            {
                e.Graphics.DrawString("Use the Properties Window to access", new Font("Arial", 8), new SolidBrush(Color.Black), 3,2);
                e.Graphics.DrawString("the AngleEditor UITypeEditor by", new Font("Arial", 8), new SolidBrush(Color.Black), 3,14);
                e.Graphics.DrawString("configuring the \"Angle\" property.", new Font("Arial", 8), new SolidBrush(Color.Black), 3,26);
            }
            else
                e.Graphics.DrawString("This example requires design mode.", new Font("Arial", 8), new SolidBrush(Color.Black), 3,2);
        }
    }
}
//</Snippet1>
