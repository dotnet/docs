<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void SubmitBtn_Click(object sender, EventArgs e)
  {
    FirstSelect.Style.Remove("font");
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CssStyleCollection Remove Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Click the submit button to clear the font formatting.
    <br />
    <select id="FirstSelect" 
            style="font: 14pt Arial; background-color:Yellow; color:Blue;"
            runat="server">
        <option >option 1</option>
        <option >option 2</option>
        <option >option 3</option>
    </select> 
    <input id="SubmitBtn" 
           value="Submit" 
           type="submit" 
           onserverclick="SubmitBtn_Click"
           runat="server" /><br />
    </div>
    </form>
</body></html>
<!-- </Snippet1> -->