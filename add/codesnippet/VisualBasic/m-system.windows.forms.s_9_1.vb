
    ' Clicking Button1 causes a message box to appear.
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click
        MessageBox.Show("Click here!")
    End Sub


    ' Use the SendKeys.Send method to raise the Button1 click event 
    ' and display the message box.
    Private Sub Form1_DoubleClick(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.DoubleClick

        ' Send the enter key; since the tab stop of Button1 is 0, this
        ' will trigger the click event.
        SendKeys.Send("{ENTER}")
    End Sub