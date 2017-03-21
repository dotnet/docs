                // Save state information which is used by display handler after the postback has occured.
                void SubmitBtn_Click(Object sender, EventArgs e) 
                {
                  // Clear all values from session state of 'Page'.
                  Session.Clear();

                  // Populate Session State of UserControl with the values entered by user.
                  myControl.Session.Add("username",myControl.user.Text);
                  myControl.Session.Add("password",myControl.password.Text);

                  // Add UserControl state to the SessionState object of Page.
                  Session[myControl.user.Text]= myControl;
                  display.Enabled = true;
                }

                void Display_Click(Object sender, EventArgs e)
                {
                  int position = Session.Count - 1;

                  // Extract stored UserControl from the session state of page.
                  LogOnControl tempControl = (LogOnControl)Session[Session.Keys[position]];

                  // Use SessionState of UserControl to display previously typed information.
                  txtSession.Text = "<br /><br />User:" + tempControl.Session["username"] + "<br />Password : " + tempControl.Session["password"];
                  display.Enabled = false;
                }