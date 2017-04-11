#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#endregion

namespace ListViewProperties
{
    class Form1 : Form
    {
    
        public Form1()
        {
            
            //InitializeHotTrackingListView();
            //InitializeListViewWithBackgroundImage();
            //InitializeFindNearestItemListView();
            //InitializeFindListView();
            InitializeListView1();
            listView1.Items.Add(new ListViewItem("One item"));
            listView1.Items.Add(new ListViewItem("two items"));
            listView1.MouseDown += new MouseEventHandler(HandleMouseDown);
            InitializeComponent();
            //InitializeResizingListView();
            
        }
        // The following code example demonstrates handling the ColumnWidthChanging event. It
        // also demonstrates the NewWidth and Cancel members.  To run this example paste the code
        // into a Windows Form. Call InitializeListView1 from the form's constructor or load-event
        // handling method. 

        //<snippet6>
        ListView listView1 = new ListView();
        private void InitializeListView1()
        {
			// Initialize a ListView in detail view and add some columns.
            listView1.View = View.Details;
            listView1.Width = 200;
            listView1.Columns.Add("Column1");
            listView1.Columns.Add("Column2");

			// Associate a method with the ColumnWidthChangingEvent.
            listView1.ColumnWidthChanging += 
                new ColumnWidthChangingEventHandler(listView1_ColumnWidthChanging);
            this.Controls.Add(listView1);
        }
       
		// Handle the ColumnWidthChangingEvent.
        private void listView1_ColumnWidthChanging(object sender,  
            ColumnWidthChangingEventArgs e)
        {
			// Check if the new width is too big or too small.
            if (e.NewWidth > 100 || e.NewWidth < 5)
            {
				// Cancel the event and inform the user if the new
				// width does not meet the criteria.
                MessageBox.Show("Column width is too large or too small");
		        e.Cancel = true;
            }
        }
        
    //</snippet6>

    #region snippet3
       
        //<snippet3>
		// Declare the ListView and Button for the example.
        ListView findListView = new ListView();
        Button findButton = new Button();

        private void InitializeFindListView()
        {
	    // Set up the location and event handling for the button.
            findButton.Click += new EventHandler(findButton_Click);
            findButton.Location = new Point(10, 10);
			
	    // Set up the location of the ListView and add some items.
	    findListView.Location = new Point(10, 30);
            findListView.Items.Add(new ListViewItem("angle bracket"));
            findListView.Items.Add(new ListViewItem("bracket holder"));
            findListView.Items.Add(new ListViewItem("bracket"));

            // Add the button and ListView to the form.
            this.Controls.Add(findButton);
            this.Controls.Add(findListView);
        }

		void findButton_Click(object sender, EventArgs e)
		{
	            // Call FindItemWithText, sending output to MessageBox.
		    ListViewItem item1 = findListView.FindItemWithText("brack");
			 if (item1 != null)
				 MessageBox.Show("Calling FindItemWithText passing 'brack': " 
                     + item1.ToString());
			 else
				 MessageBox.Show("Calling FindItemWithText passing 'brack': null");
		 }
		//</snippet3>
     
#endregion
		//This method is for testing purposes only.
		//void findButton_Click(object sender, EventArgs e)
		//{
		//    Console.WriteLine("findListView contains: ");
		//    foreach (ListViewItem item in findListView.Items)
		//        Console.WriteLine(item.ToString());
		//    ListViewItem item1 = findListView.FindItemWithText("brack");
		//    Console.WriteLine("Call FindItemWithText('brack')");
		//    if (item1 != null) 
		//        Console.WriteLine(item1.ToString());
		//    else Console.WriteLine("null");
		//    ListViewItem item2 = findListView.FindItemWithText("brack", true, 0);
		//    Console.WriteLine("Call FindItemWithText('brack', true, 0)");
		//    if (item2 != null) 
		//        Console.WriteLine(item2.ToString());
		//    else Console.WriteLine("null");
		//    ListViewItem item3 = findListView.FindItemWithText("brack", true, 0, false);
		//    Console.WriteLine("Call FindItemWithText('brack', true, 0, false)");
		//    if (item3 != null)
		//        Console.WriteLine(item3.ToString());
		//    else Console.WriteLine("null");
		//    ListViewItem item4 = findListView.FindItemWithText("brack", true, 0, true);
		//    Console.WriteLine("Call FindItemWithText('brack', true, 0, true)");
		//    if (item4 != null)
		//        Console.WriteLine(item4.ToString());
		//    else Console.WriteLine("null");
		//}
 

        #region snippet2
        // The following code example demonstrates a ListView with hot tracking enabled.
        // To run this example paste the following code into a Windows Form and and call
        // the InitializeHotTrackingListView method from the form's constructor or load-event
        // handling method.
//<snippet2>
        private ImageList list = new ImageList();
        private ListView hotTrackinglistView = new ListView();

        private void InitializeHotTrackingListView(){
            list.Images.Add(new Bitmap(typeof(Button), "Button.bmp"));
            hotTrackinglistView.SmallImageList = list;
            hotTrackinglistView.Location = new Point(20, 20);
            hotTrackinglistView.View = View.SmallIcon;
            ListViewItem listItem1 = new ListViewItem("Short", 0 );
            ListViewItem listItem2 = new ListViewItem("Tiny", 0);
            hotTrackinglistView.Items.Add(listItem1);
            hotTrackinglistView.Items.Add(listItem2);
            hotTrackinglistView.HotTracking = true;
            this.Controls.Add(hotTrackinglistView);
        }
//</snippet2>
        #endregion

        #region snippet1
        // The following code example demonstrates initializing a ListView in detail view and
        // automatically resizing the columns using the AutoResizeColumn method. 
        // To run this example, paste this code into a  Windows Form and call
        // the InitializeResizingListView method from the form's constructor or load-event
        // handling method.
        //<snippet1>
        private ListView resizingListView = new ListView();
        private Button button1 = new Button();

        private void InitializeResizingListView()
        {
            // Set location and text for button.
            button1.Location = new Point(100, 15);
            button1.Text = "Resize";
            button1.Click += new EventHandler(button1_Click);

            // Set the ListView to details view.
            resizingListView.View = View.Details;

            //Set size, location and populate the ListView.
            resizingListView.Size = new Size(200, 100);
            resizingListView.Location = new Point(40, 40);
            resizingListView.Columns.Add("HeaderSize");
            resizingListView.Columns.Add("ColumnContent");
            ListViewItem listItem1 = new ListViewItem("Short");
            ListViewItem listItem2 = new ListViewItem("Tiny");
            listItem1.SubItems.Add(new ListViewItem.ListViewSubItem( 
                    listItem1, "Something longer"));
            listItem2.SubItems.Add(new ListViewItem.ListViewSubItem(
                listItem2, "Something even longer"));
            resizingListView.Items.Add(listItem1);
            resizingListView.Items.Add(listItem2);

            // Add the ListView and the Button to the form.
            this.Controls.Add(resizingListView);
            this.Controls.Add(button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resizingListView.AutoResizeColumn(0, 
                ColumnHeaderAutoResizeStyle.HeaderSize);
            resizingListView.AutoResizeColumn(1, 
                ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        //</snippet1>
        #endregion

    
        // The following code example demonstrates the use of the BackGroundImageLayout
        // To run this example, paste the following
        // code into a Windows Form and call the InitializeListViewWithBackgroundImage method
        // from the form's constructor or load-event handling method. You must have the STAThread
        // attribute applied to the Main method of your form.

        //<snippet4>
        private ListView imageListView = new ListView();
    
        private void InitializeListViewWithBackgroundImage()
        {
           
            imageListView.Location = new Point(40, 40);
            imageListView.BackgroundImageLayout = ImageLayout.Stretch;
            imageListView.Items.AddRange(new ListViewItem[]{ 
                    new ListViewItem("Yes"), new ListViewItem("No")});
            Bitmap bmp1 = new Bitmap(@"c:\FakePhoto.jpg");
            imageListView.BackgroundImage = new Bitmap(bmp1, new Size(30,40));
            this.Controls.Add(imageListView);

        }

        //</snippet4>
       
        #region snippet5
        // The following code example demonstrates the FindNearestItem method. 
        // To run this example, paste the code into a Windows Form and call the
        // InitializeFindNearestItemListView from the form's constructor or load-
        // event handling method. When the application is running, click the 
        // ListView to see the results of calling the FindNearestItem method.

        //<snippet5>
        private ListView findNearestItemListView = new ListView();

        private void InitializeFindNearestItemListView()
        {
            findNearestItemListView.Size = new Size(200, 100);
            Bitmap buttonImage = new Bitmap(typeof(Button), "Button.bmp");
            ImageList list = new ImageList();
            findNearestItemListView.LargeImageList = list;

            list.Images.Add(buttonImage);
            findNearestItemListView.Items.Add(new ListViewItem("Click", 0));
            findNearestItemListView.Items.Add(new ListViewItem("OK", 0));
            findNearestItemListView.Items.Add(new ListViewItem("Cancel", 0));
            findNearestItemListView.Items.Add(new ListViewItem("Exit", 0));
            findNearestItemListView.Items.Add(new ListViewItem("Help", 0));
            this.Controls.Add(findNearestItemListView);
            findNearestItemListView.MouseClick += 
                new MouseEventHandler(findNearestItemListView_MouseClick);

        }

        void findNearestItemListView_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem foundItem = 
                findNearestItemListView.FindNearestItem(SearchDirectionHint.Right, 
                new Point(e.X, e.Y));
            if (foundItem != null)
                MessageBox.Show(foundItem.Text);
            else
                MessageBox.Show("Did not find an item");
        }

        //</snippet5>
        #endregion snippet5

        [STAThread]
        public static void Main()
        {
		Application.EnableVisualStyles();
		Application.Run(new Form1());
        }

        private void InitializeComponent()
        {
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandleMouseDown);

        }

        // The following example demonstrates handling the ItemSelectionChanged event.

        //<snippet8>
        void listView1_ItemSelectionChanged(object sender, 
            ListViewItemSelectionChangedEventArgs e)
        {
           MessageBox.Show("Selection changed to " + e.Item.ToString());
        }
        //</snippet8>


        
        // The following example demonstrates using the HitTest method to determine
        // the location of a MouseDown in a ListView. To run this code paste it into
        // a Windows Form that contains a ListView named listView1 that is populated with
        // items.  Associate the MouseDown event for the form and listView1
        // the HandleMouseDown method in this example.
//<snippet7>
        void HandleMouseDown(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);
            MessageBox.Show(info.Location.ToString());
        }
//</snippet7>

//<snippet9>
      	private ListView resizingListView2 = new ListView();
        private Button resizeButton = new Button();

        private void InitializeResizingListView2()
        {
            // Set location and text for button.
            resizeButton.Location = new Point(100, 15);
            button1.Text = "Resize";
            button1.Click += new EventHandler(button1_Click);

            // Set the ListView to details view.
            resizingListView2.View = View.Details;

            //Set size, location and populate the ListView.
            resizingListView2.Size = new Size(200, 100);
            resizingListView2.Location = new Point(40, 40);
            resizingListView2.Columns.Add("HeaderSize");
            resizingListView2.Columns.Add("ColumnContent");
            ListViewItem listItem1 = new ListViewItem("Short");
            ListViewItem listItem2 = new ListViewItem("Tiny");
            listItem1.SubItems.Add(new ListViewItem.ListViewSubItem(
                    listItem1, "Something longer"));
            listItem2.SubItems.Add(new ListViewItem.ListViewSubItem(
                listItem2, "Something even longer"));
            resizingListView2.Items.Add(listItem1);
            resizingListView2.Items.Add(listItem2);

            // Add the ListView and the Button to the form.
            this.Controls.Add(resizingListView2);
            this.Controls.Add(resizeButton);
        }

        private void resizeButton_Click(object sender, EventArgs e)
        {
            resizingListView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
//</snippet9>

       
    }
}