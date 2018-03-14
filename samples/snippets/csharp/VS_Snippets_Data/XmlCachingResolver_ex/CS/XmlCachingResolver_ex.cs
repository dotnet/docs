using System;
using System.IO;
using System.Xml;
using System.Net;
using System.Net.Cache;

namespace XmlCachingResolver_ex
{
    //<snippet1>	
    class XmlCachingResolver : XmlUrlResolver
    {
        bool enableHttpCaching;
        ICredentials credentials;

        //resolve resources from cache (if possible) when enableHttpCaching is set to true
        //resolve resources from source when enableHttpcaching is set to false 
        public XmlCachingResolver(bool enableHttpCaching)
        {
            this.enableHttpCaching = enableHttpCaching;
        }

        public override ICredentials Credentials
        {
            set
            {
                credentials = value;
                base.Credentials = value;
            }
        }

        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            if (absoluteUri == null)
            {
                throw new ArgumentNullException("absoluteUri");
            }
            //resolve resources from cache (if possible)
            if (absoluteUri.Scheme == "http" && enableHttpCaching && (ofObjectToReturn == null || ofObjectToReturn == typeof(Stream)))
            {
                WebRequest webReq = WebRequest.Create(absoluteUri);
                webReq.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Default);
                if (credentials != null)
                {
                    webReq.Credentials = credentials;
                }
                WebResponse resp = webReq.GetResponse();
                return resp.GetResponseStream();
            }
            //otherwise use the default behavior of the XmlUrlResolver class (resolve resources from source)
            else
            {
                return base.GetEntity(absoluteUri, role, ofObjectToReturn);
            }
        }
    }
    //</snippet1>
    class Program
    {
        static void Main(string[] args)
        {   
	    //<snippet2>    
            XmlCachingResolver resolver = new XmlCachingResolver(true);
            Uri baseUri = new Uri("http://serverName/");
            Uri fulluri = resolver.ResolveUri(baseUri, "fileName.xml");

            // Get a stream object containing the XML file
            Stream s = (Stream)resolver.GetEntity(fulluri, null, typeof(Stream));

            // Read the stream object and display the contents of the file
            XmlTextReader reader = new XmlTextReader(s);
            while (reader.Read())
            {
                Console.WriteLine(reader.ReadOuterXml());
            }
            //</snippet2> 
        }
    }
}
