private:
   void InitializeTreeView()
   {
      
      // Construct the TreeView object.
      this->TreeView1 = gcnew System::Windows::Forms::TreeView;
      
      // Set dock, location, size name, and tab order
      // values for the TreeView object.
      TreeView1->Dock = System::Windows::Forms::DockStyle::Left;
      TreeView1->Location = System::Drawing::Point( 0, 0 );
      TreeView1->Name = "TreeView1";
      TreeView1->Size = System::Drawing::Size( 152, 266 );
      TreeView1->TabIndex = 1;
      
      // Associate the event-handling methods with the
      // BeforeLabeEdit and the AfterSelect events.
      TreeView1->BeforeLabelEdit += gcnew NodeLabelEditEventHandler( this, &Form1::TreeView1_BeforeLabelEdit );
      TreeView1->AfterSelect += gcnew TreeViewEventHandler( this, &Form1::TreeView1_AfterSelect );
      
      // Set the LabelEdit property to true to allow the 
      // user to edit the TreeNode text.
      this->TreeView1->LabelEdit = true;
      
      // Declare and create objects needed to populate 
      // the TreeView.
      array<String^>^files = {"bigPresentation.ppt","myFinances.xls","myResume.doc"};
      ;
      String^ filePath = "c:\\myFiles";
      System::Collections::ArrayList^ nodes = gcnew System::Collections::ArrayList;
      
      // Create a node for each file, setting the Text property to the 
      // file's name and the Tag property to file's fully-qualified name.
      System::Collections::IEnumerator^ myEnum = files->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         String^ file = safe_cast<String^>(myEnum->Current);
         TreeNode^ node = gcnew TreeNode( file );
         node->Tag = String::Concat( filePath, "\\", file );
         nodes->Add( node );
      }

      array<TreeNode^>^treeNodes = gcnew array<TreeNode^>(nodes->Count);
      nodes->CopyTo( treeNodes );
      
      // Create a new node named topNode and add the ArrayList of 
      // nodes to topNode.
      TreeNode^ topNode = gcnew TreeNode( "myFiles",treeNodes );
      topNode->Tag = filePath;
      
      // Add topNode to the TreeView.
      TreeView1->Nodes->Add( topNode );
      
      // Add the TreeView to the form.
      this->Controls->Add( TreeView1 );
   }

   void TreeView1_BeforeLabelEdit( Object^ /*sender*/, NodeLabelEditEventArgs^ e )
   {
      
      // Determine whether the user has selected the top node. If so,
      // change the CancelEdit property to true to cancel the edit.
      if ( e->Node == TreeView1->TopNode )
      {
         e->CancelEdit = true;
         MessageBox::Show( "You are not allowed to edit the top node" );
      }

   }