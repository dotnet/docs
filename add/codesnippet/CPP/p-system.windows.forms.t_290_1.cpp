      void button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         // If neither TreeNodeCollection is read-only, move the
         // selected node from treeView1 to treeView2.
         if (  !treeView1->Nodes->IsReadOnly &&  !treeView2->Nodes->IsReadOnly )
         {
            if ( treeView1->SelectedNode != nullptr )
            {
               TreeNode^ tn = treeView1->SelectedNode;
               treeView1->Nodes->Remove( tn );
               treeView2->Nodes->Insert( treeView2->Nodes->Count, tn );
            }
         }
      }