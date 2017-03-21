        ' Saves state information which is used by display handler after the postback has occured.

        Sub SubmitBtn_Click(Sender As Object, e As EventArgs) 

            ' Clear all values from session state of 'Page'.
            Session.Clear()

            ' Populate Session State of UserControl with the values entered by user.
            myControl.Session.Add("username",myControl.user.Text)
            myControl.Session.Add("password",myControl.password.Text)

            ' Add UserControl state to the SessionState object of Page.
            Session(myControl.user.Text)= myControl
            Display.Enabled = true
        End Sub

        Sub Display_Click(Sender As Object,e As EventArgs)

            Dim position As Integer = Session.Count - 1

            ' Extract stored UserControl from the session state of page.
            Dim tempControl As LogOnControl = CType(Session(Session.Keys(position)),LogOnControl)

            ' Use SessionState of UserControl to display previously typed information.
            txtSession.Text = "<br /><br />User:" + tempControl.Session("username") + "<br />Password : " + tempControl.Session("password")
            Display.Enabled = false
        End Sub