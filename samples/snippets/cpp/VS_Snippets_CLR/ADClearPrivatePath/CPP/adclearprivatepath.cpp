
//  <SNIPPET1>
using namespace System;
using namespace System::Reflection;
using namespace System::Security::Policy;

//for evidence Object
int main()
{
   
   //Create evidence for new appdomain.
   Evidence^ adevidence = AppDomain::CurrentDomain->Evidence;
   
   //Create the new application domain.
   AppDomain^ domain = AppDomain::CreateDomain( "MyDomain", adevidence );
   
   //Display the current relative search path.
   Console::WriteLine( "Relative search path is: {0}", domain->RelativeSearchPath );
   
   //Append the relative path.
   String^ Newpath = "www.code.microsoft.com";
   domain->AppendPrivatePath( Newpath );
   
   //Display the new relative search path.
   Console::WriteLine( "Relative search path is: {0}", domain->RelativeSearchPath );
   
   //Clear the private search path.
   domain->ClearPrivatePath();
   
   //Display the new relative search path.
   Console::WriteLine( "Relative search path is now: {0}", domain->RelativeSearchPath );
   AppDomain::Unload( domain );
}

//  </SNIPPET1>
