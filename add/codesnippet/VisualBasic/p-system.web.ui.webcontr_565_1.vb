        ' Returns a strongly-typed reference to the MyDataBound control.
        Public Shadows ReadOnly Property Control() As MyDataBound
            Get
                Return CType(MyBase.Control, MyDataBound)
            End Get
        End Property