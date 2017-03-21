Sub Page_Init(sender As Object, e As EventArgs)
   ' Add a event Handler for 'Init'.
   AddHandler myControl.Init, AddressOf Control_Init
End Sub

Sub Control_Init(sender As Object, e As EventArgs)
   Response.Write(("The ID of the object initially : " + myControl.ID))
   ' Change the ID property.
   myControl.ID = "TestControl"
   Response.Write(("<br />The changed ID : " + myControl.ID))
End Sub