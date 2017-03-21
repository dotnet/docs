 FileIOPermission^ f2 = gcnew FileIOPermission( FileIOPermissionAccess::Read,"C:\\test_r" );
 f2->AddPathList( (FileIOPermissionAccess) (FileIOPermissionAccess::Write | FileIOPermissionAccess::Read), "C:\\example\\out.txt" );
 try
 {
	 f2->Demand();
 }
 catch (SecurityException^ s)
 {
	 Console::WriteLine(s->Message);
 }