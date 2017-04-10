using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ListBoxFeedback
{
    public class Form1 : Form
    {
        //<snippet1>
        private ListBox ListBox1 = new ListBox();
        private void InitializeListBox()
        {
            ListBox1.Items.AddRange(new Object[] 
                { "Red Item", "Orange Item", "Purple Item" });
            ListBox1.Location = new System.Drawing.Point(81, 69);
            ListBox1.Size = new System.Drawing.Size(120, 95);
            ListBox1.DrawMode = DrawMode.OwnerDrawFixed;
            ListBox1.DrawItem += new DrawItemEventHandler(ListBox1_DrawItem);
            Controls.Add(ListBox1);
        }

        private void ListBox1_DrawItem(object sender, 
            System.Windows.Forms.DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Define the default color of the brush as black.
            Brush myBrush = Brushes.Black;

            // Determine the color of the brush to draw each item based 
            // on the index of the item to draw.
            switch (e.Index)
            {
                case 0:
                    myBrush = Brushes.Red;
                    break;
                case 1:
                    myBrush = Brushes.Orange;
                    break;
                case 2:
                    myBrush = Brushes.Purple;
                    break;
            }

            // Draw the current item text based on the current Font 
            // and the custom brush settings.
            e.Graphics.DrawString(ListBox1.Items[e.Index].ToString(), 
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }
        //</snippet1>

        public Form1()
        {
            InitializeListBox();
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}