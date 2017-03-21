    Protected Overrides Sub PerformSelect()

        ' Call OnDataBinding here if bound to a data source using the 
        ' DataSource property (instead of a DataSourceID) because the 
        ' data-binding statement is evaluated before the call to GetData.
        If Not IsBoundUsingDataSourceID Then
            OnDataBinding(EventArgs.Empty)
        End If

        ' The GetData method retrieves the DataSourceView object from the 
        ' IDataSource associated with the data-bound control.            
        GetData().Select(CreateDataSourceSelectArguments(), _
            AddressOf OnDataSourceViewSelectCallback)

        ' The PerformDataBinding method has completed.
        RequiresDataBinding = False
        MarkAsDataBound()

        ' Raise the DataBound event.
            OnDataBound(EventArgs.Empty)

    End Sub 'PerformSelect
