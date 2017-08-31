using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace VbPowerPacksShapeSuspendPaintCS
{
    public partial class ShapeSuspendPaint : Form
    {
        public ShapeSuspendPaint()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void ovalShape1_Click(System.Object sender, System.EventArgs e)
        {
            // Suspend painting.
            ovalShape1.SuspendPaint();
            // Set some properties.
            ovalShape1.BackStyle = BackStyle.Opaque;
            ovalShape1.BackColor = Color.Blue;
            ovalShape1.FillStyle = FillStyle.Plaid;
            ovalShape1.FillColor = Color.Red;
            // Resume painting and execute any pending requests.
            ovalShape1.ResumePaint(true);
        }
        // </Snippet1>
    }
}
