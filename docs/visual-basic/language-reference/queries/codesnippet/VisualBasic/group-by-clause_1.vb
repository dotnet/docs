  Public Sub GroupBySample()
    Dim customers = GetCustomerList()

    Dim customersByCountry = From cust In customers
                             Order By cust.City
                             Group By CountryName = cust.Country
                             Into RegionalCustomers = Group, Count()
                             Order By CountryName

    For Each country In customersByCountry
      Console.WriteLine(country.CountryName &
                        " (" & country.Count & ")" & vbCrLf)

      For Each customer In country.RegionalCustomers
        Console.WriteLine(vbTab & customer.CompanyName &
                          " (" & customer.City & ")")
      Next
    Next
  End Sub