  // Retrieve and display the 'Message' attribute tag 
  // initialized in the .aspx code.
  Response.Write("<b>Message tag value declared in the aspx file is : </b>" + myControl.Attributes["Message"]);