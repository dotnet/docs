        // Create a new assembly reference.
        AssemblyInfo myAssembly = 
          new AssemblyInfo("MyAssembly, Version=1.0.0000.0, " +
          "Culture=neutral, Public KeyToken=b03f5f7f11d50a3a");
        // Add an assembly to the configuration.
        configSection.Assemblies.Add(myAssembly);