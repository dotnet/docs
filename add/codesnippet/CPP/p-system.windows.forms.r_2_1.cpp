private:
   void RedoAllButDeletes()
   {
      // Determines if a Redo operation can be performed.
      if ( richTextBox1->CanRedo == true )
      {
         // Determines if the redo operation deletes text.
         if (  !richTextBox1->RedoActionName->Equals( "Delete" ) )
         // Perform the redo.
         richTextBox1->Redo();
      }
   }