      Console::WriteLine( "User {0} {1}", request->Credentials->GetCredential( request->RequestUri, "basic" )->UserName, request->RequestUri );
