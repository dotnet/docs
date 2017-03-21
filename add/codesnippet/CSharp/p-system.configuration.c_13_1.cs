
        static void DisplayCustomSectionInformation()
        {

            try
            {
                CustomSection customSection;

                customSection =
                    ConfigurationManager.GetSection("CustomSection") as CustomSection;

                if (customSection == null)
                    Console.WriteLine("Failed to load " + "CustomSection" + ".");
                else
                {
                    // Display specific information
                    Console.WriteLine("Defaults:");
                    Console.WriteLine("File Name:       {0}", customSection.FileName);
                    Console.WriteLine("Max Users:       {0}", customSection.MaxUsers);
                    Console.WriteLine("Max Idle Time:   {0}", customSection.MaxIdleTime);

                    // Display generic information
                    Console.WriteLine("Generic information:");
                    Console.WriteLine("AllowExeDefinition:  {0}",
                        customSection.SectionInformation.AllowExeDefinition.ToString());
                    Console.WriteLine("IsLocked:            {0}",
                        customSection.SectionInformation.IsLocked.ToString());

                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
            
        }
