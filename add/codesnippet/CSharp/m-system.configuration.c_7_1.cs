        static void GetEnumerator()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);


                ConfigurationSectionCollection sections =
                    config.Sections;

                IEnumerator secEnum =
                    sections.GetEnumerator();

                int i = 0;
                while (secEnum.MoveNext())
                {
                    string setionName = sections.GetKey(i);
                    Console.WriteLine(
                        "Section name: {0}", setionName);
                    i += 1;
                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }