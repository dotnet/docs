Private Sub SetBorderStyle(ByRef myGrid As DataGrid, ByRef style As Integer)
    Select Case style
    Case 0
       myGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
    Case 1
       myGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Case 2 
       myGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Case Else
       myGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
    End Select
 End Sub
    