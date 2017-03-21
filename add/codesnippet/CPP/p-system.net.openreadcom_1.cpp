void OpenReadCallback2( Object^ /*sender*/, OpenReadCompletedEventArgs^ e )
{
   Stream^ reply = nullptr;
   StreamReader^ s = nullptr;
   try
   {
      reply = dynamic_cast<Stream^>(e->Result);
      s = gcnew StreamReader( reply );
      Console::WriteLine( s->ReadToEnd() );
   }
   finally
   {
      if ( s != nullptr )
      {
         s->Close();
      }
      if ( reply != nullptr )
      {
         reply->Close();
      }
   }

}

