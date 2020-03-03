<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script language = "VB" runat="server">

Function CreateDataSource() As ICollection
   Dim dt As New DataTable()
   Dim dr As DataRow
   
   dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
   
   Dim i As Integer
   For i = 0 To 9
      dr = dt.NewRow()
      dr(0) = "Item " + i.ToString()
      dt.Rows.Add(dr)
   Next i
   
   Dim dv As New DataView(dt)
   Return dv
End Function 'CreateDataSource

' <snippet1> 
Sub Page_Load(sender As [Object], e As EventArgs)
   If Not IsPostBack Then
      DataList1.AlternatingItemTemplate = LoadTemplate("newtemplate.ascx")
      
      DataList1.DataSource = CreateDataSource()
      DataList1.DataBind()
   End If
End Sub 'Page_Load

' </snippet1> 
Sub Button1_Click(sender As [Object], e As EventArgs)
   
   If DropDown1.SelectedIndex = 0 Then
      DataList1.RepeatDirection = RepeatDirection.Horizontal
   Else
      DataList1.RepeatDirection = RepeatDirection.Vertical
   End If 
   If DropDown2.SelectedIndex = 0 Then
      DataList1.RepeatLayout = RepeatLayout.Table
   Else
      DataList1.RepeatLayout = RepeatLayout.Flow
   End If
   DataList1.RepeatColumns = DropDown3.SelectedIndex + 1
   
   If Check1.Checked = True And DataList1.RepeatLayout = RepeatLayout.Table Then
      
      DataList1.BorderWidth = Unit.Pixel(1)
      DataList1.GridLines = GridLines.Both
   Else
      DataList1.BorderWidth = Unit.Pixel(0)
      DataList1.GridLines = GridLines.None
   End If
End Sub 'Button1_Click
</script>

<head runat="server">
    <title>DataList Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataList Example</h3>
 
       <asp:DataList id="DataList1" runat="server"
           BorderColor="black"
           CellPadding="3"
           Font-Names="Verdana"
           Font-Size="8pt">

         <HeaderStyle BackColor="#aaaadd">
         </HeaderStyle>

         <AlternatingItemStyle BackColor="Gainsboro">
         </AlternatingItemStyle>

         <HeaderTemplate>

            Items

         </HeaderTemplate>
               
         <ItemTemplate>

            <%# DataBinder.Eval(Container.DataItem, "StringValue") %>

         </ItemTemplate>

 
      </asp:DataList>

      <br />
      <hr style="width: 300px; text-align:left" />

      RepeatDirection:

      <asp:DropDownList id="DropDown1" runat="server">

         <asp:ListItem>Horizontal</asp:ListItem>
         <asp:ListItem>Vertical</asp:ListItem>

      </asp:DropDownList><br />
 
      RepeatLayout:

      <asp:DropDownList id="DropDown2" runat="server">

         <asp:ListItem>Table</asp:ListItem>
         <asp:ListItem>Flow</asp:ListItem>

      </asp:DropDownList><br />
 
RepeatColumns:

      <asp:DropDownList id="DropDown3" runat="server">

         <asp:ListItem>1</asp:ListItem>
         <asp:ListItem>2</asp:ListItem>
         <asp:ListItem>3</asp:ListItem>
         <asp:ListItem>4</asp:ListItem>
         <asp:ListItem>5</asp:ListItem>

      </asp:DropDownList><br />
         
      Show Borders: 

      <asp:CheckBox id="Check1" runat="server" /><br />
         
      <asp:LinkButton id="Button1" 
           Text="Refresh DataList" 
           OnClick="Button1_Click" 
           runat="server"/>
   </form>
 
</body>
</html>