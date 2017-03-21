            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast={day}");
            UriTemplate template2 = new UriTemplate("weather/{country}/{village}?forecast={type}");

            bool equiv = template.IsEquivalentTo(template2);