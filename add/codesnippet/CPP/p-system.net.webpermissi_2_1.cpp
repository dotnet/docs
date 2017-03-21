      // Gets all URIs with Connect permission.
      IEnumerator^ myEnum = myWebPermission1->ConnectList;
      Console::WriteLine( "\nThe URIs with Connect permission are :\n" );
      while ( myEnum->MoveNext() )
      {
         Console::WriteLine( "\tThe URI is : {0}", myEnum->Current );
      }