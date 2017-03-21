      // Get the MinLocalRequestFreeThreads property value.
      Response.Write("MinLocalRequestFreeThreads: " +
        configSection.MinLocalRequestFreeThreads + "<br>");

      // Set the MinLocalRequestFreeThreads property value to 8.
      configSection.MinLocalRequestFreeThreads = 8;