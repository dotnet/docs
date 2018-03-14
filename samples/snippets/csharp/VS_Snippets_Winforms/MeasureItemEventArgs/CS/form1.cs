using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ListBoxOwnerDrawSnippet
{
   //<Snippet1>
   public class Form1 : System.Windows.Forms.Form
   {
      private System.Windows.Forms.ListBox listBox1;
      private System.ComponentModel.Container components = null;


      protected override void Dispose(bool disposing)
      {
         if( disposing )
         {
            if ( components != null ) 
               components.Dispose();

            if ( foreColorBrush != null )
               foreColorBrush.Dispose();
         }
         base.Dispose(disposing);
      }

		#region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.listBox1 = new System.Windows.Forms.ListBox();
         this.SuspendLayout();
         // 
         // listBox1
         // 
         this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
         this.listBox1.Location = new System.Drawing.Point(16, 48);
         this.listBox1.Name = "listBox1";
         this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
         this.listBox1.Size = new System.Drawing.Size(256, 134);
         this.listBox1.TabIndex = 0;
         this.listBox1.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.listBox1_MeasureItem);
         this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.listBox1});
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }
		#endregion

      [STAThread]
      static void Main() 
      {
         Application.Run(new Form1());
      }

      private void listBox1_MeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
      {
         Font font = ((ListBoxFontItem)listBox1.Items[e.Index]).Font;
         SizeF stringSize = e.Graphics.MeasureString(font.Name, font);

         // Set the height and width of the item
         e.ItemHeight = (int)stringSize.Height;
         e.ItemWidth = (int)stringSize.Width;
      }

      // For efficiency, cache the brush to use for drawing.
      private SolidBrush foreColorBrush;

      private void listBox1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
      {
         Brush brush;

         // Create the brush using the ForeColor specified by the DrawItemEventArgs
         if ( foreColorBrush == null )
            foreColorBrush = new SolidBrush(e.ForeColor);
         else if ( foreColorBrush.Color != e.ForeColor )
         {
            // The control's ForeColor has changed, so dispose of the cached brush and
            // create a new one.
            foreColorBrush.Dispose();
            foreColorBrush = new SolidBrush(e.ForeColor);
         }

         // Select the appropriate brush depending on if the item is selected.
         // Since State can be a combinateion (bit-flag) of enum values, you can't use
         // "==" to compare them.
         if ( (e.State & DrawItemState.Selected) == DrawItemState.Selected )
            brush = SystemBrushes.HighlightText;
         else
            brush = foreColorBrush;

         // Perform the painting.
         Font font = ((ListBoxFontItem)listBox1.Items[e.Index]).Font;
         e.DrawBackground();
         e.Graphics.DrawString(font.Name, font, brush, e.Bounds);
         e.DrawFocusRectangle();
      }

      /// <summary>
      ///  A wrapper class for use with storing Fonts in a ListBox.  Since ListBox uses the
      ///  ToString() of its items for the text it displays, this class is needed to return
      ///  the name of the font, rather than its ToString() value.
      /// </summary>
      public class ListBoxFontItem 
      {
         public Font Font;

         public ListBoxFontItem(Font f) 
         {
            Font = f;
         }

         public override string ToString() 
         {
            return Font.Name;
         }
      }
   }
   //</Snippet1>
}
