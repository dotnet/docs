void R1_ItemCommand(Object Sender, RepeaterCommandEventArgs e) {        
    Label2.Text = "The " + ((Button)e.CommandSource).Text + " button has just been clicked; <br>";
 }
    