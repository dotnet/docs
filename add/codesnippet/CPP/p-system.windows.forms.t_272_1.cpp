   void SelectNode( TreeNode^ node )
   {
      if ( node->IsSelected )
      {
         
         // Determine which TreeNode to select.
         String^ str = myComboBox->Text;
         if ( str->Equals( "Previous" ) )
                  node->TreeView->SelectedNode = node->PrevNode;
         else
         if ( str->Equals( "PreviousVisible" ) )
                  node->TreeView->SelectedNode = node->PrevVisibleNode;
         else
         if ( str->Equals( "Next" ) )
                  node->TreeView->SelectedNode = node->NextNode;
         else
         if ( str->Equals( "NextVisible" ) )
                  node->TreeView->SelectedNode = node->NextVisibleNode;
         else
         if ( str->Equals( "First" ) )
                  node->TreeView->SelectedNode = node->FirstNode;
         else
         if ( str->Equals( "Last" ) )
                  node->TreeView->SelectedNode = node->LastNode;
      }

      node->TreeView->Focus();
   }