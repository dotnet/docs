            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast=today");
            Uri baseAddress = new Uri("http://localhost");
            Uri fullUri = new Uri("http://localhost/weather/WA/Seattle?forecast=today");

            Console.WriteLine("Matching {0} to {1}", template.ToString(), fullUri.ToString());

            // Match a URI to a template
            UriTemplateMatch results = template.Match(baseAddress, fullUri);
            if (results != null)
            {
                Console.WriteLine("QueryParameters:");
                foreach (string queryName in results.QueryParameters.Keys)
                {
                    Console.WriteLine("    {0} : {1}", queryName, results.QueryParameters[queryName]);
                }
                Console.WriteLine();
            }
            // Code output:
            //  QueryParameters:
            //  forecast : today