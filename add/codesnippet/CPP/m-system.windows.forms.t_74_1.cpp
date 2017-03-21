      void button2_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         // Delete the first TreeNode in the collection
         // if the Text property is S"Node0."
         if ( this->treeView1->Nodes[ 0 ]->Text->Equals( "Node0" ) )
         {
            this->treeView1->Nodes->RemoveAt( 0 );
         }
      }