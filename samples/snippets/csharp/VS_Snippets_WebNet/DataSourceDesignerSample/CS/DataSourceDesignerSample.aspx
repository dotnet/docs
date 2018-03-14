<!-- <Snippet6> -->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="aspSample" Namespace="ASPNet.Design.Samples_CS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <aspSample:CustomDataSource ID="CustomDS1" 
        runat="server"></aspSample:CustomDataSource>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    
    </div>
    </form>
</body>
</html>
<!-- </Snippet6> -->