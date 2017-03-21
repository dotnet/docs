if (Context.IsEnabled) { 
   for (int i=0; i<DS.Tables["Categories"].Rows.Count; i++) { 
     Trace.Write("ProductCategory", DS.Tables["Categories"].Rows[i][0].ToString());
    }
}
   