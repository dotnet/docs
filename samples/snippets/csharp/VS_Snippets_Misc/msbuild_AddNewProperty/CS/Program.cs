//<Snippet1>
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Build.BuildEngine;

namespace AddNewProperty
{
    class Program
    {
        /// <summary>
        /// This code demonstrates the use of the following methods:
        ///     Engine constructor
        ///     Project constructor
        ///     Project.LoadFromXml
        ///     Project.Xml
        ///     BuildPropertyGroupCollection.GetEnumerator
        ///     BuildPropertyGroup.GetEnumerator
        ///     BuildProperty.Name (get)
        ///     BuildProperty.Value (set)
        ///     BuildPropertyGroup.RemoveProperty
        ///     BuildPropertyGroup.AddNewProperty
        /// </summary>
        static void Main()
        {
            // Create a new Engine object.
            Engine engine = new Engine(Environment.CurrentDirectory);

            // Create a new Project object.
            Project project = new Project(engine);

            // Load the project with the following XML, which contains
            // two PropertyGroups.
            project.LoadXml(@"
                <Project xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>

                    <PropertyGroup>
                        <Optimize>true</Optimize>
                        <WarningLevel>4</WarningLevel>
                    </PropertyGroup>

                    <PropertyGroup>
                        <OutputPath>bin\debug\</OutputPath>
                        <RemoveThisPropertyPlease>1</RemoveThisPropertyPlease>
                    </PropertyGroup>

                </Project>
                ");

            // Iterate through each PropertyGroup in the Project.  There are two.
            foreach (BuildPropertyGroup pg in project.PropertyGroups)
            {
                BuildProperty propertyToRemove = null;

                // Iterate through each Property in the PropertyGroup.
                foreach (BuildProperty property in pg)
                {
                    // If the property's name is "RemoveThisPropertyPlease", then
                    // store a reference to this property in a local variable,
                    // so we can remove it later.
                    if (property.Name == "RemoveThisPropertyPlease")
                    {
                        propertyToRemove = property;
                    }

                    // If the property's name is "OutputPath", change its value
                    // from "bin\debug\" to "bin\release\".
                    if (property.Name == "OutputPath")
                    {
                        property.Value = @"bin\release\";
                    }
                }

                // Remove the property named "RemoveThisPropertyPlease" from the
                // PropertyGroup
                if (propertyToRemove != null)
                {
                    pg.RemoveProperty(propertyToRemove);
                }

                // For each PropertyGroup that we found, add to the end of it
                // a new property called "MyNewProperty".
                pg.AddNewProperty("MyNewProperty", "MyNewValue");
            }

            // The project now looks like this:
            //
            //     <?xml version="1.0" encoding="utf-16"?>
            //     <Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
            //       <PropertyGroup>
            //         <Optimize>true</Optimize>
            //         <WarningLevel>4</WarningLevel>
            //         <MyNewProperty>MyNewValue</MyNewProperty>
            //       </PropertyGroup>
            //       <PropertyGroup>
            //         <OutputPath>bin\release</OutputPath>
            //         <MyNewProperty>MyNewValue</MyNewProperty>
            //       </PropertyGroup>
            //     </Project>
            Console.WriteLine(project.Xml);
        }
    }
}
//</Snippet1>