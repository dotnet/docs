   private Sub AddArray()
      ' Get three CurrencyManager objects used to construct 
      ' DataGridTableSTyle objects.
      Dim customersManager As CurrencyManager = _
      CType(me.BindingContext(myDataSet, "Customers"), CurrencyManager)

      Dim regionsManager As CurrencyManager = _
      CType(me.BindingContext(myDataSet, "Customers"), CurrencyManager)

      Dim productsManager As CurrencyManager = _
      CType(me.BindingContext(myDataSet, "Customers"), CurrencyManager)


      Dim gridCustomers As DataGridTableStyle = _
      new DataGridTableStyle(customersManager)
      Dim gridRegions As DataGridTableStyle  = _
      new DataGridTableStyle(regionsManager)
      Dim gridProducts As DataGridTableStyle = _
      new DataGridTableStyle(productsManager)

      ' Create a DataGridTableStyle array.
      Dim myGrids() As DataGridTableStyle = {gridCustomers, gridRegions, gridProducts}

      ' Use AddRange to add to the collection.
      myDataGrid.TableStyles.AddRange(myGrids)

   End Sub