void Page_Load(Object sender, EventArgs e) 
{ 
   String scriptString = "<script language=\"JavaScript\"> function doClick() {";
   scriptString += "document.write('<h4>' + myForm.myHiddenField.value+ '</h4>');}<";
   scriptString += "/" + "script>";
      
   RegisterHiddenField("myHiddenField", "Welcome to Microsoft!"); 
   
   RegisterOnSubmitStatement("submit", "document.write('<h4>Submit button clicked.</h4>')"); 
   
   RegisterStartupScript("startup", scriptString);
} 