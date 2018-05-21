              // queryCustomersByCity is an IEnumerable<IGrouping<string, Customer>>
                var queryCustomersByCity =
                    from cust in customers
                    group cust by cust.City;

                // customerGroup is an IGrouping<string, Customer>
                foreach (var customerGroup in queryCustomersByCity)
                {
                    Console.WriteLine(customerGroup.Key);
                    foreach (Customer customer in customerGroup)
                    {
                        Console.WriteLine("    {0}", customer.Name);
                    }
                }