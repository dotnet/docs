            ConfigurationSectionGroupCollection
                groups = config.SectionGroups;
            Console.WriteLine("Groups: {0}", groups.Count.ToString());
            foreach (ConfigurationSectionGroup group in groups)
            {
                Console.WriteLine("Group Name: {0}", group.Name);
               // Console.WriteLine("Group Type: {0}", group.Type);
            }