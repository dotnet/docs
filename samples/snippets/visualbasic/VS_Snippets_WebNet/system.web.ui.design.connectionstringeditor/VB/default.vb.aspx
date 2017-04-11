<%@ Page Language="VB" AutoEventWireup="false" %>
<!-- Register the tag prefix for the custom control in the sample file.
     The namespace must match that in the CS source file, and the 
     assembly must match the bin\*.DLL file compiled by the makefile. -->
     
<%@ Register tagprefix="aspSample" 
    namespace="ASP.NET.Samples.VB"
    assembly="ConnectionStringEditorSample_VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <aspSample:SqlDataSourceWithBackup runat="server" id="MyVBControl">
         </aspSample:SqlDataSourceWithBackup>
    
   
    </div>
    </form>
</body>
</html>
