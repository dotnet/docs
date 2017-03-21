        'Boolean properties are automatically displayed with binary 
        ' UI (such as a checkbox).
        Public Property LockColors() As Boolean
            Get
                Return colLabel.ColorLocked
            End Get
            Set(ByVal value As Boolean)
                GetPropertyByName("ColorLocked").SetValue(colLabel, value)

                ' Refresh the list.
                Me.designerActionUISvc.Refresh(Me.Component)
            End Set
        End Property