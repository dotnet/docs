<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title> CheckBoxList Constructor Example </title>
<script runat="server">

      Sub Check_Clicked(sender As Object, e As EventArgs) 

         ' Retrieve the CheckBoxList control from the Controls collection
         ' of the PlaceHolder control.
         Dim checklist As CheckBoxList = _
             CType(Place.FindControl("checkboxlist1"), CheckBoxList)

         ' Make sure a control was found.
         If Not checklist Is Nothing

            Message.Text = "Selected Item(s):<br /><br />"

            ' Iterate through the Items collection of CheckBoxList 
            ' control and display the selected items.
            Dim i As Integer

            For i=0 To checklist.Items.Count - 1

               If checklist.Items(i).Selected Then

                  Message.Text &= checklist.Items(i).Text & "<br />"

               End If

            Next i

         Else

            ' Display an error message.
            Message.Text = "Unable to find CheckBoxList control."

         End If

      End Sub

      Sub Page_Load(sender As Object, e As EventArgs)

         ' Create a new CheckBoxList control.
         Dim checklist As CheckBoxList = New CheckBoxList()

         ' Set the properties of the control.
         checklist.ID = "checkboxlist1"
         checklist.AutoPostBack = True
         checklist.CellPadding = 5
         checklist.CellSpacing = 5
         checklist.RepeatColumns = 2
         checklist.RepeatDirection = RepeatDirection.Vertical
         checklist.RepeatLayout = RepeatLayout.Flow
         checklist.TextAlign = TextAlign.Right

         ' Populate the CheckBoxList control.
         checklist.Items.Add(New ListItem("Item 1"))
         checklist.Items.Add(New ListItem("Item 2"))
         checklist.Items.Add(New ListItem("Item 3"))
         checklist.Items.Add(New ListItem("Item 4"))
         checklist.Items.Add(New ListItem("Item 5"))
         checklist.Items.Add(New ListItem("Item 6"))

         ' Manually register the event-handling method for the 
         ' SelectedIndexChanged event.
         AddHandler checklist.SelectedIndexChanged, AddressOf Check_Clicked

         ' Add the control to the Controls collection of the 
         ' PlaceHolder control.
         Place.Controls.Add(checklist)

      End Sub

   </script>
 
</head>

<body>
   
   <form id="form1" runat="server">
 
      <h3> CheckBoxList Constructor Example </h3>

      Select items from the CheckBoxList.

      <br /><br />

      <asp:PlaceHolder id="Place" runat="server"/>
 
      <br /><br />

      <asp:label id="Message" runat="server"/>
             
   </form>
          
</body>

</html>

<!-- </Snippet1> -->