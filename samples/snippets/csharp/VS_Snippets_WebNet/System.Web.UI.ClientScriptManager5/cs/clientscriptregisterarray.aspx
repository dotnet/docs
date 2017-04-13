<!-- <Snippet1> -->
<%@ Page Language="C#"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
 
  public void Page_Load(Object sender, EventArgs e)
  {
    // Define the array name and values.
    String arrName = "MyArray";
    String arrValue = "\"1\", \"2\", \"text\"";
    
    // Define the hidden field name and initial value.
    String hiddenName = "MyHiddenField";
    String hiddenValue = "3";
    
    // Define script name and type.
    String csname = "ConcatScript";
    Type cstype = this.GetType();
        
    // Get a ClientScriptManager reference from the Page class.
    ClientScriptManager cs = Page.ClientScript;

    // Register the array with the Page class.
    cs.RegisterArrayDeclaration(arrName, arrValue);

    // Register the hidden field with the Page class.
    cs.RegisterHiddenField(hiddenName, hiddenValue);

    // Check to see if the  script is already registered.
    if (!cs.IsClientScriptBlockRegistered(cstype, csname))
    {
      StringBuilder cstext = new StringBuilder();
      cstext.Append("<script type=\"text/javascript\"> function DoClick() {"); 
      cstext.Append("Form1.Message.value='Sum = ' + ");
      cstext.Append("(parseInt(" + arrName + "[0])+");
      cstext.Append("parseInt(" + arrName + "[1])+");
      cstext.Append("parseInt(" + Form1.Name + "." + hiddenName + ".value));} </");
      cstext.Append("script>");
      cs.RegisterClientScriptBlock(cstype, csname, cstext.ToString(), false);
    }
  }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ClientScriptManager Example</title>
  </head>
  <body>
     <form    id="Form1"
            runat="server">
     <input type="text"
            id="Message" />
     <input type="button" 
            onclick="DoClick()" 
            value="Run Script" />
     </form>
  </body>
</html>
<!-- </Snippet1> -->