        ' Override the Initialize method to ensure that
        ' only an instance of the SimpleDataList class is
        ' used by this designer class.
        Public Overrides Sub Initialize(ByVal component As IComponent)
            simpleList = CType(component, SimpleDataList)

            If IsNothing(simpleList) Then
                Throw New ArgumentException("Must be a SimpleDataList.", "component")
            End If

            MyBase.Initialize(component)
        End Sub