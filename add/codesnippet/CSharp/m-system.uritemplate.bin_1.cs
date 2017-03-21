            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast={day}");
            Uri prefix = new Uri("http://localhost");

            Uri positionalUri = template.BindByPosition(prefix, "Washington", "Redmond", "Today");