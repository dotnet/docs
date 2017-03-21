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