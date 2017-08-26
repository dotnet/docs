using System;
using System.Activities;
using System.Activities.XamlIntegration;
using System.Diagnostics;
using System.Xaml;
using System.Xml;
using Microsoft.Workflow.Migration;
using WF3Activities;
using WF3ActivityMigrators;
using WF3Workflows;

namespace WFMigrationSamples
{
    // This sample shows programmatic usage of the Migrator class
    class Program
    {
        static void Main()
        {
            System.Workflow.ComponentModel.Activity source = new Sequence1(); // Sequence2()

            Migrate(source, source.Name);
            Process.Start("notepad.exe", source.Name + ".xaml");
            WorkflowInvoker.Invoke(ActivityXamlServices.Load(source.Name + ".xaml"));

            Console.ReadLine();
        }

        static void Migrate(System.Workflow.ComponentModel.Activity source, string targetName)
        {
            Migrator migrator = GetMigrator();
            MigratorResults results = migrator.Migrate(source);

            foreach (MigratorError error in results.Errors)
            {
                Console.WriteLine(error.Message);
            }

            ActivityBuilder builder = results.AsActivityBuilder();
            builder.Name = targetName; // the x:Class name of the new WF4 type

            XamlServices.Save(ActivityXamlServices.CreateBuilderWriter(
                new XamlXmlWriter(XmlWriter.Create(targetName + ".xaml",
                    new XmlWriterSettings { Indent = true }), new XamlSchemaContext())), builder);
        }

        static Migrator GetMigrator()
        {
            Migrator migrator = new Migrator();

            // The commented code below shows an alternative to using WriteMigrator
            // that lets you migrate Write activities without defining a migrator type

            //migrator.MigratorTypes.Remove(typeof(WriteMigrator));

            //ActivityTypeMapping mapping = new ActivityTypeMapping
            //{
            //    SourceType = typeof(Write),
            //    TargetType = typeof(System.Activities.Statements.WriteLine)
            //};

            //mapping.PropertyNameMap.Add("Input", "Text");
            //migrator.ActivityTypeMappings.Add(mapping);

            return migrator;
        }
    }
}