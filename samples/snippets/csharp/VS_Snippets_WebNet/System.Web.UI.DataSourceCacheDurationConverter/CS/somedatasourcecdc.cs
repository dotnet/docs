namespace Samples.AspNet.CS.Controls {

// <Snippet1>
    using System;
    using System.ComponentModel;
    using System.Web.UI;
        
    [ NonVisualControl() ]
    public class SomeDataSource : DataSourceControl
    {
        // Implementation of a custom data source control.
        
        // The SdsCache object is an imaginary cache object
        // provided for this example. It has not actual 
        // implementation.
        private SdsCache m_sdsCache = new SdsCache();
        internal SdsCache Cache {
            get { return m_sdsCache; }
        }
                
        [TypeConverterAttribute(typeof(DataSourceCacheDurationConverter))]
        public int CacheDuration {
            get { return Cache.Duration; }
        }
                
        public DataSourceCacheExpiry CacheExpirationPolicy {
            get { return Cache.Expiry; }
            set { Cache.Expiry = value; }
        }
        
        public bool EnableCaching {
            get { return Cache.Enabled; }
            set { Cache.Enabled = value; }
        }

        protected override DataSourceView GetView(string viewName)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        
        // ...
    }
// </Snippet1>    

    class SdsCache {
        
        public int Duration = 0;
        
        public bool Enabled = true;
        
        public DataSourceCacheExpiry Expiry = DataSourceCacheExpiry.Absolute;
    }
}
