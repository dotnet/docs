   void myButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Set the tree view's PathSeparator property.
      myTreeView->PathSeparator = ".";
      
      // Get the count of the child tree nodes contained in the SelectedNode.
      int myNodeCount = myTreeView->SelectedNode->GetNodeCount( true );
      Decimal myChildPercentage = ((Decimal)myNodeCount / (Decimal)myTreeView->GetNodeCount( true )) * 100;
      
      // Display the tree node path and the number of child nodes it and the tree view have.
      MessageBox::Show( String::Concat( "The '", myTreeView->SelectedNode->FullPath, "' node has ", myNodeCount, " child nodes.\nThat is ", String::Format( "{0:###.##}", myChildPercentage ), "% of the total tree nodes in the tree view control." ) );
   }