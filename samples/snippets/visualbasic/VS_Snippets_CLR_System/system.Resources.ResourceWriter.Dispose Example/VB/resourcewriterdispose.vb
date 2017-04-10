'<snippet1>
Imports System
Imports System.Resources
Imports System.IO

Public Class WriteResources

  Public Shared Sub Main(ByVal args() As String)
      ' Create a file stream to encapsulate items.resources.
      Dim fs As New FileStream("items.resources", _
         FileMode.OpenOrCreate, FileAccess.Write)

      ' Open a resource writer to write from the stream.
      Dim writer = New ResourceWriter(fs)

      ' Add resources to the resource writer.
      writer.AddResource("String 1", "First String")
      writer.AddResource("String 2", "Second String")
      writer.AddResource("String 3", "Third String")

      ' Write the resources to the stream,  
      ' and clean up all resources associated with the writer.
      ' Calling Dispose is equivalent to calling Close.
      writer.Dispose()
   End Sub

End Class
'</snippet1>