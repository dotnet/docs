        static void ForceDeclaration(
            ConfigurationSectionGroup sectionGroup,
            bool force)
        {
            sectionGroup.ForceDeclaration(force);

            Console.WriteLine(
                "Forced declaration for the group: {0} is {1}",
                sectionGroup.Name, force.ToString());
        }