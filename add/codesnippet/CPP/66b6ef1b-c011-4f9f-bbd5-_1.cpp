   WindowsIdentity^ windowsIdentity = WindowsIdentity::GetCurrent();

   // Construct a GenericIdentity object based on the current Windows
   // identity name and authentication type.
   String^ authenticationType = windowsIdentity->AuthenticationType;
   String^ userName = windowsIdentity->Name;
   GenericIdentity^ authenticatedGenericIdentity = gcnew GenericIdentity( userName,authenticationType );