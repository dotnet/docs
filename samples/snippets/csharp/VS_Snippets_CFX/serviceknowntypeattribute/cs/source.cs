//  Copyright (c) Microsoft Corporation.  All Rights Reserved.
//<snippet0>
using System.Collections;
using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Reflection;
//</snippet0>
using System.Security.Permissions;
[assembly: SecurityPermission(
   SecurityAction.RequestMinimum, Execution = true)]
namespace Microsoft.ServiceModel.Samples
{
    public class Test
    {
        static void Main()
        {
           // This is empty, just to get it into the build.
        }
    }
            

    //<snippet1>
    // Define a service contract and apply the ServiceKnownTypeAttribute
    // to specify types to include when generating client code. 
    // The types must have the DataContractAttribute and DataMemberAttribute
    // applied to be serialized and deserialized. The attribute specifies the 
    // name of a method (GetKnownTypes) in a class (Helper) defined below.
    [ServiceKnownType("GetKnownTypes", typeof(Helper))]
    [ServiceContract()]
    public interface ICatalog
    {
        // Any object type can be inserted into a Hashtable. The 
        // ServiceKnownTypeAttribute allows you to include those types
        // with the client code.
        [OperationContract]
        Hashtable GetItems();
    }

    // This class has the method named GetKnownTypes that returns a generic IEnumerable.
    static class Helper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            System.Collections.Generic.List<System.Type> knownTypes =
                new System.Collections.Generic.List<System.Type>();
            // Add any types to include here.
            knownTypes.Add(typeof(Widget));
            knownTypes.Add(typeof(Machine));
            return knownTypes;
        }
    }

    [DataContract()]
    public class Widget
    {
        [DataMember]
        public string Id;
        [DataMember]
        public string Catalog;
    }

    [DataContract()]
    public class Machine : Widget
    {
        [DataMember]
        public string Maker;
    }

    //</snippet1>

    //<snippet2>
    // Apply the ServiceKnownTypeAttribute to the 
    // interface specifying the type to include. Apply 
    // the attribute more than once if needed.
    [ServiceKnownType(typeof(Widget))]
    [ServiceKnownType(typeof(Machine))]
    [ServiceContract()]
    public interface ICatalog2
    {
        // Any object type can be inserted into a Hashtable. The 
        // ServiceKnownTypeAttribute allows you to include those types
        // with the client code.
        [OperationContract]
        Hashtable GetItems();
    }
    //</snippet2>

    public class CatalogService : ICatalog
    {
        public Hashtable GetItems()
        {
            Hashtable myHashtable =
                new Hashtable();

            Widget widget1 = new Widget();
            widget1.Catalog = "My First Widget";
            widget1.Id = "W-00001";

            Machine machine1 = new Machine();
            machine1.Catalog = "My Machine";
            machine1.Id = "M-00001";
            machine1.Maker = "Contoso.com";

            myHashtable.Add("Key1", widget1);
            myHashtable.Add("Key2", machine1);
            return myHashtable;
        }
    }
}
