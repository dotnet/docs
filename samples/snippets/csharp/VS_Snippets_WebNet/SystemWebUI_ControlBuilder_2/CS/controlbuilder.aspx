<!-- <Snippet2> -->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="AspNetSamples" Assembly="cs_mycontrolbuilder" Namespace="CustomControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ControlBuilder Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <AspNetSamples:MyCS_CustomControl id="Custom1" 
                                         title="Auto-Generated Table"
                                         columns="3"
                                         rows="3"  
                                         runat="server">
         <mycell cellid="r0c0" BackColor="red" text="red cell"></mycell>
         <mycell cellid="r2c2" BackColor="green" text="green cell"></mycell>
       </AspNetSamples:MyCS_CustomControl>
    </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->
