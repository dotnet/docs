            // percentileQuery is an IEnumerable<IGrouping<int, Country>>
            var percentileQuery =
                from country in countries
                let percentile = (int) country.Population / 10_000_000
                group country by percentile into countryGroup
                where countryGroup.Key >= 20
                orderby countryGroup.Key
                select countryGroup;

            // grouping is an IGrouping<int, Country>
            foreach (var grouping in percentileQuery)
            {
                Console.WriteLine(grouping.Key);
                foreach (var country in grouping)
                    Console.WriteLine(country.Name + ":" + country.Population);
            }