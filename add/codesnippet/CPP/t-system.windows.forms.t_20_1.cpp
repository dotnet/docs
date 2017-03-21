private:
   void showCheckedNodesButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Disable redrawing of treeView1 to prevent flickering 
      // while changes are made.
      treeView1->BeginUpdate();
      
      // Collapse all nodes of treeView1.
      treeView1->CollapseAll();
      
      // Add the checkForCheckedChildren event handler to the BeforeExpand event.
      treeView1->BeforeExpand += checkForCheckedChildren;
      
      // Expand all nodes of treeView1. Nodes without checked children are 
      // prevented from expanding by the checkForCheckedChildren event handler.
      treeView1->ExpandAll();
      
      // Remove the checkForCheckedChildren event handler from the BeforeExpand 
      // event so manual node expansion will work correctly.
      treeView1->BeforeExpand -= checkForCheckedChildren;
      
      // Enable redrawing of treeView1.
      treeView1->EndUpdate();
   }

   // Prevent expansion of a node that does not have any checked child nodes.
   void CheckForCheckedChildrenHandler( Object^ /*sender*/, TreeViewCancelEventArgs^ e )
   {
      if (  !HasCheckedChildNodes( e->Node ) )
            e->Cancel = true;
   }


   // Returns a value indicating whether the specified 
   // TreeNode has checked child nodes.
   bool HasCheckedChildNodes( TreeNode^ node )
   {
      if ( node->Nodes->Count == 0 )
            return false;

      System::Collections::IEnumerator^ myEnum = node->Nodes->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         TreeNode^ childNode = safe_cast<TreeNode^>(myEnum->Current);
         if ( childNode->Checked )
                  return true;

         // Recursively check the children of the current child node.
         if ( HasCheckedChildNodes( childNode ) )
                  return true;
      }

      return false;
   }