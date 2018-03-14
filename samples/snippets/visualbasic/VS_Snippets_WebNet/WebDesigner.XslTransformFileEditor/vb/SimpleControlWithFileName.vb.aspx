<%@ Page Language="VB" %>
<%@ Register tagprefix="aspSample" 
    namespace="ControlDesignerSamples.VB"
    assembly="Simplecontrolwithfilename_VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
            <div style="font-family:tahoma;font-size:small;">
            <span style="font-size: 14pt">
                Simple text control using an XSL transform file property</span><p/>
        </div>
        <aspSample:SimpleTextControl runat="server" id="Control1" >
         </aspSample:SimpleTextControl>

        <br /><br />

    </div>
    </form>
</body>
</html>
