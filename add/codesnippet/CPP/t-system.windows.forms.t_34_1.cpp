   TreeViewOwnerDraw()
   {
      tagFont = gcnew System::Drawing::Font( "Helvetica",8,FontStyle::Bold );

      // Create and initialize the TreeView control.
      myTreeView = gcnew TreeView;
      myTreeView->Dock = DockStyle::Fill;
      myTreeView->BackColor = Color::Tan;
      myTreeView->CheckBoxes = true;
      
      // Add nodes to the TreeView control.
      TreeNode^ node;
      for ( int x = 1; x < 4; ++x )
      {
         // Add a root node to the TreeView control.
         node = myTreeView->Nodes->Add( String::Format( "Task {0}", x ) );
         for ( int y = 1; y < 4; ++y )
         {
            // Add a child node to the root node.
            node->Nodes->Add( String::Format( "Subtask {0}", y ) );
         }
      }
      myTreeView->ExpandAll();
      
      // Add tags containing alert messages to a few nodes 
      // and set the node background color to highlight them.
      myTreeView->Nodes[ 1 ]->Nodes[ 0 ]->Tag = "urgent!";
      myTreeView->Nodes[ 1 ]->Nodes[ 0 ]->BackColor = Color::Yellow;
      myTreeView->SelectedNode = myTreeView->Nodes[ 1 ]->Nodes[ 0 ];
      myTreeView->Nodes[ 2 ]->Nodes[ 1 ]->Tag = "urgent!";
      myTreeView->Nodes[ 2 ]->Nodes[ 1 ]->BackColor = Color::Yellow;
      
      // Configure the TreeView control for owner-draw and add
      // a handler for the DrawNode event.
      myTreeView->DrawMode = TreeViewDrawMode::OwnerDrawText;
      myTreeView->DrawNode += gcnew DrawTreeNodeEventHandler( this, &TreeViewOwnerDraw::myTreeView_DrawNode );
      
      // Add a handler for the MouseDown event so that a node can be 
      // selected by clicking the tag text as well as the node text.
      myTreeView->MouseDown += gcnew MouseEventHandler( this, &TreeViewOwnerDraw::myTreeView_MouseDown );
      
      // Initialize the form and add the TreeView control to it.
      this->ClientSize = System::Drawing::Size( 292, 273 );
      this->Controls->Add( myTreeView );
   }