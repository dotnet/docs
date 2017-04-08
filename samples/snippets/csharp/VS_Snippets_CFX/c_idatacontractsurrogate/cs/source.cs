using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Runtime.Serialization;
using System.CodeDom.Compiler;
using System.Xml.Serialization;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Description;


namespace DCSurrogateSample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Inventory store1 = new Inventory();
            store1.pencils = 5;
            store1.pens = 10;
            store1.paper = 15;
            DataContractSerializer surrogateDcs =
                new DataContractSerializer(typeof(Inventory), null, int.MaxValue, false, false, new InventoryTypeSurrogate());

            // Plug in the surrogate in order to use the serializer.
            Console.WriteLine("Plug in a surrogate for the Inventory class\n");
            StringWriter sw2 = new StringWriter();
            XmlWriter xw2 = XmlWriter.Create(sw2);
            try
            {
                surrogateDcs.WriteObject(xw2, store1);
            }
            catch (InvalidDataContractException)
            {
                Console.WriteLine(" We should never get here");
            }
            xw2.Flush();
            sw2.Flush();
            Console.Write(sw2.ToString());
            Console.WriteLine("\n\n Serialization succeeded. Now doing deserialization...\n");

            StringReader tr = new StringReader(sw2.ToString());
            XmlReader xr = XmlReader.Create(tr);
            Inventory newstore = (Inventory)surrogateDcs.ReadObject(xr);
            Console.Write("Deserialized Inventory data: \nPens:" + newstore.pens + "\nPencils: " + newstore.pencils + "\nPaper: " + newstore.paper);

            Console.WriteLine("\n\n Deserialization succeeded. Now doing schema export/import...\n");

            //The following code demonstrates schema export with a surrogate.
            //The surrogate indicates how to export the non-DataContract Inventory type.
            //Without the surrogate, schema export would fail.
            XsdDataContractExporter xsdexp = new XsdDataContractExporter();
            xsdexp.Options = new ExportOptions();
            xsdexp.Options.DataContractSurrogate = new InventoryTypeSurrogate();
            try
            {
                xsdexp.Export(typeof(Inventory));
            }
            catch (Exception) { }

            //Write out exported schema to a file
            using (FileStream fs = new FileStream("sample.xsd", FileMode.Create))
            {
                foreach (XmlSchema sch in xsdexp.Schemas.Schemas())
                {
                    sch.Write(fs);
                }
            }

            //The following code demonstrates schema import with a surrogate.
            //The surrogate is used to indicate that the Inventory class already exists
            //and that there is no need to generate a new class when importing the
            //"InventorySurrogated" data contract.

            XsdDataContractImporter xsdimp = new XsdDataContractImporter();
            xsdimp.Options = new ImportOptions();
            xsdimp.Options.DataContractSurrogate = new InventoryTypeSurrogate();
            xsdimp.Import(xsdexp.Schemas);

            //Write out the imported schema to a C-Sharp file
            using (FileStream fs = new FileStream("sample.cs", FileMode.Create))
            {
                TextWriter tw = new StreamWriter(fs);
                CodeDomProvider cdp = new Microsoft.CSharp.CSharpCodeProvider();
                cdp.GenerateCodeFromCompileUnit(xsdimp.CodeCompileUnit, tw, null);
                tw.Flush();
            }

            Console.WriteLine("\n\n To see the results of schema export and import,");
            Console.WriteLine(" see SAMPLE.XSD and SAMPLE.CS.\n");

            Console.WriteLine(" Press ENTER to terminate the sample.\n");
            Console.ReadLine();
        }

        //original type
        //<snippet1>
        public class Inventory
        {
            public int pencils;
            public int pens;
            public int paper;
        }
        //</snippet1>

        //surrogate type
        //<snippet2>
        [DataContract(Name = "Inventory")]
        public class InventorySurrogated
        {
            [DataMember]
            public int numpencils;
            [DataMember]
            public int numpaper;
            [DataMember]
            private int numpens;

            public int pens
            {
                get { return numpens; }
                set { numpens = value; }
            }
        }
        //</snippet2>
        public class InventoryTypeSurrogate : IDataContractSurrogate
        {

            #region IDataContractSurrogate Members

            public object GetCustomDataToExport(Type clrType, Type dataContractType)
            {
                Console.WriteLine("GetCustomDataToExport(Type)");
                return null;
            }

            //<snippet6>
            public object GetCustomDataToExport(System.Reflection.MemberInfo memberInfo, Type dataContractType)
            {
                Console.WriteLine("GetCustomDataToExport(Member)");
                System.Reflection.FieldInfo fieldInfo = (System.Reflection.FieldInfo)memberInfo;
                if (fieldInfo.IsPublic)
                {
                    return "public";
                }
                else
                {
                    return "private";
                }
            }
            //</snippet6>

            //<snippet3>
            public Type GetDataContractType(Type type)
            {
                Console.WriteLine("GetDataContractType");
                if (typeof(Inventory).IsAssignableFrom(type))
                {
                    return typeof(InventorySurrogated);
                }
                return type;
            }
            //</snippet3>

            //<snippet5>
            public object GetDeserializedObject(object obj, Type targetType)
            {
                Console.WriteLine("GetDeserializedObject");
                if (obj is InventorySurrogated)
                {
                    Inventory invent = new Inventory();
                    invent.pens = ((InventorySurrogated)obj).pens;
                    invent.pencils = ((InventorySurrogated)obj).numpencils;
                    invent.paper = ((InventorySurrogated)obj).numpaper;
                    return invent;
                }
                return obj;
            }
            //</snippet5>

            public void GetKnownCustomDataTypes(System.Collections.ObjectModel.Collection<Type> customDataTypes)
            {
            }

            //<snippet4>
            public object GetObjectToSerialize(object obj, Type targetType)
            {
                Console.WriteLine("GetObjectToSerialize");
                if (obj is Inventory)
                {
                    InventorySurrogated isur = new InventorySurrogated();
                    isur.numpaper = ((Inventory)obj).paper;
                    isur.numpencils = ((Inventory)obj).pencils;
                    isur.pens = ((Inventory)obj).pens;
                    return isur;
                }
                return obj;
            }
            //</snippet4>
            public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
            {
                /*
                Console.WriteLine("I am in GetReferencedTypeOnImport");
                if (typeNamespace.Equals("http://schemas.datacontract.org/2004/07/DCSurrogateSample"))
                {
                    if (typeName.Equals("Inventory"))
                    {
                        return typeof(Inventory);
                    }
                }
                */
                return null;
            }

            //<snippet7>
            public System.CodeDom.CodeTypeDeclaration ProcessImportedType(System.CodeDom.CodeTypeDeclaration typeDeclaration, System.CodeDom.CodeCompileUnit compileUnit)
            {
                Console.WriteLine("ProcessImportedType");
                foreach (CodeTypeMember member in typeDeclaration.Members)
                {
                    object memberCustomData = member.UserData[typeof(IDataContractSurrogate)];
                    if (memberCustomData != null
                      && memberCustomData is string
                      && ((string)memberCustomData == "private"))
                    {
                        member.Attributes = ((member.Attributes & ~MemberAttributes.AccessMask) | MemberAttributes.Private);
                    }
                }
                return typeDeclaration;
            }
            //</snippet7>
            #endregion
        }
    }

    public class Implementer
    {
        private void Run()
        {
            //<snippet8>
            using (ServiceHost serviceHost = new ServiceHost(typeof(InventoryCheck)))
                foreach (ServiceEndpoint ep in serviceHost.Description.Endpoints)
                {
                    foreach (OperationDescription op in ep.Contract.Operations)
                    {                       
                        DataContractSerializerOperationBehavior dataContractBehavior =
                            op.Behaviors.Find<DataContractSerializerOperationBehavior>()
                            as DataContractSerializerOperationBehavior;
                        if (dataContractBehavior != null)
                        {
                            dataContractBehavior.DataContractSurrogate = new InventorySurrogated();
                        }
                        else
                        {
                            dataContractBehavior = new DataContractSerializerOperationBehavior(op);
                            dataContractBehavior.DataContractSurrogate = new InventorySurrogated();
                            op.Behaviors.Add(dataContractBehavior);
                        }
                    }
                }
            //</snippet8>
        }
                

        private void WSDLImport(string metadataAddress )
        {
            //<snippet9>
            MetadataExchangeClient mexClient = new MetadataExchangeClient(metadataAddress);
            mexClient.ResolveMetadataReferences = true;
            MetadataSet metaDocs = mexClient.GetMetadata();
            WsdlImporter importer = new WsdlImporter(metaDocs);
            object dataContractImporter;
            XsdDataContractImporter xsdInventoryImporter;
            if (!importer.State.TryGetValue(typeof(XsdDataContractImporter),
                out dataContractImporter))
                xsdInventoryImporter = new XsdDataContractImporter();

            xsdInventoryImporter = (XsdDataContractImporter)dataContractImporter;
            if (xsdInventoryImporter.Options == null)
            {
                xsdInventoryImporter.Options = new ImportOptions();
            }
            xsdInventoryImporter.Options.DataContractSurrogate = new InventorySurrogated();
            importer.State.Add(typeof(XsdDataContractImporter), xsdInventoryImporter);

            Collection<ContractDescription> contracts = importer.ImportAllContracts();
            //</snippet9>
        }

        private void MetadataImport()
        {
            //<snippet10>
            WsdlExporter exporter = new WsdlExporter();
            //or
            //public void ExportContract(WsdlExporter exporter, 
            // WsdlContractConversionContext context) { ... }
            object dataContractExporter;
            XsdDataContractExporter xsdInventoryExporter;
            if (!exporter.State.TryGetValue(typeof(XsdDataContractExporter),
                out dataContractExporter))
            {
                xsdInventoryExporter = new XsdDataContractExporter(exporter.GeneratedXmlSchemas);
            }
            else
                xsdInventoryExporter = (XsdDataContractExporter)dataContractExporter;
            exporter.State.Add(typeof(XsdDataContractExporter), xsdInventoryExporter);

            

            if (xsdInventoryExporter.Options == null)
                xsdInventoryExporter.Options = new ExportOptions();
            xsdInventoryExporter.Options.DataContractSurrogate = new InventorySurrogated();
            //</snippet10>
        }
    }


    public class InventoryCheck
    {
    }

    public class InventorySurrogated:IDataContractSurrogate
    {

        #region IDataContractSurrogate Members

        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public object GetCustomDataToExport(System.Reflection.MemberInfo memberInfo, Type dataContractType)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Type GetDataContractType(Type type)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public object GetDeserializedObject(object obj, Type targetType)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public object GetObjectToSerialize(object obj, Type targetType)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}


