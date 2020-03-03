<!--<Snippet1>-->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  void VoteMap_Clicked(object sender, ImageMapEventArgs e)
  {       
    // When a user clicks the "Yes" hot spot,
    // display the hot spot's value.
    if (e.PostBackValue == "Yes")
      Message1.Text = "You selected " + e.PostBackValue + ".";
       
    else if (e.PostBackValue == "No") 
      // When a user clicks the "No" hot spot,
      // display the hot spot's value.       
      Message1.Text = "You selected " + e.PostBackValue + ".";
      
    else
      Message1.Text = "You did not click a valid hot spot region.";             
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
  <title>ImageMap.HotSpotMode Example</title>
</head>
  <body>
    <form id="form1" runat="server">
    
      <h3>ImageMap.HotSpotMode Example</h3>
      
      <!--The RectangleHotSpot objects have the post back
        behavior specified by the HotSpotMode 
        property on the ImageMap control.-->
      <asp:imagemap id="Vote"           
        imageurl="Images/VoteImage.jpg"
        alternatetext="Voting choices" 
        hotspotmode="PostBack"
        onclick="VoteMap_Clicked"   
        runat="Server">   
        
        <asp:RectangleHotSpot          
          top="0"
          left="0"
          bottom="354"
          right="250"
          postbackvalue="Yes"
          alternatetext="Vote yes">
        </asp:RectangleHotSpot>
        
        <asp:RectangleHotSpot 
          top="0"
          left="251"
          bottom="354"
          right="500"
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
