' <Snippet1>
Imports System
Imports System.Runtime.Remoting.MetadataServices


Public Class Test
   
   Public Shared Sub Main()
      MetaData.ConvertCodeSourceFileToAssemblyFile("CsSource.cs", "testAssm.dll", "")
   End Sub 'Main
End Class 'Test
' </Snippet1>