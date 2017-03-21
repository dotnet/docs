      ' Get the RequireRootedSaveAsPath property value.
      Response.Write("RequireRootedSaveAsPath: " & _
        configSection.RequireRootedSaveAsPath & "<br>")

      ' Set the RequireRootedSaveAsPath property value to true.
      configSection.RequireRootedSaveAsPath = True