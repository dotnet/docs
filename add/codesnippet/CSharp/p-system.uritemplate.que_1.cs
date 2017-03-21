            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast={day}");
            Uri prefix = new Uri("http://localhost");

            Console.WriteLine("QueryValueVariableNames:");
            foreach (string name in template.QueryValueVariableNames)
            {
                Console.WriteLine("     {0}", name);
            }