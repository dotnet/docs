 FileIOPermission^ f = gcnew FileIOPermission( PermissionState::None );
 f->AllLocalFiles = FileIOPermissionAccess::Read;
 try
 {
	 f->Demand();
 }
 catch (SecurityException^ s)
 {
	 Console::WriteLine(s->Message);
 }