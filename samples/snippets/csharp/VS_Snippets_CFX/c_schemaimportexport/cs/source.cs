//<snippet0>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
//</snippet0>

namespace ImportExport1
{
    //<snippet1>
    [DataContract]
    public partial class Vehicle : IExtensibleDataObject
    {
        private int yearField;
        private string colorField;

        [DataMember]
        public int year
        {
            get { return this.yearField; }
            set { this.yearField = value; }
        }
        [DataMember]
        public string color
        {
            get { return this.colorField; }
            set { this.colorField = value; }
        }

        private ExtensionDataObject extensionDataField;
        public ExtensionDataObject ExtensionData
        {
            get { return this.extensionDataField; }
            set { this.extensionDataField = value; }
        }
    }
    //</snippet1>
}
namespace ImportExport2
{
    //<snippet2>
    [DataContract]
    internal partial class Vehicle : IExtensibleDataObject
    {
        private int yearField;
        private string colorField;

        [DataMember]
        internal int year
        {
            get { return this.yearField; }
            set { this.yearField = value; }
        }
        [DataMember]
        internal string color
        {
            get { return this.colorField; }
            set { this.colorField = value; }
        }

        private ExtensionDataObject extensionDataField;
        public ExtensionDataObject ExtensionData
        {
            get { return this.extensionDataField; }
            set { this.extensionDataField = value; }
        }
    }
    //</snippet2>
}
namespace ImportExport3
{
    //<snippet3>
    namespace Contoso.Cars
    {
        [DataContract]
        public partial class Vehicle : IExtensibleDataObject
        {
            // Code not shown.

            public ExtensionDataObject ExtensionData
            {
                get
                {
                    throw new Exception("The method or operation is not implemented.");
                }
                set
                {
                    throw new Exception("The method or operation is not implemented.");
                }
            }
        }
        //</snippet3>
    }

    //<snippet4>
    [DataContract]
    [Serializable]
    public partial class Vehicle : IExtensibleDataObject
    {
        // Code not shown.
        public ExtensionDataObject ExtensionData
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }
    }
    //</snippet4>
}
namespace ImportExport4
{
    //<snippet5>
    [DataContract]
    public partial class Vehicle : IExtensibleDataObject, INotifyPropertyChanged
    {
        private int yearField;
        private string colorField;

        [DataMember]
        public int year
        {
            get { return this.yearField; }
            set
            {
                if (this.yearField.Equals(value) != true)
                {
                    this.yearField = value;
                    this.RaisePropertyChanged("year");
                }
            }
        }
        [DataMember]
        public string color
        {
            get { return this.colorField; }
            set
            {
                if (this.colorField.Equals(value) != true)
                {
                    this.colorField = value;
                    this.RaisePropertyChanged("color");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged =
    this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this,
    new PropertyChangedEventArgs(propertyName));
            }
        }

        private ExtensionDataObject extensionDataField;
        public ExtensionDataObject ExtensionData
        {
            get { return this.extensionDataField; }
            set { this.extensionDataField = value; }
        }
    }
    //</snippet5>
}
namespace ImportExport5
{
    //<snippet6>
    [DataContract]
    public partial class Vehicle : IExtensibleDataObject
    {
        [DataMember] public int yearField;
        [DataMember] public string colorField;
        [DataMember] public people passengers;

        // Other code not shown.

        public ExtensionDataObject ExtensionData
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }
    }
    [CollectionDataContract(ItemName = "person")]
    public class people : List<string> { }
    //</snippet6>
}

namespace ImportExport6
{
    //<snippet7>
    [CollectionDataContract(ItemName = "person")]
    public class people : BindingList<string> { }
    //</snippet7>
}

namespace ImportExport7
{
    class HolderClass
    {
        public static void snippet()
        {
            //<snippet8>
            XsdDataContractImporter importer = new XsdDataContractImporter();
            importer.Options.Namespaces.Add(new KeyValuePair<string, string>("http://schemas.contoso.com/carSchema", "Contoso.Cars"));
            // </snippet8>
        }
    }
}
