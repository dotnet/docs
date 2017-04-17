<!--<Snippet1>-->
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  void Page_Load(object sender, EventArgs e)
  {
    // Programmatically create a RectangleHotSpot.
    RectangleHotSpot Rectangle1 = new RectangleHotSpot();
    
    // Set properties on Rectangle1.
    Rectangle1.Top = 0;
    Rectangle1.Left = 0;
    Rectangle1.Bottom = 200;
    Rectangle1.Right = 200;
    Rectangle1.PostBackValue = "Yes";
    Rectangle1.AlternateText = "Vote yes";
         
    // Add the RectangleHotSpot object to the
    // Vote ImageMap control's HotSpotCollection.
    Vote.HotSpots.Add(Rectangle1);  
  }
  
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
<head id="Head1" runat="server">
  <title>RectangleHotSpot Properties Example</title>
</head>
  <body>
    <form id="Form1" runat="server">
    
      <h3>RectangleHotSpot Properties Example</h3>
      
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
