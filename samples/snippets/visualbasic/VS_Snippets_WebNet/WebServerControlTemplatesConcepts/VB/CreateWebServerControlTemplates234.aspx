<%@ Page Language="VB"   %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Create Web Server Control Templates</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <!--<Snippet2>-->
      <asp:DataList id="DataList1" runat="server">
        <ItemTemplate>
        
        </ItemTemplate>
      </asp:DataList>
      <!--</Snippet2>-->

  
      <!-- <Snippet3> -->
      <asp:DataList id="DataList3" runat="server">
         <ItemTemplate>
          Name: <asp:Label ID="Label2" runat="server" 
          Text='<%# DataBinder.Eval(Container, "DataItem.EmployeeName")%>'/>
         </ItemTemplate>
      </asp:DataList>
      <!--</Snippet3>-->
    
    
      <!--<Snippet4>-->
      <asp:datalist id="DataList2" runat="server" >
         <HeaderTemplate>
         Items matching your query: 
         </HeaderTemplate>
         <ItemTemplate>
         Name: <asp:Label id="Label1" runat="server" 
           Text='<%# DataBinder.Eval(Container, "DataItem.EmployeeName")%>'></asp:Label>
         </ItemTemplate>
         <SeparatorTemplate>
           <br /><hr />
         </SeparatorTemplate>
      </asp:datalist>
      <!--</Snippet4>-->
   
   </form>
</body>
</html>
