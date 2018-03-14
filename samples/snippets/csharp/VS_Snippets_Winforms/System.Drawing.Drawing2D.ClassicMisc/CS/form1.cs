using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace System.Drawing.Drawing2D.ClassicMiscCS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Size = new System.Drawing.Size(300,300);
			this.Text = "Form1";
		}
		#endregion
        // Snippet for: M:System.Drawing.Drawing2D.AdjustableArrowCap.#ctor(System.Single,System.Single)
        // <snippet1>
        public void ConstructAdjArrowCap1(PaintEventArgs e)
        {     
            AdjustableArrowCap myArrow = new AdjustableArrowCap(6, 6);
            Pen capPen = new Pen(Color.Black);
            capPen.CustomStartCap = myArrow;
            capPen.CustomEndCap = myArrow;
            e.Graphics.DrawLine(capPen, 50, 50, 200, 50);
        }
        // </snippet1>


        // Snippet for: M:System.Drawing.Drawing2D.AdjustableArrowCap.#ctor(System.Single,System.Single,System.Boolean)
        // <snippet2>
        public void ConstructAdjArrowCap2(PaintEventArgs e)
        {     
            AdjustableArrowCap myArrow = new AdjustableArrowCap(6, 6, false);
            Pen capPen = new Pen(Color.Black);
            capPen.CustomStartCap = myArrow;
            capPen.CustomEndCap = myArrow;
            e.Graphics.DrawLine(capPen, 50, 50, 200, 50);
        }
        // </snippet2>


        // Snippet for: M:System.Drawing.Drawing2D.Blend.#ctor
        // <snippet3>
        public void BlendConstExample(PaintEventArgs e)
        {
                     
            //Draw ellipse using Blend.
            Point startPoint2 = new Point(20, 110);
            Point endPoint2 = new Point(140, 110);
            float[] myFactors = {.2f,.4f,.8f,.8f,.4f,.2f};
            float[] myPositions = {0.0f,.2f,.4f,.6f,.8f,1.0f};
            Blend myBlend = new Blend();
            myBlend.Factors = myFactors;
            myBlend.Positions = myPositions;
            LinearGradientBrush lgBrush2 = new LinearGradientBrush(
                startPoint2,
                endPoint2,
                Color.Blue,
                Color.Red);
            lgBrush2.Blend = myBlend;
            Rectangle ellipseRect2 = new Rectangle(20, 110, 120, 80);
            e.Graphics.FillEllipse(lgBrush2, ellipseRect2);
                     
            // End example.
        }
        // </snippet3>


        // Snippet for: M:System.Drawing.Drawing2D.ColorBlend.#ctor
        // <snippet4>
        protected override void OnPaint(PaintEventArgs e)
        {
                     
            //Draw ellipse using ColorBlend.
            Point startPoint2 = new Point(20, 110);
            Point endPoint2 = new Point(140, 110);
            Color[] myColors = {Color.Green,
                                   Color.Yellow,
                                   Color.Yellow,
                                   Color.Blue,
                                   Color.Red,
                                   Color.Red};
            float[] myPositions = {0.0f,.20f,.40f,.60f,.80f,1.0f};
            ColorBlend myBlend = new ColorBlend();
            myBlend.Colors = myColors;
            myBlend.Positions = myPositions;
            LinearGradientBrush lgBrush2 = new LinearGradientBrush(startPoint2,
                endPoint2,
                Color.Green,
                Color.Red);
            lgBrush2.InterpolationColors = myBlend;
            Rectangle ellipseRect2 = new Rectangle(20, 110, 120, 80);
            e.Graphics.FillEllipse(lgBrush2, ellipseRect2);
        }
        // </snippet4>

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
