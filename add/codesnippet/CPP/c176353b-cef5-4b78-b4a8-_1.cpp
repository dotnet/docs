int main()
{
   AppDomain^ currentDomain = AppDomain::CurrentDomain;
   AppDomain^ otherDomain = AppDomain::CreateDomain( "otherDomain" );
   currentDomain->ExecuteAssembly( "MyExecutable.exe" );
   
   // Prints S"MyExecutable running on [default]"
   otherDomain->ExecuteAssembly( "MyExecutable.exe" );
   
   // Prints S"MyExecutable running on otherDomain"
}
