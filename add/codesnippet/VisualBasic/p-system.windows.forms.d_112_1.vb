Private Sub SetAlign()
   Dim myColumnStyle As DataGridColumnStyle 
   For each myColumnStyle In dataGrid1.TableStyles("Customers"). _
   GridColumnStyles
      myColumnStyle.Alignment = HorizontalAlignment.Center
   Next
End Sub
