
//<snippet1>
// Sample for Environment class summary
using namespace System;
using namespace System::Collections;
int main()
{
   String^ str;
   String^ nl = Environment::NewLine;
   
   //
   Console::WriteLine();
   Console::WriteLine( "-- Environment members --" );
   
   //  Invoke this sample with an arbitrary set of command line arguments.
   Console::WriteLine( "CommandLine: {0}", Environment::CommandLine );
   array<String^>^arguments = Environment::GetCommandLineArgs();
   Console::WriteLine( "GetCommandLineArgs: {0}", String::Join( ", ", arguments ) );
   
   //  <-- Keep this information secure! -->
   Console::WriteLine( "CurrentDirectory: {0}", Environment::CurrentDirectory );
   Console::WriteLine( "ExitCode: {0}", Environment::ExitCode );
   Console::WriteLine( "HasShutdownStarted: {0}", Environment::HasShutdownStarted );
   
   //  <-- Keep this information secure! -->
   Console::WriteLine( "MachineName: {0}", Environment::MachineName );
   Console::WriteLine( "NewLine: {0}  first line {0}  second line {0}  third line", Environment::NewLine );
   Console::WriteLine( "OSVersion: {0}", Environment::OSVersion );
   Console::WriteLine( "StackTrace: ' {0}'", Environment::StackTrace );
   
   //  <-- Keep this information secure! -->
   Console::WriteLine( "SystemDirectory: {0}", Environment::SystemDirectory );
   Console::WriteLine( "TickCount: {0}", Environment::TickCount );
   
   //  <-- Keep this information secure! -->
   Console::WriteLine( "UserDomainName: {0}", Environment::UserDomainName );
   Console::WriteLine( "UserInteractive: {0}", Environment::UserInteractive );
   
   //  <-- Keep this information secure! -->
   Console::WriteLine( "UserName: {0}", Environment::UserName );
   Console::WriteLine( "Version: {0}", Environment::Version );
   Console::WriteLine( "WorkingSet: {0}", Environment::WorkingSet );
   
   //  No example for Exit(exitCode) because doing so would terminate this example.
   //  <-- Keep this information secure! -->
   String^ query = "My system drive is %SystemDrive% and my system root is %SystemRoot%";
   str = Environment::ExpandEnvironmentVariables( query );
   Console::WriteLine( "ExpandEnvironmentVariables: {0} {1}", nl, str );
   Console::WriteLine( "GetEnvironmentVariable: {0}  My temporary directory is {1}.", nl, Environment::GetEnvironmentVariable( "TEMP" ) );
   Console::WriteLine( "GetEnvironmentVariables: " );
   IDictionary^ environmentVariables = Environment::GetEnvironmentVariables();
   IEnumerator^ myEnum = environmentVariables->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      DictionaryEntry^ de = safe_cast<DictionaryEntry^>(myEnum->Current);
      Console::WriteLine( " {0} = {1}", de->Key, de->Value );
   }

   Console::WriteLine( "GetFolderPath: {0}", Environment::GetFolderPath( Environment::SpecialFolder::System ) );
   array<String^>^drives = Environment::GetLogicalDrives();
   Console::WriteLine( "GetLogicalDrives: {0}", String::Join( ", ", drives ) );
}

/*
This example produces results similar to the following:
(Any result that is lengthy or reveals information that should remain 
secure has been omitted and marked S"!---OMITTED---!".)

C:\>env0 ARBITRARY TEXT

-- Environment members --
CommandLine: env0 ARBITRARY TEXT
GetCommandLineArgs: env0, ARBITRARY, TEXT
CurrentDirectory: C:\Documents and Settings\!---OMITTED---!
ExitCode: 0
HasShutdownStarted: False
MachineName: !---OMITTED---!
NewLine:
  first line
  second line
  third line
OSVersion: Microsoft Windows NT 5.1.2600.0
StackTrace: '   at System::Environment::GetStackTrace(Exception e)
   at System::Environment::GetStackTrace(Exception e)
   at System::Environment::get_StackTrace()
   at Sample::Main()'
SystemDirectory: C:\WINNT\System32
TickCount: 17995355
UserDomainName: !---OMITTED---!
UserInteractive: True
UserName: !---OMITTED---!
Version: !---OMITTED---!
WorkingSet: 5038080
ExpandEnvironmentVariables:
  My system drive is C: and my system root is C:\WINNT
GetEnvironmentVariable:
  My temporary directory is C:\DOCUME~1\!---OMITTED---!\LOCALS~1\Temp.
GetEnvironmentVariables:
  !---OMITTED---!
GetFolderPath: C:\WINNT\System32
GetLogicalDrives: A:\, C:\, D:\

*/
//</snippet1>
