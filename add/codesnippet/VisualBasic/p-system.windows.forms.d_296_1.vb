    Private Sub WriteMappingNames()
        Dim dgt As DataGridTableStyle
        For Each dgt In  myDataGrid.TableStyles
            Console.WriteLine(dgt.MappingName)
            Dim dgc As DataGridColumnStyle
            For Each dgc In  dgt.GridColumnStyles
                Console.WriteLine(dgc.MappingName)
            Next dgc
        Next dgt
    End Sub 'WriteMappingNames