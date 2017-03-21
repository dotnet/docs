        Public Overrides Sub Initialize(ByVal Component As IComponent)
            ' Initialize the base
            MyBase.Initialize(Component)
            ' Turn on template editing
            SetViewFlags(ViewFlags.TemplateEditing, True)
        End Sub