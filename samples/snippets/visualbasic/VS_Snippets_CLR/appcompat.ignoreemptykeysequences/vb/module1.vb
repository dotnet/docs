Module Module1
   Sub Main()
      ' <Snippet1>
      ' Ignore empty key sequences in apps that target .NET 4.6
      AppContext.SetSwitch("System.Xml.IgnoreEmptyKeySequences", True)
      ' </Snippet1>

      ' <Snippet2>
      ' Do Not ignore empty key sequences in apps that target .NET 4.5.1 And earlier
      AppContext.SetSwitch("System.Xml.IgnoreEmptyKeySequences", False)
      ' </Snippet2>
   End Sub
End Module
