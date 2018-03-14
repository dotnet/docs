using System;
using System.Collections;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Security.Permissions;
using System.Collections.Generic;

[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution=true)]
namespace Microsoft.Security.Samples
{
    //<snippet1>
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
    //</snippet1>

    //<snippet2>
    // This is the generated code. Note that the class is renamed to "CustomBookList", 
    // and the ItemName is set to "CustomItem".
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(ItemName = "CustomItem")]
    public class CustomBookList : System.Collections.Generic.List<Microsoft.Security.Samples.Book>
    {
    }
    //</snippet2>


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


    [DataContract]
    public class Book
    {
        [DataMember]
        public string Author;
        [DataMember]
        public string Title;
    }
}