   Type^ myType = MyService::typeid;
   MethodInfo^ myMethodInfo = myType->GetMethod( "Add" );

   // Create a synchronous 'LogicalMethodInfo' instance.
   array<MethodInfo^>^temparray = {myMethodInfo};
   LogicalMethodInfo^ myLogicalMethodInfo = (LogicalMethodInfo::Create( temparray, LogicalMethodTypes::Sync ))[ 0 ];

   // Display the method for which the attributes are being displayed.
   Console::WriteLine( "\nDisplaying the attributes for the method : {0}\n", myLogicalMethodInfo->MethodInfo );