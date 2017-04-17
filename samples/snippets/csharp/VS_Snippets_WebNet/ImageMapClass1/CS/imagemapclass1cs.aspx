<!--<Snippet1>-->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
  <title>ImageMap Class Navigate Example</title>
</head>
  <body>
    <form id="form1" runat="server">
    
      <h3>ImageMap Class Navigate Example</h3>
      
      <h4>Shopping Choices:</h4>
      
      <asp:imagemap id="Shop"           
        imageurl="Images/ShopChoice.jpg"
        width="150" 
        height="360"
        alternatetext="Shopping choices" 
        runat="Server">    
        
        <asp:circlehotspot
          navigateurl="http://www.tailspintoys.com"
          x="75"
          y="290"
          radius="75"
          hotspotmode="Navigate"
          alternatetext="Shop for toys">           
        </asp:circlehotspot> 
        
        <asp:circlehotspot
          navigateurl="http://www.cohowinery.com"
          x="75"
          y="120"
          radius="75"
          hotspotmode="Navigate"
          alternatetext="Shop for wine">
        </asp:circlehotspot>     
          
      </asp:imagemap>                 
                 
    </form>      
  </body>
</html>
<!--</Snippet1>-->
