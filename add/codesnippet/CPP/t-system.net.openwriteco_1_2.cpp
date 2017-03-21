void OpenWriteCallback2( Object^ /*sender*/, OpenWriteCompletedEventArgs^ e )
{
   Stream^ body = nullptr;
   StreamWriter^ s = nullptr;
   try
   {
      body = dynamic_cast<Stream^>(e->Result);
      s = gcnew StreamWriter( body );
      s->AutoFlush = true;
      s->Write( "This is content data to be sent to the server." );
   }
   finally
   {
      if ( s != nullptr )
      {
         s->Close();
      }
      if ( body != nullptr )
      {
         body->Close();
      }
   }

}

