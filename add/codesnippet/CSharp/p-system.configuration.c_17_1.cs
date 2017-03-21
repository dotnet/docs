            foreach (ConfigurationSection section 
                in sectionGroup.Sections)
            {
                indent("Section Name:" + section.SectionInformation.Name);
            }