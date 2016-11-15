        Private _Prop2 As String = "Empty"
        Property Prop2 As String
            Get
                Return _Prop2
            End Get
            Set(ByVal value As String)
                _Prop2 = value
            End Set
        End Property