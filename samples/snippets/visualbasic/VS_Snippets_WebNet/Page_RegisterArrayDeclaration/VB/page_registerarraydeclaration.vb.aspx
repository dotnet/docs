<%--
    The following program demonstrates the 'RegisterArrayDeclaration' method of 'Page' class.
    
    The program declares and initializes an array of script based objects.When the button click event
    occurs the client side script loops through the array and executes a method on each of these 
    instances to display the names given to them.
--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="VB" runat="server">
Sub Page_Load(Sender As Object,e As EventArgs) 

' <Snippet1>    
  
        Dim scriptString As String = "<script language=""JavaScript""> function doClick() {"
   scriptString += "for(var index=0;index < myArray.length;index++)"
   scriptString += " myArray[index].show(); } <"
   scriptString += "/" + "script>"
     
   RegisterStartupScript("arrayScript", scriptString)
   RegisterArrayDeclaration("myArray", "new obj('x'),new obj('y'),new obj('z')")
' </Snippet1>    
    End Sub 
   </script>
<script type="text/javascript">
     function obj(a) {
     this.name = "This Object name is :" + a;
     this.id = a;
     this.show = new Function("showthis(this)");
     }
     function showthis(a) {
     document.write ("<h3>" + a.name + " </h3>");
     }
    </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>" + a.name + " </title>
</head>
  <body>
     <form method="post" runat="server" id="Form1">
        <input type="Button" value="Display Array elements" onclick="doClick()" />
        <br />
     </form>
  </body>
</html>
