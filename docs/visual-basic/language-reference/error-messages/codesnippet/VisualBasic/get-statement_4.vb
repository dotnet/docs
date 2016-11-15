    Class propClass
        ' Define a private local variable to store the property value.
        Private currentTime As String
        ' Define the read-only property.
        Public ReadOnly Property dateAndTime() As String
            Get
                ' The Get procedure is called automatically when the
                ' value of the property is retrieved.
                currentTime = CStr(Now)
                ' Return the date and time As a string.
                Return currentTime
            End Get
        End Property
    End Class