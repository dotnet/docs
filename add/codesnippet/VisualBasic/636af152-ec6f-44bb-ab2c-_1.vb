        ' The collection of AutoFormat objects for the IndentLabel object
        Public Overrides ReadOnly Property AutoFormats() As DesignerAutoFormatCollection
            Get
                If _autoFormats Is Nothing Then
                    ' Create the collection
                    _autoFormats = New DesignerAutoFormatCollection()

                    ' Create and add each AutoFormat object
                    _autoFormats.Add(New IndentLabelAutoFormat("MyClassic"))
                    _autoFormats.Add(New IndentLabelAutoFormat("MyBright"))
                    _autoFormats.Add(New IndentLabelAutoFormat("Default"))
                End If

                Return _autoFormats
            End Get
        End Property