   public override void Uninstall(IDictionary savedState)
   {
      base.Uninstall(savedState);
      Console.WriteLine("UnInstall ...");
      // Throw an error if a particular file doesn't exist.
      if(!File.Exists("FileDoesNotExist.txt"))
         throw new InstallException("The file 'FileDoesNotExist'" +
            " does not exist");
      // Perform the uninstall activites if the file exists.
   }