      // Get the MaxRequestLength property value.
      Response.Write("MaxRequestLength: " +
        configSection.MaxRequestLength + "<br>");

      // Set the MaxRequestLength property value to 2048 kilobytes.
      configSection.MaxRequestLength = 2048;