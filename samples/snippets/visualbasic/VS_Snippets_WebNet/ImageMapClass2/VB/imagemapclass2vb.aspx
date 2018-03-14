<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  Sub VoteMap_Clicked(ByVal sender As Object, ByVal e As ImageMapEventArgs)
    Dim coordinates As String
    Dim hotSpotType As String
    Dim yescount As Integer
    Dim nocount As Integer
    
    If (ViewState("yescount") IsNot Nothing) Then
      yescount = Convert.ToInt32(ViewState("yescount"))
    Else
      yescount = 0
    End If
    If (ViewState("nocount") IsNot Nothing) Then
      nocount = Convert.ToInt32(ViewState("nocount"))
    Else
      nocount = 0
    End If
      
    
    ' When a user clicks the "Yes" hot spot,
    ' display the hot spot's name and coordinates.
    If (e.PostBackValue.Contains("Yes")) Then
      
      yescount += 1
      coordinates = Vote.HotSpots(0).GetCoordinates()
      hotSpotType = Vote.HotSpots(0).ToString()
      Message1.Text = "You selected " & hotSpotType & " " & e.PostBackValue & ".<br />" & _
                      "The coordinates are " & coordinates & ".<br />" & _
                      "The current vote count is " & yescount.ToString() & _
                      " yes votes and " & nocount.ToString() & " no votes."
       
      ' When a user clicks the "No" hot spot,
      ' display the hot spot's name and coordinates.
    ElseIf (e.PostBackValue.Contains("No")) Then
      
      nocount += 1
      coordinates = Vote.HotSpots.Item(1).GetCoordinates()
      hotSpotType = Vote.HotSpots.Item(1).ToString()
      Message1.Text = "You selected " & hotSpotType & " " & e.PostBackValue & ".<br />" & _
                     "The coordinates are " & coordinates & ".<br />" & _
                      "The current vote count is " & yescount.ToString() & _
                      " yes votes and " & nocount.ToString() & " no votes."
      
    Else
      
      Message1.Text = "You did not click a valid hot spot region."
                
    End If
      
    ViewState("yescount") = yescount
    ViewState("nocount") = nocount
    
  End Sub
  
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

