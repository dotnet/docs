<!--<Snippet1>-->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  void Page_Load (Object sender, EventArgs e)
  {
    // Programmatically create a CircleHotSpot object.
    CircleHotSpot Circle1 = new CircleHotSpot();
    Circle1.HotSpotMode = HotSpotMode.Navigate;
    Circle1.NavigateUrl = "http://www.tailspintoys.com";
    Circle1.X = 145;
    Circle1.Y = 120;
    Circle1.Radius = 75;
    Circle1.AlternateText = "Shop for toys";

    // Programmatically create a second CircleHotSpot object.
    CircleHotSpot Circle2 = new CircleHotSpot();
    Circle2.HotSpotMode = HotSpotMode.Navigate;
    Circle2.NavigateUrl = "http://www.cohowinery.com";
    Circle2.X = 145;
    Circle2.Y = 290;
    Circle2.Radius = 75;
    Circle2.AlternateText = "Shop for wine";

    // Add the CirclHotSpot objects to the
    // Shop ImageMap control's HotSpotCollection.    
    Shop.HotSpots.Add(Circle1);
    Shop.HotSpots.Add(Circle2);
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
  <title>CircleHotSpot Constructor Example</title>
</head>
  <body>
    <form id="form1" runat="server">
    
      <h3>CircleHotSpot Constructor Example</h3>
      
      <h4>Shopping Choices:</h4>
      
      <asp:imagemap id="Shop"           
        imageurl="Images/ShopChoice.jpg" 
        alternatetext="Shopping choices"
        runat="Server">
      </asp:imagemap>
      
    </form>      
  </body>
</html>
<!--</Snippet1>-->
