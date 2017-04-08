<%--
    The following program demonstrates the 'RegisterHiddenField' and 
    'RegisterOnSubmitStatement methods of 'Page' class.
    
    The program forms a client side script for hidden field and submit button and a 
    script which display the content of hidden field when page load    event occurs. 
    Prints hidden field value and a message.
--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="VB" runat="server">
   Sub Page_Load(Sender As Object, e As EventArgs ) 

' <Snippet1>    
' <Snippet2>    
   
        Dim scriptString As String = "<script language=""JavaScript""> function doClick() {"
   scriptString += "document.write('<h4>' + myForm.myHiddenField.value+ '</h4>');}<"
   scriptString += "/" + "script>"
      
   RegisterHiddenField("myHiddenField", "Welcome to Microsoft!")
   
   RegisterOnSubmitStatement("submit", "document.write('<h4>Submit button clicked.</h4>')")
   
   RegisterStartupScript("startup", scriptString)
' </Snippet2>    
' </Snippet1>    
End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
    <title>' + myForm.myHiddenField.value+ '</title>
</head>
    <body>
        <form method="post" runat="server" id="myForm">
            <h4>
                Page Example
            </h4>
            <input type="Button" value="Display hidden field value" onclick="doClick()" />
         <input type="submit" value="Submit" />
        </form>
    </body>
</html>
