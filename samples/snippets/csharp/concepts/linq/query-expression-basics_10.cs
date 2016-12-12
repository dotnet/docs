            IEnumerable<City> cityQuery =
                from country in countries
                from city in country.Cities
                where city.Population > 10000
                select city;