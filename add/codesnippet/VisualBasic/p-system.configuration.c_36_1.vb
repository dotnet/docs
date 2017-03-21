            Dim groups As ConfigurationSectionGroupCollection = config.SectionGroups
            Console.WriteLine("Groups: {0}", groups.Count.ToString())
            For Each group As ConfigurationSectionGroup In groups
                Console.WriteLine("Group Name: {0}", group.Name)
                ' Console.WriteLine("Group Type: {0}", group.Type);
            Next group