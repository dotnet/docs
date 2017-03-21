void GetPage( String^ url )
{
   try
   {
      Uri^ fileUrl = gcnew Uri( String::Concat( "file://", url ) );
      
      // Create a 'FileWebrequest' object with the specified Uri .
      FileWebRequest^ myFileWebRequest = (FileWebRequest^)( WebRequest::Create( fileUrl ) );
      
      // Send the 'fileWebRequest' and wait for response.
      FileWebResponse^ myFileWebResponse = (FileWebResponse^)( myFileWebRequest->GetResponse() );
      Console::WriteLine( "\nThe Uri of the file system resource that provided the response is :\n {0}\n\n", myFileWebResponse->ResponseUri );
      
      // Release resources of response object.
      myFileWebResponse->Close();
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\r\nWebException thrown.The Reason for failure is : {0}", e->Status );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nThe following Exception was raised : {0}", e->Message );
   }
}