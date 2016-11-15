                //queryAllCustomers is an IEnumerable<Customer>
                var queryAllCustomers = from cust in customers
                                        select cust;