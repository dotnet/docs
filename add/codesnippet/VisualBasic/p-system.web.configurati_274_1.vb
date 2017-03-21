      ' Get the ExecutionTimeout property value.
      Response.Write("ExecutionTimeout: " & _
        configSection.ExecutionTimeout.ToString() & "<br>")

      ' Set the ExecutionTimeout property value to 2 minutes.
      configSection.ExecutionTimeout = TimeSpan.FromMinutes(2)