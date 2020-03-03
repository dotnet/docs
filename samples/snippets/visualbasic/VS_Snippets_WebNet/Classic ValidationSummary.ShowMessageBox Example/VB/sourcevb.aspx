<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>ASP.NET Sample</title>
</head>
<body>
<!--<Snippet1>-->

 <asp:ValidationSummary 
      id="valSum" 
      DisplayMode="BulletList"
      ShowMessageBox="true"
      ShowSummary="false" 
      HeaderText="You must enter a value in the following fields:"
      Font-Names="verdana" 
      Font-Size="12"
      runat="server"/>
    
<!--</Snippet1>-->
</body>
</html>