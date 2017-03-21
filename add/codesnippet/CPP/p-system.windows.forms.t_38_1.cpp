   private:
      void treeView1_AfterSelect( Object^ /*sender*/, TreeViewEventArgs^ e )
      {
         /* Display the Text and Index of the
               * selected tree node's Parent. */
         if ( e->Node->Parent != nullptr && e->Node->Parent->GetType() == TreeNode::typeid )
         {
            statusBar1->Text = String::Format( "Parent: {0}\n Index Position: {1}", e->Node->Parent->Text, e->Node->Parent->Index );
         }
         else
         {
            statusBar1->Text = "No parent node.";
         }
      }