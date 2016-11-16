            //Query syntax
            IEnumerable<City> queryMajorCities =
                from city in cities
                where city.Population > 100000
                select city;

            
            // Method-based syntax
            IEnumerable<City> queryMajorCities2 = cities.Where(c => c.Population > 100000);