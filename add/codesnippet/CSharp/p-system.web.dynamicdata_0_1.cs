    // Gets only the visible tables in the data model.
    protected void GetVisibleTables()
    {
         System.Collections.IList visibleTables =
             MetaModel.Default.VisibleTables;
         if (visibleTables.Count == 0)
         {
             throw new InvalidOperationException(
                 "There are no accessible tables. Make sure that at least one data model is registered in Global.asax and scaffolding is enabled or implement custom pages.");
         }
         Menu1.DataSource = visibleTables;
         Menu1.DataBind();
    }