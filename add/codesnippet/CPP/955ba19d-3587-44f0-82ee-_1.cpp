      if ( myOperationMessageCollection->Contains( myOperationMessage ) == true )
      {
         int myIndex = myOperationMessageCollection->IndexOf( myOperationMessage );
         Console::WriteLine( " The index of the Add operation message in the collection is : {0}", myIndex );
      }