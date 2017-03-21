   // Create an Operation.
   Operation^ myOperation = gcnew Operation;
   myOperation->Name = myOperationName;
   OperationMessage^ myInput = dynamic_cast<OperationMessage^>(gcnew OperationInput);
   myInput->Message = gcnew XmlQualifiedName( myInputMesg );
   OperationMessage^ myOutput = dynamic_cast<OperationMessage^>(gcnew OperationOutput);
   myOutput->Message = gcnew XmlQualifiedName( myOutputMesg );
   
   // Add messages to the OperationMessageCollection.
   myOperation->Messages->Add( myInput );
   myOperation->Messages->Add( myOutput );
   Console::WriteLine( "Operation name is: {0}", myOperation->Name );
   