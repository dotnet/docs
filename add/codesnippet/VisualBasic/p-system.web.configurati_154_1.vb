         ' Get the current ServerErrorMessageFile property value.
            Dim srvErrMsgFile As String = _
            processModelSection.ServerErrorMessageFile
         
         ' Set the ServerErrorMessageFile property to
         ' "custommessages.log".
            processModelSection.ServerErrorMessageFile = _
            "custommessages.log"
         