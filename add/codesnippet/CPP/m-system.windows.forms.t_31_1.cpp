   void CopyTreeNodes()
   {
      // Get the collection of TreeNodes.
      TreeNodeCollection^ myNodeCollection = myTreeView->Nodes;
      int myCount = myNodeCollection->Count;
      myLabel->Text = String::Concat( myLabel->Text, "Number of nodes in the collection : ", myCount );
      myLabel->Text = String::Concat( myLabel->Text, "\n\nElements of the Array after Copying from the collection :\n" );
      
      // Create an Object array.
      array<Object^>^myArray = gcnew array<Object^>(myCount);
      
      // Copy the collection into an array.
      myNodeCollection->CopyTo( myArray, 0 );
      for ( int i = 0; i < myArray->Length; i++ )
      {
         myLabel->Text = myLabel->Text + (dynamic_cast<TreeNode^>(myArray[ i ]))->Text + "\n";

      }
   }