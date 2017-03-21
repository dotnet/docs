   ListViewInsertionMarkExample()
   {
      // Initialize myListView.
      myListView = gcnew ListView;
      myListView->Dock = DockStyle::Fill;
      myListView->View = View::LargeIcon;
      myListView->MultiSelect = false;
      myListView->ListViewItemSorter = gcnew ListViewIndexComparer;

      // Initialize the insertion mark.
      myListView->InsertionMark->Color = Color::Green;

      // Add items to myListView.
      myListView->Items->Add( "zero" );
      myListView->Items->Add( "one" );
      myListView->Items->Add( "two" );
      myListView->Items->Add( "three" );
      myListView->Items->Add( "four" );
      myListView->Items->Add( "five" );

      // Initialize the drag-and-drop operation when running
      // under Windows XP or a later operating system.
      if ( System::Environment::OSVersion->Version->Major > 5 || (System::Environment::OSVersion->Version->Major == 5 && System::Environment::OSVersion->Version->Minor >= 1) )
      {
         myListView->AllowDrop = true;
         myListView->ItemDrag += gcnew ItemDragEventHandler( this, &ListViewInsertionMarkExample::myListView_ItemDrag );
         myListView->DragEnter += gcnew DragEventHandler( this, &ListViewInsertionMarkExample::myListView_DragEnter );
         myListView->DragOver += gcnew DragEventHandler( this, &ListViewInsertionMarkExample::myListView_DragOver );
         myListView->DragLeave += gcnew EventHandler( this, &ListViewInsertionMarkExample::myListView_DragLeave );
         myListView->DragDrop += gcnew DragEventHandler( this, &ListViewInsertionMarkExample::myListView_DragDrop );
      }

      // Initialize the form.
      this->Text = "ListView Insertion Mark Example";
      this->Controls->Add( myListView );
   }

private:
