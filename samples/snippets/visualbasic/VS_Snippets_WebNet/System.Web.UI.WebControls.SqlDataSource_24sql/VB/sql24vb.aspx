<!-- <Snippet1> -->
<%@Page  Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
Private Sub InsertShipper (ByVal Source As Object, ByVal e As EventArgs)
  SqlDataSource1.Insert()
End Sub ' InsertShipper
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <asp:dropdownlist
        id="DropDownList1"
        runat="server"
        datasourceid="SqlDataSource1"
        datatextfield="CompanyName"
        datavaluefield="ShipperID" />

<!-- Security Note: The SqlDataSource uses a FormParameter,
     Security Note: which does not perform validation of input from the client.
     Security Note: To validate the value of the FormParameter, handle the Inserting event. -->

      <asp:sqldatasource
        id="SqlDataSource1"
        runat="server"
        connectionstring="<%$ ConnectionStrings:MyNorthwind %>"
        selectcommand="SELECT CompanyName,ShipperID FROM Shippers"
        insertcommand="INSERT INTO Shippers (CompanyName,Phone) VALUES (@CoName,@Phone)">
          <insertparameters>
            <asp:formparameter name="CoName" formfield="CompanyNameBox" />
            <asp:formparameter name="Phone"  formfield="PhoneBox" />
          </insertparameters>
      </asp:sqldatasource>

      <br /><asp:textbox
           id="CompanyNameBox"
           runat="server" />

      <asp:RequiredFieldValidator
        id="RequiredFieldValidator1"
        runat="server"
        ControlToValidate="CompanyNameBox"
        Display="Static"
        ErrorMessage="Please enter a company name." />

      <br /><asp:textbox
           id="PhoneBox"
           runat="server" />

      <asp:RequiredFieldValidator
        id="RequiredFieldValidator2"
        runat="server"
        ControlToValidate="PhoneBox"
        Display="Static"
        ErrorMessage="Please enter a phone number." />

      <br /><asp:button
           id="Button1"
           runat="server"
           text="Insert New Shipper"
           onclick="InsertShipper" />

    </form>
  </body>
</html>
<!-- </Snippet1> -->