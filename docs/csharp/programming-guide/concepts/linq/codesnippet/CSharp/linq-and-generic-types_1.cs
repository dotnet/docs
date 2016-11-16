                IEnumerable<Customer> customerQuery =
                    from cust in customers
                    where cust.City == "London"
                    select cust;

                foreach (Customer customer in customerQuery)
                {
                    Console.WriteLine(customer.LastName + ", " + customer.FirstName);
                }