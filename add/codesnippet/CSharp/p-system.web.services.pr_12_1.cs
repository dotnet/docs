      if(message.OneWay)
         myStreamWriter.WriteLine(
            "The method invoked on the client shall not wait"
            + " till the server finishes");
      else
         myStreamWriter.WriteLine(
            "The method invoked on the client shall wait"
            + " till the server finishes");