using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Persistence;
using System.Collections.Specialized;

namespace SqlPersistenceProviderFactorySnippets
{
    class SqlPersistenceProviderFactorySnippets
    {
        //Constructors
        void Container0()
        {
            //Constructor: SqlPersistenceProviderFactory(String, Boolean, TimeSpan)
            //<snippet0>
            SqlPersistenceProviderFactory factory = new SqlPersistenceProviderFactory(
                DataBaseConstants.ConnectionString, 
                false, 
                TimeSpan.FromSeconds(60));
            //</snippet0>
        }
        void Container1()
        {
            //Constructor: SqlPersistenceProviderFactory(String, Boolean)
            //<snippet1>
            SqlPersistenceProviderFactory factory = new SqlPersistenceProviderFactory(
                DataBaseConstants.ConnectionString,
                false);
            //</snippet1>
        }
        void Container2()
        {
            //Constructor: SqlPersistenceProviderFactory(String)
            //<snippet2>
            SqlPersistenceProviderFactory factory = new SqlPersistenceProviderFactory(
                 DataBaseConstants.ConnectionString);
            //</snippet2>
        }
        void Container3()
        {
            //Constructor: SqlPersistenceProviderFactory(NameValueCollection)
            //<snippet3>
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("connectionStringName", DataBaseConstants.ConnectionString);
            parameters.Add("lockTimeout", "00:01:00");
            parameters.Add("serializeAsText", "false");
            
            SqlPersistenceProviderFactory factory = new SqlPersistenceProviderFactory(
                parameters);
            //</snippet3>
        }
        void Container4()
        {
            //Parameter: ConnectionString
            //<snippet4>
            SqlPersistenceProviderFactory factory = new SqlPersistenceProviderFactory(
                 DataBaseConstants.ConnectionString);
            String databaseConnectionString = factory.ConnectionString;
            //</snippet4>
        }
        void Container5()
        {
            //Parameter: LockTimeout
            //<snippet5>
            SqlPersistenceProviderFactory factory = new SqlPersistenceProviderFactory(
                 DataBaseConstants.ConnectionString);
            TimeSpan lockTimeout = factory.LockTimeout;
            //</snippet5>
        }

        void Container6()
        {
            //Parameter: SerializeAsText
            //<snippet6>
            SqlPersistenceProviderFactory factory = new SqlPersistenceProviderFactory(
                 DataBaseConstants.ConnectionString);
            bool serializeAsText = factory.SerializeAsText;
            //</snippet6>
        }

        void Container7()
        {
            //Method: CreateProvider
            //<snippet7>
            SqlPersistenceProviderFactory factory = new SqlPersistenceProviderFactory(
                DataBaseConstants.ConnectionString,
                false,
                TimeSpan.FromSeconds(60));
            LockingPersistenceProvider provider = (LockingPersistenceProvider)factory.CreateProvider(Guid.NewGuid());
            //</snippet7>
        }

        class DataBaseConstants
        {
            public static String ConnectionString = "";
        }
        
    }
}
