<%@ Register TagPrefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<!-- <Snippet3> -->
<%@ Page Language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>
      QuickContacts test page
    </title>
  </head>
  <body>
    <form id="Form1" runat="server">
      <aspSample:QuickContacts ID="QuickContacts1" Runat="server" 
        BorderStyle="Solid" BorderWidth="1px">
        <aspSample:Contact Name="someone" Email="someone@example.com" 
          Phone="(555) 555-0100"/>
        <aspSample:Contact Name="jae" Email="jae@fourthcoffee.com" 
          Phone="(555) 555-0101"/>
        <aspSample:Contact Name="lene" Email="lene@contoso.com" 
          Phone="(555) 555-0102"/>        
      </aspSample:QuickContacts>
    </form>
  </body>
</html>
<!-- </Snippet3> -->
