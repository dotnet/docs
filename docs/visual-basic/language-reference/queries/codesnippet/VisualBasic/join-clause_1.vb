    Dim customerIDs() = {"ALFKI", "VICTE", "BLAUS", "TRAIH"}

    Dim customerList = From cust In customers, custID In customerIDs
                       Where cust.CustomerID = custID
                       Select cust.CompanyName

    For Each companyName In customerList
      Console.WriteLine(companyName)
    Next