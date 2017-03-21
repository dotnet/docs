      Sub Page_Load(sender As Object, e As System.EventArgs)
         DataBind()
         ' Set EnableViewState to false to disable saving of view state 
         ' information.
         myControl.EnableViewState = False
         If Not IsPostBack Then
            display.Enabled = False
         End If 
      End Sub