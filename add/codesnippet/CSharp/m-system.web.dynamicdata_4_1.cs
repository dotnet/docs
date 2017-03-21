        MetaModel model = new MetaModel();
        model.RegisterContext(typeof(AdventureWorksLTDataContext), 
            new ContextConfiguration() { ScaffoldAllTables = true });