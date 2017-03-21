 FileIOPermission^ f3 = gcnew FileIOPermission( PermissionState::None );
 f->AllFiles = FileIOPermissionAccess::Read;
 try
 {
	 f3->Demand();
 }
 catch (SecurityException^ s)
 {
	 Console::WriteLine(s->Message);
 }