            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast=today");
            Uri baseAddress = new Uri("http://localhost");
            Uri fullUri = new Uri("http://localhost/weather/WA/Seattle?forecast=today");

            Console.WriteLine("Matching {0} to {1}", template.ToString(), fullUri.ToString());

            // Match a URI to a template
            UriTemplateMatch results = template.Match(baseAddress, fullUri);
            if (results != null)
            {
                // BaseUri
                Console.WriteLine("BaseUri: {0}", results.BaseUri);

                Console.WriteLine("BoundVariables:");
                foreach (string variableName in results.BoundVariables.Keys)
                {
                    Console.WriteLine("    {0}: {1}", variableName, results.BoundVariables[variableName]);
                }
            }
            // Code output:
            // BaseUri: http://localhost/
            // BoundVariables:
            //  state: wa
            //  city: seattleConsole.WriteLine("BaseUri: {0}", results.BaseUri);