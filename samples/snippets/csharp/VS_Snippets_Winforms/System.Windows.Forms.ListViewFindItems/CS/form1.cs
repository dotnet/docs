#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace ListViewFindItemWithTextHowTo
{
    class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //InitializeTextSearchListView();
            InitializeLocationSearchListView();
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "Form1";
            this.Text = "Form1";

        }

        #endregion

        //<snippet1>
        private ListView textListView = new ListView();
        private TextBox searchBox = new TextBox();
        private void InitializeTextSearchListView()
        {
            searchBox.Location = new Point(10, 60);
            textListView.Scrollable = true;
            textListView.Width = 80;
            textListView.Height = 50;

            // Set the View to list to use the FindItemWithText method.
            textListView.View = View.List;

            // Populate the ListViewWithItems
            textListView.Items.AddRange(new ListViewItem[]{ 
                new ListViewItem("Amy Alberts"), 
                new ListViewItem("Amy Recker"), 
                new ListViewItem("Erin Hagens"), 
                new ListViewItem("Barry Johnson"), 
                new ListViewItem("Jay Hamlin"), 
                new ListViewItem("Brian Valentine"), 
                new ListViewItem("Brian Welker"), 
                new ListViewItem("Daniel Weisman") });

            // Handle the TextChanged to get the text for our search.
            searchBox.TextChanged += new EventHandler(searchBox_TextChanged);

            // Add the controls to the form.
            this.Controls.Add(textListView);
            this.Controls.Add(searchBox);

        }

        //<snippet11>
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            // Call FindItemWithText with the contents of the textbox.
            ListViewItem foundItem =
                textListView.FindItemWithText(searchBox.Text, false, 0, true);
            if (foundItem != null)
            {
                textListView.TopItem = foundItem;

            }
        }
        //</snippet11>
        //</snippet1>

        //<snippet2>
        ListView iconListView = new ListView();
        TextBox previousItemBox = new TextBox();

        private void InitializeLocationSearchListView()
        {
            previousItemBox.Location = new Point(150, 20);

            // Create an image list for the icon ListView.
            iconListView.LargeImageList = new ImageList();
            iconListView.Height = 400;
            
            // Add an image to the ListView large icon list.
            iconListView.LargeImageList.Images.Add(
                new Bitmap(typeof(Control), "Edit.bmp"));

            // Set the view to large icon and add some items with the image
            // in the image list.
            iconListView.View = View.LargeIcon;
            iconListView.Items.AddRange(new ListViewItem[]{
                new ListViewItem("Amy Alberts", 0), 
                new ListViewItem("Amy Recker", 0), 
                new ListViewItem("Erin Hagens", 0), 
                new ListViewItem("Barry Johnson", 0), 
                new ListViewItem("Jay Hamlin", 0), 
                new ListViewItem("Brian Valentine", 0), 
                new ListViewItem("Brian Welker", 0), 
                new ListViewItem("Daniel Weisman", 0) });
            this.Controls.Add(iconListView);
            this.Controls.Add(previousItemBox);

            // Handle the MouseDown event to capture user input.
           iconListView.MouseDown +=
               new MouseEventHandler(iconListView_MouseDown);
            //iconListView.MouseWheel += new MouseEventHandler(iconListView_MouseWheel);   
        }

        //<snippet21>
        void iconListView_MouseDown(object sender, MouseEventArgs e)
        {
            
            // Find the an item above where the user clicked.
            ListViewItem foundItem =
                iconListView.FindNearestItem(SearchDirectionHint.Up, e.X, e.Y);

            // Display the results in a textbox..
            if (foundItem != null)
                previousItemBox.Text = foundItem.Text;
            else
                previousItemBox.Text = "No item found";
        }
        //</snippet21>
        //</snippet2>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }






    }

}