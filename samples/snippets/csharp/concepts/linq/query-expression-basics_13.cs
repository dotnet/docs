            // Here var is required because the query
            // produces an anonymous type.
            var queryNameAndPop =
                from country in countries
                select new { Name = country.Name, Pop = country.Population };