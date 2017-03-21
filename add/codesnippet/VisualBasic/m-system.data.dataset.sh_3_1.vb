Public Class DerivedDataSet
    Inherits System.Data.DataSet
    
    Public Sub ResetDataSetRelations()
        ' Check the ShouldSerializeRelations methods 
        ' before invoking Reset.
        If Not Me.ShouldSerializeRelations() Then
            Me.Reset()
        End If
    End Sub
End Class