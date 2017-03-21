            //Create a series of templates
            UriTemplate weatherByCity = new UriTemplate("weather/{state}/{city}");
            UriTemplate weatherByCountry = new UriTemplate("weather/{country}/{village}");
            UriTemplate weatherByState = new UriTemplate("weather/{state}");
            UriTemplate traffic = new UriTemplate("traffic/*");
            UriTemplate wildcard = new UriTemplate("*");

            //Add each template to the table with some associated data
            List<KeyValuePair<UriTemplate,Object>> list = new List<KeyValuePair<UriTemplate,object>>();
            list.Add(new KeyValuePair<UriTemplate, Object>(weatherByCity, "weatherByCity"));
            list.Add(new KeyValuePair<UriTemplate, Object>(weatherByCountry, "weatherByCountry"));
            list.Add(new KeyValuePair<UriTemplate, Object>(weatherByState, "weatherByState"));
            list.Add(new KeyValuePair<UriTemplate, Object>(traffic, "traffic"));

            //Create a template table
            UriTemplateTable table = new UriTemplateTable(list);
            table.BaseAddress = new Uri("http://localhost/");
            table.MakeReadOnly(true);