        ' Provide a design-time caption for the panel.
        Public Overrides ReadOnly Property FrameCaption() As String
            Get
                ' If the FrameCaption is empty, use the panel control ID.
                Dim localCaption As String = MyBase.FrameCaption
                If localCaption Is Nothing Or localCaption = "" Then
                    localCaption = CType(Component, Panel).ID.ToString()
                End If

                Return localCaption
            End Get
        End Property ' FrameCaption