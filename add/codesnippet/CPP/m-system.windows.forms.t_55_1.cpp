   void EnumerateTreeNodes()
   {
      TreeNodeCollection^ myNodeCollection = myTreeView->Nodes;

      // Check for a node in the collection.
      if ( myNodeCollection->Contains( myTreeNode2 ) )
      {
         myLabel->Text = myLabel->Text + "Node2 is at index: " + myNodeCollection->IndexOf( myTreeNode2 );
      }

      myLabel->Text = myLabel->Text + "\n\nElements of the TreeNodeCollection:\n";

      // Create an enumerator for the collection.
      IEnumerator^ myEnumerator = myNodeCollection->GetEnumerator();
      while ( myEnumerator->MoveNext() )
      {
         myLabel->Text = myLabel->Text + (dynamic_cast<TreeNode^>(myEnumerator->Current))->Text + "\n";
      }
   }