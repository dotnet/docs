//<Snippet1>
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Build.BuildEngine;

namespace AddNewItem
{
    class Program
    {
        /// <summary>
        /// This code demonstrates the use of the following methods:
        ///     Engine constructor
        ///     Project constructor
        ///     Project.LoadFromXml
        ///     Project.Xml
        ///     BuildItemGroupCollection.GetEnumerator
        ///     BuildItemGroup.GetEnumerator
        ///     BuildItem.Name (get)
        ///     BuildItem.Include (set)
        ///     BuildItem.GetMetadata
        ///     BuildItem.SetMetadata
        ///     BuildItemGroup.RemoveItem
        ///     BuildItemGroup.AddNewItem
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Create a new Engine object.
            Engine engine = new Engine(Environment.CurrentDirectory);

            // Create a new Project object.
            Project project = new Project(engine);

            // Load the project with the following XML, which contains
            // two ItemGroups.
            project.LoadXml(@"
                <Project xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>

                    <ItemGroup>
                        <Compile Include='Program.cs'/>
                        <Compile Include='Class1.cs'/>
                        <RemoveThisItemPlease Include='readme.txt'/>
                    </ItemGroup>

                    <ItemGroup>
                        <EmbeddedResource Include='Strings.resx'>
                            <LogicalName>Strings.resources</LogicalName>
                            <Culture>fr-fr</Culture>
                        </EmbeddedResource>
                    </ItemGroup>

                </Project>
                ");

            // Iterate through each ItemGroup in the Project.  There are two.
            foreach (BuildItemGroup ig in project.ItemGroups)
            {
                BuildItem itemToRemove = null;

                // Iterate through each Item in the ItemGroup.
                foreach (BuildItem item in ig)
                {
                    // If the item's name is "RemoveThisItemPlease", then
                    // store a reference to this item in a local variable,
                    // so we can remove it later.
                    if (item.Name == "RemoveThisItemPlease")
                    {
                        itemToRemove = item;
                    }

                    // If the item's name is "EmbeddedResource" and it has a metadata Culture
                    // set to "fr-fr", then ...
                    if ((item.Name == "EmbeddedResource") && (item.GetMetadata("Culture") == "fr-fr"))
                    {
                        // Change the item's Include path to "FrenchStrings.fr.resx", 
                        // and add a new metadata Visiable="false".
                        item.Include = @"FrenchStrings.fr.resx";
                        item.SetMetadata("Visible", "false");
                    }
                }

                // Remove the item named "RemoveThisItemPlease" from the
                // ItemGroup
                if (itemToRemove != null)
                {
                    ig.RemoveItem(itemToRemove);
                }

                // For each ItemGroup that we found, add to the end of it
                // a new item Content with Include="SplashScreen.bmp".
                ig.AddNewItem("Content", "SplashScreen.bmp");
            }

            // The project now looks like this:
            //
            //     <?xml version="1.0" encoding="utf-16"?>
            //     <Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
            //       <ItemGroup>
            //         <Compile Include="Program.cs" />
            //         <Compile Include="Class1.cs" />
            //         <Content Include="SplashScreen.bmp" />
            //       </ItemGroup>
            //       <ItemGroup>
            //         <EmbeddedResource Include="FrenchStrings.fr.resx">
            //           <LogicalName>Strings.resources</LogicalName>
            //           <Culture>fr-fr</Culture>
            //           <Visible>false</Visible>
            //         </EmbeddedResource>
            //         <Content Include="SplashScreen.bmp" />
            //       </ItemGroup>
            //     </Project>
            //
            Console.WriteLine(project.Xml);
        }
    }
}
//</Snippet1>