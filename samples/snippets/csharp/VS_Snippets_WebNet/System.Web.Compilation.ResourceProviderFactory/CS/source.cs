// <Snippet1>
namespace CustomResourceProviders
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.Compilation;
    using System.Resources;
    using System.Globalization;
    using System.Collections;
    using System.Reflection;
    using System.Web.UI.Design;

    // <Snippet2>
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
    // </Snippet2>

    
    public class CustomDesignTimeResourceProviderFactory :
        DesignTimeResourceProviderFactory
    {
        private CustomDesignTimeLocalResourceProvider _localResourceProvider;
        private CustomDesignTimeLocalResourceWriter _localResourceWriter;
        private CustomDesignTimeGlobalResourceProvider _globalResourceProvider;

        public override IResourceProvider
            CreateDesignTimeLocalResourceProvider(IServiceProvider serviceProvider)
        {
            // Return an IResourceProvider.
            if (_localResourceProvider == null)
            {
                _localResourceProvider = new CustomDesignTimeLocalResourceProvider();
            }
            return _localResourceProvider;
        }

        public override IDesignTimeResourceWriter
            CreateDesignTimeLocalResourceWriter(IServiceProvider serviceProvider)
        {
            // Return an IDesignTimeResourceWriter.
            if (_localResourceWriter == null)
            {
                _localResourceWriter = new CustomDesignTimeLocalResourceWriter();
            }
            return _localResourceWriter;
        }

        public override IResourceProvider
            CreateDesignTimeGlobalResourceProvider(IServiceProvider serviceProvider,
                    string classKey)
        {
            // Return an IResourceProvider.
            if (_globalResourceProvider == null)
            {
                _globalResourceProvider = new CustomDesignTimeGlobalResourceProvider();
            }
            return _globalResourceProvider;
        }
    }
// </Snippet1>

    public class CustomDesignTimeLocalResourceProvider : IResourceProvider
    {
        object IResourceProvider.GetObject
            (string resourceKey, CultureInfo culture)
        {
            return null;
        }


        IResourceReader IResourceProvider.ResourceReader
        {
            get
            {
                return null;
            }
        }
    }

    public class CustomDesignTimeLocalResourceWriter : IDesignTimeResourceWriter
    {
        void IResourceWriter.AddResource(string name, byte[] value){}
        void IResourceWriter.AddResource(string name, string value){}
        void IResourceWriter.AddResource(string name, object value){}
        void IResourceWriter.Close() { }
        void IResourceWriter.Generate() { }
        void IDisposable.Dispose() { }
        string IDesignTimeResourceWriter.CreateResourceKey(string resourceName, object obj)
        {
            return String.Empty;
        }
    }

    public class CustomDesignTimeGlobalResourceProvider : IResourceProvider
    {
        object IResourceProvider.GetObject
            (string resourceKey, CultureInfo culture)
        {
            return null;
        }


        IResourceReader IResourceProvider.ResourceReader
        {
            get
            {
                return null;
            }
        }
    }

}

