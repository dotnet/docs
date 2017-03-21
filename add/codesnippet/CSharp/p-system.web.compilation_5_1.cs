    [
        DesignTimeResourceProviderFactoryAttribute(
            typeof(CustomDesignTimeResourceProviderFactory))
    ]
    public class CustomResourceProviderFactory : ResourceProviderFactory
    {
        public override IResourceProvider
          CreateGlobalResourceProvider(string classname)
        {
            return new CustomResourceProvider(null, classname);
        }
        public override IResourceProvider
          CreateLocalResourceProvider(string virtualPath)
        {
            return new CustomResourceProvider(virtualPath, null);
        }
    }

    // Define the resource provider for global and local resources.
    internal class CustomResourceProvider : IResourceProvider
    {
        string _virtualPath;
        string _className;

        public CustomResourceProvider(string virtualPath, string classname)
        {
            _virtualPath = virtualPath;
            _className = classname;
        }

        private IDictionary GetResourceCache(string culturename)
        {
            return (IDictionary)
                System.Web.HttpContext.Current.Cache[culturename];
        }

        object IResourceProvider.GetObject
            (string resourceKey, CultureInfo culture)
        {
            object value;

            string cultureName = null;
            if (culture != null)
            {
                cultureName = culture.Name;
            }
            else
            {
                cultureName = CultureInfo.CurrentUICulture.Name;
            }

            value = GetResourceCache(cultureName)[resourceKey];
            if (value == null)
            {
                value = GetResourceCache(null)[resourceKey];
            }
            return value;
        }


        IResourceReader IResourceProvider.ResourceReader
        {
            get
            {
                string cultureName = null;
                CultureInfo currentUICulture = CultureInfo.CurrentUICulture;
                if (!String.Equals(currentUICulture.Name,
                    CultureInfo.InstalledUICulture.Name))
                {
                    cultureName = currentUICulture.Name;
                }

                return new CustomResourceReader
                    (GetResourceCache(cultureName));
            }
        }
    }


    internal sealed class CustomResourceReader : IResourceReader
    {
        private IDictionary _resources;

        public CustomResourceReader(IDictionary resources)
        {
            _resources = resources;
        }

        IDictionaryEnumerator IResourceReader.GetEnumerator()
        {
            return _resources.GetEnumerator();
        }

        void IResourceReader.Close() { }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _resources.GetEnumerator();
        }

        void IDisposable.Dispose() { return; }
    }