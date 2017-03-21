private void Button1_Click(object sender, EventArgs MyEventArgs)
{
      // Find control on page.
      Control myControl1 = FindControl("TextBox2");
      if(myControl1!=null)
      {
         // Get control's parent.
         Control myControl2 = myControl1.Parent;
         Response.Write("Parent of the text box is : " + myControl2.ID);
      }
      else
      {
         Response.Write("Control not found");
      }
}