        protected override void PerformSelect() {            

           // Call OnDataBinding here if bound to a data source using the
           // DataSource property (instead of a DataSourceID), because the
           // databinding statement is evaluated before the call to GetData.       
            if (! IsBoundUsingDataSourceID) {
                OnDataBinding(EventArgs.Empty);
            }            
            
            // The GetData method retrieves the DataSourceView object from  
            // the IDataSource associated with the data-bound control.            
            GetData().Select(CreateDataSourceSelectArguments(), 
                OnDataSourceViewSelectCallback);
            
            // The PerformDataBinding method has completed.
            RequiresDataBinding = false;
            MarkAsDataBound();
            
            // Raise the DataBound event.
            OnDataBound(EventArgs.Empty);
        }