<!-- <Snippet1> -->
<%@ Page Language="VB"%>
<html>
 <head>
 <script runat=server language="VB">
Sub Page_Load(o As Object, e As EventArgs)    
    Dim UsageCount As Integer
    ' Create a new instance of the proxy class.
    Dim math As New MyMath.Math()
    ' Make a call to the Math XML Web service, which throws an exception.
    Try
        math.Divide(3, 0)
    Catch err As System.Web.Services.Protocols.SoapException
        ' Populate our Table with the Exception details
        ErrorTable.Rows.Add(BuildNewRow("Fault Code Namespace", err.Code.Namespace))
        ErrorTable.Rows.Add(BuildNewRow("Fault Code Name", err.Code.Name))
        ErrorTable.Rows.Add(BuildNewRow("SOAP Actor that threw Exception", err.Actor))
        ErrorTable.Rows.Add(BuildNewRow("Error Message", err.Message))
        Return
    End Try
End Sub 'Page_Load


Function BuildNewRow(Cell1Text As String, Cell2Text As String) As HtmlTableRow
    Dim row As New HtmlTableRow()
    Dim cell1 As New HtmlTableCell()
    Dim cell2 As New HtmlTableCell()
    
    ' Set the contents of the two cells.
    cell1.Controls.Add(New LiteralControl(Cell1Text))
    ' Add the cells to the row.
    row.Cells.Add(cell1)
    
    cell2.Controls.Add(New LiteralControl(Cell2Text))
    
    ' Add the cells to the row.
    row.Cells.Add(cell2)
    Return row
End Function 'BuildNewRow
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

