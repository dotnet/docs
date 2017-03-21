        static void GetEnumerator()
        {

            try
            {
                System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

                ConfigurationSectionGroupCollection groups =
                    config.SectionGroups;

                IEnumerator groupEnum =
                    groups.GetEnumerator();

                int i = 0;
                while (groupEnum.MoveNext())
                {
                    string groupName = groups.GetKey(i);
                    Console.WriteLine(
                        "Group name: {0}", groupName);
                    i += 1;
                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }