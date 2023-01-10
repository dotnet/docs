using System;
using System.Collections;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ComponentModel;
using System.Security.Permissions;
using System.Collections.Generic;

namespace Microsoft.Security.Samples
{
    // <Snippet8>
    [DataContract]
    public class CountryOrRegion2
    {
        [DataMember]
        public string[] officialLanguages;
        [DataMember]
        public DateTime[] holidays;
        [DataMember]
        public Cities cities;
        [DataMember]
        public object[] otherInfo;
    }

    [CollectionDataContract(ItemName = "city", KeyName = "cityName", ValueName = "population")]
    public class Cities : Dictionary<string, int> { }
    // </Snippet8>

    // <Snippet9>
    [DataContract]
    public class CountryOrRegion3
    {
        [DataMember]
        public BindingList<string> officialLanguages;
        [DataMember]
        public BindingList<DateTime> holidays;
        [DataMember]
        public Cities cities;
        [DataMember]
        public BindingList<object> otherInfo;
    }

    [CollectionDataContract(ItemName = "city", KeyName = "cityName", ValueName = "population")]
    public class Cities3 : Hashtable { }
    // </Snippet9>

    // <Snippet10>
    [DataContract]
    public class CountryOrRegion4
    {
        [DataMember]
        public string[] officialLanguages;
        [DataMember]
        public DateTime[] holidays;
        [DataMember]
        public Cities cities;
        [DataMember]
        public object[] otherInfo;
    }

    [CollectionDataContract(ItemName = "city", KeyName = "cityName", ValueName = "population")]
    public class Cities4 : Dictionary<string, int> { }
    // </Snippet10>

    // <Snippet11>
    [DataContract]
    public class Student
    {
        [DataMember]
        public string name;
        [DataMember]
        public IList<int> testMarks;
    }
    public class Marks1 : List<int> {}
    [CollectionDataContract(ItemName="mark")]
    public class Marks2 : List<int> {}
    // </Snippet11>

    [CollectionDataContract(Name = "Custom{0}List", ItemName = "CustomItem")]
    public class CustomList<T> : List<T>
    {
        public CustomList()
            : base()
        {
        }

        public CustomList(T[] items)
            : base()
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }
    }

    // This is the generated code. Note that the class is renamed to "CustomBookList",
    // and the ItemName is set to "CustomItem".
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(ItemName = "CustomItem")]
    public class CustomBookList : System.Collections.Generic.List<Microsoft.Security.Samples.Book>
    {
    }

    [ServiceContract]
    public interface ICatalog
    {
        [OperationContract]
        CustomList<Book> Books();
    }

    public class Catalog : ICatalog
    {
        private Catalog()
        {
            Book Twain = new Book();
            Twain.Author = "Twain, Mark";
            Twain.Title = "Huckleberry Finn";
            booksProperty_Value.Add(Twain);
        }

        private CustomList<Book> booksProperty_Value;
        public CustomList<Book> BooksProperty
        {
            get { return booksProperty_Value; }
            set { booksProperty_Value = value; }
        }

        public CustomList<Book> Books()
        {
            return booksProperty_Value;
        }
    }

    public class Test
    {
        static void Main()
        {
            Test t = new Test();
            Console.WriteLine("Starting....");
            t.Run();
        }

        private void Run()
        {
            //<snippet12>
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.Windows;

            // Create the Type instances for later use and the Uri for
            // the base address.
            Type contractType = typeof(ICatalog);
            Type serviceType = typeof(Catalog);
            Uri baseAddress = new
                Uri("http://localhost:8036/serviceModelSamples/");

            // Create the ServiceHost and add an endpoint, then start
            // the service.
            ServiceHost myServiceHost =
                new ServiceHost(serviceType, baseAddress);
            myServiceHost.AddServiceEndpoint
                (contractType, myBinding, "secureCatalog");
            AddMetabehaviors(ref myServiceHost);
            myServiceHost.Open();
            //</snippet12>
            Console.WriteLine("Listening");
            Console.WriteLine("Press Enter to close the service");
            Console.ReadLine();
            myServiceHost.Close();
        }

        internal void AddMetabehaviors(ref ServiceHost sh)
        {
            ServiceMetadataBehavior sb = new ServiceMetadataBehavior();
            sb.HttpGetEnabled = true;
            sh.Description.Behaviors.Add(sb);
            sh.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
        }
    }

    public class Address
    {
        //int houseNumber;
        //string streetName;
    }

    public class Collection<T>
    {
        //private T firstMember;
    }

    public class Item
    {
        //private int firstMember;
    }

    // <Snippet1>
    [DataContract(Name="Customer")]
    public class Customer1
    {
        [DataMember]
        public string customerName;
        [DataMember]
        public Collection<Address> addresses;
    }

    [DataContract(Name="Customer")]
    public class Customer2
    {
        [DataMember]
        public string customerName;
        [DataMember]
        public ICollection<Address> addresses;
    }
    // </Snippet1>

    // <Snippet2>
    [CollectionDataContract]
    public class CustomerList2 : Collection<string> {}
    // </Snippet2>

    // <Snippet3>
    [CollectionDataContract(Name="cust_list")]
    public class CustomerList3 : Collection<string> {}
    // </Snippet3>

    // <Snippet4>
    [CollectionDataContract(ItemName="customer")]
    public class CustomerList4 : Collection<string>  {}
    // </Snippet4>

    // <Snippet5>
    [CollectionDataContract
        (Name = "CountriesOrRegionsWithCapitals",
        ItemName = "entry",
        KeyName = "countryorregion",
        ValueName = "capital")]
    public class CountriesOrRegionsWithCapitals2 : Dictionary<string, string> { }
    // </Snippet5>

    // <Snippet6>
    [DataContract]
    public class Employee
    {
        [DataMember]
        public string name = "John Doe";
        [DataMember]
        public Payroll payrollRecord;
        [DataMember]
        public Training trainingRecord;
    }

    [DataContract]
    [KnownType(typeof(int[]))] //required because int[] is used polymorphically
    [KnownType(typeof(ArrayList))] //required because ArrayList is used polymorphically
    public class Payroll
    {
        [DataMember]
        public object salaryPayments = new int[12];
        //float[] not needed in known types because polymorphic assignment is to another collection type
        [DataMember]
        public IEnumerable<float> stockAwards = new float[12];
        [DataMember]
        public object otherPayments = new ArrayList();
    }

    [DataContract]
    [KnownType(typeof(List<object>))]
    //required because List<object> is used polymorphically
    //does not conflict with ArrayList above because it's a different scope,
    //even though it's the same data contract
    [KnownType(typeof(InHouseTraining))] //Required if InHouseTraining can be used in the collection
    [KnownType(typeof(OutsideTraining))] //Required if OutsideTraining can be used in the collection
    public class Training
    {
        [DataMember]
        public object training = new List<object>();
    }

    [DataContract]
    public class InHouseTraining
    {
        //code omitted
    }

    [DataContract]
    public class OutsideTraining
    {
        //code omitted
    }
    // </Snippet6>

    // <Snippet7>
    [DataContract]
    public class CountryOrRegion
    {
        [DataMember]
        public Collection<string> officialLanguages;
        [DataMember]
        public List<DateTime> holidays;
        [DataMember]
        public CityList cities;
        [DataMember]
        public ArrayList otherInfo;
    }

    public class Person
    {
        public Person(string fName, string lName)
        {
            this.firstName = fName;
            this.lastName = lName;
        }

        public string firstName;
        public string lastName;
    }

    public class PeopleEnum : IEnumerator
    {
        public Person[] _people;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public PeopleEnum(Person[] list)
        {
            _people = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _people.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    [CollectionDataContract(Name = "Cities", ItemName = "city", KeyName = "cityName", ValueName = "population")]
    public class CityList : IDictionary<string, int>, IEnumerable<System.Collections.Generic.KeyValuePair<string, int>>
    {
        private Person[] _people = null;

        public bool ContainsKey(string s) { return true; }
        public bool Contains(string s) { return true; }
        public bool Contains(KeyValuePair<string, int> item) { return (true); }
        public void Add(string key, int value) { }
        public void Add(KeyValuePair<string, int> keykValue) { }
        public bool Remove(string s) { return true; }
        public bool TryGetValue(string d, out int i)
        {
            i = 0; return (true);
        }

        /*
        [TypeConverterAttribute(typeof(SynchronizationHandlesTypeConverter))]
        public ICollection<string> SynchronizationHandles {
            get { return (System.Collections.Generic.ICollection<string>) new Stack<string> (); }
            set { }
        }*/

        public ICollection<string> Keys
        {
            get
            {
                return (System.Collections.Generic.ICollection<string>)new Stack<string>();
            }
        }

        public int this[string s]
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public ICollection<int> Values
        {
            get
            {
                return (System.Collections.Generic.ICollection<int>)new Stack<string>();
            }
        }

        public void Clear() { }
        public void CopyTo(KeyValuePair<string, int>[] array, int index) { }
        public bool Remove(KeyValuePair<string, int> item) { return true; }
        public int Count { get { return 0; } }
        public bool IsReadOnly { get { return true; } }

        IEnumerator<KeyValuePair<string, int>>
            System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, int>>.GetEnumerator()
        {
            return (IEnumerator<KeyValuePair<string, int>>)new PeopleEnum(_people); ;
        }

        public IEnumerator GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }

    // </Snippet7>

    // <Snippet0>
    [DataContract(Name = "PurchaseOrder")]
    public class PurchaseOrder1
    {
        [DataMember]
        public string customerName;
        [DataMember]
        public Collection<Item> items;
        [DataMember]
        public string[] comments;
    }

    [DataContract(Name = "PurchaseOrder")]
    public class PurchaseOrder2
    {
        [DataMember]
        public string customerName;
        [DataMember]
        public List<Item> items;
        [DataMember]
        public BindingList<string> comments;
    }
    // </Snippet0>

    [DataContract]
    public class Book
    {
        [DataMember]
        public string Author;
        [DataMember]
        public string Title;
    }
}
