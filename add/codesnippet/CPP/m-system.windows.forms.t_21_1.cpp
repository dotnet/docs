private:
   void MyButtonAddAllClick( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      
      // Get the 'myTreeNodeCollection' from the 'myTreeViewBase' TreeView.
      TreeNodeCollection^ myTreeNodeCollection = myTreeViewBase->Nodes;
      
      // Create an array of 'TreeNodes'.
      array<TreeNode^>^myTreeNodeArray = gcnew array<TreeNode^>(myTreeViewBase->Nodes->Count);
      
      // Copy the tree nodes to the 'myTreeNodeArray' array.
      myTreeViewBase->Nodes->CopyTo( myTreeNodeArray, 0 );
      
      // Remove all the tree nodes from the 'myTreeViewBase' TreeView.
      myTreeViewBase->Nodes->Clear();
      
      // Add the 'myTreeNodeArray' to the 'myTreeViewCustom' TreeView.
      myTreeViewCustom->Nodes->AddRange( myTreeNodeArray );
   }