      FrameworkName supportedVer1 = new FrameworkName(".NET Framework, Version=4.0");
      FrameworkName actualVersion = new FrameworkName(String.Format(
                                                 ".NET Framework, Version={0}", 
                                                 Environment.Version.ToString()));
                                                 
      Console.WriteLine("Supported Version: {0}", supportedVer1);
      Console.WriteLine("Actual Version:    {0}", actualVersion);
      if (supportedVer1 != actualVersion)    
         Console.WriteLine("The supported and actual Framework versions are different.");
      else
         Console.WriteLine("The supported and actual Framework versions are the same.");

      Console.WriteLine();
      // The example displays the following output:
      //       The supported and actual Framework versions are different.       