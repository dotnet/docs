    Class Class1
        ' Define a local variable to store the property value.
        Private propertyValue As String
        ' Define the property.
        Public Property prop1() As String
            Get
                ' The Get property procedure is called when the value
                ' of a property is retrieved.
                Return propertyValue
            End Get
            Set(ByVal value As String)
                ' The Set property procedure is called when the value 
                ' of a property is modified.  The value to be assigned
                ' is passed in the argument to Set.
                propertyValue = value
            End Set
        End Property
    End Class