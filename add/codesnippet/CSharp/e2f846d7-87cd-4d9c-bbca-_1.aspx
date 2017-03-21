<script runat="server">
private void UpdateRecords(Object source, EventArgs e)
{
  // This method is an example of batch updating using a
  // data source control. The method iterates through the rows
  // of the GridView, extracts each CheckBox from the row and, if
  // the CheckBox is checked, updates data by calling the Update
  // method of the data source control, adding required parameters
  // to the UpdateParameters collection.
  CheckBox cb;
  foreach(GridViewRow row in this.GridView1.Rows) {
    cb = (CheckBox) row.Cells[0].Controls[1];
    if(cb.Checked) {
      string oid = (string) row.Cells[1].Text;
      MyAccessDataSource.UpdateParameters.Add(new Parameter("date",TypeCode.DateTime,DateTime.Now.ToString()));
      MyAccessDataSource.UpdateParameters.Add(new Parameter("orderid",TypeCode.String,oid));
      MyAccessDataSource.Update();
      MyAccessDataSource.UpdateParameters.Clear();
    }
  }
}
</script>