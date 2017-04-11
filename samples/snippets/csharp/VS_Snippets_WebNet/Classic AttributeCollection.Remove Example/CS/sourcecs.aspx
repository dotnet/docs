<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
 
    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        FirstSelect.Attributes.Remove("Size");
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>AttributeCollection Example</title>
</head>

 <body>
    <form id="form1" runat="server">
    <div>
    Make a selection:
    <select id="FirstSelect"
            size="10"
            runat="server">
       <option>This</option>
       <option>That</option>
       <option>Other</option>
    </select>
    <br/><br/>

    <input type="submit" 
           id="SubmitBtn"
           value="Remove Size Attribute" 
           onserverclick="SubmitBtn_Click" 
           runat="server"/>
    </div>
 </form>
 </body>
 </html>
<!--</Snippet1>-->
