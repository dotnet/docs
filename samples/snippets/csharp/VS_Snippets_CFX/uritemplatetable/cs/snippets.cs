using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace UriTemplateTableSnippets
{
    public class Snippets
    {
        public static void Snippet2()
        {
            // <Snippet2>
            // <Snippet5>
            //Create a series of templates
            UriTemplate weatherByCity = new UriTemplate("weather/{state}/{city}");
            UriTemplate weatherByCountry = new UriTemplate("weather/{country}/{village}");
            UriTemplate weatherByState = new UriTemplate("weather/{state}");
            UriTemplate traffic = new UriTemplate("traffic/*");
            UriTemplate wildcard = new UriTemplate("*");

            //Add each template to the table with some associated data
            List<KeyValuePair<UriTemplate,Object>> list = new List<KeyValuePair<UriTemplate,object>>();
            list.Add(new KeyValuePair<UriTemplate, Object>(weatherByCity, "weatherByCity"));
            list.Add(new KeyValuePair<UriTemplate, Object>(weatherByCountry, "weatherByCountry"));
            list.Add(new KeyValuePair<UriTemplate, Object>(weatherByState, "weatherByState"));
            list.Add(new KeyValuePair<UriTemplate, Object>(traffic, "traffic"));

            //Create a template table
            UriTemplateTable table = new UriTemplateTable(list);
            table.BaseAddress = new Uri("http://localhost/");
            table.MakeReadOnly(true);
            // </Snippet5>
            // </Snippet2>
        }

        public static void Snippet4()
        {
            // <Snippet6>
            // <Snippet4>
            Uri baseAddress = new Uri("http://localhost/");
            //Create a series of templates
            UriTemplate weatherByCity = new UriTemplate("weather/{state}/{city}");
            UriTemplate weatherByCountry = new UriTemplate("weather/{country}/{village}");
            UriTemplate weatherByState = new UriTemplate("weather/{state}");
            UriTemplate traffic = new UriTemplate("traffic/*");
            UriTemplate wildcard = new UriTemplate("*");

            //Add each template to the table with some associated data
            List<KeyValuePair<UriTemplate, Object>> list = new List<KeyValuePair<UriTemplate, object>>();
            list.Add(new KeyValuePair<UriTemplate, Object>(weatherByCity, "weatherByCity"));
            list.Add(new KeyValuePair<UriTemplate, Object>(weatherByCountry, "weatherByCountry"));
            list.Add(new KeyValuePair<UriTemplate, Object>(weatherByState, "weatherByState"));
            list.Add(new KeyValuePair<UriTemplate, Object>(traffic, "traffic"));

            //Create a template table
            UriTemplateTable table = new UriTemplateTable(baseAddress, list);
            table.MakeReadOnly(true);
            // </Snippet4>
            if (table.IsReadOnly)
                Console.WriteLine("UriTemplateTable is read only");
            else
                Console.WriteLine("UriTemplateTable is not read only");
            // </Snippet6>
        }

        public static void Snippet7()
        {
            // <Snippet7>
            Uri prefix = new Uri("http://localhost/");

            //Create a series of templates
            UriTemplate weatherByCity = new UriTemplate("weather/ state}/ city}");
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

            Console.WriteLine("KeyValuePairs:");
            foreach (KeyValuePair<UriTemplate, Object> keyPair in table.KeyValuePairs)
            {
                Console.WriteLine("     0},  1}", keyPair.Key, keyPair.Value);
            }

            Console.WriteLine();
            // </Snippet7>
        }

        public static void Snippet9()
        {
            // <Snippet9>
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

            //Call Match to retrieve some match results:
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
            // </Snippet9>
        }

        public static void Snippet10()
        {
            // <Snippet10>
            Uri prefix = new Uri("http://localhost/");

            //Create a series of templates
            UriTemplate weatherByCity = new UriTemplate("weather/ state}/ city}");
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

            //Call MatchSingle to retrieve some match results:
            Uri weatherInSeattle = new Uri("http://localhost/weather/Washington/Seattle");
            UriTemplateMatch match = table.MatchSingle(weatherInSeattle);

            Console.WriteLine("Matching template: {0}", match.Template.ToString());
            // </Snippet10>
        }
    }
}
