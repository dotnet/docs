' <Snippet2>
Namespace ASPSample

    Public Class Product
        Private _Model As String
        Private _UnitPrice As Double

        ' The product Model.
        Public Property Model() As String
            Get
                Return _Model
            End Get
            Set(ByVal Value As String)
                _Model = Value
            End Set
        End Property

        ' The price of the each product.
        Public Property UnitPrice() As Double
            Get
                Return _UnitPrice
            End Get
            Set(ByVal Value As Double)
                _UnitPrice = Value
            End Set
        End Property


        Public Sub New(ByVal Model As String, ByVal UnitPrice As Double)
            _Model = Model
            _UnitPrice = UnitPrice
        End Sub

    End Class

End Namespace
' </Snippet2>