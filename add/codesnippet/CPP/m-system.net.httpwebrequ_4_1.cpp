      // Set the 'Method' property of the 'Webrequest' to 'POST'.
      myHttpWebRequest->Method = "POST";
      Console::WriteLine( "\nPlease enter the data to be posted to the (http://www.contoso.com/codesnippets/next.asp) Uri :" );
      
      // Create a new String* Object* to POST data to the Url.
      String^ inputData = Console::ReadLine();
      
      String^ postData = String::Concat( "firstone= ", inputData );
      ASCIIEncoding^ encoding = gcnew ASCIIEncoding;
      array<Byte>^ byte1 = encoding->GetBytes( postData );
      
      // Set the content type of the data being posted.
      myHttpWebRequest->ContentType = "application/x-www-form-urlencoded";
      
      // Set the content length of the String* being posted.
      myHttpWebRequest->ContentLength = byte1->Length;

      Stream^ newStream = myHttpWebRequest->GetRequestStream();

      newStream->Write( byte1, 0, byte1->Length );
      Console::WriteLine( "The value of 'ContentLength' property after sending the data is {0}", myHttpWebRequest->ContentLength );
      
      // Close the Stream Object*.
      newStream->Close();