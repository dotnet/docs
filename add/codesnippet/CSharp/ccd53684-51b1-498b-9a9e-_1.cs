    // Get the registered action path.
    public string EvaluateActionPath()
    {
        string tableName = LinqDataSource1.TableName;
        
        MetaModel model = GetModel(false);

        string actionPath =
            model.GetActionPath(tableName,
                System.Web.DynamicData.PageAction.List, GetDataItem());
        return actionPath;
    }