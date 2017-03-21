public:
   void HighlightCheckedNodes()
   {
      int countIndex = 0;
      String^ selectedNode = "Selected customer nodes are : ";
      IEnumerator^ myEnum = myTreeView->Nodes[ 0 ]->Nodes->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         TreeNode^ myNode = safe_cast<TreeNode^>(myEnum->Current);
         
         // Check whether the tree node is checked.
         if ( myNode->Checked )
         {
            
            // Set the node's backColor.
            myNode->BackColor = Color::Yellow;
            selectedNode = String::Concat( selectedNode, myNode->Text, " " );
            countIndex++;
         }
         else
                  myNode->BackColor = Color::White;
      }

      if ( countIndex > 0 )
            MessageBox::Show( selectedNode );
      else
            MessageBox::Show( "No nodes are selected" );
   }