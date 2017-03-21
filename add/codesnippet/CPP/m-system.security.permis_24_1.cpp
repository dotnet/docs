         GacIdentityPermission ^ Gac1 = gcnew GacIdentityPermission;
         GacIdentityPermission ^ Gac2 = gcnew GacIdentityPermission( PermissionState::None );
         if ( Gac1->Equals( Gac2 ) )
                  Console::WriteLine( "GacIdentityPermission() equals GacIdentityPermission(PermissionState.None)." );

         