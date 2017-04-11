<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      void Page_Load(Object sender, EventArgs e)
      {
         if(!IsPostBack)
         {
            // Create the first HtmlInputRadioButton control.
            HtmlInputRadioButton radio1 = new HtmlInputRadioButton();
            radio1.Value = "Value1";
            radio1.Checked = true;
            radio1.Name = "RadioSet";

            // Create the caption for the first HtmlInputRadioButton control.
            HtmlGenericControl span1 = new HtmlGenericControl("span");
            span1.InnerHtml = "Radio Button 1 <br />";

            // Add the controls to the Controls collection of the 
            // PlaceHolder control.
            Place.Controls.Clear();
            Place.Controls.Add(radio1);
            Place.Controls.Add(span1);

            // Create the second HtmlInputRadioButton control.
            HtmlInputRadioButton radio2 = new HtmlInputRadioButton();
            radio2.Value = "Value2";
            radio2.Checked = false;
            radio2.Name = "RadioSet";

            // Create the caption for the second HtmlInputRadioButton control.
            HtmlGenericControl span2 = new HtmlGenericControl("span");
            span2.InnerHtml = "Radio Button 2 <br />";
         
            // Add the control to the Controls collection of the 
            // PlaceHolder control.
            Place.Controls.Add(radio2);
            Place.Controls.Add(span2);
         }
      }
  
   </script>
  
<head runat="server">
    <title> HtmlInputRadioButton Constructor Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> HtmlInputRadioButton Constructor Example </h3> 
  
      <asp:PlaceHolder id="Place" runat="server"/>
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
