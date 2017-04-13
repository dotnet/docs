<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title> CheckBox Constructor Example </title>
<script runat="server">

      void Page_Load(Object sender, EventArgs e)
      {

         // Create new CheckBox control.
         CheckBox NewCheckBox = new CheckBox();
         NewCheckBox.ID="FeatureCheckBox";
         NewCheckBox.Text="Enable feature";
         NewCheckBox.AutoPostBack = true;

         // Register the event-handling method for the CheckedChanged event. 
         NewCheckBox.CheckedChanged += new EventHandler(this.Check_Change);

         // Add the control to the Controls collection of the
         // PlaceHolder control. 
         Place.Controls.Clear();
         Place.Controls.Add(NewCheckBox);

      }

      void Check_Change(Object sender, EventArgs e)
      {

         // Retrieve the CheckBox control from the PlaceHolder control.
         CheckBox check = (CheckBox)Place.FindControl("FeatureCheckBox");

         // Display the appropriate message based on the state of the
         // CheckBox control. 
         if(check.Checked)
         {
            Message.Text = "Feature enabled.";
         }
         else
         {
            Message.Text = "Feature disabled.";
         }

      }

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3> CheckBox Constructor Example </h3>

      Click the check box.

      <br /><br />

      <asp:Placeholder id="Place" 
           runat="server"/>

      <br /><br />

      <asp:Label id="Message" 
           runat="server"/>

   </form>

</body>

</html>

<!-- </Snippet1> -->