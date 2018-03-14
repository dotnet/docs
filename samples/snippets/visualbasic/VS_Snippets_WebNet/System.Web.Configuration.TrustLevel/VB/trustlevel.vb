' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
  Class UsingTrustLevel
    Public Shared Sub Main()
      Try
        ' Display title.
        Console.WriteLine("ASP.NET TrustLevel Info")
        Console.WriteLine()

        ' <Snippet2>
        ' Instantiate a new TrustLevel object.
        Dim TrustLevel1 As TrustLevel = _
          New TrustLevel("myLevel1", "myLevel1.config")
        ' </Snippet2>

        ' <Snippet3>
        ' Get the Name of the TrustLevel object.
        Console.WriteLine("Name: {0}", TrustLevel1.Name)
        ' </Snippet3>

        ' <Snippet4>
        ' Instantiate a new TrustLevel object.
        Dim TrustLevel2 As TrustLevel = _
          New TrustLevel("myLevel2", "myLevel2.config")
        ' </Snippet4>

        ' <Snippet5>
        ' Get the PolicyFile of the TrustLevel object.
        Console.WriteLine("PolicyFile: {0}", TrustLevel2.PolicyFile)
        ' </Snippet5>

      Catch e As Exception
        ' Unknown error.
        Console.WriteLine(e.ToString())
      End Try

      ' Display and wait.
      Console.ReadLine()
    End Sub
  End Class
End Namespace
' </Snippet1>