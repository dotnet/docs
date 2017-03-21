      ' Send data to ClientTarget.
      Console.WriteLine(ControlChars.Lf + "The ClientOriginator sent:" + ControlChars.Lf)
      Send.OriginatorSendData(clientOriginator, m_ClientTargetdest)
      
      ' Receive data from ClientTarget
      Ret = Receive.ReceiveUntilStop(clientOriginator)
      
      ' Stop the ClientTarget thread
      m_t.Abort()
      
      ' Abandon the multicast group.
      clientOriginator.DropMulticastGroup(m_GrpAddr)
      