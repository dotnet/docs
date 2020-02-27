<!-- <Snippet1> -->
<!--  -->
<!-- </Snippet1> -->
<!-- <Snippet2> -->
<!-- To view this code snippet in a fully-working example, see the 
Style Class topic. -->

<!-- </Snippet2> -->

<!-- <Snippet3> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Drawing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    private Style primaryStyle = new Style();

    void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Add data to the borderColorList, 
            // backColorList, and foreColorList controls.
            ListItemCollection colors = new ListItemCollection();
            colors.Add(Color.Black.Name);
            colors.Add(Color.Blue.Name);
            colors.Add(Color.Green.Name);
            colors.Add(Color.Orange.Name);
            colors.Add(Color.Purple.Name);
            colors.Add(Color.Red.Name);
            colors.Add(Color.White.Name);
            colors.Add(Color.Yellow.Name);
            borderColorList.DataSource = colors;
            borderColorList.DataBind();
            backColorList.DataSource = colors;
            backColorList.DataBind();
            foreColorList.DataSource = colors;
            foreColorList.DataBind();
            //<Snippet4>              

            // Add data to the borderStyleList control.
            ListItemCollection styles = new ListItemCollection();
            Type styleType = typeof(BorderStyle);
            foreach (string s in Enum.GetNames(styleType))
            {
                styles.Add(s);
            }
            borderStyleList.DataSource = styles;
            borderStyleList.DataBind();
            //</Snippet4>           

            // Add data to the borderWidthList control.
            ListItemCollection widths = new ListItemCollection();
            for (int i = 0; i < 11; i++)
            {
                widths.Add(i.ToString() + "px");
            }
            borderWidthList.DataSource = widths;
            borderWidthList.DataBind();

            // Add data to the fontNameList control.
            ListItemCollection names = new ListItemCollection();
            names.Add("Arial");
            names.Add("Courier");
            names.Add("Garamond");
            names.Add("Times New Roman");
            names.Add("Verdana");
            fontNameList.DataSource = names;
            fontNameList.DataBind();

            // Add data to the fontSizeList control.
            ListItemCollection fontSizes = new ListItemCollection();
            fontSizes.Add("Small");
            fontSizes.Add("Medium");
            fontSizes.Add("Large");
            fontSizes.Add("10pt");
            fontSizes.Add("14pt");
            fontSizes.Add("20pt");
            fontSizeList.DataSource = fontSizes;
            fontSizeList.DataBind();

            //Set primaryStyle as the style for each control.
            Label1.ApplyStyle(primaryStyle);
            ListBox1.ApplyStyle(primaryStyle);
            Button1.ApplyStyle(primaryStyle);
            Table1.ApplyStyle(primaryStyle);
            TextBox1.ApplyStyle(primaryStyle);
        }
    }
    //<Snippet5>
    void ChangeBorderColor(object sender, System.EventArgs e)
    {
        primaryStyle.BorderColor =
            Color.FromName(borderColorList.SelectedItem.Text);
        Label1.ApplyStyle(primaryStyle);
        ListBox1.ApplyStyle(primaryStyle);
        Button1.ApplyStyle(primaryStyle);
        Table1.ApplyStyle(primaryStyle);
        TextBox1.ApplyStyle(primaryStyle);
    }
    //</Snippet5>

    //<Snippet6>
    void ChangeBackColor(object sender, System.EventArgs e)
    {
        primaryStyle.BackColor =
            Color.FromName(backColorList.SelectedItem.Text);
        Label1.ApplyStyle(primaryStyle);
        ListBox1.ApplyStyle(primaryStyle);
        Button1.ApplyStyle(primaryStyle);
        Table1.ApplyStyle(primaryStyle);
        TextBox1.ApplyStyle(primaryStyle);
    }
    //</Snippet6>

    //<Snippet7>
    void ChangeForeColor(object sender, System.EventArgs e)
    {
        primaryStyle.ForeColor =
            Color.FromName(foreColorList.SelectedItem.Text);
        Label1.ApplyStyle(primaryStyle);
        ListBox1.ApplyStyle(primaryStyle);
        Button1.ApplyStyle(primaryStyle);
        Table1.ApplyStyle(primaryStyle);
        TextBox1.ApplyStyle(primaryStyle);
    }
    //</Snippet7>

    //<Snippet8>
    void ChangeBorderStyle(object sender, System.EventArgs e)
    {
        primaryStyle.BorderStyle =
            (BorderStyle)Enum.Parse(typeof(BorderStyle),
            borderStyleList.SelectedItem.Text);
        Label1.ApplyStyle(primaryStyle);
        ListBox1.ApplyStyle(primaryStyle);
        Button1.ApplyStyle(primaryStyle);
        Table1.ApplyStyle(primaryStyle);
        TextBox1.ApplyStyle(primaryStyle);
    }
    //</Snippet8>

    //<Snippet9>
    void ChangeBorderWidth(object sender, System.EventArgs e)
    {
        primaryStyle.BorderWidth =
            Unit.Parse(borderWidthList.SelectedItem.Text);
        Label1.ApplyStyle(primaryStyle);
        ListBox1.ApplyStyle(primaryStyle);
        Button1.ApplyStyle(primaryStyle);
        Table1.ApplyStyle(primaryStyle);
        TextBox1.ApplyStyle(primaryStyle);
    }
    //</Snippet9>

    //<Snippet10>
    void ChangeFont(object sender, System.EventArgs e)
    {
        primaryStyle.Font.Name =
            fontNameList.SelectedItem.Text;
        Label1.ApplyStyle(primaryStyle);
        ListBox1.ApplyStyle(primaryStyle);
        Button1.ApplyStyle(primaryStyle);
        Table1.ApplyStyle(primaryStyle);
        TextBox1.ApplyStyle(primaryStyle);
    }
    //</Snippet10>

    //<Snippet11>
    void ChangeFontSize(object sender, System.EventArgs e)
    {
        primaryStyle.Font.Size =
            FontUnit.Parse(fontSizeList.SelectedItem.Text);
        Label1.ApplyStyle(primaryStyle);
        ListBox1.ApplyStyle(primaryStyle);
        Button1.ApplyStyle(primaryStyle);
        Table1.ApplyStyle(primaryStyle);
        TextBox1.ApplyStyle(primaryStyle);
    }
    //</Snippet11>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <table cellpadding="6" border="0">
        <tr>
            <td rowspan="10" style="border:solid 1px Gray">
                <p>
                    <asp:label id="Label1" 
                        Text="Border Properties Example" Runat="server">
                        Label Styles
                    </asp:label>
                </p>
                <p>
                    <asp:button id="Button1" runat="server" 
                        Text="Button Styles">
                    </asp:button>
                </p>
                <p>
                    <asp:listbox id="ListBox1" Runat="server">
                        <asp:ListItem Value="0" Text="List Item 0">
                        </asp:ListItem>
                        <asp:ListItem Value="1" Text="List Item 1">
                        </asp:ListItem>
                        <asp:ListItem Value="2" Text="List Item 2">
                        </asp:ListItem>
                    </asp:listbox>
                </p>
                <p>
                    <asp:textbox id="TextBox1" 
                        Text="TextBox Styles" Runat="server">
                    </asp:textbox>
                </p>
                <p>
                    <asp:table id="Table1" Runat="server">
                        <asp:TableRow>
                            <asp:TableCell Text="(0,0)"></asp:TableCell>
                            <asp:TableCell Text="(0,1)"></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Text="(1,0)"></asp:TableCell>
                            <asp:TableCell Text="(1,1)"></asp:TableCell>
                        </asp:TableRow>
                    </asp:table>
                </p>
            </td>
            <td align="right">
                <asp:Label ID="Label2" runat="server" 
                    AssociatedControlID="borderColorList" 
                    Text="Border Color:">
                </asp:Label>
            </td>
            <td>
                <asp:dropdownlist id="borderColorList" 
                    Runat="server" AutoPostBack="True" 
                    OnSelectedIndexChanged="ChangeBorderColor">
                </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label3" Runat="server" 
                    AssociatedControlID="borderStyleList"
                    Text="Border Style:">
                </asp:Label>
            </td>
            <td>
                <asp:dropdownlist id="borderStyleList" 
                    Runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="ChangeBorderStyle">
                </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label4" Runat="server" 
                    AssociatedControlID="borderWidthList"
                    Text="Border Width">
                </asp:Label>
            </td>
            <td>
                <asp:dropdownlist id="borderWidthList" 
                    Runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="ChangeBorderWidth">
                </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label5" Runat="server" 
                    AssociatedControlID="backColorList"
                    Text="Back Color:">
                </asp:Label>
            </td>
            <td>
                <asp:dropdownlist id="backColorList" 
                    Runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="ChangeBackColor">
                </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label6" Runat="server" 
                    AssociatedControlID="foreColorList"
                    Text="Foreground Color:">
                </asp:Label>
            </td>
            <td>
                <asp:dropdownlist id="foreColorList" 
                    Runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="ChangeForeColor">
                </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label7" Runat="server" 
                    AssociatedControlID="fontNameList"
                    Text="Font Name:">
                </asp:Label>
            </td>
            <td>
                <asp:dropdownlist id="fontNameList" 
                    Runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="ChangeFont">
                </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label8" Runat="server" 
                    AssociatedControlID="fontSizeList"
                    Text="Font Size:">
                </asp:Label>
            </td>
            <td>
                <asp:dropdownlist id="fontSizeList" 
                    Runat="server" AutoPostBack="True" 
                    OnSelectedIndexChanged="ChangeFontSize">
                </asp:dropdownlist>
            </td>
        </tr>
    </table>

    </div>
    </form>
</body>
</html>
<!-- </Snippet3> -->
