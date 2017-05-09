<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<html>
 <head>
 <script runat=server language="C#">
   void Page_Load(Object o, EventArgs e)
   {
     
   int UsageCount;
   // Create a new instance of the proxy class.
   MyMath.Math math = new MyMath.Math(); 
   // Make a call to the Math XML Web service, which throws an exception.
   try
       {
       math.Divide(3, 0);
       }
   catch (System.Web.Services.Protocols.SoapException error)
       {
       // Populate the table with the exception details.
       ErrorTable.Rows.Add(BuildNewRow("Fault Code Namespace", error.Code.Namespace));
       ErrorTable.Rows.Add(BuildNewRow("Fault Code Name", error.Code.Name));        
       ErrorTable.Rows.Add(BuildNewRow("SOAP Actor that threw Exception", error.Actor));        
       ErrorTable.Rows.Add(BuildNewRow("Error Message", error.Message));        
       return;
       }
   }
 
   HtmlTableRow BuildNewRow(string Cell1Text, string Cell2Text)
   {
       HtmlTableRow row = new HtmlTableRow();
       HtmlTableCell cell1 = new HtmlTableCell();
       HtmlTableCell cell2 = new HtmlTableCell();
         
       // Set the contents of the two cells.
       cell1.Controls.Add(new LiteralControl(Cell1Text));
       // Add the cells to the row.
       row.Cells.Add(cell1);
     
       cell2.Controls.Add(new LiteralControl(Cell2Text));
     
       // Add the cells to the row.
       row.Cells.Add(cell2);
       return row;
     }
 </script>
 </head>
 <body>
     <table id="ErrorTable"
        CellPadding=5 
        CellSpacing=0 
        Border="1" 
        BorderColor="black" 
        runat="server" />
 </body>
<!-- </Snippet1> -->

