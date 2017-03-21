      protected override void LoadViewState(object savedState) 
      {
         if (savedState != null)
         {
            // Load State from the array of objects that was saved at ;
            // SavedViewState.
            object[] myState = (object[])savedState;
            if (myState[0] != null)
               base.LoadViewState(myState[0]);
            if (myState[1] != null)
               UserText = (string)myState[1];
            if (myState[2] != null)
               PasswordText = (string)myState[2];
         }
      }