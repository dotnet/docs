      // Get the operating system version.
      OperatingSystem os = Environment.OSVersion;
      Version ver = os.Version;
      Console.WriteLine("Operating System: {0} ({1})", os.VersionString, ver.ToString());