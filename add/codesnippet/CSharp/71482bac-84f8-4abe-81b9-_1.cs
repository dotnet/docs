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
