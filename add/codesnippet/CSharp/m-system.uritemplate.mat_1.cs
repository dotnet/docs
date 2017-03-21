            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast={day}");
            Uri prefix = new Uri("http://localhost");

            Uri fullUri = new Uri("http://localhost/weather/Washington/Redmond?forecast=today");
            UriTemplateMatch results = template.Match(prefix, fullUri);

            Console.WriteLine("Matching {0} to {1}", template.ToString(), fullUri.ToString());

            if (results != null)
            {
                foreach (string variableName in results.BoundVariables.Keys)
                {
                    Console.WriteLine("   {0}: {1}", variableName, results.BoundVariables[variableName]);
                }
            }