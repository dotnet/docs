    
    Public WriteOnly Property MyProperty() As MyPropertyEnum
        Set
            ' Checks to see if the value passed is valid.
            If Not TypeDescriptor.GetConverter(GetType(MyPropertyEnum)).IsValid(value) Then
                Throw New ArgumentException()
            End If
            ' The value is valid. Insert code to set the property.
        End Set 
    End Property
    