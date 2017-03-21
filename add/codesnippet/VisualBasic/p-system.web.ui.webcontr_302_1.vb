 Sub R1_ItemCommand(Sender As Object, e As RepeaterCommandEventArgs)
     Label2.Text = "The " & CType(e.CommandSource, Button).Text & _
        " button has just been clicked; <br>"
 End Sub
