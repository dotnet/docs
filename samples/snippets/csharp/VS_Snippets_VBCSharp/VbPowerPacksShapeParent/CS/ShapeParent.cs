using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeParentCS
{
    public partial class ShapeParent : Form
    {
        public ShapeParent()
        {
            InitializeComponent();
        }

        private void ShapeParent_Load(object sender, EventArgs e)
        {
            // <Snippet1>
            OvalShape NewOval = new OvalShape();
            int i;
            bool found = false;
            // Loop through the Controls collection.
            for (i = 0; i < this.Controls.Count; i++)
            {
                // If a ShapeContainer is found, make it the parent.
                if (this.Controls[i] is ShapeContainer)
                {
                    NewOval.Parent = ((ShapeContainer)Controls[i]);
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
            found = true;
            // </Snippet1>
        }
    }
}
