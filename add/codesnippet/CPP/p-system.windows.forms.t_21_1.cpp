private:
   void Button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myTreeView->ItemHeight = 5;
      myTreeView->SelectedNode->NodeFont = gcnew System::Drawing::Font( "Arial",5 );
      
      // Get the font size from combobox.
      String^ selectedString = myComboBox->SelectedItem->ToString();
      int myNodeFontSize = Int32::Parse( selectedString );
      
      // Set the font of root node.
      myTreeView->SelectedNode->NodeFont = gcnew System::Drawing::Font( "Arial",(float)myNodeFontSize );
      for ( int i = 0; i < myTreeView->Nodes[ 0 ]->Nodes->Count; i++ )
      {
         
         // Set the font of child nodes.
         myTreeView->Nodes[ 0 ]->Nodes[ i ]->NodeFont = gcnew System::Drawing::Font( "Arial",(float)myNodeFontSize );

      }
      
      // Get the bounds of the tree node.
      Rectangle myRectangle = myTreeView->SelectedNode->Bounds;
      int myNodeHeight = myRectangle.Height;
      if ( myNodeHeight < myNodeFontSize )
      {
         myNodeHeight = myNodeFontSize;
      }

      myTreeView->ItemHeight = myNodeHeight + 4;
   }