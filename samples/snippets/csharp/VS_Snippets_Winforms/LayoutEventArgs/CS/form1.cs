using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

//<Snippet1>
public class Form1 : System.Windows.Forms.Form
{
   private System.Windows.Forms.TextBox textBox1;
   private System.Windows.Forms.Label label1;
   private System.Windows.Forms.Button layoutButton;
   private System.ComponentModel.Container components = null;

   public Form1()
   {
      InitializeComponent();
   }

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

   private void InitializeComponent()
   {
      this.layoutButton = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // layoutButton
      // 
      this.layoutButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.layoutButton.Location = new System.Drawing.Point(72, 88);
      this.layoutButton.Name = "layoutButton";
      this.layoutButton.Size = new System.Drawing.Size(150, 23);
      this.layoutButton.TabIndex = 0;
      this.layoutButton.Text = "Hello";
      // 
      // textBox1
      // 
      this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
         | System.Windows.Forms.AnchorStyles.Right);
      this.textBox1.Location = new System.Drawing.Point(24, 40);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(248, 20);
      this.textBox1.TabIndex = 1;
      this.textBox1.Text = "Hello";
      this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(24, 16);
      this.label1.Name = "label1";
      this.label1.TabIndex = 2;
      this.label1.Text = "Button\'s Text:";
      // 
      // Form1
      // 
      this.ClientSize = new System.Drawing.Size(292, 129);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                   this.label1,
                                                                   this.textBox1,
                                                                   this.layoutButton});
      this.Name = "Form1";
      this.Text = "Layout Sample";
      this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Form1_Layout);
      this.ResumeLayout(false);

   }

   [STAThread]
   static void Main() 
   {
      Application.Run(new Form1());
   }
   
   // This method ensures that the form's width is the preferred size of 300 pixels
   // or the size of the button plus 50 pixels, whichever amount is less.
   private void Form1_Layout(object sender, System.Windows.Forms.LayoutEventArgs e)
   {
      // This event is raised once at startup with the AffectedControl
      // and AffectedProperty properties on the LayoutEventArgs as null. 
      // The event provides size preferences for that case.
      if ((e.AffectedControl != null) && (e.AffectedProperty != null))
      {
         // Ensure that the affected property is the Bounds property
         // of the form.
         if (e.AffectedProperty.ToString() == "Bounds") 
         {
            // If layoutButton's width plus a padding of 50 pixels is greater than the preferred 
            // size of 300 pixels, increase the form's width.
            if ((this.layoutButton.Width + 50) > 300) 
            {
               this.Width = this.layoutButton.Width + 50;
            }
               // If not, keep the form's width at 300 pixels.
            else 
            {
               this.Width = 300;
            }

            // Center layoutButton on the form.
            this.layoutButton.Left = (this.ClientSize.Width - this.layoutButton.Width) / 2;
         }
      }
   }

   // This method sets the Text property of layoutButton to the Text property
   // of textBox1.  If the new text plus a padding of 20 pixels is larger than 
   // the preferred size of 150 pixels, increase layoutButton's Width property.
   private void textBox1_TextChanged(object sender, System.EventArgs e)
   {
      // Set the Text property of layoutButton.
      this.layoutButton.Text = this.textBox1.Text;
      // Get the width of the text using the proper font.
      int textWidth = (int)this.CreateGraphics().MeasureString(layoutButton.Text, layoutButton.Font).Width;

      // If the width of the text plus a padding of 20 pixels is greater than the preferred size of
      // 150 pixels, increase layoutButton's width.
      if ((textWidth + 20) > 150)
      {
         // Setting the size property on any control raises 
         // the Layout event for its container.
         this.layoutButton.Width = textWidth + 20;
      }
         // If not, keep layoutButton's width at 150 pixels.
      else 
      {
         this.layoutButton.Width = 150;
      }
   }
}
//</Snippet1>

