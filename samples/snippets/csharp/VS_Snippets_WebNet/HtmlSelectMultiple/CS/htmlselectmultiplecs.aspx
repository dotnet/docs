<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

      void Button_Click (Object sender, EventArgs e)
      {

         Label1.Text = "You selected:";

         for (int i=0; i<=Select1.Items.Count - 1; i++)
         {
  
            if (Select1.Items[i].Selected)
               Label1.Text += "<br /> &nbsp;&nbsp; -" + Select1.Items[i].Text;      

         }

         Select1.Size = Convert.ToInt32(Select2.Value);

      }

      void Check_Changed (Object sender, EventArgs e)
      {
        
         Select1.Multiple = CheckBox1.Checked;

      }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title> HtmlSelect Example </title>
</head>
<body>
<form id="form1" runat="server">
   <div>

      <h3> HtmlSelect Example </h3>

      Select item(s) from the list: <br /><br />

      <select id="Select1" 
              multiple="true"
              runat="server">

         <option value="1" selected="selected"> Item 1 </option>
         <option value="2"> Item 2 </option>
         <option value="3"> Item 3 </option>
         <option value="4"> Item 4 </option>
         <option value="5"> Item 5 </option>
         <option value="6"> Item 6 </option>

      </select>

      <hr />

      HtmlSelect Size: <br />

      <select id="Select2" 
              runat="server">

         <option value="1"> 1 </option>
         <option value="2"> 2 </option>
         <option value="3"> 3 </option>
         <option value="4" selected="selected"> 4 </option>
         <option value="5"> 5 </option>
         <option value="6"> 6 </option>

      </select>

      &nbsp;&nbsp;

      <asp:CheckBox id="CheckBox1"
           Text="Enable Multiple Property"
           AutoPostBack="True"
           OnCheckedChanged="Check_Changed"
           Checked="True"
           runat="server"/>

      <br /><br />

      <button id="Button1"
              onserverclick="Button_Click"
              runat="server">

         Submit

      </button>

      <br /><br />

      <asp:Label id="Label1" runat="server"/>

   </div>
</form>
</body>
</html>
<!--</Snippet1>-->