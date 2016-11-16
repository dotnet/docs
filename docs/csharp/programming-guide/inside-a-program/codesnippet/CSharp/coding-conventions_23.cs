            var localDistributors =
                from customer in customers
                join distributor in distributors on customer.City equals distributor.City
                select new { Customer = customer, Distributor = distributor };