
      ' Receive the host home page content and loop until all the data is received.

      'Dim bytes As Int32 = s.Receive(RecvBytes, RecvBytes.Length, 0)
      Dim bytes As Int32 = s.Receive(RecvBytes, RecvBytes.Length, 0)

      strRetPage = "Default HTML page on " + server + ":\r\n"
      strRetPage = "Default HTML page on " + server + ":" + ControlChars.Lf + ControlChars.NewLine

      Dim i As Integer

      While bytes > 0

        bytes = s.Receive(RecvBytes, RecvBytes.Length, 0)

        strRetPage = strRetPage + ASCII.GetString(RecvBytes, 0, bytes)

      End While
