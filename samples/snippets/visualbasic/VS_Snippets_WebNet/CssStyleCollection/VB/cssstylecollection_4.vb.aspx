<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    If Not IsPostBack Then
      CountStyleFunc(sender, e)
    End If
  End Sub

  Protected Sub CountStyleFunc(ByVal sender As Object, ByVal e As EventArgs)
    Dim styleCount As Integer
    ' Get the StylesCollection Count.
    styleCount = mytextBox.Style.Count
    Response.Write("<br /> CssStyleCollection Count  " & styleCount)
  End Sub


  Protected Sub AddBtn_Click(ByVal Src As Object, ByVal e As EventArgs)
    ' Add style to textbox.
    mytextBox.Style("background-color") = "green"
    CountStyleFunc(Src, e)
  End Sub

  Protected Sub ClearButton_Click(ByVal Src As Object, ByVal e As EventArgs)
    mytextBox.Style.Clear()
    CountStyleFunc(Src, e)
  End Sub

  Protected Sub RemoveButton_Click(ByVal Src As Object, ByVal e As EventArgs)
    mytextBox.Style.Remove("background-color")
    CountStyleFunc(Src, e)
  End Sub

  Protected Sub ShowButton_Click(ByVal Src As Object, ByVal e As EventArgs)
    
    Dim dt As New DataTable()
    Dim dr As DataRow
    dt.Columns.Add(New DataColumn("AttributeName", GetType(String)))
    dt.Columns.Add(New DataColumn("AttributeValue", GetType(String)))

    ' Get the styles collection.
    Dim styleKey As Object
    For Each styleKey In mytextBox.Style.Keys
      
      dr = dt.NewRow()
      dr(0) = CStr(styleKey)
      dr(1) = mytextBox.Style(CStr(styleKey))
      dt.Rows.Add(dr)

    Next styleKey
    Dim dv As New DataView(dt)
    DataList1.DataSource = dv
    DataList1.DataBind()

  End Sub
   </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>CssStyleCollection Example</title>
</head>
   <body>
      <form id="CSSForm" runat="server">
        <div>
         <input type="text"
                id="mytextBox"
                style="color:black;font: 12pt arial;" 
                runat="server" 
                name="mytextBox"/>
         <br /> <br />
         <input type="Button"
                id="addBtn"
                value="AddStyle"
                onserverclick="AddBtn_Click"
                runat="server" 
                name="addBtn"/>
         <input type="Button" 
                id="removeBtn" 
                value="RemoveStyle" 
                onserverclick="RemoveButton_Click" 
                runat="server"
                name="removeBtn"/>
         <input type="Button" 
                id="clearBtn"
                value="ClearStyle" 
                onserverclick="ClearButton_Click" 
                runat="server" 
                name="clearBtn"/>
         <input type="Button" 
                id="showBtn"
                value="ShowAllStyles" 
                onserverclick="ShowButton_Click" 
                runat="server"
                name="showBtn"/>
         <asp:DataList id="DataList1"
                       runat="server">
           <HeaderStyle Font-Bold="true"/>
           <HeaderTemplate>
              CssStyleCollection
           </HeaderTemplate>
           <ItemTemplate>
             Attribute: 
             <%# DataBinder.Eval(Container.DataItem, "AttributeName") %>
             , 
             Value: 
             <%# DataBinder.Eval(Container.DataItem, "AttributeValue") %>
           </ItemTemplate>
         </asp:DataList>
        </div>
      </form>
   </body>
</html>
<!-- </Snippet1> -->