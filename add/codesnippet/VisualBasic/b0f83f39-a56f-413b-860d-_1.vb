        ' Shadow the control properties with design-time properties.
        Protected Overrides Sub PreFilterProperties( _
            ByVal properties As IDictionary)

            Dim namingContainer As String = "NamingContainer"

            ' Call the base method first.
            MyBase.PreFilterProperties(properties)

            ' Make the NamingContainery visible in the Properties grid.
            Dim selectProp As PropertyDescriptor = _
                CType(properties(namingContainer), PropertyDescriptor)
            properties(namingContainer) = _
                TypeDescriptor.CreateProperty(selectProp.ComponentType, _
                    selectProp, BrowsableAttribute.Yes)
        End Sub ' PreFilterProperties