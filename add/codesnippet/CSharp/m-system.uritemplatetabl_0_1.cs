            Uri prefix = new Uri("http://localhost/");

            //Create a series of templates
            UriTemplate weatherByCity  = new UriTemplate("weather/ state}/ city}");
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

            //Call Match to retrieve some match results:
            ICollection<UriTemplateMatch> results = null;
            Uri weatherInSeattle = new Uri("http://localhost/weather/Washington/Seattle");

            results = table.Match(weatherInSeattle);
            if( results != null)
            {
                Console.WriteLine("Matching templates:");
                foreach (UriTemplateMatch match in results)
                {
                    Console.WriteLine("    0}", match.Template);
                }
            }