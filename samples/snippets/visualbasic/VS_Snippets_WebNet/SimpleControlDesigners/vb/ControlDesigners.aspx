<!-- <Snippet14> -->
<%@ Page Language="VB" %>
<%@ register tagprefix="aspSample" 
  assembly="SimpleControlDesignersVB" 
  namespace="Samples.AspNet.VB.Controls" %>
<!-- </Snippet14> -->
<!-- <Snippet15> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Designers Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p style="font-family:tahoma;font-size:large;
            font-weight:bold">
            Simple Control Designers
        </p>
        <div style="font-family:tahoma;font-size:x-small;">
            <span style="font-size: 14pt">
            Composite, no-resize</span>
        </div>
        <aspSample:SimpleCompositeControl id="SimpleControl1" runat="server" />
        <br /><br />
        <div style="font-family:tahoma;font-size:x-small;">
            <span style="font-size: 14pt">
            Composite, resize</span>
        </div>
        <aspSample:SimpleCompositeControl2 id="SimpleControl2" runat="server"  
            height="87px" width="238px" />
        <br /><br />
        <div style="font-family:tahoma;font-size:x-small;">
            <span style="font-size: 14pt">
                Container</span>
        </div>
        <aspSample:SimpleContainerControl id="SimpleControl3" runat="server" 
            height="57px">
            Type some content here.
        </aspSample:SimpleContainerControl>
        <br /><br />
    </div>
    </form>
</body>
</html>
<!-- </Snippet15> -->
