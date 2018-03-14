#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace ListViewItemMembers
{
    public class Form1 : Form
    {
        
         
        public Form1()
        {
            InitializeComponent();
            //InitializeFindItemListView();
            //InitializeItemsWithToolTips();
            //InitializeIndentedListViewItems();
             InitializeListView1();
            this.Load += new EventHandler(Form1_Load);


        }
       
        private void InitializeComponent()
        {
           
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(292, 266);
           
            this.Name = "Form1";
            this.ResumeLayout(false);

        }
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

      

        // The following example demonstrates how to use the ShowItemToolTip and ToolTipText 
        // properties. To run this example, paste the code into a Windows Form and call
        // InitializeItemsWithToolTips from the form's constructor or Load event handling
        // method.

        //<snippet4>

        // Declare the ListView.
        private ListView ListViewWithToolTips;
        private void InitializeItemsWithToolTips()
        {

            // Construct and set the View property of the ListView.
            ListViewWithToolTips = new ListView();
            ListViewWithToolTips.Width = 200;
            ListViewWithToolTips.View = View.List;

            // Show item tooltips.
            ListViewWithToolTips.ShowItemToolTips = true;
            
            // Create items with a tooltip.
            ListViewItem item1WithToolTip = new ListViewItem("Item with a tooltip");
            item1WithToolTip.ToolTipText = "This is the item tooltip.";
            ListViewItem item2WithToolTip = new ListViewItem("Second item with a tooltip");
            item2WithToolTip.ToolTipText = "A different tooltip for this item.";

            // Create an item without a tooltip.
            ListViewItem itemWithoutToolTip = new ListViewItem("Item without tooltip.");

            // Add the items to the ListView.
            ListViewWithToolTips.Items.AddRange(new ListViewItem[]{item1WithToolTip, 
                item2WithToolTip, itemWithoutToolTip} );

            // Add the ListView to the form.
            this.Controls.Add(ListViewWithToolTips);
            this.Controls.Add(button1);
        }
        //</snippet4>

        //<snippet2>
        ListView indentedListView;

        private void InitializeIndentedListViewItems()
        {
            indentedListView = new ListView();
            indentedListView.Width = 200;

            // View must be set to Details to use IndentCount.
            indentedListView.View = View.Details;
            indentedListView.Columns.Add("Indented Items", 150);
           
            // Create an image list and add an image.
            ImageList list = new ImageList();
            list.Images.Add(new Bitmap(typeof(Button), "Button.bmp"));

            // SmallImageList must be set when using IndentCount.
            indentedListView.SmallImageList = list;

            ListViewItem item1 = new ListViewItem("Click", 0);
            item1.IndentCount = 1;
            ListViewItem item2 = new ListViewItem("OK", 0);
            item2.IndentCount = 2;
            ListViewItem item3 = new ListViewItem("Cancel", 0);
            item3.IndentCount = 3;
            indentedListView.Items.AddRange(new ListViewItem[] { item1, item2, item3 });

            // Add the controls to the form.
            this.Controls.Add(indentedListView);

        }
        //</snippet2>

        // Declare the ListView and the Label.
        private ListView findListView;
        private Label label1;

        private void InitializeFindItemListView()
        {
            findListView = new ListView();
            label1 = new Label();
            label1.Location = new Point(200, 20);

            // View must be set to SmallIcon to use the FindNearestItem method.
            findListView.View = View.SmallIcon;

            // Create an image list and add items to the ListView with an image.
            ImageList list = new ImageList();
            list.Images.Add(new Bitmap(typeof(Button), "Button.bmp"));
            findListView.SmallImageList = list;
            findListView.Items.Add(new ListViewItem("Click", 0));
            findListView.Items.Add(new ListViewItem("OK", 0));
            findListView.Items.Add(new ListViewItem("Cancel", 0));

            // Add the controls to the form.
            this.Controls.Add(findListView);
            this.Controls.Add(label1);
            
            // Handle the MouseDown event.
            findListView.MouseDown += new MouseEventHandler(findListView_MouseDown);
        }

        // The following example demonstrates how to use the FindNearestItem
        // method.  To run this example, paste the following code into
        // a Windows Form that contains a ListView named findListView. Ensure
        // the View property is set to an icon view, and that the ListView 
        // is populated with items. Associate the MouseDown event of findListView
        // with the findListView_MouseDown method in this example.

        // <snippet1>
        void findListView_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = findListView.HitTest(e.X, e.Y);
            ListViewItem foundItem = null;
            if (info.Item != null)
                foundItem = info.Item.FindNearestItem(SearchDirectionHint.Up);
            if (foundItem != null)
                label1.Text = "Previous Item: " + foundItem.Text;

            else
                label1.Text = "No item found";
        }
        // </snippet1>

        // The following code example demonstrates how to use the Position property. To run
        // this example paste the code into a Windows Form and call InitializePositionedListView
        // from the form's constructor or Load-event handling method. Click the button to see
        // the Position property of moveItem change.

        //<snippet3>
        private ListView positionListView;
        private ListViewItem moveItem;
        private Button button1;

        private void InitializePositionedListViewItems()
        {
            // Set some basic properties on the ListView and button.
            positionListView = new ListView();
            positionListView.Height = 200;
            button1 = new Button();
            button1.Location = new Point(160, 30);
            button1.AutoSize = true;
            button1.Text = "Click to reposition";
            button1.Click += new System.EventHandler(button1_Click);

            // View must be set to icon view to use the Position property.
            positionListView.View = View.LargeIcon;
          
            // Create the items and add them to the ListView.
            ListViewItem item1 = new ListViewItem("Click");
            ListViewItem item2 = new ListViewItem("OK");
            moveItem = new ListViewItem("Move");
            positionListView.Items.AddRange(new ListViewItem[] 
                { item1, item2, moveItem });

            // Add the controls to the form.
            this.Controls.Add(positionListView);
            this.Controls.Add(button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            moveItem.Position = new Point(30, 30);
        }
        //</snippet3>
        

        // The following code example demonstrates how to use the GetSubItemAt
        // method.  To run this code, paste it into a Windows Form and call 
        // InitializeListView1 from the form's constructor or Load event-handling
        // method.

        //<snippet5>
        private ListView listView1;

        private void  InitializeListView1(){
            listView1 = new ListView();
            
            // Set the view to details to show subitems.
            listView1.View = View.Details;
           
            // Add some columns and set the width.
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Number");
            listView1.Columns.Add("Description");
            listView1.Width = 175;

            // Create some items and subitems; add the to the ListView.
            ListViewItem item1 = new ListViewItem("Widget");
            item1.SubItems.Add(new ListViewItem.ListViewSubItem(item1, "14"));
            item1.SubItems.Add(new ListViewItem.ListViewSubItem(item1, 
                "A description of Widget"));
            ListViewItem item2 = new ListViewItem("Bracket");
            item2.SubItems.Add(new ListViewItem.ListViewSubItem(item2, "8"));
            listView1.Items.Add(item1);
            listView1.Items.Add(item2);
            
            // Add the ListView to the form.
            this.Controls.Add(listView1);
            listView1.MouseDown += new MouseEventHandler(listView1_MouseDown);
        }

        void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the item at the mouse pointer.
            ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);

            ListViewItem.ListViewSubItem subItem = null;
            
            // Get the subitem 120 pixels to the right.
            if (info != null)
                if (info.Item != null)
                    subItem = info.Item.GetSubItemAt(e.X + 120, e.Y);
            
            // Show the text of the subitem, if found.
            if (subItem != null)
                MessageBox.Show(subItem.Text);
        }
        //</snippet5>

        void Form1_Load(object sender, EventArgs e)
        {
            //InitializePositionedListViewItems();
        }






       
    }
}