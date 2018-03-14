            IEnumerable<City> queryCityPop =
                from city in cities
                where city.Population < 200000 && city.Population > 100000
                select city;