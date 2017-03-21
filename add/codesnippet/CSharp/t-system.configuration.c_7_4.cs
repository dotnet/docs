using System;
using System.Configuration;
using System.Collections;

namespace Samples.AspNet
{
    public class UrlsCollection : ConfigurationElementCollection
    {
        public UrlsCollection()
        {
            // Add one url to the collection.  This is
            // not necessary; could leave the collection 
            // empty until items are added to it outside
            // the constructor.
            UrlConfigElement url = 
                (UrlConfigElement)CreateNewElement();
            Add(url);
        }

        public override 
            ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return 

                    ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override 
            ConfigurationElement CreateNewElement()
        {
            return new UrlConfigElement();
        }


        protected override 
            ConfigurationElement CreateNewElement(
            string elementName)
        {
            return new UrlConfigElement(elementName);
        }


        protected override Object 
            GetElementKey(ConfigurationElement element)
        {
            return ((UrlConfigElement)element).Name;
        }


        public new string AddElementName
        {
            get
            { return base.AddElementName; }

            set
            { base.AddElementName = value; }

        }

        public new string ClearElementName
        {
            get
            { return base.ClearElementName; }

            set
            { base.ClearElementName = value; }

        }

        public new string RemoveElementName
        {
            get
            { return base.RemoveElementName; }
        }

        public new int Count
        {
            get { return base.Count; }
        }


        public UrlConfigElement this[int index]
        {
            get
            {
                return (UrlConfigElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public UrlConfigElement this[string Name]
        {
            get
            {
                return (UrlConfigElement)BaseGet(Name);
            }
        }

        public int IndexOf(UrlConfigElement url)
        {
            return BaseIndexOf(url);
        }

        public void Add(UrlConfigElement url)
        {
            BaseAdd(url);
            // Add custom code here.
        }

        protected override void 
            BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
            // Add custom code here.
        }

        public void Remove(UrlConfigElement url)
        {
            if (BaseIndexOf(url) >= 0)
                BaseRemove(url.Name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
            // Add custom code here.
        }
    }
}