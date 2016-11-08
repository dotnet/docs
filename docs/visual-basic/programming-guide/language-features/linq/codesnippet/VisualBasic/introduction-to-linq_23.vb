    Public Function GetAllCustomers() As List(Of Customer)
        Dim customers1 = From cust In domesticCustomers
        Dim customers2 = From cust In internationalCustomers

        Dim customerList = customers1.Union(customers2)

        Return customerList.ToList()
    End Function