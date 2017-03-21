// Displays the properties of the OperationMessageCollection.
void DisplayFlowInputOutput( OperationMessageCollection^ myOperationMessageCollection, String^ myOperation )
{
   Console::WriteLine( "After {0}:", myOperation );
   Console::WriteLine( "Flow : {0}", myOperationMessageCollection->Flow );
   Console::WriteLine( "The first occurrence of operation Input in the collection {0}", myOperationMessageCollection->Input );
   Console::WriteLine( "The first occurrence of operation Output in the collection {0}", myOperationMessageCollection->Output );
   Console::WriteLine();
}