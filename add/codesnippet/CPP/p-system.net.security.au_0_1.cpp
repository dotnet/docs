// The following class displays the properties of an authenticatedStream.
public ref class AuthenticatedStreamReporter
{
public:
   static void DisplayProperties( AuthenticatedStream^ stream )
   {
      Console::WriteLine( L"IsAuthenticated: {0}", stream->IsAuthenticated );
      Console::WriteLine( L"IsMutuallyAuthenticated: {0}", stream->IsMutuallyAuthenticated );
      Console::WriteLine( L"IsEncrypted: {0}", stream->IsEncrypted );
      Console::WriteLine( L"IsSigned: {0}", stream->IsSigned );
      Console::WriteLine( L"IsServer: {0}", stream->IsServer );
   }

};

