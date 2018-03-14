//<Snippet1>
using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace GlobalizationLibrary
{
   public class DuplicateAccelerators : Form
   {
      [STAThread]
      public static void Main()
      {
         DuplicateAccelerators accelerators = new DuplicateAccelerators();
         Application.Run(accelerators);
      }

      private CheckBox checkBox1;
      private CheckBox checkBox2;

      public DuplicateAccelerators()
      {
         ResourceManager resources = 
            new ResourceManager(typeof(DuplicateAccelerators));

         checkBox1 = new CheckBox();
         checkBox1.Location = new Point(8, 16);
         // checkBox1.Text = "&checkBox1";
         checkBox1.Text = resources.GetString("checkBox1.Text");

         checkBox2 = new CheckBox();
         checkBox2.Location = new Point(8, 56);
         // checkBox2.Text = "&checkBox2";
         checkBox2.Text = resources.GetString("checkBox2.Text");

         Controls.Add(checkBox1);
         Controls.Add(checkBox2);
      }
   }
}
//</Snippet1>
