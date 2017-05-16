<!-- <Snippet2> -->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Data Binding ListBox</title>
<script language="C#" runat="server">

      void Page_Load(Object sender, EventArgs e) 
      {

         if (!IsPostBack) 
         {

            ArrayList values = new ArrayList();

            values.Add ("Item 1");
            values.Add ("Item 2");
            values.Add ("Item 3");
            values.Add ("Item 4");
            values.Add ("Item 5");
            values.Add ("Item 6");

            ListBox1.DataSource = values;
            ListBox1.DataBind();

         }

      }

      void SubmitBtn_Click(Object sender, EventArgs e) 
      {
      
         if ( ListBox1.SelectedIndex > -1 )
            Label1.Text = "You chose: " + ListBox1.SelectedItem.Text;
         
      }

   </script>

</head>
<body>

   <form id="form1" runat="server">

        <h3>Data Binding ListBox</h3>
    
        <asp:ListBox id="ListBox1" 
             Width="100px" 
             runat="server"/>

        <asp:button id="Button1"
             Text="Submit" 
             OnClick="SubmitBtn_Click" 
             runat="server" />
        
        <asp:Label id="Label1" 
             Font-Names="Verdana" 
             font-size="10pt" 
             runat="server"/>

   </form>

</body>
</html>
<!-- </Snippet2> -->

