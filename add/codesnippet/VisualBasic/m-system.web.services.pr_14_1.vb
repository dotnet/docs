    Public Overrides Function ChainStream(stream As Stream) As Stream
        m_oldStream = stream
        m_newStream = New MemoryStream()
        Return m_newStream
    End Function