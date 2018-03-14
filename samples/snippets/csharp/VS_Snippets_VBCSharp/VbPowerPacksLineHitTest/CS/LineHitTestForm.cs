using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksLineHitTestCS
{
    public partial class LineHitTestForm : Form
    {
        public LineHitTestForm()
        {
            InitializeComponent();
        }

        // <Snippet1>
        private void LineHitTestForm_PreviewKeyDown(object sender, 
            System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                int px;
                int py;
                bool hit;
                string result;
                px = LineHitTestForm.MousePosition.X;
                py = LineHitTestForm.MousePosition.Y;
                hit = lineShape1.HitTest(px, py);
                result = hit.ToString();
                MessageBox.Show(result);
            }
        }
        // </Snippet1>
    }
}
