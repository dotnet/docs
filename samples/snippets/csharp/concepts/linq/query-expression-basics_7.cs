            int highestScore =
                (from score in scores
                 select score)
                .Max();

            // or split the expression
            IEnumerable<int> scoreQuery =
                from score in scores
                select score;

            int highScore = scoreQuery.Max();
            // the following returns the same result
            int highScore = scores.Max();

            List<City> largeCitiesList =
                (from country in countries
                 from city in country.Cities
                 where city.Population > 10000
                 select city)
                   .ToList();

            // or split the expression
            IEnumerable<City> largeCitiesQuery =
                from country in countries
                from city in country.Cities
                where city.Population > 10000
                select city;

            List<City> largeCitiesList2 = largeCitiesQuery.ToList();