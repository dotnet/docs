        ' Initialize the designer.
        Public Overrides Sub Initialize(ByVal component As IComponent)

            ' Ensure that only a MyPanelContainer can be created   
            ' in this designer. 
            If Not TypeOf component Is MyPanelContainer Then
                Throw New ArgumentException()
            End If

            MyBase.Initialize(component)

        End Sub ' Initialize