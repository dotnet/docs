    // Create route information based on the
    // foreign-key specified in the 
    // DynamicRouteExpression page markup. 
    protected string GetRouteInformation()
    {

        // Retrieve the current data item.
        var productItem = (Product)GetDataItem();

        if (productItem != null)
        {

            RouteValueDictionary rvd = new RouteValueDictionary();
            rvd.Add("ProductCategoryID", productItem.ProductCategoryID );

            string routePath =
                table.GetActionPath(PageAction.List, rvd);

            return routePath;

        }

        return string.Empty;
    }

    // Get the name of the foreign-key category. 
    protected string GetProductCategory()
    {
        // Retrieves the current data item.
        var productItem = (Product)GetDataItem();

        if (productItem != null)
        {
            return productItem.ProductCategory.Name;
        }
        return string.Empty;
    }