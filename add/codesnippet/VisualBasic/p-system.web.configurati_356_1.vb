      ' Get the UseFullyQualifiedRedirectUrl property value.
      Response.Write("UseFullyQualifiedRedirectUrl: " & _
        configSection.UseFullyQualifiedRedirectUrl & "<br>")

      ' Set the UseFullyQualifiedRedirectUrl property value set to true.
      configSection.UseFullyQualifiedRedirectUrl = True