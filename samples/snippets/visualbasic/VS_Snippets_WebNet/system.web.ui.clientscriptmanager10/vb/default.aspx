<!-- <Snippet1> -->
<%@ Page EnableEventValidation="true" Language="VB"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Register an option for event validation</title>
    <script runat="server">
        Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
            ClientScript.RegisterForEventValidation("DropDownList1", "This is Option 1")
            ClientScript.RegisterForEventValidation("DropDownList1", "This is Option 2")
            ClientScript.RegisterForEventValidation("DropDownList1", "This is Option 3")
            ' Uncomment the line below when you want to specifically register the option for event validation.
            ' ClientScript.RegisterForEventValidation("DropDownList1", "Is this option registered for event validation?")
            MyBase.Render(writer)
        End Sub
    </script>
    <script type="text/javascript">
        function Initialize()
        {
            var oOption = document.createElement("OPTION");
            document.all("DropDownList1").options.add(oOption);
            oOption.innerText = "This is Option 1";            
            oOption = document.createElement("OPTION");            
            document.all("DropDownList1").options.add(oOption);
            oOption.innerText = "This is Option 2";
            oOption = document.createElement("OPTION");                
            document.all("DropDownList1").options.add(oOption); 
            oOption.innerText = "This is Option 3";
            oOption = document.createElement("OPTION");                
            document.all("DropDownList1").options.add(oOption); 
            oOption.innerText = "Is this option registered for event validation?";
        }
    </script>
</head>
<body onload="Initialize();">
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Postback to server for validation" />
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->

