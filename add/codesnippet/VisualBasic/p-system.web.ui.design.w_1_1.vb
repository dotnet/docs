        ' Provide a design-time border style for the panel.
        Public Overrides ReadOnly Property FrameStyle() As Style
            Get
                Dim styleOfFrame As Style = MyBase.FrameStyle

                ' If no border style is defined, define one.
                If (styleOfFrame.BorderStyle = BorderStyle.NotSet Or _
                    styleOfFrame.BorderStyle = BorderStyle.None) Then
                    styleOfFrame.BorderStyle = BorderStyle.Outset
                End If

                Return styleOfFrame
            End Get
        End Property ' FrameStyle