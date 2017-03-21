   public override void Commit(IDictionary savedState)
   {
      base.Commit(savedState);
      Console.WriteLine("Commit ...");
      // Throw an error if a particular file doesn't exist.
      if(!File.Exists("FileDoesNotExist.txt"))
         throw new InstallException();
      // Perform the final installation if the file exists.
   }