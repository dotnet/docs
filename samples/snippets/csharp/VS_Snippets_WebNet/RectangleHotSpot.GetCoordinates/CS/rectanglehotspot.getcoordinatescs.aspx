<!--<Snippet1>-->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  void VoteMap_Clicked(object sender, ImageMapEventArgs e)
  {
    string coordinates;
        
    // When a user clicks the "Yes" hot spot,
    // display the hot spot's coordinates.
    if (e.PostBackValue == "Yes") 
    {
      coordinates = Vote.HotSpots[0].GetCoordinates();
      Message1.Text = "The hot spot's coordinates are " + coordinates;
    }
  
    // When a user clicks the "No" hot spot,
    // display the hot spot's coordinates.
    else if (e.PostBackValue == "No") 
    {
      coordinates = Vote.HotSpots[1].GetCoordinates();
      Message1.Text = "The hot spot's coordinates are " + coordinates;
    }
      
    else
      Message1.Text = "You did not click a valid hot spot region.";
                    
    }
        
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>RectangleHotSpot.GetCoordinates Example</title>
</head>
  <body>
    <form id="Form1" runat="server">
    
      <h3>RectangleHotSpot.GetCoordinates Example</h3>
      
      <!-- Change or remove the width and height attributes as
           appropriate for your image. -->
      <asp:imagemap id="Vote"           
        imageurl="Images/VoteImage.jpg" 
        alternatetext="Voting choices"
        hotspotmode="PostBack"
        width="400"
        height="200"
        onclick="VoteMap_Clicked"   
        runat="Server">            
          
        <asp:RectangleHotSpot          
          top="0"
          left="0"
          bottom="200"
          right="200"
          postbackvalue="Yes"
          alternatetext="Vote yes">
        </asp:RectangleHotSpot>
          
        <asp:RectangleHotSpot 
          top="0"
          left="201"
          bottom="200"
          right="400"
          postbackvalue="No"
          alternatetext="Vote no">
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
