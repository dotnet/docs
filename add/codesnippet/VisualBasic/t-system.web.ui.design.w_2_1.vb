        ' Shadow control properties with design time properties.
        Protected Overrides Sub PreFilterProperties(ByVal properties As IDictionary)

            ' Call the base class method first.
            MyBase.PreFilterProperties(properties)

            ' Add the ConnectionString property to the property grid.
            Dim prop As PropertyDescriptor
            prop = CType(properties("ConnectionString"), PropertyDescriptor)

           Dim atts(1) As Attribute
            atts(0) = New BrowsableAttribute(True)
            atts(1) = New ReadOnlyAttribute(True)

            properties("ConnectionString") = TypeDescriptor.CreateProperty( _
                prop.GetType(), prop, atts)
        End Sub