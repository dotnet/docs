<!--<Snippet1>-->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' Programmatically create a RectangleHotSpot.
    Dim Rectangle1 As New RectangleHotSpot
    Rectangle1.Top = 0
    Rectangle1.Left = 0
    Rectangle1.Bottom = 200
    Rectangle1.Right = 200
    Rectangle1.PostBackValue = "Yes"
    Rectangle1.AlternateText = "Vote yes"
      
    ' Programmatically create a second RectangleHotSpot.
    Dim Rectangle2 As New RectangleHotSpot
    Rectangle2.Top = 0
    Rectangle2.Left = 201
    Rectangle2.Bottom = 200
    Rectangle2.Right = 400
    Rectangle2.PostBackValue = "No"
    Rectangle2.AlternateText = "Vote no"

    
    ' Add the RectangleHotSpot objects to the
    ' Vote ImageMap control's HotSpotCollection.
    Vote.HotSpots.Add(Rectangle1)
    Vote.HotSpots.Add(Rectangle2)
  
  End Sub
    
  Sub VoteMap_Clicked(ByVal sender As Object, ByVal e As ImageMapEventArgs)
    Dim hotSpotType As String
        
    ' When a user clicks the "Yes" hot spot,
    ' display the hot spot's name.
    If (e.PostBackValue = "Yes") Then
      hotSpotType = Vote.HotSpots(0).ToString()
      Message1.Text = "You selected " & hotSpotType & " " & e.PostBackValue & "."
       
      ' When a user clicks the "No" hot spot,
      ' display the hot spot's name.
    ElseIf (e.PostBackValue = "No") Then
      hotSpotType = Vote.HotSpots(1).ToString()
      Message1.Text = "You selected " & hotSpotType & " " & e.PostBackValue & "."
      
    Else
      Message1.Text = "You did not click in a valid hot spot region."
                
    End If
        
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>RectangleHotSpot VB Constructor Example</title>
</head>
  <body>
    <form id="Form1" runat="server">
    
      <h3>RectangleHotSpot Constructor Example</h3>
      
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
      </asp:imagemap>
      
      <br />
                
      <asp:label id="Message1"
        runat="Server">
      </asp:label>                 
                 
    </form>      
  </body>
</html>
<!--</Snippet1>-->
