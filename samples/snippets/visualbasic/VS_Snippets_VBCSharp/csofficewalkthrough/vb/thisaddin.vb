
'<snippet1>
Imports Microsoft.Office.Interop
'</snippet1>

Public Class ThisAddIn

    Private Sub ThisAddIn_Startup() Handles Me.Startup
        '<snippet3>
        Dim bankAccounts As New List(Of Account) From {
            New Account With {
                                  .ID = 345,
                                  .Balance = 541.27
                             },
            New Account With {
                                  .ID = 123,
                                  .Balance = -127.44
                             }
            }
        '</snippet3>

        '<snippet9>
        DisplayInExcel(bankAccounts,
               Sub(account, cell)
                   ' This multiline lambda expression sets custom
                   ' processing rules for the bankAccounts.
                   cell.Value = account.ID
                   cell.Offset(0, 1).Value = account.Balance

                   If account.Balance < 0 Then
                       cell.Interior.Color = RGB(255, 0, 0)
                       cell.Offset(0, 1).Interior.Color = RGB(255, 0, 0)
                   End If
               End Sub)
        '</snippet9>

    '<snippet10>
        Dim wordApp As New Word.Application
        wordApp.Visible = True
        wordApp.Documents.Add()
        wordApp.Selection.PasteSpecial(Link:=True, DisplayAsIcon:=True)
        '</snippet10>
    End Sub

    '<snippet4>
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
    '</snippet4>

    Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown

    End Sub

    Public Sub Pieces(ByVal accounts As IEnumerable(Of Account),
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

            '<snippet7>
            ' Add the following two lines at the end of the With statement.
            .Columns(1).AutoFit()
            .Columns(2).AutoFit()
            '</snippet7>
        End With
    End Sub

End Class
