Private Sub PrintTableMappingName _
(ByVal myColumnStyle As DataGridColumnStyle)
    Console.WriteLine _
    (myColumnStyle.DataGridTableStyle.MappingName)
End Sub