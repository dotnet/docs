                var customerQuery2 = 
                    from cust in customers
                    where cust.City == "London"
                    select cust;

                foreach(var customer in customerQuery2)
                {
                    Console.WriteLine(customer.LastName + ", " + customer.FirstName);
                }