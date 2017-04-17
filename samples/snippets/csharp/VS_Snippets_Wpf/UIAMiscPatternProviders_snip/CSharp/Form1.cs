using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ElementProvider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CustomGrid grid = new CustomGrid(this, new Rectangle(5, 5, 50, 200));
            this.Controls.Add(grid);
            
        }
    }
}

