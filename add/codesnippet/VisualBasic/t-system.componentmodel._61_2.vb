        Public Overrides ReadOnly Property ActionLists() _
        As DesignerActionListCollection
            Get
                If lists Is Nothing Then
                    lists = New DesignerActionListCollection()
                    lists.Add( _
                    New ColorLabelActionList(Me.Component))
                End If
                Return lists
            End Get
        End Property