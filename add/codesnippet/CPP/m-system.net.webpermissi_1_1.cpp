   // Create the target permission.
   WebPermission^ targetPermission = gcnew WebPermission;
   targetPermission->AddPermission( NetworkAccess::Connect, gcnew Regex( "www\\.contoso\\.com/Public/.*" ) );
   
   // Create the permission for a URI matching target.
   WebPermission^ connectPermission = gcnew WebPermission;
   connectPermission->AddPermission( NetworkAccess::Connect, "www.contoso.com/Public/default.htm" );
   
   //The following statement prints true.
   Console::WriteLine( "Is the second URI a subset of the first one?: {0}", connectPermission->IsSubsetOf( targetPermission ) );