using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ExtractAssociatedIcon
{
    public class Form1 : Form
    {
        public Form1()
        {
            ExtractAssociatedIconEx();
        }

        // <snippet1>
        ListView listView1;
        ImageList imageList1;

        public void ExtractAssociatedIconEx()
        {
            // Initialize the ListView, ImageList and Form.
            listView1 = new ListView();
            imageList1 = new ImageList();
            listView1.Location = new Point(37, 12);
            listView1.Size = new Size(151, 262);
            listView1.SmallImageList = imageList1;
            listView1.View = View.SmallIcon;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.listView1);
            this.Text = "Form1";

            // Get the c:\ directory.
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\");
            
            ListViewItem item;
            listView1.BeginUpdate();

            // For each file in the c:\ directory, create a ListViewItem
            // and set the icon to the icon extracted from the file.
            foreach (System.IO.FileInfo file in dir.GetFiles())
            {
                // Set a default icon for the file.
                Icon iconForFile = SystemIcons.WinLogo;

                item = new ListViewItem(file.Name, 1);
                iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
                
                // Check to see if the image collection contains an image
                // for this extension, using the extension as a key.
                if (!imageList1.Images.ContainsKey(file.Extension))
                {
                    // If not, add the image to the image list.
                    iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(file.FullName);
                    imageList1.Images.Add(file.Extension, iconForFile);
                }
                item.ImageKey = file.Extension;
                listView1.Items.Add(item);
            }
            listView1.EndUpdate();
        }
        // </snippet1>

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}