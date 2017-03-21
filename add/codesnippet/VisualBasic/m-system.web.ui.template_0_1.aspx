    Sub Page_Load(ByVal Sender As Object, ByVal e As EventArgs)
        ' Obtain a UserControl object MyControl from the
        ' user control file TempControl_Samples1.ascx.vb
        Dim myControl1 As MyControl = CType(LoadControl("TempControl_Samples1.vb.ascx"), MyControl)
        Controls.Add(myControl1)
    End Sub