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

            //Call MatchSingle to retrieve some match results:
            Uri weatherInSeattle = new Uri("http://localhost/weather/Washington/Seattle");
            UriTemplateMatch match = table.MatchSingle(weatherInSeattle);

            Console.WriteLine("Matching template: {0}", match.Template.ToString());