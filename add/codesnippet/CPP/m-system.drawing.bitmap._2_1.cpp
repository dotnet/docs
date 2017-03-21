   void InitializeStreamBitmap()
   {
      try
      {
         System::Net::WebRequest^ request = System::Net::WebRequest::Create( "http://www.microsoft.com//h/en-us/r/ms_masthead_ltr.gif" );
         System::Net::WebResponse^ response = request->GetResponse();
         System::IO::Stream^ responseStream = response->GetResponseStream();
         Bitmap^ bitmap2 = gcnew Bitmap( responseStream );
         PictureBox1->Image = bitmap2;
      }
      catch ( System::Net::WebException^ ) 
      {
         MessageBox::Show( "There was an error opening the image file."
         "Check the URL" );
      }

   }