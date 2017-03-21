      System.Reflection.Assembly assem = 
                   System.Reflection.Assembly.LoadFrom(@".\MyLibrary.dll"); 
      System.IO.Stream fs = 
                   assem.GetManifestResourceStream("MyCompany.LibraryResources.resources");
      var rr = new System.Resources.ResourceReader(fs); 