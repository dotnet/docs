    Protected Sub LinqDataSource_Selecting(sender As Object, e As LinqDataSourceSelectEventArgs)
        Dim exampleContext As New ExampleDataContext()

        e.Result = From p In exampleContext.Products Where p.Category = "Beverages"
                   Select New With { _
                        Key .ID = p.ProductID, _
                        Key .Name = p.Name _
        }
    End Sub