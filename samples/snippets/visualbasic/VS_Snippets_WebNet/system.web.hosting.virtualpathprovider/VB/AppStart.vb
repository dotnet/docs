' <Snippet10>
Imports Microsoft.VisualBasic

Imports System.Web.Hosting

Namespace Samples.AspNet.VB

  Public Class AppStart

    Public Shared Sub AppInitialize()
      ' <Snippet11>
      Dim sampleProvider As SamplePathProvider = New SamplePathProvider()
      HostingEnvironment.RegisterVirtualPathProvider(sampleProvider)
      ' </Snippet11>
    End Sub

  End Class
End Namespace
' </Snippet10>