<script runat="server">
private void UpdateRecords(Object source, EventArgs e)
{
  CheckBox cb;
  foreach(GridViewRow row in this.GridView1.Rows) {
    cb = (CheckBox) row.Cells[0].Controls[1];
    if(cb.Checked) {
      string oid = (string) row.Cells[1].Text;
      MyAccessDataSource.UpdateParameters.Add("date", TypeCode.DateTime, DateTime.Now.ToString());
      MyAccessDataSource.UpdateParameters.Add("orderid", oid);
      MyAccessDataSource.Update();
      MyAccessDataSource.UpdateParameters.Clear();
    }
  }
}
</script>