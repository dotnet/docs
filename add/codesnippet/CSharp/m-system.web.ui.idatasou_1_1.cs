        // The ListSourceHelper class calls GetList, which
        // calls the DataSourceControl.GetViewNames method.
        // Override the original implementation to return
        // a collection of one element, the default view name.
        protected override ICollection GetViewNames() {
            ArrayList al = new ArrayList(1);
            al.Add(CsvDataSourceView.DefaultViewName);
            return al as ICollection;
        }
    }