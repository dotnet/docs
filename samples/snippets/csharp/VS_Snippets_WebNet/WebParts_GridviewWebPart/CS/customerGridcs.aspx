<!-- <snippet1> -->
<%@ Page Language="C#" %>
<!-- Register the user control to change display modes. -->
<%@ register src="displaymodecs.ascx" tagname="displaymodecs" 
    tagprefix="uc1" %>
<!-- Register the namespace that contains the custom WebPart 
control. Note there is no assembly attribute because this example 
uses dynamic compilation, by placing the source file for the 
control in an App_Code subfolder. -->
<%@ register tagprefix="aspSample" 
    namespace="Samples.AspNet.CS.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:webpartmanager id="WebPartManager1" runat="server">
      </asp:webpartmanager>
      <uc1:displaymodecs id="Displaymodecs1" runat="server" />
      <br />
      <table style="width: 80%; position: relative">
        <tr valign="top">
          <td style="width: 40%">
            <asp:webpartzone id="WebPartZone1" runat="server" 
              style="position: relative" >
              <parttitlestyle font-size="14" font-names="Verdana, Arial" />
              <zonetemplate>
                <aspSample:SmallGridWebPart id="grid1" runat="server" 
                  title="Customer Phone List" width="300" 
                  connectionstring="<%$ ConnectionStrings:nwind %>"  
                  />
              </zonetemplate>
            </asp:webpartzone>
          </td>
          <td style="width: 40%">
            <asp:webpartzone id="WebPartZone2" runat="server" 
              style="position: relative">
              <zonetemplate>
                <asp:calendar id="Calendar1" runat="server" 
                  style="position: relative"></asp:calendar>
              </zonetemplate>
            </asp:webpartzone>
          </td>
        </tr>
      </table>
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->