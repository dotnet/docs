    Private Sub Form_Paginated(ByVal sender As Object, _
        ByVal e As EventArgs)
        
        ' Set the background color based on 
        ' the number of pages
        If ActiveForm.PageCount > 1 Then
            ActiveForm.BackColor = Color.LightBlue
        Else
            ActiveForm.BackColor = Color.LightGray
        End If
        
        ' Check to see if the Footer template has been chosen
        If DevSpec.HasTemplates Then
            Dim lbl As System.Web.UI.MobileControls.Label
            
            ' Get the Footer panel
            Dim pan As System.Web.UI.MobileControls.Panel = Form1.Footer

            ' Get the Label from the panel
            lbl = CType(pan.FindControl("lblCount"), System.Web.UI.MobileControls.Label)
            ' Set the text in the Label
            lbl.Text = "Page #" + Form1.CurrentPage.ToString()
        End If
    End Sub