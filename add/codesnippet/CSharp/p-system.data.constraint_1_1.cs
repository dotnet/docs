 private void PrintConstraintNames(DataTable myTable){
    foreach(Constraint cs in myTable.Constraints){
       Console.WriteLine(cs.ConstraintName);
    }
 }