      if (Trace.IsEnabled)
      {
        for (int i=0; i<ds.Tables["Categories"].Rows.Count; i++)
        {
          Trace.Write("ProductCategory",ds.Tables["Categories"].Rows[i][0].ToString());
        }
      }