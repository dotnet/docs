        Public Overrides Sub Initialize(ByVal component As IComponent)

            simpleGView = CType(component, SimpleGridView)

            MyBase.Initialize(component)

        End Sub