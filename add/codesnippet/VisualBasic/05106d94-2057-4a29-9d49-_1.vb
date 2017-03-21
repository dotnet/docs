        ' If the data source changes, set a Boolean variable.
        Public Overrides Sub OnDataSourceChanged()
            changedDataSource = True
        End Sub ' OnDataSourceChanged