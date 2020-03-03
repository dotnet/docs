<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Hyperlinks using expressions</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!-- <Snippet2> -->
    <!-- Define a hyperlink that maps the NavigateUrl property to the
         MyHyperLinkSetting value in the Web.Config appSettings section. -->
    <asp:HyperLink runat="server" ID="HyperLink1" 
         NavigateUrl="<%$ AppSettings:MyHyperLinkSetting %>">
         HyperLink using an AppSetting expression
    </asp:HyperLink>
    <!-- </Snippet2> -->
    
    <br />
    <br />
    
    <!-- <Snippet3> -->
    <!-- Define a hyperlink that maps the Text property to the
         myLinkText string value in the Strings.resx resource file. -->
    <asp:HyperLink runat="server" ID="HyperLink2" 
         Text="<%$ Resources:Strings, myLinkText%>"
         NavigateUrl="http://www.microsoft.com"></asp:HyperLink>
    <!-- </Snippet3> -->
        <br />
        <br />
        
    <!-- <Snippet4> -->
      <!-- Define a SQL data source control that maps the ConnectionStrings
       property to the MyDBConnection value in the Web.Config 
       connectionStrings section. -->
    <asp:SqlDataSource ID="MySqlDataSource" runat="server" 
         ConnectionString="<%$ ConnectionStrings:MyDBConnection %>">
    </asp:SqlDataSource>
    <!-- </Snippet4> -->
    
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->