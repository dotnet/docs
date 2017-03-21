Public Class DerivedDataSet
    Inherits System.Data.DataSet
    
    Public Sub ResetDataSetRelations()
        ' Check the ShouldPersistTable method 
        ' before invoking Reset.
        If Not Me.ShouldSerializeTables() Then
            Me.Reset()
        End If
    End Sub
End Class