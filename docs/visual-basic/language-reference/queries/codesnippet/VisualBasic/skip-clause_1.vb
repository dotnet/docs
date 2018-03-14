  Public Sub PagingSample()
    Dim pageNumber As Integer = 0
    Dim pageSize As Integer = 10

    Dim customersPage = GetCustomers(pageNumber * pageSize, pageSize)

    Do While customersPage IsNot Nothing
      Console.WriteLine(vbCrLf & "Page: " & pageNumber + 1 & vbCrLf)

      For Each cust In customersPage
        Console.WriteLine(cust.CustomerID & ", " & cust.CompanyName)
      Next

      Console.WriteLine(vbCrLf)

      pageNumber += 1
      customersPage = GetCustomers(pageNumber * pageSize, pageSize)
    Loop
  End Sub

  Public Function GetCustomers(ByVal startIndex As Integer,
                               ByVal pageSize As Integer) As List(Of Customer)

    Dim customers = GetCustomerList()

    Dim returnCustomers = From cust In customers
                          Skip startIndex Take pageSize

    If returnCustomers.Count = 0 Then Return Nothing

    Return returnCustomers
  End Function