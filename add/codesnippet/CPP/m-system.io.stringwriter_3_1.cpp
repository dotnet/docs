   strWriter->Close();
   
   // Since the StringWriter is closed, an exception will 
   // be thrown if the Write method is called. However, 
   // the StringBuilder can still manipulate the string.
   strBuilder->Insert( 0, "Invalid " );
   Console::WriteLine( strWriter->ToString() );
   