' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
  Class UsingTrustLevelCollection
    Public Shared Sub Main()
      Try
        ' Display title.
        Console.WriteLine("ASP.NET TrustLevelCollection Info")
        Console.WriteLine()

        ' Instantiate a new TrustLevelCollection object.
        Dim TrustLevelCollection1 As TrustLevelCollection = _
          New TrustLevelCollection()

        ' <Snippet2>
        ' Add a new TrustLevel to the collection.
        TrustLevelCollection1.Add(New TrustLevel("Level1", "Level1.config"))
        ' </Snippet2>

        ' Create a new TrustLevel object.
        Dim TrustLevel2 As TrustLevel = _
          New TrustLevel("myLevel2", "myLevel2.config")

        ' <Snippet3>
        ' Set the TrustLevel object within the collection.
        TrustLevelCollection1.Set(1, TrustLevel2)
        ' </Snippet3>

        ' <Snippet4>
        ' Display item details of the collection.
        For i As Integer = 0 To (TrustLevelCollection1.Count - 1)
          Console.WriteLine("Collection item {0}", i)
          Console.WriteLine("Name: {0}", _
           TrustLevelCollection1.Get(i).Name)
          Console.WriteLine("PolicyFile: {0}", _
           TrustLevelCollection1.Get(i).PolicyFile)
          Console.WriteLine()
        Next i
        ' </Snippet4>

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