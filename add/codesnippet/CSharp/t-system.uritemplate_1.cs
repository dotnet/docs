            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast={day}");
            Uri prefix = new Uri("http://localhost");

            Console.WriteLine("PathSegmentVariableNames:");
            foreach (string name in template.PathSegmentVariableNames)
            {
                Console.WriteLine("     {0}", name);
            }
            Console.WriteLine();

            Console.WriteLine("QueryValueVariableNames:");
            foreach (string name in template.QueryValueVariableNames)
            {
                Console.WriteLine("     {0}", name);
            }
            Console.WriteLine();

            Uri positionalUri = template.BindByPosition(prefix, "Washington", "Redmond", "Today");

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("state", "Washington");
            parameters.Add("city", "Redmond");
            parameters.Add("day", "Today");
            Uri namedUri = template.BindByName(prefix, parameters);

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