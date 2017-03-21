
 Private Sub SetWidth()
    Dim dgc As DataGridColumnStyle
    dgc = DataGrid1.TableStyles(0).GridColumnStyles("id")
    dgc.Width = 500
 End Sub
       