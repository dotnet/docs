      Import[] myImports = new Import[myServiceDescription.Imports.Count];
      // Copy 'ImportCollection' to an array.
      myServiceDescription.Imports.CopyTo(myImports,0);
      Console.WriteLine("Imports that are copied to Importarray ...");
      for(int i=0;i < myImports.Length; ++i)
         Console.WriteLine("\tImport Namespace :{0} Import Location :{1} "
                                                ,myImports[i].Namespace
                                                ,myImports[i].Location);