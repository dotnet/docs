 private void AddUniqueConstraint(DataTable table){
    table.Constraints.Add("idConstraint", table.Columns["id"], true);
 }