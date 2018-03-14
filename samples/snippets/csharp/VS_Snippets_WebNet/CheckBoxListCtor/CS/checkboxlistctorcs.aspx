<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title> CheckBoxList Constructor Example </title>
<script runat="server">

      void Check_Clicked(Object sender, EventArgs e) 
      {

         // Retrieve the CheckBoxList control from the Controls collection
         // of the PlaceHolder control.
         CheckBoxList checklist = 
             (CheckBoxList)Place.FindControl("checkboxlist1");

         // Make sure a control was found.
         if(checklist != null)
         { 

            Message.Text = "Selected Item(s):<br /><br />";

            // Iterate through the Items collection of the CheckBoxList 
            // control and display the selected items.
            for (int i=0; i<checklist.Items.Count; i++)
            {

               if (checklist.Items[i].Selected)
               {

                  Message.Text += checklist.Items[i].Text + "<br />";

               }

            }

         }

         else
         {

            // Display an error message.
            Message.Text = "Unable to find CheckBoxList control.";

         }

      }

      void Page_Load(Object sender, EventArgs e)
      {

         // Create a new CheckBoxList control.
         CheckBoxList checklist = new CheckBoxList();

         // Set the properties of the control.
         checklist.ID = "checkboxlist1";
         checklist.AutoPostBack = true;
         checklist.CellPadding = 5;
         checklist.CellSpacing = 5;
         checklist.RepeatColumns = 2;
         checklist.RepeatDirection = RepeatDirection.Vertical;
         checklist.RepeatLayout = RepeatLayout.Flow;
         checklist.TextAlign = TextAlign.Right;

         // Populate the CheckBoxList control.
         checklist.Items.Add(new ListItem("Item 1"));
         checklist.Items.Add(new ListItem("Item 2"));
         checklist.Items.Add(new ListItem("Item 3"));
         checklist.Items.Add(new ListItem("Item 4"));
         checklist.Items.Add(new ListItem("Item 5"));
         checklist.Items.Add(new ListItem("Item 6"));

         // Manually register the event-handling method for the 
         // SelectedIndexChanged event.
         checklist.SelectedIndexChanged += new EventHandler(this.Check_Clicked);

         // Add the control to the Controls collection of the 
         // PlaceHolder control.
         Place.Controls.Add(checklist);

      }

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