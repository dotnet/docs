static void DisplayAuthenticationProperties( NegotiateStream^ stream )
{
   Console::WriteLine( L"IsAuthenticated: {0}", stream->IsAuthenticated );
   Console::WriteLine( L"IsMutuallyAuthenticated: {0}", stream->IsMutuallyAuthenticated );
   Console::WriteLine( L"IsEncrypted: {0}", stream->IsEncrypted );
   Console::WriteLine( L"IsSigned: {0}", stream->IsSigned );
   Console::WriteLine( L"ImpersonationLevel: {0}", stream->ImpersonationLevel );
   Console::WriteLine( L"IsServer: {0}", stream->IsServer );
}

