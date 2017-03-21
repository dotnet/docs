   MyApplicationContext()
   {
      formCount = 0;
      
      // Handle the ApplicationExit event to know when the application is exiting.
      Application::ApplicationExit += gcnew EventHandler( this, &MyApplicationContext::OnApplicationExit );
      try
      {
         
         // Create a file that the application will store user specific data in.
         userData = gcnew FileStream( String::Concat( Application::UserAppDataPath, "\\appdata.txt" ),FileMode::OpenOrCreate );
      }
      catch ( IOException^ e ) 
      {
         
         // Inform the user that an error occurred.
         MessageBox::Show( "An error occurred while attempting to show the application. The error is: {0}", dynamic_cast<String^>(e) );
         
         // Exit the current thread instead of showing the windows.
         ExitThread();
      }

      
      // Create both application forms and handle the Closed event
      // to know when both forms are closed.
      form1 = gcnew AppForm1;
      form1->Closed += gcnew EventHandler( this, &MyApplicationContext::OnFormClosed );
      form1->Closing += gcnew CancelEventHandler( this, &MyApplicationContext::OnFormClosing );
      formCount++;
      form2 = gcnew AppForm2;
      form2->Closed += gcnew EventHandler( this, &MyApplicationContext::OnFormClosed );
      form2->Closing += gcnew CancelEventHandler( this, &MyApplicationContext::OnFormClosing );
      formCount++;
      
      // Get the form positions based upon the user specific data.
      if ( ReadFormDataFromFile() )
      {
         
         // If the data was read from the file, set the form
         // positions manually.
         form1->StartPosition = FormStartPosition::Manual;
         form2->StartPosition = FormStartPosition::Manual;
         form1->Bounds = form1Position;
         form2->Bounds = form2Position;
      }

      
      // Show both forms.
      form1->Show();
      form2->Show();
   }

   void OnApplicationExit( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      
      // When the application is exiting, write the application data to the
      // user file and close it.
      WriteFormDataToFile();
      try
      {
         
         // Ignore any errors that might occur while closing the file handle.
         userData->Close();
      }
      catch ( Exception^ ) 
      {
      }

   }


private:
