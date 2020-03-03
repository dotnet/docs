<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!--<Snippet5>-->
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>Using the FindControl Method to Search for a Control</title>
</head>

<script language="c#" runat="server">
    
   string[] list;
    
   private void Page_Load(Object sender, EventArgs e) 
   {
     list = new string[] {"One", "Two", "Three" };
     MyRepeater.DataSource = list;
     MyRepeater.DataBind();
   }
    
   private void ChangeBtn_Click(Object sender, EventArgs e) 
   {
      Control x = MyRepeater.FindControl("_ctl0");
      if (x != null) 
      {
        list[0] = "This control was found with FindControl.";
      }
       MyRepeater.DataBind();
   }
    
    
</script>

<body>
    <form id="form1" action="repeater.aspx" method="post" runat="server">
         
         <asp:repeater id="MyRepeater" runat="server">
            <ItemTemplate>
               <span id="span1" runat="server">
                  <%# Container.DataItem %><br/>
               </span>
            </ItemTemplate>
         </asp:repeater>
         <input id="changebtn" type="submit" onserverclick="ChangeBtn_Click" runat="server"/>
         
      </form>
</body>
</html>
<!--</Snippet5>-->