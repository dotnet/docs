<!--<Snippet1>-->
<%@ page language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  void VoteMap_Clicked (Object sender, ImageMapEventArgs e)
  {
    string coordinates;
    string hotSpotType;
    int yescount = ((ViewState["yescount"] != null)? (int)ViewState["yescount"] : 0);
    int nocount = ((ViewState["nocount"] != null)? (int)ViewState["nocount"] : 0);

    // When a user clicks the "Yes" hot spot,
    // display the hot spot's name and coordinates.
    if (e.PostBackValue.Contains("Yes"))
    {
      yescount += 1;
      coordinates = Vote.HotSpots[0].GetCoordinates();
      hotSpotType = Vote.HotSpots[0].ToString ();
      Message1.Text = "You selected " + hotSpotType + " " + e.PostBackValue + ".<br />" +
                      "The coordinates are " + coordinates + ".<br />" +
                      "The current vote count is " + yescount.ToString() + 
            " yes votes and " + nocount.ToString() + " no votes.";
    }
      
    // When a user clicks the "No" hot spot,
    // display the hot spot's name and coordinates.
    else if (e.PostBackValue.Contains("No"))
    {
      nocount += 1;
      coordinates = Vote.HotSpots[1].GetCoordinates();
      hotSpotType = Vote.HotSpots[1].ToString ();
      Message1.Text = "You selected " + hotSpotType + " " + e.PostBackValue + ".<br />" +
                      "The coordinates are " + coordinates + ".<br />" +
            "The current vote count is " + yescount.ToString() +
            " yes votes and " + nocount.ToString() + " no votes.";
    }
    
    else
    {
      Message1.Text = "You did not click a valid hot spot region.";
    }

    ViewState["yescount"] = yescount;
    ViewState["nocount"] = nocount;
  }           
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
  <title>ImageMap Class Post Back Example</title>
</head>
  <body>
    <form id="form1" runat="server">
    
      <h3>ImageMap Class Post Back Example</h3>
      
      <asp:imagemap id="Vote"           
        imageurl="Images/VoteImage.jpg"
        width="400" 
        height="200" 
        alternatetext="Vote Yes or No"
        hotspotmode="PostBack"
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
            
      <br /><br />
          
      <asp:label id="Message1"
        runat="Server">
      </asp:label>                 
                 
    </form>      
  </body>
</html>
<!--</Snippet1>-->
