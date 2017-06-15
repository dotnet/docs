//<Snippet1>
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Build.BuildEngine;

namespace ListItemAndPropertiesCS
{
    class Program
    {        
        static void Main(string[] args)
        {
            // SET THIS TO POINT TO THE RIGHT LOCATION
            Engine.GlobalEngine.BinPath = @"C:\Windows\Microsoft.NET\Framework\v2.0.xxxxx";

            // Create a new empty project
            Project project = new Project();

            // Load a project
            project.Load(@"c:\temp\validate.proj");

            Console.WriteLine("Project Properties");
            Console.WriteLine("----------------------------------");

            // Iterate through the various property groups and subsequently 
            // through teh various properties
            foreach (BuildPropertyGroup propertyGroup in project.PropertyGroups)
            {
                foreach (BuildProperty prop in propertyGroup)
                {
                    Console.WriteLine("{0}:{1}", prop.Name, prop.Value);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Project Items");
            Console.WriteLine("----------------------------------");

            // Iterate through the various itemgroups
            // and subsequently through the items
            foreach (BuildItemGroup itemGroup in project.ItemGroups)
            {
                foreach (BuildItem item in itemGroup)
                {
                    Console.WriteLine("{0}:{1}", item.Name, item.Include);
                }
            }            
        }
    }
}
//</Snippet1>