        ' Obtain a list of customers.
        Dim customers As List(Of Customer) = GetCustomers()

        ' Return customers that are grouped based on country.
        Dim countries = From cust In customers
                        Order By cust.Country, cust.City
                        Group By CountryName = cust.Country
                        Into CustomersInCountry = Group, Count()
                        Order By CountryName

        ' Output the results.
        For Each country In countries
            Debug.WriteLine(country.CountryName & " count=" & country.Count)

            For Each customer In country.CustomersInCountry
                Debug.WriteLine("   " & customer.CompanyName & "  " & customer.City)
            Next
        Next

        ' Output:
        '   Canada count=2
        '      Contoso, Ltd  Halifax
        '      Fabrikam, Inc.  Vancouver
        '   United States count=1
        '      Margie's Travel  Redmond