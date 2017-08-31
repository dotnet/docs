using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeContainerCS
{
    public partial class ShapeContainerForm : Form
    {
        public ShapeContainerForm()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void form1_Load(System.Object sender, System.EventArgs e)
        {
            OvalShape NewOval = new OvalShape();
            int i;
            bool found = false;
            // Loop through the Controls collection.
            for (i = 0; i < this.Controls.Count; i++)
            {
                // If a ShapeContainer is found, make it the parent.
                if (this.Controls[i] is ShapeContainer)
                {
                    NewOval.Parent = ((ShapeContainer)this.Controls[i]);
                    found = true;
                    break;
                }
            }
            // If no ShapeContainer is found, create one and set the parents.
            if (found == false)
            {
                ShapeContainer sc = new ShapeContainer();
                sc.Parent = this;
                NewOval.Parent = sc;
            }
            NewOval.Size = new Size(200, 300);
        }
        // </Snippet1>
    }
}
