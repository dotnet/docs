Imports Microsoft.VisualBasic

Imports System.Web.Hosting

Namespace Samples.AspNet.VB

  Public Class AppStart

    Public Shared Sub AppInitialize()
      Dim sampleProvider As SamplePathProvider = New SamplePathProvider()
      HostingEnvironment.RegisterVirtualPathProvider(sampleProvider)
    End Sub

  End Class
End Namespace