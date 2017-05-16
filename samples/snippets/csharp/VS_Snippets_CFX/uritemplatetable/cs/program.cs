using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace UriTemplateTableSnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            Snippets.Snippet2();
            // <Snippet0>
            // <Snippet1>
            // <Snippet3>
            Uri prefix = new Uri("http://localhost/");

            //Create a series of templates
            UriTemplate weatherByCity  = new UriTemplate("weather/ state}/ city}");
            UriTemplate weatherByCountry = new UriTemplate("weather/ country}/ village}");       
            UriTemplate weatherByState = new UriTemplate("weather/ state}");
            UriTemplate traffic = new UriTemplate("traffic/*");
            UriTemplate wildcard = new UriTemplate("*");

            //Create a template table
            UriTemplateTable table = new UriTemplateTable(prefix);
            //Add each template to the table with some associated data
            table.KeyValuePairs.Add(new KeyValuePair<UriTemplate, Object>(weatherByCity, "weatherByCity"));
            table.KeyValuePairs.Add(new KeyValuePair<UriTemplate, Object>(weatherByCountry, "weatherByCountry"));
            table.KeyValuePairs.Add(new KeyValuePair<UriTemplate, Object>(weatherByState, "weatherByState"));
            table.KeyValuePairs.Add(new KeyValuePair<UriTemplate, Object>(traffic, "traffic"));

            table.MakeReadOnly(true);
            // </Snippet3>
            // </Snippet1>
            Console.WriteLine("KeyValuePairs:");
            foreach (KeyValuePair<UriTemplate, Object> keyPair in table.KeyValuePairs)
            {
                Console.WriteLine("     0},  1}", keyPair.Key, keyPair.Value);
            }

            Console.WriteLine();

            //Call MatchSingle to retrieve some match results:
            ICollection<UriTemplateMatch> results = null;
            Uri weatherInSeattle = new Uri("http://localhost/weather/Washington/Seattle");

            results = table.Match(weatherInSeattle);
            if( results != null)
            {
                Console.WriteLine("Matching templates:");
                foreach (UriTemplateMatch match in results)
                {
                    Console.WriteLine("    0}", match.Template);
                }
            }
            // </Snippet0>
        }
    }
}
