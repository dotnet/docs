//<Snippet1>
using System;
using System.Collections;
using System.Configuration;

namespace Samples.AspNet
{
    class UsingConfigurationSectionGroup
    {
        static int indentLevel = 0;

        static void Main(string[] args)
        {

            //<Snippet10>
            // Get the application configuration file.
            System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);

            // Get the collection of the section groups.
            ConfigurationSectionGroupCollection sectionGroups =
                config.SectionGroups;

            // Display the section groups.
            ShowSectionGroupCollectionInfo(sectionGroups);
            //</Snippet10>
        }

        static void ShowSectionGroupCollectionInfo(
            ConfigurationSectionGroupCollection sectionGroups)
        {
            foreach (ConfigurationSectionGroup sectionGroup in sectionGroups)
            {
                ShowSectionGroupInfo(sectionGroup);
            }
        }

        //<Snippet2>
        static void ShowSectionGroupInfo(
            ConfigurationSectionGroup sectionGroup)
        {
            //<Snippet3>
            // Get the section group name.
            indent("Section Group Name: " + sectionGroup.Name);
            //</Snippet3>

            //<Snippet11>
            // Get the fully qualified group name.
            indent("Section Group Name: " + sectionGroup.SectionGroupName);
            //</Snippet11>

            indentLevel++;

            //<Snippet4>
            indent("Type: " + sectionGroup.Type);
            //</Snippet4>
            //<Snippet5>
            indent("Is Group Required?: " + 
                sectionGroup.IsDeclarationRequired);
            //</Snippet5>
            //<Snippet6>
            indent("Is Group Declared?: " + sectionGroup.IsDeclared);
            //</Snippet6>
            indent("Contained Sections:");

            indentLevel++;
            //<Snippet7>
            foreach (ConfigurationSection section 
                in sectionGroup.Sections)
            {
                indent("Section Name:" + section.SectionInformation.Name);
            }
            //</Snippet7>
            indentLevel--;

            // Display contained section groups if there are any.
            if (sectionGroup.SectionGroups.Count > 0)
            {
                indent("Contained Section Groups:");

                indentLevel++;
                //<Snippet8>
                ConfigurationSectionGroupCollection sectionGroups =
                    sectionGroup.SectionGroups;
                ShowSectionGroupCollectionInfo(sectionGroups);
                //</Snippet8>
            }

            Console.WriteLine("");
            indentLevel--;
        }
        //</Snippet2>

        static void indent(string text)
        {
            for (int i = 0; i < indentLevel; i++)
            {
                Console.Write("  ");
            }
            Console.WriteLine(text.Substring(0, Math.Min(79 - indentLevel * 2, text.Length)));
        }
    }

}
//</Snippet1>

namespace Samples.AspNet
{
    class UsingConfigurationSectionGroup2
    {
        //<Snippet12>
        static void ForceDeclaration(
            ConfigurationSectionGroup sectionGroup)
        {

            // Get the application configuration file.
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            sectionGroup.ForceDeclaration();

            config.Save(ConfigurationSaveMode.Full);

            Console.WriteLine(
                "Forced declaration for the group: {0}",
                sectionGroup.Name);
        }
        //</Snippet12>

        //<Snippet13>
        static void ForceDeclaration(
            ConfigurationSectionGroup sectionGroup,
            bool force)
        {
            sectionGroup.ForceDeclaration(force);

            Console.WriteLine(
                "Forced declaration for the group: {0} is {1}",
                sectionGroup.Name, force.ToString());
        }
        //</Snippet13>

    }
}
