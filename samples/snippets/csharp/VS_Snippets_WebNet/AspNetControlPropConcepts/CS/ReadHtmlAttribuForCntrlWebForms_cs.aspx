<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Read HTML Attributes for Controls in Web Forms Pages (C#)</title>
</head>
<script runat="server">
    
    private void Page_Load()
    {
       //<Snippet6> 
        Response.Write(Button1.Attributes[("Style")] + "<br />");
        
        //String key;
        
        foreach ( String key in Button1.Attributes.Keys)
        {
            Response.Write(key + "=" + Button1.Attributes[key] + "<br />");
        }
            
        foreach ( String key in Submit1.Attributes.Keys)
        {
            Response.Write(key + "=" + Submit1.Attributes[key] + "<br />");
        }
        //</Snippet6>
                      
      }
      
    
</script>

<body>
    <form id="form1" runat="server">
      <asp:Button id="Button1" runat="server" />
      <asp:Button id ="Submit1" runat="server" />
    </form>
</body>
</html>
