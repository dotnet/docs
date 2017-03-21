      ' Get the AppRequestQueueLimit property value.
      Response.Write("AppRequestQueueLimit: " & _
        configSection.AppRequestQueueLimit & "<br>")

      ' Set the AppRequestQueueLimit property value to 4500.
      configSection.AppRequestQueueLimit = 4500