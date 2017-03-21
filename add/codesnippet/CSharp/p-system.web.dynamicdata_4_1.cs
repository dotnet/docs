    // Get the data model. 
    public MetaModel GetModel(bool defaultModel)
    {
        MetaModel model;

        if (defaultModel)
            model = MetaModel.Default;
        else
            model =
               MetaModel.GetModel(typeof(AdventureWorksLTDataContext));
        return model;
    }