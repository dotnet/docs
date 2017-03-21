private:
   void CreateMySplitControls()
   {
      // Create TreeView, ListView, and Splitter controls.
      TreeView^ treeView1 = gcnew TreeView;
      ListView^ listView1 = gcnew ListView;
      Splitter^ splitter1 = gcnew Splitter;

      // Set the TreeView control to dock to the left side of the form.
      treeView1->Dock = DockStyle::Left;

      // Set the Splitter to dock to the left side of the TreeView control.
      splitter1->Dock = DockStyle::Left;

      // Set the minimum size the ListView control can be sized to.
      splitter1->MinExtra = 100;

      // Set the minimum size the TreeView control can be sized to.
      splitter1->MinSize = 75;

      // Set the ListView control to fill the remaining space on the form.
      listView1->Dock = DockStyle::Fill;

      // Add a TreeView and a ListView item to identify the controls on the form.
      treeView1->Nodes->Add( "TreeView Node" );
      listView1->Items->Add( "ListView Item" );

      // Add the controls in reverse order to the form to ensure proper location.
      array<Control^>^temp0 = {listView1,splitter1,treeView1};
      this->Controls->AddRange( temp0 );
   }