//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PerformanceLibrary
{
   public class SomeForm : Form
   {
      Button start, reset;

      public SomeForm()
      {
         start = new Button();
         reset = new Button();
         start.Click += new EventHandler(start_Click);
         reset.Click += new EventHandler(reset_Click);
         Controls.Add(start);
         Controls.Add(reset);
      }

      // This method violates the rule.
      void start_Click(object sender, EventArgs e)
      {
         Size controlSize = ((Control)sender).Size;
         RightToLeft rightToLeftValue = ((Control)sender).RightToLeft;
         Control parent = (Control)sender;
      }

      // This method satisfies the rule.
      void reset_Click(object sender, EventArgs e)
      {
         Control someControl = (Control)sender;
         Size controlSize = someControl.Size;
         RightToLeft rightToLeftValue = someControl.RightToLeft;
         Control parent = someControl;
      }
   }
}
//</Snippet1>
