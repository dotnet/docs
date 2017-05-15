
//-----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All Rights Reserved.
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Microsoft.Samples.DCR
{
    [KnownAssembly("Types")]
    public class DCRSample
    {
        static void Main(string[] args)
        {
            object[] attributes = typeof(DCRSample).GetCustomAttributes(typeof(KnownAssembly), true);
            if (attributes.GetLength(0) != 0)
            {
                // Loading the assembly with types
                Assembly assembly = Assembly.Load(new AssemblyName(((KnownAssembly)attributes[0]).AssemblyName));

                // Creating the DataContractResolver
                DataContractResolverSample dcrSample = new DataContractResolverSample(assembly);

                Console.WriteLine("Serializing types from assembly: " + ((KnownAssembly)attributes[0]).AssemblyName);

                // Processing types
                foreach (Type type in assembly.GetTypes())
                {
                    dcrSample.serialize(type);
                    dcrSample.deserialize(type);
                }
                Console.WriteLine("----------------------------------------");
            }
            else
            {
                Console.WriteLine("Assembly not found");
            }
            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate.");
            Console.ReadLine();
        }
    }

    class DataContractResolverSample
    {
        DataContractSerializer serializer;
        StringBuilder buffer;

        public DataContractResolverSample(Assembly assembly)
        {
            // Adding the DataContractResolver to the DataContractSerializer
            this.serializer = new DataContractSerializer(typeof(Object), null, int.MaxValue, false, true, null, new MyDataContractResolver(assembly));
        }

        public void serialize(Type type)
        {
            Object instance = Activator.CreateInstance(type);

            // Serializing types
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Serializing type: {0}", type.Name);
            Console.WriteLine();
            this.buffer = new StringBuilder();
            using (XmlWriter xmlWriter = XmlWriter.Create(this.buffer))
            {
                try
                {
                    this.serializer.WriteObject(xmlWriter, instance);
                }
                catch (SerializationException error)
                {
                    Console.WriteLine(error.ToString());
                }
            }
            Console.WriteLine(this.buffer.ToString());
        }

        public void deserialize(Type type)
        {
            // Deserializing types
            Console.WriteLine();
            Console.WriteLine("Deserializing type: {0}", type.Name);
            Console.WriteLine();
            using (XmlReader xmlReader = XmlReader.Create(new StringReader(this.buffer.ToString())))
            {
                Object obj = this.serializer.ReadObject(xmlReader);
            }
        }
    }
    // <Snippet2>
    class MyDataContractResolver : DataContractResolver
    {
        private Dictionary<string, XmlDictionaryString> dictionary = new Dictionary<string, XmlDictionaryString>();
        Assembly assembly;

        // Definition of the DataContractResolver
        public MyDataContractResolver(Assembly assembly)
        {
            this.assembly = assembly;
        }

        //<Snippet0>
        // Used at deserialization
        // Allows users to map xsi:type name to any Type 
        public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
        {
            XmlDictionaryString tName;
            XmlDictionaryString tNamespace;
            if (dictionary.TryGetValue(typeName, out tName) && dictionary.TryGetValue(typeNamespace, out tNamespace))
            {
                return this.assembly.GetType(tNamespace.Value + "." + tName.Value);
            }
            else
            {
                return null;
            }
        }
        // </Snippet0>
        // <Snippet1>
        // Used at serialization
        // Maps any Type to a new xsi:type representation
        public override bool TryResolveType(Type type, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            string name = type.Name;
            string namesp = type.Namespace;
            typeName = new XmlDictionaryString(XmlDictionary.Empty, name, 0); 
            typeNamespace = new XmlDictionaryString(XmlDictionary.Empty, namesp, 0);
            if (!dictionary.ContainsKey(type.Name))
            {
                dictionary.Add(name, typeName);
            }
            if (!dictionary.ContainsKey(type.Namespace))
            {
                dictionary.Add(namesp, typeNamespace);
            }
            return true;
        }
        // </Snippet1>
    }
    //</Snippet2>
    [AttributeUsage(AttributeTargets.All)]
    class KnownAssembly : System.Attribute
    {
        public KnownAssembly(string name)
        {
            this.AssemblyName = name;
        }

        public string AssemblyName { get; set; }
    }

}
