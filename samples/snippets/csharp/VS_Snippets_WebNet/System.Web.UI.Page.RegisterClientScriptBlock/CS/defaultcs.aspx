<!-- <Snippet1> -->
<%@ Page Language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  public void Page_Load(Object sender, EventArgs e)
  {
    String csname1 = "PopupScript";
    String csname2 = "ButtonClickScript";

    if (!IsClientScriptBlockRegistered(csname1))
    {
        String cstext1 = "<script type=\"text/javascript\">" +
            "alert('Hello World');</" + "script>";
        RegisterStartupScript(csname1, cstext1);
    }

    if (!IsClientScriptBlockRegistered(csname2))
    {
      StringBuilder cstext2 = new StringBuilder();
      cstext2.Append("<script type=\"text/javascript\"> function DoClick() {");
      cstext2.Append("Form1.Message.value='Text from client script.'} </");
      cstext2.Append("script>");
      RegisterClientScriptBlock(csname2, cstext2.ToString());
    }
  }
</script>
<html  >
  <head>
    <title>RegisterClientScriptBlock Example</title>
  </head>
  <body>
     <form id="Form1"
         runat="server">
        <input type="text" id="Message" /> <input type="button" value="ClickMe" onclick="DoClick()" />
     </form>
  </body>
</html>

<!-- </Snippet1> -->