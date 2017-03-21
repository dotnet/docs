   // Create a synchronous 'LogicalMethodInfo' instance.
   array<MethodInfo^>^temparray = {myMethodInfo};
   LogicalMethodInfo^ myLogicalMethodInfo = (LogicalMethodInfo::Create( temparray, LogicalMethodTypes::Sync ))[ 0 ];