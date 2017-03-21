   private:
      void treeView1_AfterCollapse( Object^ /*sender*/, TreeViewEventArgs^ e )
      {
         // Create a copy of the e.Node from its Handle.
         TreeNode^ tn = TreeNode::FromHandle( e->Node->TreeView, e->Node->Handle );
         tn->Text = String::Concat( tn->Text, "Copy" );

         // Remove the e.Node so it can be replaced with tn.
         e->Node->Remove();

         // Add tn to the TreeNodeCollection.
         treeView1->Nodes->Add( tn );
      }