  Sub DisplayCustomersForRegion(ByVal customers As List(Of Customer),
                                ByVal region As String)

    Dim customersForRegion = From cust In customers
                             Where cust.Region = region

    For Each cust In customersForRegion
      Console.WriteLine(cust.CompanyName)
    Next
  End Sub