Private Sub RemoveCol(ByVal dc As DataColumn) 
    Dim myGridColumns As GridColumnStylesCollection
    myGridColumns = DataGrid1.TableStyles(0).GridColumnStyles

    If myGridColumns.Contains("FirstName") Then
        Dim i As Integer
        i = myGridColumns.IndexOf(myGridColumns("FirstName"))
        myGridColumns.RemoveAt(i)
    End If
End Sub 