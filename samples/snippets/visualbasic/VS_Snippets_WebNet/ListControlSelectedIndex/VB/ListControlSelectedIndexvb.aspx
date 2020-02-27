<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <script language="vb" runat="server">

    Function CreateDataSource() As ICollection
        Dim dt As New DataTable()
        Dim dr As DataRow
        
        dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
        dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
        dt.Columns.Add(New DataColumn("DateTimeValue", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("BoolValue", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
        
        Dim i As Integer
        For i = 0 To 8
            dr = dt.NewRow()
            
            dr(0) = i
            dr(1) = "Item " + i.ToString()
            dr(2) = DateTime.Now
            If (i Mod 2) <> 0 Then
                dr(3) = True
            Else
                dr(3) = False
            End If
            dr(4) = 1.23 *(i + 1)
            
            dt.Rows.Add(dr)
        Next i
        
        Dim dv As New DataView(dt)
        Return dv
    End Function

    Sub Page_Load(sender As Object, e As EventArgs)
        If Not IsPostBack Then
            CheckBoxList1.DataSource = CreateDataSource()
            CheckBoxList1.DataTextField = "StringValue"
            CheckBoxList1.DataValueField = "CurrencyValue"
            CheckBoxList1.DataBind()
        End If
    End Sub

    Sub Index_Changed(sender As Object, e As EventArgs)        
        Label1.Text = "The index of the first item selected is: " & _
            CheckBoxList1.SelectedIndex.ToString()
    End Sub
 
 </script>
 
 <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
 
    <form id="form1" runat="server">
 
       <asp:CheckBoxList id="CheckBoxList1" 
            OnSelectedIndexChanged="Index_Changed"
            AutoPostBack="true"
            runat="server"/>
 
       <br />
 
       <asp:Label id="Label1" runat="server"/>
 
    </form>
 
 </body>
 </html>
 
<!--</Snippet1>-->
