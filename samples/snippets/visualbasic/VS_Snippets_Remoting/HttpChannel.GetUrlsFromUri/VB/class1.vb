 '<Snippet1>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels.Http

Class SampleClass
   
   Public Shared Sub Main()
      ' Create a remotable object.
      Dim httpChannel As New HttpChannel(8085)
      
      Dim WKSTE As New WellKnownServiceTypeEntry(GetType(HelloService), "Service", WellKnownObjectMode.Singleton)
      RemotingConfiguration.RegisterWellKnownServiceType(WKSTE)
      
      RemotingConfiguration.ApplicationName = "HelloServer"
      
      ' Print out the urls for HelloServer.
      Dim urls As String() = httpChannel.GetUrlsForUri("HelloServer")
      Dim url As String

      For Each url In  urls
         System.Console.WriteLine("{0}", url)
      Next url 
   End Sub 'Main

End Class 'Class1
'</Snippet1>

Public Class HelloService
	Inherits MarshalByRefObject
End Class