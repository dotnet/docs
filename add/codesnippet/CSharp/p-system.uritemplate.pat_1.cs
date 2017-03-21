            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast={day}");

            Uri prefix = new Uri("http://localhost");

            Console.WriteLine("PathSegmentVariableNames:");
            foreach (string name in template.PathSegmentVariableNames)
            {
                Console.WriteLine("     {0}", name);
            }