<%@ Register TagPrefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" 
  Assembly="Samples.AspNet.CS" %>
<!-- <Snippet2> -->
<%@ Page Language="C#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      VacationHome1.DataBind();
      VacationHome2.DataBind();
    }
  }
  
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>
      VacationHome Control Test Page
    </title>
  </head>
  <body>
    <form id="form1" runat="server">
    <aspSample:VacationHome ID="VacationHome1" 
      Title="Condo for Rent in Hawaii"  
      Caption="Ocean view starting $200" 
      Runat="server" Width="230px" Height="129px">
    <Template>
      <table id="TABLE1" runat="server" 
        style="width: 286px; height: 260px; 
        background-color:Aqua; text-align:center">
        <tr>
          <td style="width: 404px" align="center">
            <asp:Label ID="Label1" Runat="server" 
              Text="<%#Container.Title%>" 
              Font-Names="Arial, Helvetica"></asp:Label>
          </td>
        </tr>
        <tr>
          <td style="width: 404px">
            <asp:Image ID="Image1" Runat="server" 
              ImageUrl="~/images/hawaii.jpg" 
              AlternateText="Hawaii home" />
          </td>
        </tr>
        <tr>
          <td style="width: 404px; height: 26px;" align="center">
            <asp:Label ID="Label2" Runat="server" 
              Text="<%#Container.Caption%>" 
              Font-Names="Arial, Helvetica">
            </asp:Label>
          </td>
        </tr>
      </table>
     </Template>
    </aspSample:VacationHome>  
    <br /> <br />
      <br />
    The VacationHome control rendered with its default template:
    <br /> <br />
    <aspSample:VacationHome ID="VacationHome2" 
      Title="Condo for Rent in Hawaii" 
      Caption="Ocean view starting $200" 
      Runat="server" BorderStyle="Solid" BackColor="#66ffff" 
      Height="30px" Width="238px" Font-Names="Arial, Helvetica" />
    </form>
  </body>
</html>
<!-- </Snippet2> -->
