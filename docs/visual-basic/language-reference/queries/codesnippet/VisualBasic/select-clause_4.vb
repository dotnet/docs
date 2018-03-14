  Sub SelectCustomerNameAndId(ByVal customers() As Customer)
    Dim nameIds = From cust In customers
                  Select cust.CompanyName, cust.CustomerID
    For Each nameId In nameIds
      Console.WriteLine(nameId.CompanyName & ": " & nameId.CustomerID)
    Next
  End Sub