      ' Get the MaxRequestLength property value.
      Response.Write("MaxRequestLength: " & _
        configSection.MaxRequestLength & "<br>")

      ' Set the MaxRequestLength property value to 2048 kilobytes.
      configSection.MaxRequestLength = 2048