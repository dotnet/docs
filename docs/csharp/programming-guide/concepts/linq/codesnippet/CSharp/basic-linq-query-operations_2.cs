              var queryLondonCustomers = from cust in customers
                                         where cust.City == "London"
                                         select cust;