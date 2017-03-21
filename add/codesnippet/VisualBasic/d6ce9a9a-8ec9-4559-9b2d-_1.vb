      Dim objRefSample As ObjRef = RemotingServices.GetObjRefForProxy(myRemoteObject)
      
      Console.WriteLine("***ObjRef Details***")
      Console.WriteLine("URI:" + ControlChars.Tab + "{0}", objRefSample.URI)
      
      Dim channelData As Object() = objRefSample.ChannelInfo.ChannelData
      Console.WriteLine("Channel Info:")
      
      Dim o As Object
      For Each o In  channelData
         Console.WriteLine(ControlChars.Tab + "{0}", o.ToString())
      Next o
      
      Dim envoyInfo As IEnvoyInfo = objRefSample.EnvoyInfo
      If envoyInfo Is Nothing Then
         Console.WriteLine("This ObjRef does not have envoy information.")
      Else
         Dim envoySinks As IMessageSink = envoyInfo.EnvoySinks
         Console.WriteLine("Envoy Sink Class: {0}", envoySinks)
      End If
      
      Dim typeInfo As IRemotingTypeInfo = objRefSample.TypeInfo
      Console.WriteLine("Remote type name: {0}", typeInfo.TypeName)
      
      Console.WriteLine("Can my object cast to a Bitmap? {0}", typeInfo.CanCastTo(GetType(System.Drawing.Bitmap), objRefSample))