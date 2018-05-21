              var queryLondonCustomers3 = 
                  from cust in customers
                  where cust.City == "London"
                  orderby cust.Name ascending
                  select cust;