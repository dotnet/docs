      ' Get the WaitChangeNotification property value.
      Response.Write("WaitChangeNotification: " & _
        configSection.WaitChangeNotification & "<br>")

      ' Set the WaitChangeNotification property value to 10 seconds.
      configSection.WaitChangeNotification = 10