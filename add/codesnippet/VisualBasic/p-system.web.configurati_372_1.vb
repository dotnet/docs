      ' Get the current EnableKernelOutputCache property value.
      Response.Write("EnableKernelOutputCache: " & _
        configSection.EnableKernelOutputCache & "<br>")

      ' Set the EnableKernelOutputCache property to true.
      configSection.EnableKernelOutputCache = True