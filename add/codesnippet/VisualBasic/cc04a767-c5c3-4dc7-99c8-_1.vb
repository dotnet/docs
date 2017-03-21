        Public Sub New(ByVal component As IComponent)

            MyBase.New(component)
            Me.colLabel = component

            ' Cache a reference to DesignerActionUIService, so the
            ' DesigneractionList can be refreshed.
            Me.designerActionUISvc = _
            CType(GetService(GetType(DesignerActionUIService)), _
            DesignerActionUIService)

        End Sub