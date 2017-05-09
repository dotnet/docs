
    public static void RegisterRoutes(RouteCollection routes) {
        
        // <Snippet99>
        MetaModel model = new MetaModel();
        model.RegisterContext(typeof(AdventureWorksLTDataContext), 
            new ContextConfiguration() { ScaffoldAllTables = true });
        // </Snippet99>
        
       
    }
