static void DisplayStreamProperties( NegotiateStream^ stream )
{
   Console::WriteLine( L"Can read: {0}", stream->CanRead );
   Console::WriteLine( L"Can write: {0}", stream->CanWrite );
   Console::WriteLine( L"Can seek: {0}", stream->CanSeek );
   try
   {
      
      // If the underlying stream supports it, display the length.
      Console::WriteLine( L"Length: {0}", stream->Length );
   }
   catch ( NotSupportedException^ ) 
   {
      Console::WriteLine( L"Cannot get the length of the underlying stream." );
   }

   if ( stream->CanTimeout )
   {
      Console::WriteLine( L"Read time-out: {0}", stream->ReadTimeout );
      Console::WriteLine( L"Write time-out: {0}", stream->WriteTimeout );
   }
}

