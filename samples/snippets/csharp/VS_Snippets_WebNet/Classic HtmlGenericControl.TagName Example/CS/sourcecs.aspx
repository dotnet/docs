<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void BG_Button_Click(object sender, EventArgs e)
  {
    Body.Attributes["bgcolor"] = ColorSelect.Value;
  }

  protected void Font_Button_Click(object sender, EventArgs e)
  {
    Body.TagName = "Font";
    Body.Attributes["Color"] = ColorSelect.Value;
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>HtmlGenericControl Example</title> 
</head>
 
 <body id="Body" 
       runat="server"> 

     <h3>HtmlGenericControl Example</h3>

     <form id="form1" runat="server">
     <div>
       <br />
       Select a background color for the page: <br />
       <select id="ColorSelect" 
               runat="server">
           <option>White</option>
           <option>LightBlue</option>
           <option>LightGreen</option>
           <option>Yellow</option>
       </select>
       <br />
       <input type="submit" 
              runat="server"
              value="Change Background Color" 
              onserverclick="BG_Button_Click" id="Submit1" />
       <input type="submit" 
              runat="server" 
              value="Change Font Color" 
              onserverclick="Font_Button_Click" id="Submit2" />
     </div>
     </form>
 
 </body>
 </html>
<!--</Snippet1>-->
