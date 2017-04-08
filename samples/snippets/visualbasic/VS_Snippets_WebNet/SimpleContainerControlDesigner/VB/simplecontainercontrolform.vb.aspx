<%@ Page Language="C#" %>
<!-- Register the tag prefix for the custom control in the sample file.
     The namespace must match that in the VB source file, and the 
     assembly must match the bin\*.DLL file compiled by the makefile. -->
     
<%@ Register tagprefix="aspSample" 
    namespace="ControlDesignerSamples.VB"
    assembly="SimpleContainerControl_VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server" id="Head1">
    <title>Web Page with Simple Container Control</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
            <div style="font-family:tahoma;font-size:small;">
            <span style="font-size: 14pt">
                Simple Container Control</span><p/>
        </div>
        <aspSample:SimpleContainerControl runat="server" id="Control1" >
            </aspSample:SimpleContainerControl>

        <br /><br />

    </div>
    </form>
</body>
</html>
