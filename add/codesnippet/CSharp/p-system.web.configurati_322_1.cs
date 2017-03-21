      // Get the MinFreeThreads property value.
      Response.Write("MinFreeThreads: " +
        configSection.MinFreeThreads + "<br>");

      // Set the MinFreeThreads property value to 16
      configSection.MinFreeThreads = 16;