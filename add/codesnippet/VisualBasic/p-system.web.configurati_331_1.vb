      ' Get the ShutdownTimeout property value.
      Response.Write("ShutdownTimeout: " & _
        configSection.ShutdownTimeout.ToString() & "<br>")

      ' Set the ShutdownTimeout property value to 2 minutes.
      configSection.ShutdownTimeout = TimeSpan.FromMinutes(2)