<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Validate Against a Specific Value for ASP.NET Server Controls</title>
</head>
<body>
    <form id="form1" runat="server">
      <div>
      
      <!--<Snippet2>-->
      <table>
        <tr>
          <td>
            <asp:Textbox id="txtAge" runat="server"></asp:Textbox>
          </td>
          <td>
            <asp:CompareValidator id="CompareFieldValidator1" runat="server"
              ForeColor="Red"
              ControlToValidate="txtAge"
              ValueToCompare="0"
              Type="Integer"
              Operator="GreaterThanEqual"
              ErrorMessage="Please enter a whole number zero or greater.">
            </asp:CompareValidator >
          </td>
        </tr>
      </table>
      <!--</Snippet2>-->
      
      <!--<Snippet3>-->
      <table>
        <tr>
          <td>
            Arrive<asp:Textbox id="txtArrivalDate" runat="server"></asp:Textbox>
            Depart<asp:Textbox id="txtDepartureDate" runat="server"></asp:Textbox>
          </td>
          <td>
            <asp:CompareValidator id="CompareValidator1" runat="server"
              ForeColor="Red"
              ControlToValidate="txtDepartureDate"
              ControlToCompare="txtArrivalDate"
              Type="Date"       
              Operator="GreaterThanEqual"      
              ErrorMessage="Departure date cannot be earlier than arrival date.">
            </asp:CompareValidator >
          </td>
        </tr>
      </table>
      <!--</Snippet3>-->

<asp:Button id="Button1" runat="server"></asp:Button>
      </div>
    </form>
</body>
</html>
