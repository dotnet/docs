        Dim section As ConfigurationSection
        For Each section In sectionGroup.Sections
            indent("Section Name:" + section.SectionInformation.Name)
        Next section