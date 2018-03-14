using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public class LogOnControl:UserControl
{
   protected TextBox user;
   protected TextBox password;
// <Snippet1>  
// <Snippet2>
   public string UserText
   {
	   get
	   {
		   return (string)ViewState["usertext"];
	   }
	   set
	   {
		   ViewState["usertext"] = value;
	   }
   }
   public string PasswordText
   {
	   get
	   {
		   return (string)ViewState["passwordtext"];
	   }
	   set
	   {
		   ViewState["passwordtext"] = value;
	   }
   }

   [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
   protected override void LoadViewState(object savedState) 
   {
	   object[] totalState = null;	   
	   if (savedState != null)
	   {
		   totalState = (object[])savedState;
		   if (totalState.Length != 3)
		   {
			   // Throw an appropriate exception.
		   }
		   // Load base state.
		   base.LoadViewState(totalState[0]);
		   // Load extra information specific to this control.
		   if (totalState != null && totalState[1] != null && totalState[2] != null)
		   {
			   UserText = (string)totalState[1];
			   PasswordText = (string)totalState[2];
		   }
	   }

   }

   [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
   protected override object SaveViewState()
   {
	   object baseState = base.SaveViewState();
	   object[] totalState = new object[3];
	   totalState[0] = baseState;
	   totalState[1] = user.Text;
	   totalState[2] = password.Text;
	   return totalState;
   }
// </Snippet2>  
// </Snippet1>
}
