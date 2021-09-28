            IEnumerable<Country> sortedQuery =
                from country in countries
                orderby country.Area
                select country;