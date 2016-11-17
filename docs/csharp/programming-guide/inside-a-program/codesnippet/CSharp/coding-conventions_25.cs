            var seattleCustomers2 = from cust in customers
                                    where cust.City == "Seattle"
                                    orderby cust.Name
                                    select cust;