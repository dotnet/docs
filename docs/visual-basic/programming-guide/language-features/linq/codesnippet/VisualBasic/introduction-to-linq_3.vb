        Dim customers = GetCustomers()

        Dim queryResults = From cust In customers

        For Each result In queryResults
            Debug.WriteLine(result.CompanyName & "  " & result.Country)
        Next

        ' Output:
        '   Contoso, Ltd  Canada
        '   Margie's Travel  United States
        '   Fabrikam, Inc.  Canada