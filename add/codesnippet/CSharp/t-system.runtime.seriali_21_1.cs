    // Implement the IExtensibleDataObject interface 
    // to store the extra data for future versions.
    [DataContract(
        Name = "Person",
        Namespace = "http://www.cohowinery.com/employees")]
    class Person : IExtensibleDataObject
    {
        // To implement the IExtensibleDataObject interface,
        // you must implement the ExtensionData property. The property
        // holds data from future versions of the class for backward
        // compatibility.
        private ExtensionDataObject extensionDataObject_value;
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataObject_value;
            }
            set
            {
                extensionDataObject_value = value;
            }
        }
        [DataMember]
        public string Name;
    }

    // The second version of the class adds a new field. The field's 
    // data is stored in the ExtensionDataObject field of
    // the first version (Person). You must also set the Name property 
    // of the DataContractAttribute to match the first version. 
    // If necessary, also set the Namespace property so that the 
    // name of the contracts is the same.
    [DataContract(Name = "Person",
        Namespace = "http://www.cohowinery.com/employees")]
    class PersonVersion2 : IExtensibleDataObject
    {
        // Best practice: add an Order number to new members.
        [DataMember(Order=2)]
        public int ID;

        [DataMember]
        public string Name;

        private ExtensionDataObject extensionDataObject_value;
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataObject_value;
            }
            set
            {
                extensionDataObject_value = value;
            }
        }
    }