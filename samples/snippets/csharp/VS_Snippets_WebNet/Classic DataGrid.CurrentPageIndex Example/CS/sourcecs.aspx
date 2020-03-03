<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script language="C#" runat="server">

      ICollection CreateDataSource() 
      {
         DataTable dt = new DataTable();
         DataRow dr;

         dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
         dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
         dt.Columns.Add(new DataColumn("DateTimeValue", typeof(string)));
         dt.Columns.Add(new DataColumn("BoolValue", typeof(bool)));

         for (int i = 0; i < 200; i++) 
         {
            dr = dt.NewRow();

            dr[0] = i;
            dr[1] = "Item " + i.ToString();
            dr[2] = DateTime.Now.ToShortDateString();
            dr[3] = (i % 2 != 0) ? true : false;

            dt.Rows.Add(dr);
         }

         DataView dv = new DataView(dt);
         return dv;
      }

      void Page_Load(Object sender, EventArgs e) 
      {
         if (chk1.Checked)
            MyDataGrid.PagerStyle.Visible=true;
         else
            MyDataGrid.PagerStyle.Visible=false;    

         BindGrid();
      }

      void PagerButtonClick(Object sender, EventArgs e) 
      {
         // Used by external paging UI.
         String arg = ((LinkButton)sender).CommandArgument;

         switch(arg)
         {
            case ("next"):
               if (MyDataGrid.CurrentPageIndex < (MyDataGrid.PageCount - 1))
                  MyDataGrid.CurrentPageIndex ++;
               break;
            case ("prev"):
               if (MyDataGrid.CurrentPageIndex > 0)
                  MyDataGrid.CurrentPageIndex --;
               break;
            case ("last"):
               MyDataGrid.CurrentPageIndex = (MyDataGrid.PageCount - 1);
               break;
            default:

               // Page number.
               MyDataGrid.CurrentPageIndex = Convert.ToInt32(arg);
               break;
         }
         BindGrid();
      }

      void MyDataGrid_Page(Object sender, DataGridPageChangedEventArgs e) 
      {
         // Used by built-in pager.  CurrentPageIndex is already set.
         BindGrid();
      }

      void BindGrid() 
      {
         MyDataGrid.DataSource = CreateDataSource();
         MyDataGrid.DataBind();
         ShowStats();
      }

      void ShowStats() 
      {
         lblCurrentIndex.Text = "CurrentPageIndex is " + MyDataGrid.CurrentPageIndex;
         lblPageCount.Text = "PageCount is " + MyDataGrid.PageCount;
      }


   </script>

<head runat="server">
    <title>DataGrid Custom Paging Controls</title>
</head>
<body>

   <form id="form1" runat="server">

      <h3>DataGrid Custom Paging Controls</h3>

      <asp:DataGrid id="MyDataGrid"
           AllowPaging="True"
           PageSize="10"
           OnPageIndexChanged="MyDataGrid_Page"
           BorderColor="black"
           BorderWidth="1"
           GridLines="Both"
           CellPadding="3"
           CellSpacing="0"
           Font-Names="Verdana"
           Font-Size="8pt"
           runat="server">

          <PagerStyle Mode="NumericPages"
                      HorizontalAlign="Right">
          </PagerStyle>

          <HeaderStyle BackColor="#aaaadd">
          </HeaderStyle>

          <AlternatingItemStyle BackColor="#eeeeee">
          </AlternatingItemStyle>

      </asp:DataGrid>

      <br />

      <asp:LinkButton id="btnPrev"
           Text="Previous page"
           CommandArgument="prev"
           ForeColor="navy"
           Font-Names="Verdana"
           Font-Size="8pt"
           OnClick="PagerButtonClick"
           runat="server"/>

      &nbsp;

      <asp:LinkButton id="btnNext"
           Text="Next page"
           CommandArgument="next"
           ForeColor="navy"
           Font-Names="Verdana"
           Font-Size="8pt"
           OnClick="PagerButtonClick"
           runat="server"/>

      &nbsp;

      <asp:LinkButton id="btnPage8" runat="server"
           Text="Go to Page 8"
           CommandArgument="7"
           ForeColor="navy"
           Font-Names="Verdana"
           Font-Size="8pt"
           OnClick="PagerButtonClick"/>

      &nbsp;
 
      <asp:LinkButton id="btnFirst"
           Text="Go to the first page"
           CommandArgument="0"
           ForeColor="navy"
           Font-Names="Verdana"
           Font-Size="8pt"
           OnClick="PagerButtonClick"
           runat="server"/>

      &nbsp;

      <asp:LinkButton id="btnLast"
           Text="Go to the last page"
           CommandArgument="last"
           ForeColor="navy"
           Font-Names="Verdana"
           Font-Size="8pt"
           OnClick="PagerButtonClick"
           runat="server"/>

      <br />

      <asp:Checkbox id="chk1"
           Text="Show built-in pager"
           Font-Names="Verdana"
           Font-Size="8pt"
           AutoPostBack="true"
           runat="server"/>

      <br />

      <table style="background-color:#eeeeee; padding:6">
         <tr>
            <td style="display:inline">
               

                  <asp:Label id="lblCurrentIndex" 
                       runat="server" />
                  <br />

                  <asp:Label id="lblPageCount" 
                       runat="server" />
                  <br />

               
            </td>
         </tr>
      </table>
   </form>

</body>
</html>

<!--</Snippet1>-->
