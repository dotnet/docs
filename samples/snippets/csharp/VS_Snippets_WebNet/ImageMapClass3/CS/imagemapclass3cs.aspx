<!--<Snippet1>-->
<%@ page language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  void ButtonsMap_Clicked(object sender, ImageMapEventArgs e)
  {       
    // When a user clicks the "Background" hot spot,
    // display the hot spot's value.
    if (e.PostBackValue == "Background")
    {
      string coordinates = Buttons.HotSpots[3].GetCoordinates();
      Message1.Text = "You selected the " + e.PostBackValue + "<br />" +
                                "The coordinates are " + coordinates;
    }
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
  <title>ImageMap Class Mixed HotSpotMode Example</title>
</head>
  <body>
    <form id="form1" runat="server">
    
      <h3>ImageMap Class Mixed HotSpotMode Example</h3>
      
      <!--In this scenario, the ImageMap.HotSpotMode
      property is not set, because the 
      HotSpotMode property is set on each individual
      RectangleHotSpot object to specify its behavior.-->
      <asp:imagemap id="Buttons"           
        imageurl="Images/MixedImage.jpg"
        width="350"
        height="350" 
        alternatetext="Navigation buttons"
        hotspotmode="NotSet"     
        onclick="ButtonsMap_Clicked"
        runat="Server">                 
        
        <asp:RectangleHotSpot
          hotspotmode="Navigate"
          NavigateUrl="http://www.contoso.com"
          alternatetext="Button 1"
          top="50"
          left="50"
          bottom="100"
          right="300">
        </asp:RectangleHotSpot>
        
        <asp:RectangleHotSpot  
          hotspotmode="Navigate"
          NavigateUrl="http://www.tailspintoys.com"
          alternatetext="Button 2"        
          top="150"
          left="50"
          bottom="200"
          right="300">          
        </asp:RectangleHotSpot>
        
        <asp:RectangleHotSpot
          hotspotmode="Navigate"
          NavigateUrl="http://www.cohowinery.com"
          alternatetext="Button 3"          
          top="250"
          left="50"
          bottom="300"
          right="300">
        </asp:RectangleHotSpot> 
        
        <asp:RectangleHotSpot 
          hotspotmode="PostBack"
          PostBackValue="Background"
          alternatetext="Background"
          top="0"
          left="0"
          bottom="350"
          right="350">
        </asp:RectangleHotSpot>      
      
      </asp:imagemap>
            
      <br />
          
      <asp:label id="Message1"
        runat="Server">
      </asp:label>                 
                 
    </form>      
  </body>
</html>
<!--</Snippet1>-->