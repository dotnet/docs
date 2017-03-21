    public ListViewInsertionMarkExample()
    {
        // Initialize myListView.
        myListView = new ListView();
        myListView.Dock = DockStyle.Fill;
        myListView.View = View.LargeIcon;
        myListView.MultiSelect = false;
        myListView.ListViewItemSorter = new ListViewIndexComparer();

        // Initialize the insertion mark.
        myListView.InsertionMark.Color = Color.Green;

        // Add items to myListView.
        myListView.Items.Add("zero");
        myListView.Items.Add("one");
        myListView.Items.Add("two");
        myListView.Items.Add("three");
        myListView.Items.Add("four");
        myListView.Items.Add("five");
        
        // Initialize the drag-and-drop operation when running
        // under Windows XP or a later operating system.
        if (OSFeature.Feature.IsPresent(OSFeature.Themes))
        {
            myListView.AllowDrop = true;
            myListView.ItemDrag += new ItemDragEventHandler(myListView_ItemDrag);
            myListView.DragEnter += new DragEventHandler(myListView_DragEnter);
            myListView.DragOver += new DragEventHandler(myListView_DragOver);
            myListView.DragLeave += new EventHandler(myListView_DragLeave);
            myListView.DragDrop += new DragEventHandler(myListView_DragDrop);
        }

        // Initialize the form.
        this.Text = "ListView Insertion Mark Example";
        this.Controls.Add(myListView);
    }