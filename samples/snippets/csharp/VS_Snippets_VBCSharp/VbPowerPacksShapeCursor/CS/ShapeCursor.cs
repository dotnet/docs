using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbPowerPacksShapeCursorCS
{
    public partial class ShapeCursor : Form
    {
        public ShapeCursor()
        {
            InitializeComponent();
        }
        // <Snippet1>
        private void ShapeCursor_Load(object sender, EventArgs e)
        {
            rectangleShape1.Cursor = Cursors.Hand;
        }
        // </Snippet1>
    }
}
