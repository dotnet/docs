// System.Web.UI.Control.LoadViewState;
// System.Web.UI.Control.SaveViewState;
// System.Web.UI.Control.HasChildViewState;
// System.Web.UI.Control.IsTrackingViewState;
// System.Web.UI.Control.TrackViewState;
// System.Web.UI.Control.DataBind;
// System.Web.UI.Control.EnableViewState

/*
   The following example demonstrates the methods 'LoadViewState',
   'SaveViewState','HasChildViewState','IsTrackingViewState','TrackViewState',
   'DataBind','EnableViewState' of 'Control' class.
   A custom control LogOnControl is created by deriving from 'Control' class.
   LogOnControl class overloads 'LoadViewState'   
   After the postback, the saved information is retrieved and displayed by 
   clicking the 'Display Saved ViewState' button.
*/

using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogOnControlSample
{
   public class LogOnControl:Control
   {
      private string userText;
      private string passwordText;
      
      public string UserText
      {
         get
         {
            return userText;
         }
         set
         {
            userText = value;
         }
         
      }
      public string PasswordText
      {
         get
         {
            return passwordText;
         }
         set
         {
            passwordText = value;
         }
      }
// <Snippet1>
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
// </Snippet1>

// <Snippet2>
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
// </Snippet2>

      // Add a Label as one of the child controls.
      protected override void CreateChildControls()
      {
         Label myLabel = new Label();
         myLabel.Text = "Custom Control";
         Controls.Add(new Label());
      }
      // Demonstrates implementation of DataBind method. 
// <Snippet3>
// <Snippet4>
// <Snippet5>
// <Snippet6>
      public override void DataBind() 
      {
         base.OnDataBinding(EventArgs.Empty);
         // Reset the control's state.
         Controls.Clear();
         // Check for HasChildViewState to avoid unnecessary calls to ClearChildViewState.
         if (HasChildViewState)
            ClearChildViewState();
         ChildControlsCreated = true;
         if (!IsTrackingViewState)
            TrackViewState();
      }
// </Snippet6>
// </Snippet5>
// </Snippet4>
// </Snippet3>
   }
}