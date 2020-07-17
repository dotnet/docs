            IEnumerable<Country> countryAreaQuery =
                from country in countries
                where country.Area > 500000 //sq km
                select country;