            var localDistributors2 =
                from cust in customers
                join dist in distributors on cust.City equals dist.City
                select new { CustomerName = cust.Name, DistributorID = dist.ID };