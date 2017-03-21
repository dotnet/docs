        Public Overrides Sub Initialize(ByVal component As IComponent)

            ' Ensure that only a MyMenu can be created in this designer. 
            If Not TypeOf component Is MyMenu Then
                Throw New ArgumentException( _
                    "The component is not a MyMenu control.")
            End If

            MyBase.Initialize(component)

        End Sub ' Initialize