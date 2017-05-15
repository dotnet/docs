<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Sub Button_Click (sender As Object, e As EventArgs)
        ' Display the selected items.
        Label1.Text = "You selected:"

        Dim i As Integer

        For i=0 To Select1.Items.Count - 1
            If Select1.Items(i).Selected Then
                Label1.Text &= "<br /> &nbsp;&nbsp; -" & Select1.Items(i).Text
            End If      
        Next
    End Sub

    Sub Server_Change(sender As Object, e As EventArgs)
        ' The ServerChange event is commonly used for data validation.
        ' This method will display a warning if the "All" option is 
        ' selected in combination with another item in the list.
        Dim Count As Integer = 0
        Dim i As Integer

        ' Determine the number of selected items in the list.
        For i=0 To Select1.Items.Count - 1
            If Select1.Items(i).Selected Then
                Count = Count + 1      
            End If
        Next

        ' Display an error message if more than one item is selected with
        ' the "All" item selected.
        If ((Count > 1) And (Select1.Items(0).Selected)) Then
            Label2.Text = "Hey! You can't select 'All' with another selection!!"
        Else
            Label2.Text = ""
        End If
    End Sub

    Sub Page_Load(sender As Object, e As EventArgs)
        ' Create an EventHandler delegate for the method you want to 
        ' handle the event, and then add it to the list of methods
        ' called when the event is raised.
        AddHandler Select1.ServerChange, AddressOf Server_Change
        AddHandler Button1.ServerClick, AddressOf Button_Click
    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title> HtmlSelect ServerChange Example </title>
</head>
<body>
<form id="form1" runat="server">
   <div>

      <h3> HtmlSelect ServerChange Example </h3>

      Select items from the list: <br /><br />

      <select id="Select1" 
              multiple="true"
              runat="server">

         <option value="All"> All </option>
         <option value="1" selected="selected"> Item 1 </option>
         <option value="2"> Item 2 </option>
         <option value="3"> Item 3 </option>
         <option value="4"> Item 4 </option>
         <option value="5"> Item 5 </option>
         <option value="6"> Item 6 </option>

      </select>

      <br /><br />

      <button id="Button1"
              runat="server">

         Submit

      </button>

      <br /><br />

      <asp:Label id="Label1"
           runat="server"/>

      <br />

      <asp:Label id="Label2"
           runat="server"/>

   </div>
</form>
</body>
</html>

<!-- </Snippet1> -->   