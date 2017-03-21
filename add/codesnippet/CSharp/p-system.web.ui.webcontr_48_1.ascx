            PersonalizationStateInfoCollection findresult;
          findresult = PersonalizationAdministration.FindUserState(null, TextBox3.Text);
          if (findresult.Count != 0)
          {
              Label4.Text = findresult.Count + "  user(s) found";
              Label4.Visible = true;
          }