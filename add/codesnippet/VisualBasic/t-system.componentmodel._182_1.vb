        ' Adds a property to this designer's control at design time 
        ' that indicates the outline color to use.
        ' The DesignOnlyAttribute ensures that the OutlineColor
        ' property is not serialized by the designer.
        Protected Overrides Sub PreFilterProperties(ByVal properties As System.Collections.IDictionary)
            Dim pd As PropertyDescriptor = TypeDescriptor.CreateProperty( _
            GetType(ExampleControlDesigner), _
            "OutlineColor", _
            GetType(System.Drawing.Color), _
            New Attribute() {New DesignOnlyAttribute(True)})

            properties.Add("OutlineColor", pd)
        End Sub