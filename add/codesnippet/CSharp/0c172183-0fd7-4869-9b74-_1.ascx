    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox3.Text != null)
        {
            PersonalizationStateInfoCollection findresult;
          findresult = PersonalizationAdministration.FindUserState(null, TextBox3.Text);
          if (findresult.Count != 0)
          {
              Label4.Text = findresult.Count + "  user(s) found";
              Label4.Visible = true;
          }
          else
          {
              Label4.Text = "No users found.";
              Label4.Visible = true;
          }
        }
      else
      {
          Label4.Text = "You must enter a user name to find.";
      }

    }