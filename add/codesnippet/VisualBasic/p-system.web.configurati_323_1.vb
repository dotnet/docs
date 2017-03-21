      ' Get the RequestLengthDiskThreshold property value.
      Response.Write("RequestLengthDiskThreshold: " & _
        configSection.RequestLengthDiskThreshold & "<br>")

      ' Set the RequestLengthDiskThreshold property value to 512 bytes.
      configSection.RequestLengthDiskThreshold = 512