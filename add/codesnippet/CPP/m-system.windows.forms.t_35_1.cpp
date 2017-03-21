      void button3_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         TreeNode^ lastNode = treeView1->Nodes[ treeView1->Nodes->Count - 1 ]->Nodes[ treeView1->Nodes[ treeView1->Nodes->Count - 1 ]->Nodes->Count - 1 ];
         if (  !lastNode->IsVisible )
         {
            lastNode->EnsureVisible();
            MessageBox::Show( String::Concat( lastNode->Text, " tree node is visible." ) );
         }
      }