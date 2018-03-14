<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  Sub VoteMap_Clicked(ByVal sender As Object, ByVal e As ImageMapEventArgs)
    Dim coordinates As String
        
    ' When a user clicks the "Yes" hot spot,
    ' display the hot spot's coordinates.
    If (e.PostBackValue = "Yes") Then
      coordinates = Vote.HotSpots(0).GetCoordinates()
      Message1.Text = "The hot spot's coordinates are " & coordinates
       
      ' When a user clicks the "No" hot spot,
      ' display the hot spot's coordinates.
    ElseIf (e.PostBackValue = "No") Then
      coordinates = Vote.HotSpots(1).GetCoordinates()
      Message1.Text = "The hot spot's coordinates are " & coordinates
      
    Else
      Message1.Text = "You did not click in a valid hot spot region."
                
    End If
        
  End Sub
  
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
            
      <br /><br />
          
      <asp:label id="Message1"
        runat="Server">
      </asp:label>                 
                 
    </form>      
  </body>
</html>
<!--</Snippet1>-->
