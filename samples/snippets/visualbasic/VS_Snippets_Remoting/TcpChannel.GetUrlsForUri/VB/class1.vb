' <Snippet1>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels.Tcp


Class SampleClass
   
   Public Shared Sub Main()
      ' Create a remotable object.
      Dim tcpChannel As New TcpChannel(8085)
      
      Dim WKSTE As New WellKnownServiceTypeEntry(GetType(HelloService), "Service", WellKnownObjectMode.Singleton)
      RemotingConfiguration.RegisterWellKnownServiceType(WKSTE)
      
      RemotingConfiguration.ApplicationName = "HelloServer"
      
      ' Print out the urls for the HelloServer.
      Dim urls As String() = tcpChannel.GetUrlsForUri("HelloServer")
      Dim url As String
      
      For Each url In  urls
         System.Console.WriteLine("{0}", url)
      Next url 
   End Sub 'Main
   
End Class 'Class1
' </Snippet1>
