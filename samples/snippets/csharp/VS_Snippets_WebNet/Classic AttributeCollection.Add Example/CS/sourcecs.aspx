<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
 
    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        firstselect.Attributes.Add("Multiple", "True");
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
    <select id="firstselect" 
            runat="server">
       <option>This</option>
       <option>That</option>
       <option>Other</option>
    </select>
    <br/><br/>

    <input type="submit" 
           id="submitbtn"
           value="modify attribute" 
           onserverclick="SubmitBtn_Click" 
           runat="server"/>
    </div>
 </form>
 </body>
 </html>
<!--</Snippet1>-->