    ' Create an event for this user control
    Public Event myControl As System.EventHandler

    ' Override the default constructor.
    Protected Overrides Sub Construct()
        ' Specify the handler for the OnInit method.
        AddHandler Me.myControl, AddressOf MyInit
    End Sub

    Protected Overrides Sub OnInit(ByVal e As EventArgs)
        RaiseEvent myControl(Me, e)
        Response.Write("The OnInit() method is used to raise the Init event.")
    End Sub
   
   
    ' Use the MyInit handler to set the Message property
    Sub MyInit(ByVal sender As Object, ByVal e As System.EventArgs)
        Message = "Hello World!"
    End Sub
   