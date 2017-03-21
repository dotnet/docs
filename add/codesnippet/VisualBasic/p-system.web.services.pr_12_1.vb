      If message.OneWay Then
         myStreamWriter.WriteLine( _
            "The method invoked on the client shall not wait" & _
            " till the server finishes")
      Else
         myStreamWriter.WriteLine( _
            "The method invoked on the client shall wait" & _
            " till the server finishes")
      End If