      Dim assem As System.Reflection.Assembly = 
                   System.Reflection.Assembly.LoadFrom(".\MyLibrary.dll") 
      Dim fs As System.IO.Stream = 
                   assem.GetManifestResourceStream("MyCompany.LibraryResources.resources")
      Dim rr As New System.Resources.ResourceReader(fs) 