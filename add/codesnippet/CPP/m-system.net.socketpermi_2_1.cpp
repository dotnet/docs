   // Creates a copy of the intersect SocketPermission.
   SocketPermission^ mySocketPermissionIntersectCopy =
      (SocketPermission^)( mySocketPermissionIntersect->Copy() );
   if ( mySocketPermissionIntersectCopy->Equals( mySocketPermissionIntersect ) )
   {
      Console::WriteLine(  "Copy successfull" );
   }