<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom Repeater - OnDataBinding - C# Example</title>
    <script language="C#" runat="server">
      void Page_Load(Object Sender, EventArgs e) 
      {
        if (!IsPostBack) 
        {
          ArrayList values = new ArrayList();
          values.Add(new PositionData("Microsoft", "Msft"));
          values.Add(new PositionData("Intel", "Intc"));
          values.Add(new PositionData("Dell", "Dell"));

          Repeater1.DataSource = values;
          Repeater1.DataBind();
        }
      }

      public class PositionData 
      {
        private string name;
        private string ticker;

        public PositionData(string name, string ticker) 
        {
          this.name = name;
          this.ticker = ticker;
        }

        public string Name 
        {
          get 
          {
            return name;
          }
        }

        public string Ticker 
        {
          get 
          {
            return ticker;
          }
        }
      }
    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom Repeater - OnDataBinding - C# Example</h3>
      <aspSample:CustomRepeaterOnDataBinding id="Repeater1" runat="server">
        <HeaderTemplate>
          <table border="1" cellpadding="4" cellspacing="0">
            <tr>
              <th>Company</th>
              <th>Symbol</th>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
          <tr>
            <td> <%# DataBinder.Eval(Container.DataItem, "Name") %></td>
            <td> <%# DataBinder.Eval(Container.DataItem, "Ticker") %></td>
          </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
      </aspSample:CustomRepeaterOnDataBinding>
    </form>
  </body>
</html>
<!-- </Snippet1> --> 