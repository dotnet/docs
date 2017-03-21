      ' Get the operating system version.
      Dim os As OperatingSystem = Environment.OSVersion
      Dim ver As Version = os.Version
      Console.WriteLine("Operating System: {0} ({1})", os.VersionString, ver.ToString())