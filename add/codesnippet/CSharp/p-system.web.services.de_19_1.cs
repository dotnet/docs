   // Creates an Import object with namespace and location.
   public static Import CreateImport(string targetNamespace, 
      string targetlocation)
   {
      Import myImport = new Import();
      myImport.Location = targetlocation;
      myImport.Namespace = targetNamespace;
      return myImport;
   }