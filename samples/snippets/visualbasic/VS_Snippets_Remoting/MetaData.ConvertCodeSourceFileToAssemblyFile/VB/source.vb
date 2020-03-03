' <Snippet1>
Imports System.Runtime.Remoting.MetadataServices


Public Class Test
   
   Public Shared Sub Main()
      MetaData.ConvertCodeSourceFileToAssemblyFile("CsSource.cs", "testAssm.dll", "")
   End Sub
End Class
' </Snippet1>