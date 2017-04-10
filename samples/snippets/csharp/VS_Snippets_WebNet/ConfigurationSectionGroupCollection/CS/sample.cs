using System;
using System.Collections;
using System.Configuration;

namespace Samples.AspNet.CS
{
    //<Snippet1>
    class ListSectionGroupCollectionInfo
    {
        static int indentLevel = 0;
        //<Snippet10>
        static void Main(string[] args)
        {
            Configuration config = ConfigurationManager.OpenMachineConfiguration();
            ConfigurationSectionGroupCollection mySectionGroupCollection = config.SectionGroups;
            ShowSectionGroupCollectionInfo(mySectionGroupCollection);

        }
        //</Snippet10>
        static String getSpacer()
        {
            String spacer = "";
            for (int i = 0; i < indentLevel; i++)
            {
                spacer = spacer + "    ";
            }
            return spacer;
        }
        //<Snippet9>
        static void ShowSectionGroupCollectionInfo(ConfigurationSectionGroupCollection mySectionGroupCollection)
        {
            foreach (String mySectionGroupName in mySectionGroupCollection.Keys)
            {
                ConfigurationSectionGroup mySectionGroup = 
                    (ConfigurationSectionGroup)mySectionGroupCollection[mySectionGroupName];
                ShowSectionGroupInfo(mySectionGroup);
            }
        }
        //</Snippet9>
        //<Snippet2>
        static void ShowSectionGroupInfo(ConfigurationSectionGroup mySectionGroup)
        {
            //<Snippet3>
            Console.WriteLine(getSpacer() + "Section Group Name:" + mySectionGroup.Name);
            //</Snippet3>
            indentLevel++;
            //<Snippet4>
            Console.WriteLine(getSpacer() + "Type:" + mySectionGroup.Type);
            //</Snippet4>
            //<Snippet6>
            Console.WriteLine(getSpacer() + "Is Group Declared?:" + mySectionGroup.IsDeclared);
            //</Snippet6>

            Console.WriteLine(getSpacer() + "Contained Sections:");

            indentLevel++;
            //<Snippet7>
            ConfigurationSectionCollection mySectionCollection = mySectionGroup.Sections;
            foreach (String mySectionName in mySectionCollection.Keys)
            {
                ConfigurationSection mySection = (ConfigurationSection)mySectionCollection[mySectionName];
                Console.WriteLine(getSpacer() + "Section Name:" 
                    + mySection.SectionInformation.Name);
            }
            //</Snippet7>
            indentLevel--;

            Console.WriteLine(getSpacer() + "Contained Section Groups:");

            indentLevel++;
            //<Snippet8>
            ConfigurationSectionGroupCollection mySectionGroupCollection = mySectionGroup.SectionGroups;
            ShowSectionGroupCollectionInfo(mySectionGroupCollection);
            //</Snippet8>
            indentLevel--;
        }
        //</Snippet2>
    }
    //</Snippet1>
}
