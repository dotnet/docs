using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksSimpleShapeHitTestCS
{
    public partial class SimpleShapeHitTest : Form
    {
        public SimpleShapeHitTest()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void form1_PreviewKeyDown(object sender, 
            System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                int px;
                int py;
                bool hit;
                string result;
                px = MousePosition.X;
                py = MousePosition.Y;
                hit = ovalShape1.HitTest(px, py);
                result = hit.ToString();
                MessageBox.Show(result);
            }
        }
        // </Snippet1>
    }
}
