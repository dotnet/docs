        Public Overrides Sub Initialize(ByVal component As IComponent)

            ' Ensure that only a SimpleRadioButtonList can be created 
            ' in this designer.
            Debug.Assert( _
                TypeOf component Is SimpleRadioButtonList, _
                "An invalid SimpleRadioButtonList control was initialized.")

            simpleRadioButtonList = CType(component, SimpleRadioButtonList)
            MyBase.Initialize(component)
        End Sub ' Initialize