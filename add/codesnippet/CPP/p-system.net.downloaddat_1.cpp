void DownloadDataCallback( Object^ /*sender*/, DownloadDataCompletedEventArgs^ e )
{
   System::Threading::AutoResetEvent^ waiter = dynamic_cast<System::Threading::AutoResetEvent^>(e->UserState);
   try
   {
      
      // If the request was not canceled and did not throw
      // an exception, display the resource.
      if (  !e->Cancelled && e->Error == nullptr )
      {
         array<Byte>^data = dynamic_cast<array<Byte>^>(e->Result);
         String^ textData = System::Text::Encoding::UTF8->GetString( data );
         Console::WriteLine( textData );
      }
   }
   finally
   {
      
      // Let the main application thread resume.
      waiter->Set();
   }

}

