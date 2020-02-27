<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    ' Programmatically create a PolygonHotSpot.
    Dim Polygon1 As New PolygonHotSpot
    Polygon1.Coordinates = "128,185,335,157,400,224,400,400,228,400"
    Polygon1.PostBackValue = "Southern"
    Polygon1.AlternateText = "Southern Region"
    
    ' Add it to the end of the ImageMap control's
    ' HotSpotCollection.
    Regions.HotSpots.Add(Polygon1)
  End Sub
  
  Sub RegionMap_Clicked(ByVal sender As Object, ByVal e As ImageMapEventArgs)
    Dim hotSpotType As String
        
    ' When a user clicks a hot spot, display
    ' the hot spot's type and name.
    Select Case (e.PostBackValue)
      
      Case ("Western")
        hotSpotType = Regions.HotSpots(0).ToString()
        Message1.Text = "You selected " & hotSpotType & " " & e.PostBackValue
      
      Case ("Northern")
        hotSpotType = Regions.HotSpots(1).ToString()
        Message1.Text = "You selected " & hotSpotType & " " & e.PostBackValue
      
      Case ("Southern")
        hotSpotType = Regions.HotSpots(2).ToString()
        Message1.Text = "You selected " & hotSpotType & " " & e.PostBackValue
      
      Case Else
        Message1.Text = "You did not click a valid hot spot region."
    
    End Select
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>PolygonHotSpot Constructor Example</title>
</head>
  <body>
    <form id="Form1" runat="server">
    
      <h3>PolygonHotSpot Constructor Example</h3>
      
      <!-- Change or remove the width and height attributes as
           appropriate for your image. -->
      <asp:imagemap id="Regions"           
        imageurl="Images/RegionMap.jpg"
        alternatetext="Sales regions" 
        hotspotmode="PostBack"
        width="400"
        height="400"
        onclick="RegionMap_Clicked"   
        runat="Server">            
          
        <asp:PolygonHotSpot 
          coordinates="0,0,176,0,125,182,227,400,0,400"         
          postbackvalue="Western"
          alternatetext="Western Region">
        </asp:PolygonHotSpot>
          
        <asp:PolygonHotSpot 
          coordinates="177,0,400,0,400,223,335,154,127,180"         
          postbackvalue="Northern"
          alternatetext="Northern Region">
        </asp:PolygonHotSpot>
      
      </asp:imagemap>
            
      <br /><br />
          
      <asp:label id="Message1"
        runat="Server">
      </asp:label>                 
                 
    </form>      
  </body>
</html>
<!--</Snippet1>-->
