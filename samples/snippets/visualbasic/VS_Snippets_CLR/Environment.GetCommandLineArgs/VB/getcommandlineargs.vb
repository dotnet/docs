'<snippet1>
Class Sample
   Public Shared Sub Main()
      Console.WriteLine()
      '  Invoke this sample with an arbitrary set of command line arguments.
      Dim arguments As String() = Environment.GetCommandLineArgs()
      Console.WriteLine("GetCommandLineArgs: {0}", String.Join(", ", arguments))
   End Sub
End Class
'This example produces output like the following:
'    
'    C:\>GetCommandLineArgs ARBITRARY TEXT
'    
'      GetCommandLineArgs: GetCommandLineArgs, ARBITRARY, TEXT
'    
'</snippet1>