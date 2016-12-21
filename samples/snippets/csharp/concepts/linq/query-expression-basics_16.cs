            IEnumerable<Country> querySortedCountries =
                from country in countries
                orderby country.Area, country.Population descending
                select country;