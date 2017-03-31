<!-- <Snippet1> -->
<!-- -->
<!-- </Snippet1> -->
<!-- <Snippet2> -->
<!-- To view this code snippet in a fully-working example, see the 
Style Class topic. -->

<!-- </Snippet2> -->

<!-- <Snippet3> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Drawing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Private primaryStyle As New Style()

    Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            ' Add data to the borderColorList, 
            ' backColorList, and foreColorList controls.
            Dim colors As New ListItemCollection()
            colors.Add(Color.Black.Name)
            colors.Add(Color.Blue.Name)
            colors.Add(Color.Green.Name)
            colors.Add(Color.Orange.Name)
            colors.Add(Color.Purple.Name)
            colors.Add(Color.Red.Name)
            colors.Add(Color.White.Name)
            colors.Add(Color.Yellow.Name)
            borderColorList.DataSource = colors
            borderColorList.DataBind()
            backColorList.DataSource = colors
            backColorList.DataBind()
            foreColorList.DataSource = colors
            foreColorList.DataBind()
                
            '<Snippet4>
            ' Add data to the borderStyleList control.
            Dim styles As New ListItemCollection()
            Dim styleType As Type = GetType(BorderStyle)
            Dim s As String
            For Each s In [Enum].GetNames(styleType)
                styles.Add(s)
            Next s
            borderStyleList.DataSource = styles
            borderStyleList.DataBind()
            '</Snippet4>           

            ' Add data to the borderWidthList control.
            Dim widths As New ListItemCollection()
            Dim i As Integer
            For i = 0 To 10
                widths.Add(i.ToString() & "px")
            Next i
            borderWidthList.DataSource = widths
            borderWidthList.DataBind()

            ' Add data to the fontNameList control.
            Dim names As New ListItemCollection()
            names.Add("Arial")
            names.Add("Courier")
            names.Add("Garamond")
            names.Add("Times New Roman")
            names.Add("Verdana")
            fontNameList.DataSource = names
            fontNameList.DataBind()

            ' Add data to the fontSizeList control.
            Dim fontSizes As New ListItemCollection()
            fontSizes.Add("Small")
            fontSizes.Add("Medium")
            fontSizes.Add("Large")
            fontSizes.Add("10pt")
            fontSizes.Add("14pt")
            fontSizes.Add("20pt")
            fontSizeList.DataSource = fontSizes
            fontSizeList.DataBind()
                    
            ' Set primaryStyle as the style for each control.
            Label1.ApplyStyle(primaryStyle)
            ListBox1.ApplyStyle(primaryStyle)
            Button1.ApplyStyle(primaryStyle)
            Table1.ApplyStyle(primaryStyle)
            TextBox1.ApplyStyle(primaryStyle)
        End If
    End Sub

    '<Snippet5>
    Sub ChangeBorderColor(ByVal sender As Object, ByVal e As System.EventArgs)
        primaryStyle.BorderColor = _
            Color.FromName(borderColorList.SelectedItem.Text)
        Label1.ApplyStyle(primaryStyle)
        ListBox1.ApplyStyle(primaryStyle)
        Button1.ApplyStyle(primaryStyle)
        Table1.ApplyStyle(primaryStyle)
        TextBox1.ApplyStyle(primaryStyle)
    End Sub
    '</Snippet5>

    '<Snippet6>    
    Sub ChangeBackColor(ByVal sender As Object, ByVal e As System.EventArgs)
        primaryStyle.BackColor = _
            Color.FromName(backColorList.SelectedItem.Text)
        Label1.ApplyStyle(primaryStyle)
        ListBox1.ApplyStyle(primaryStyle)
        Button1.ApplyStyle(primaryStyle)
        Table1.ApplyStyle(primaryStyle)
        TextBox1.ApplyStyle(primaryStyle)
    End Sub
    '</Snippet6>

    '<Snippet7>
    Sub ChangeForeColor(ByVal sender As Object, ByVal e As System.EventArgs)
        primaryStyle.ForeColor = _
            Color.FromName(foreColorList.SelectedItem.Text)
        Label1.ApplyStyle(primaryStyle)
        ListBox1.ApplyStyle(primaryStyle)
        Button1.ApplyStyle(primaryStyle)
        Table1.ApplyStyle(primaryStyle)
        TextBox1.ApplyStyle(primaryStyle)
    End Sub
    '</Snippet7>

    '<Snippet8>
    Sub ChangeBorderStyle(ByVal sender As Object, ByVal e As System.EventArgs)
        primaryStyle.BorderStyle = _
            CType([Enum].Parse(GetType(BorderStyle), _
            borderStyleList.SelectedItem.Text), BorderStyle)
        Label1.ApplyStyle(primaryStyle)
        ListBox1.ApplyStyle(primaryStyle)
        Button1.ApplyStyle(primaryStyle)
        Table1.ApplyStyle(primaryStyle)
        TextBox1.ApplyStyle(primaryStyle)
    End Sub
    '</Snippet8>

    '<Snippet9>
    Sub ChangeBorderWidth(ByVal sender As Object, ByVal e As System.EventArgs)
        primaryStyle.BorderWidth = _
            Unit.Parse(borderWidthList.SelectedItem.Text)
        Label1.ApplyStyle(primaryStyle)
        ListBox1.ApplyStyle(primaryStyle)
        Button1.ApplyStyle(primaryStyle)
        Table1.ApplyStyle(primaryStyle)
        TextBox1.ApplyStyle(primaryStyle)
    End Sub
    '</Snippet9>

    '<Snippet10>
    Sub ChangeFont(ByVal sender As Object, ByVal e As System.EventArgs)
        primaryStyle.Font.Name = _
            fontNameList.SelectedItem.Text
        Label1.ApplyStyle(primaryStyle)
        ListBox1.ApplyStyle(primaryStyle)
        Button1.ApplyStyle(primaryStyle)
        Table1.ApplyStyle(primaryStyle)
        TextBox1.ApplyStyle(primaryStyle)
    End Sub
    '</Snippet10>

    '<Snippet11>
    Sub ChangeFontSize(ByVal sender As Object, ByVal e As System.EventArgs)
        primaryStyle.Font.Size = _
            FontUnit.Parse(fontSizeList.SelectedItem.Text)
        Label1.ApplyStyle(primaryStyle)
        ListBox1.ApplyStyle(primaryStyle)
        Button1.ApplyStyle(primaryStyle)
        Table1.ApplyStyle(primaryStyle)
        TextBox1.ApplyStyle(primaryStyle)
    End Sub
    '</Snippet11>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Applied Style Example</title>
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