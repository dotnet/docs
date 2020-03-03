' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      Standalone()
      Console.WriteLine("---")
      Embedded
   End Sub
   
   Private Sub Standalone()
      ' <Snippet2>
      ' Instantiate a standalone .resources file from its filename.
      Dim rr1 As New System.Resources.ResourceReader("Resources1.resources")

      ' Instantiate a standalone .resources file from a stream.
      Dim fs As New System.IO.FileStream(".\Resources2.resources",
                                         System.IO.FileMode.Open)
      Dim rr2 As New System.Resources.ResourceReader(fs)      
      ' </Snippet2>

      Console.WriteLine("rr1: {0}", rr1 IsNot Nothing)
      Console.WriteLine("rr2: {0}", rr2 IsNot Nothing)
   End Sub
   
   Private Sub Embedded()   
      ' <Snippet3>
      Dim assem As System.Reflection.Assembly = 
                   System.Reflection.Assembly.LoadFrom(".\MyLibrary.dll") 
      Dim fs As System.IO.Stream = 
                   assem.GetManifestResourceStream("MyCompany.LibraryResources.resources")
      Dim rr As New System.Resources.ResourceReader(fs) 
      ' </Snippet3>
      
      If fs Is Nothing Then 
         Console.WriteLine(fs Is Nothing)
         For Each name In assem.GetManifestResourceNames()
            Console.WriteLine(name)
         Next
         Exit Sub
      Else
         Console.WriteLine(fs Is Nothing)
      End If
   End Sub
End Module

