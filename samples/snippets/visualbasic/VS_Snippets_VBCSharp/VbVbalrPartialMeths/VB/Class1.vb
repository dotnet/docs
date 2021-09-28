' *************************************************************

Option Infer On

'<Snippet6>
Module Module1

    Sub Main()
        Dim product1 As New Product With {.Quantity = 100}
    End Sub

End Module
'</Snippet6>


' *****************************************************
' From file ProductDesigner

'<Snippet4>
Partial Class Product

    Private _Quantity As Integer

    Property Quantity() As Integer
        Get
            Return _Quantity
        End Get
        Set(ByVal value As Integer)
            _Quantity = value
            QuantityChanged()
        End Set
    End Property

    ' Provide a signature for the partial method.
    Partial Private Sub QuantityChanged()
    End Sub
End Class
'</Snippet4>


' *********************************************************
' From File Product

'<Snippet5>
Partial Class Product

    Private Sub QuantityChanged()
        MsgBox("Quantity was changed to " & Me.Quantity)
    End Sub

End Class
'</Snippet5>

