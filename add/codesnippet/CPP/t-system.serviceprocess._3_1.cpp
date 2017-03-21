   // Prompt the user for service installation account values.
public:
   static bool GetServiceAccount( interior_ptr<ServiceProcessInstaller^> svcInst )
   {
      bool accountSet = false;
      ServiceInstallerDialog^ svcDialog = gcnew ServiceInstallerDialog;

      // Query the user for the service account type.
      do
      {
         svcDialog->TopMost = true;
         svcDialog->ShowDialog();
         if ( svcDialog->Result == ServiceInstallerDialogResult::OK )
         {
            // Do a very simple validation on the user
            // input.  Check to see whether the user name
            // or password is blank.
            if ( (svcDialog->Username->Length > 0) && (svcDialog->Password->Length > 0) )
            {
               // Use the account and password.
               accountSet = true;
               ( *svcInst)->Account = ServiceAccount::User;
               ( *svcInst)->Username = svcDialog->Username;
               ( *svcInst)->Password = svcDialog->Password;
            }
         }
         else
         if ( svcDialog->Result == ServiceInstallerDialogResult::UseSystem )
         {
            ( *svcInst)->Account = ServiceAccount::LocalSystem;
            ( *svcInst)->Username = nullptr;
            ( *svcInst)->Password = nullptr;
            accountSet = true;
         }

         if (  !accountSet )
         {
            // Display a message box.  Tell the user to
            // enter a valid user and password, or cancel
            // out to leave the service account alone.
            DialogResult result;
            result = MessageBox::Show( "Invalid user name or password for service installation."
                  "  Press Cancel to leave the service account unchanged.", "Change Service Account", 
                  MessageBoxButtons::OKCancel, MessageBoxIcon::Hand );
            if ( result == DialogResult::Cancel )
            {
               // Break out of loop.
               break;
            }
         }
      }
      while (  !accountSet );

      return accountSet;
   }