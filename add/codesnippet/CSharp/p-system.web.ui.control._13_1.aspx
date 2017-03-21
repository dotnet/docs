void Page_Load(object sender, System.EventArgs e)
{
      DataBind();
      // Set EnableViewState to false to disable saving of view state 
      // information.
      myControl.EnableViewState = false;
      if (!IsPostBack)
         display.Enabled = false;
      
}