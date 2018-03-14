<!-- <Snippet15> -->
<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Validate Programmatically for ASP.NET Server Controls</title>
</head>

<script runat="server">
    
    private void Button1_Click(object sender, System.EventArgs e)
    {
        RangeValidator1.MinimumValue = txtArrival.Text;
        RangeValidator1.MaximumValue = txtDeparture.Text;
        RangeValidator1.Type = ValidationDataType.Date;
        RangeValidator1.Validate();

        if (!RangeValidator1.IsValid)
        {
            RangeValidator1.ErrorMessage = "The tour date must " +
            "fall between the arrival and departure dates.";
        }
    }
    
</script>

<body>
    <form id="form1" runat="server">
    <div>
      Arrival:
      <asp:TextBox id="txtArrival" runat="server"></asp:TextBox><br />
      
      Departure:
      <asp:TextBox id="txtDeparture" runat="server"></asp:TextBox><br />
     
      Free Tour Date:
      <asp:TextBox id="txtFreeTour" runat="server"></asp:TextBox><br />
      <asp:RangeValidator EnableClientScript="false" 
                          id="RangeValidator1" 
                          runat="server" 
                          ControlToValidate="txtFreeTour" >
      </asp:RangeValidator>
      
      <asp:Button Text="Book Trip" id="Button1" OnClick="Button1_Click" runat="server" />
    </div>
    </form>
</body>
</html>
<!-- </Snippet15> -->
