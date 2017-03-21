            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast={day}");
            Uri prefix = new Uri("http://localhost");

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("state", "Washington");
            parameters.Add("city", "Redmond");
            parameters.Add("day", "Today");
            Uri namedUri = template.BindByName(prefix, parameters);