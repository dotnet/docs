<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title> CheckBox Constructor Example </title>
<script runat="server">

      Sub Page_Load(sender As Object, e As EventArgs)

         ' Create new CheckBox control.
         Dim NewCheckBox As CheckBox = New CheckBox()
         NewCheckBox.ID="FeatureCheckBox"
         NewCheckBox.Text="Enable feature"
         NewCheckBox.AutoPostBack = True

         ' Register the event handling method for the CheckedChanged event. 
         AddHandler NewCheckBox.CheckedChanged, AddressOf Check_Change

         ' Add the control to the Controls collection of the
         ' PlaceHolder control. 
         Place.Controls.Clear()
         Place.Controls.Add(NewCheckBox)

      End Sub

      Sub Check_Change(sender As Object, e As EventArgs)

         ' Retrieve the CheckBox control from the PlaceHolder control.
         Dim check As CheckBox = _
            CType(Place.FindControl("FeatureCheckBox"), CheckBox)

         ' Display the appropriate message based on the state of the
         ' CheckBox control. 
         If check.Checked Then
         
            Message.Text = "Feature enabled."
     
         Else
         
            Message.Text = "Feature disabled."
         
         End If


      End Sub

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