// <snippet1>
using System;
using System.Web;
using System.Xml;
using System.IO;
using System.Data;
using System.Web.Caching;

namespace Samples.AspNet.CS
{
    // Create a class with static methods.
    public class DataHelper
    {
// <snippet2>
        // Create a method that supplied book data
        // to pages.
        public static DataView GetBookData()
        {
            HttpContext ctxtCurrent = HttpContext.Current;

            // Check for the DataView in the application cache.            
            DataView Source =
              (DataView)ctxtCurrent.Cache["bookData"];


            // If not in the cache, create the DataView
            // from the source XML file.            
            if (Source == null)
            {
                DataSet ds = new DataSet();

                FileStream fs = new FileStream(
                    ctxtCurrent.Server.MapPath(@"books.xml"),
                    FileMode.Open, FileAccess.Read);
                
                try
                {
                    StreamReader reader = new StreamReader(fs);
                    ds.ReadXml(reader);
                }
                finally
                {
                    fs.Close();
                }

                Source = new DataView(ds.Tables[0]);

                // Create a dependency on an XML data source
                // and put the DataView into the cache with a
                // dependency and 15 second expiration policy.
                CacheDependency depBooks = new CacheDependency( 
                    ctxtCurrent.Server.MapPath(@"books.xml"));
                ctxtCurrent.Cache.Insert(
                    "bookData", Source, depBooks, 
                     DateTime.Now.AddSeconds(15), TimeSpan.Zero);
            }

            return Source;
          
        }
// </snippet2>
        
        public static DataView GetAuthorData()
        {
            HttpContext ctxtCurrent = HttpContext.Current;

            // Check for the DataView in the application cache.            
            DataView Source =
              (DataView)ctxtCurrent.Cache["authorData"];


            // If not in the cache, create the DataView
            // from the source XML file.            
            if (Source == null)
            {
                DataSet ds = new DataSet();

                FileStream fs = new FileStream(
                    ctxtCurrent.Server.MapPath(@"authors.xml"),
                    FileMode.Open, FileAccess.Read);

                try
                {
                    StreamReader reader = new StreamReader(fs);
                    ds.ReadXml(reader);
                }
                finally
                {
                    fs.Close();
                }

                Source = new DataView(ds.Tables[0]);

                // Create a dependency on an XML data source
                // and put the DataView into the cache with a
                // dependency and 15 second expiration policy.
                CacheDependency depAuthors = new CacheDependency( 
                    ctxtCurrent.Server.MapPath(@"authors.xml"));
                ctxtCurrent.Cache.Insert(
                    "authorData", Source, depAuthors);
            }

            return Source;
          
        }
        

    }
    
    
}
// </snippet1>
