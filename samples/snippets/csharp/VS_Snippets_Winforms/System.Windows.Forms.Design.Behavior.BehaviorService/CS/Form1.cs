//<snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;

namespace BehaviorServiceSample
{
    class Form1 : Form
    {
        private UserControl1 userControl;

        public Form1()
        {
            InitializeComponent();
        }

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.userControl = new BehaviorServiceSample.UserControl1();
            this.SuspendLayout();

            this.userControl.Location = new System.Drawing.Point(12, 13);
            this.userControl.Name = "userControl";
            this.userControl.Size = new System.Drawing.Size(143, 110);
            this.userControl.TabIndex = 0;
            
            this.ClientSize = new System.Drawing.Size(184, 153);
            this.Controls.Add(this.userControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }

    [Designer(typeof(MyDesigner))]
    public class UserControl1 : UserControl
    {
        private System.ComponentModel.IContainer components = null;

        public UserControl1()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(170, 156);
        }
    }

//<snippet2>
    class MyDesigner : ControlDesigner
    {
        private Adorner myAdorner;

        protected override void Dispose(bool disposing)
        {
            if (disposing && myAdorner != null)
            {
                BehaviorService b = BehaviorService;
                if (b != null)
                {
                    b.Adorners.Remove(myAdorner);
                }
            }
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            // Add the custom set of glyphs using the BehaviorService. 
            // Glyphs live on adornders.
//<snippet4>
//<snippet3>
            myAdorner = new Adorner();
            BehaviorService.Adorners.Add(myAdorner);
//</snippet3>
            myAdorner.Glyphs.Add(new MyGlyph(BehaviorService, Control));
//</snippet4>
        }
    }
//</snippet2>

//<snippet5>
    class MyGlyph : Glyph
    {
        Control control;
        BehaviorService behaviorSvc;

//<snippet7>
        public MyGlyph(BehaviorService behaviorSvc, Control control) : 
            base(new MyBehavior())
        {
            this.behaviorSvc = behaviorSvc;
            this.control = control;
        }
//</snippet7>

//<snippet8>
        public override Rectangle Bounds
        {
            get
            {
                // Create a glyph that is 10x10 and sitting
                // in the middle of the control.  Glyph coordinates
                // are in adorner window coordinates, so we must map
                // using the behavior service.
                Point edge = behaviorSvc.ControlToAdornerWindow(control);
                Size size = control.Size;
                Point center = new Point(edge.X + (size.Width / 2), 
                    edge.Y + (size.Height / 2));

                Rectangle bounds = new Rectangle(
                    center.X - 5,
                    center.Y - 5,
                    10,
                    10);

                return bounds;
            }
        }
//</snippet8>

//<snippet9>
        public override Cursor GetHitTest(Point p)
        {
            // GetHitTest is called to see if the point is
            // within this glyph.  This gives us a chance to decide
            // what cursor to show.  Returning null from here means
            // the mouse pointer is not currently inside of the glyph.
            // Returning a valid cursor here indicates the pointer is
            // inside the glyph, and also enables our Behavior property
            // as the active behavior.
            if (Bounds.Contains(p))
            {
                return Cursors.Hand;
            }

            return null;
        }
//</snippet9>

//<snippet10>
        public override void Paint(PaintEventArgs pe)
        {
            // Draw our glyph. It is simply a blue ellipse.
            pe.Graphics.FillEllipse(Brushes.Blue, Bounds);
        }
//</snippet10>

        // By providing our own behavior we can do something interesting
        // when the user clicks or manipulates our glyph.
//<snippet6>
        class MyBehavior : Behavior
        {
            public override bool OnMouseUp(Glyph g, MouseButtons button)
            {
                MessageBox.Show("Hey, you clicked the mouse here");
                return true; // indicating we processed this event.
            }
        }
//</snippet6>
    }
//</snippet5>
}
//</snippet1>
