                var innerJoinQuery =
                    from cust in customers
                    join dist in distributors on cust.City equals dist.City
                    select new { CustomerName = cust.Name, DistributorName = dist.Name };