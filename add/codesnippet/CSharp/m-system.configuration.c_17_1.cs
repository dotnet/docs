        static void GetSection()
        {

            try
            {
                CustomSection customSection =
                    ConfigurationManager.GetSection(
                    "CustomSection") as CustomSection;

                if (customSection == null)
                    Console.WriteLine(
                        "Failed to load CustomSection.");
                else
                {
                    // Display section information
                    Console.WriteLine("Defaults:");
                    Console.WriteLine("File Name:       {0}",
                        customSection.FileName);
                    Console.WriteLine("Max Users:       {0}",
                        customSection.MaxUsers);
                    Console.WriteLine("Max Idle Time:   {0}",
                        customSection.MaxIdleTime);

                }

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }