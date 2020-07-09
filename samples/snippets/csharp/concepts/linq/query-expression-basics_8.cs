            // Use of var is optional here and in all queries.
            // queryCities is an IEnumerable<City> just as
            // when it is explicitly typed.
            var queryCities =
                from city in cities
                where city.Population > 100000
                select city;