      Console.WriteLine("Connecting to SampleNamespace.SampleWellKnown.")
      
      Dim proxy As SampleWellKnown = _
         CType(RemotingServices.Connect(GetType(SampleWellKnown), SERVER_URL), SampleWellKnown)
      
      Console.WriteLine("Connected to SampleWellKnown")
      
      ' Verifies that the object reference is to a transparent proxy.
      If RemotingServices.IsTransparentProxy(proxy) Then
         Console.WriteLine("proxy is a reference to a transparent proxy.")
      Else
         Console.WriteLine("proxy is not a transparent proxy.  This is unexpected.")
      End If
      
      ' Calls a method on the server object.
      Console.WriteLine("proxy.Add returned {0}.", proxy.Add(2, 3))