            var seattleCustomers = from cust in customers
                                   where cust.City == "Seattle"
                                   select cust.Name;