'<snippet1>
' Sample for Environment class summary
Imports System
Imports System.Collections

Class Sample
   Public Shared Sub Main()
      Dim str As [String]
      Dim nl As [String] = Environment.NewLine
      '
      Console.WriteLine()
      Console.WriteLine("-- Environment members --")
      
      '  Invoke this sample with an arbitrary set of command line arguments.
      Console.WriteLine("CommandLine: {0}", Environment.CommandLine)
      
      Dim arguments As [String]() = Environment.GetCommandLineArgs()
      Console.WriteLine("GetCommandLineArgs: {0}", [String].Join(", ", arguments))
      
      '  <-- Keep this information secure! -->
      Console.WriteLine("CurrentDirectory: {0}", Environment.CurrentDirectory)
      
      Console.WriteLine("ExitCode: {0}", Environment.ExitCode)
      
      Console.WriteLine("HasShutdownStarted: {0}", Environment.HasShutdownStarted)
      
      '  <-- Keep this information secure! -->
      Console.WriteLine("MachineName: {0}", Environment.MachineName)
      
      Console.WriteLine("NewLine: {0}  first line{0}  second line{0}" & _
                        "  third line", Environment.NewLine)
      
      Console.WriteLine("OSVersion: {0}", Environment.OSVersion.ToString())
      
      Console.WriteLine("StackTrace: '{0}'", Environment.StackTrace)
      
      '  <-- Keep this information secure! -->
      Console.WriteLine("SystemDirectory: {0}", Environment.SystemDirectory)
      
      Console.WriteLine("TickCount: {0}", Environment.TickCount)
      
      '  <-- Keep this information secure! -->
      Console.WriteLine("UserDomainName: {0}", Environment.UserDomainName)
      
      Console.WriteLine("UserInteractive: {0}", Environment.UserInteractive)
      
      '  <-- Keep this information secure! -->
      Console.WriteLine("UserName: {0}", Environment.UserName)
      
      Console.WriteLine("Version: {0}", Environment.Version.ToString())
      
      Console.WriteLine("WorkingSet: {0}", Environment.WorkingSet)
      
      '  No example for Exit(exitCode) because doing so would terminate this example.

      '  <-- Keep this information secure! -->
      Dim query As [String] = "My system drive is %SystemDrive% and my" & _
                              " system root is %SystemRoot%"
      str = Environment.ExpandEnvironmentVariables(query)
      Console.WriteLine("ExpandEnvironmentVariables: {0}  {1}", nl, str)
      
      Console.WriteLine("GetEnvironmentVariable: {0}  My temporary directory is {1}.", _
                        nl, Environment.GetEnvironmentVariable("TEMP"))
      
      Console.WriteLine("GetEnvironmentVariables: ")
      Dim environmentVariables As IDictionary = Environment.GetEnvironmentVariables()
      Dim de As DictionaryEntry
      For Each de In environmentVariables
         Console.WriteLine("  {0} = {1}", de.Key, de.Value)
      Next de
      
      Console.WriteLine("GetFolderPath: {0}", _
              Environment.GetFolderPath(Environment.SpecialFolder.System))
      
      Dim drives As [String]() = Environment.GetLogicalDrives()
      Console.WriteLine("GetLogicalDrives: {0}", [String].Join(", ", drives))
   End Sub 'Main
End Class 'Sample
'
'This example produces results similar to the following:
'(Any result that is lengthy or reveals information that should remain 
'secure has been omitted and marked "!---OMITTED---!".)
'
'C:\>env0 ARBITRARY TEXT
'
'-- Environment members --
'CommandLine: env0 ARBITRARY TEXT
'GetCommandLineArgs: env0, ARBITRARY, TEXT
'CurrentDirectory: C:\Documents and Settings\!---OMITTED---!
'ExitCode: 0
'HasShutdownStarted: False
'MachineName: !---OMITTED---!
'NewLine:
'  first line
'  second line
'  third line
'OSVersion: Microsoft Windows NT 5.1.2600.0
'StackTrace: '   at System.Environment.GetStackTrace(Exception e)
'   at System.Environment.GetStackTrace(Exception e)
'   at System.Environment.get_StackTrace()
'   at Sample.Main()'
'SystemDirectory: C:\WINNT\System32
'TickCount: 17995355
'UserDomainName: !---OMITTED---!
'UserInteractive: True
'UserName: !---OMITTED---!
'Version: !---OMITTED---!
'WorkingSet: 5038080
'ExpandEnvironmentVariables:
'  My system drive is C: and my system root is C:\WINNT
'GetEnvironmentVariable:
'  My temporary directory is C:\DOCUME~1\!---OMITTED---!\LOCALS~1\Temp.
'GetEnvironmentVariables: 
'  !---OMITTED---!
'GetFolderPath: C:\WINNT\System32
'GetLogicalDrives: A:\, C:\, D:\
'
'</snippet1>