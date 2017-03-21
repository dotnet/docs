        ' Generate the design time markup.
        Public Overrides Sub Initialize(ByVal component As IComponent)

            ' Ensure that only a MyLoginView can be created in this designer. 
            If Not TypeOf component Is MyLoginView Then
                Throw New ArgumentException()
            End If

            ' Call the base method to generate the markup.
            MyBase.Initialize(component)

        End Sub ' Initialize