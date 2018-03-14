<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
 
    Protected Sub ClearAttribute_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        FirstSelect.Attributes.Clear()
    End Sub
    
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
            style="font:16pt verdana;background-color:yellow;color:black;" 
            runat="server">
       <option>This</option>
       <option>That</option>
       <option>Other</option>
    </select>
    <br/><br/>

    <input type="submit" 
           id="clearattributes"
           value="clear all attributes" 
           onserverclick="clearattribute_click" 
           runat="server"/>
    </div>
 </form>
 </body>
 </html>
<!--</Snippet1>-->