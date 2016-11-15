  Public Sub SkipWhileSample()
    Dim customers = GetCustomerList()

    ' Return customers starting from the first U.S. customer encountered.
    Dim customerList = From cust In customers
                       Order By cust.Country
                       Skip While IsInternationalCustomer(cust)

    For Each cust In customerList
      Console.WriteLine(cust.CompanyName & vbTab & cust.Country)
    Next
  End Sub

  Public Function IsInternationalCustomer(ByVal cust As Customer) As Boolean
    If cust.Country = "USA" Then Return False

    Return True
  End Function