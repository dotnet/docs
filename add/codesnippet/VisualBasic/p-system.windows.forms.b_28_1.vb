	Private Sub GetDataSource
		Dim ds As DataSet = CType(text1.DataBindings(0).DataSource, DataSet)
		Console.WriteLine(ds.Tables(0).TableName)
	End Sub