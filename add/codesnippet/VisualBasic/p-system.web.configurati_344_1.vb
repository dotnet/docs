      ' Get the current MaxWaitChangeNotification property value.
      Response.Write("MaxWaitChangeNotification: " & _
        configSection.MaxWaitChangeNotification & "<br>")

      ' Set the MaxWaitChangeNotification property value to 10 seconds.
      configSection.MaxWaitChangeNotification = 10