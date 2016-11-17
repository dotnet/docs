    Sub DisplayInExcel(ByVal accounts As IEnumerable(Of Account),
                   ByVal DisplayAction As Action(Of Account, Excel.Range))

        With Me.Application
            ' Add a new Excel workbook.
            .Workbooks.Add()
            .Visible = True
            .Range("A1").Value = "ID"
            .Range("B1").Value = "Balance"
            .Range("A2").Select()

            For Each ac In accounts
                DisplayAction(ac, .ActiveCell)
                .ActiveCell.Offset(1, 0).Select()
            Next

            ' Copy the results to the Clipboard.
            .Range("A1:B3").Copy()
        End With
    End Sub