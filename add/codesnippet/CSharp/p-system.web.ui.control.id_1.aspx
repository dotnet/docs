void Page_Init(object sender,EventArgs e)
{
   // Add a event Handler for 'Init'.
   myControl.Init += new System.EventHandler(Control_Init);
}

void Control_Init(object sender,EventArgs e)
{ 
  Response.Write("The ID of the object initially : " + myControl.ID);      
  // Change the ID property.
   myControl.ID="TestControl";
   Response.Write("<br />The changed ID : " + myControl.ID);
}