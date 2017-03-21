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

        ' Instantiate a new TrustLevel object.
        Dim TrustLevel1 As TrustLevel = _
          New TrustLevel("myLevel1", "myLevel1.config")

        ' Get the Name of the TrustLevel object.
        Console.WriteLine("Name: {0}", TrustLevel1.Name)

        ' Instantiate a new TrustLevel object.
        Dim TrustLevel2 As TrustLevel = _
          New TrustLevel("myLevel2", "myLevel2.config")

        ' Get the PolicyFile of the TrustLevel object.
        Console.WriteLine("PolicyFile: {0}", TrustLevel2.PolicyFile)

      Catch e As Exception
        ' Unknown error.
        Console.WriteLine(e.ToString())
      End Try

      ' Display and wait.
      Console.ReadLine()
    End Sub
  End Class
End Namespace