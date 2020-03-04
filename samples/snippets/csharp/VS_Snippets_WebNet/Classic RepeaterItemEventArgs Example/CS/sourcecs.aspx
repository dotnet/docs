<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script language="C#" runat="server">
    int Count = 1;
    void Page_Load(Object Sender, EventArgs e) 
    {
        if (!IsPostBack) {
            ArrayList values = new ArrayList();
 
            values.Add(new PositionData("Microsoft", "Msft"));
            values.Add(new PositionData("Intel", "Intc"));
            values.Add(new PositionData("Dell", "Dell"));
 
            Repeater1.DataSource = values;
            Repeater1.DataBind();
        }
    }
 
    void R1_ItemCreated(Object Sender, RepeaterItemEventArgs e) 
    {
        String iTypeText = "";
 
        switch (e.Item.ItemType) 
        {
            case ListItemType.Item:
                iTypeText = "Item";
                break;
            case ListItemType.AlternatingItem:
                iTypeText = "AlternatingItem";
                break;
            case ListItemType.Header:
                iTypeText = "Header";
                break;
            case ListItemType.Footer:
                iTypeText = "Footer";
                break;
            case ListItemType.Separator:
                iTypeText = "Separator";
                break;
        }
        Label1.Text += "(" + Count++ + ") A Repeater " + iTypeText + " has been created; <br />";
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
            get { return name; }
        }
 
        public string Ticker 
        {
             get { return ticker; }
        }
    }
</script>
 
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Repeater Example</title>
</head>
<body>
    <form id="form1" runat="server">

    <h3>Repeater Example</h3>
 
       <p style="font-weight: bold">Repeater1:</p>
         
       <asp:Repeater ID="Repeater1" OnItemCreated="R1_ItemCreated" runat="server">
          <HeaderTemplate>
             <table border="1">
                <tr>
                   <td style="font-weight:bold">Company</td>
                   <td style="font-weight:bold">Symbol</td>
                </tr>
          </HeaderTemplate>
             
          <ItemTemplate>
             <tr>
                <td> <%# DataBinder.Eval(Container.DataItem, "Name") %> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "Ticker") %> </td>
             </tr>
          </ItemTemplate>
             
          <FooterTemplate>
             </table>
          </FooterTemplate>
             
       </asp:Repeater>
       <br />
         
       <asp:Label ID="Label1" Font-Names="Verdana" 
          ForeColor="Green" Font-Size="10pt" Runat="server"/>
    </form>
 </body>
 </html>
<!--</Snippet1>-->
