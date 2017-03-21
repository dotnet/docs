      protected override object SaveViewState()
      {  // Change Text Property of Label when this function is invoked.
         if(HasControls() && (Page.IsPostBack))
         {
            ((Label)(Controls[0])).Text = "Custom Control Has Saved State";
         }
         // Save State as a cumulative array of objects.
         object baseState = base.SaveViewState();
         string userText = UserText;
         string passwordText = PasswordText;
         object[] allStates = new object[3];
         allStates[0] = baseState;
         allStates[1] = userText;
         allStates[2] = PasswordText;
         return allStates;
      }