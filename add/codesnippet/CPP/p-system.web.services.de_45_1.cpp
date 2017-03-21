      // Get the operation message for the Add operation.
      OperationMessage^ myOperationMessage = myOperationMessageCollection[ 0 ];
      OperationMessage^ myInputOperationMessage = dynamic_cast<OperationMessage^>(gcnew OperationInput);
      XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "AddSoapIn",myDescription->TargetNamespace );
      myInputOperationMessage->Message = myXmlQualifiedName;

      array<OperationMessage^>^myCollection = gcnew array<OperationMessage^>(myOperationMessageCollection->Count);
      myOperationMessageCollection->CopyTo( myCollection, 0 );
      Console::WriteLine( "Operation name(s) :" );
      for ( int i = 0; i < myCollection->Length; i++ )
      {
         Console::WriteLine( " {0}", myCollection[ i ]->Operation->Name );
      }

      // Add the OperationMessage to the collection.
      myOperationMessageCollection->Add( myInputOperationMessage );
      
      DisplayFlowInputOutput( myOperationMessageCollection, "Add" );
      
      if ( myOperationMessageCollection->Contains( myOperationMessage ) == true )
      {
         int myIndex = myOperationMessageCollection->IndexOf( myOperationMessage );
         Console::WriteLine( " The index of the Add operation message in the collection is : {0}", myIndex );
      }