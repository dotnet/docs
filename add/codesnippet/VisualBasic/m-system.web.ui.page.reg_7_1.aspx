   
        Dim scriptString As String = "<script language=""JavaScript""> function doClick() {"
   scriptString += "document.write('<h4>' + myForm.myHiddenField.value+ '</h4>');}<"
   scriptString += "/" + "script>"
      
   RegisterHiddenField("myHiddenField", "Welcome to Microsoft!")
   
   RegisterOnSubmitStatement("submit", "document.write('<h4>Submit button clicked.</h4>')")
   
   RegisterStartupScript("startup", scriptString)