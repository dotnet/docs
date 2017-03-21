 
      // Receive the host home page content and loop until all the data is received.
      Int32 bytes = s.Receive(RecvBytes, RecvBytes.Length, 0);
      strRetPage = "Default HTML page on " + server + ":\r\n";
      strRetPage = strRetPage + ASCII.GetString(RecvBytes, 0, bytes);
 
      while (bytes > 0)
      {
        bytes = s.Receive(RecvBytes, RecvBytes.Length, 0);
        strRetPage = strRetPage + ASCII.GetString(RecvBytes, 0, bytes);
      }
