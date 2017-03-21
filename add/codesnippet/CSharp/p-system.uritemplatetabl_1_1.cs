            Uri prefix = new Uri("http://localhost/");

            //Create a series of templates
            UriTemplate weatherByCity = new UriTemplate("weather/ state}/ city}");
            UriTemplate weatherByCountry = new UriTemplate("weather/ country}/ village}");
            UriTemplate weatherByState = new UriTemplate("weather/ state}");
            UriTemplate traffic = new UriTemplate("traffic/*");
            UriTemplate wildcard = new UriTemplate("*");

            //Create a template table
            UriTemplateTable table = new UriTemplateTable(prefix);
            //Add each template to the table with some associated data
            table.KeyValuePairs.Add(new KeyValuePair<UriTemplate, Object>(weatherByCity, "weatherByCity"));
            table.KeyValuePairs.Add(new KeyValuePair<UriTemplate, Object>(weatherByCountry, "weatherByCountry"));
            table.KeyValuePairs.Add(new KeyValuePair<UriTemplate, Object>(weatherByState, "weatherByState"));
            table.KeyValuePairs.Add(new KeyValuePair<UriTemplate, Object>(traffic, "traffic"));

            table.MakeReadOnly(true);

            Console.WriteLine("KeyValuePairs:");
            foreach (KeyValuePair<UriTemplate, Object> keyPair in table.KeyValuePairs)
            {
                Console.WriteLine("     0},  1}", keyPair.Key, keyPair.Value);
            }

            Console.WriteLine();