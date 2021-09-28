            var queryCountryGroups =
                from country in countries
                group country by country.Name[0];