   Operation^ myPostOperation = gcnew Operation;
   myPostOperation->Name = myOperationBinding->Name;
   Console::WriteLine( "'Operation' instance uses 'OperationBinding': {0}",
      myPostOperation->IsBoundBy( myOperationBinding ) );