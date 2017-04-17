// File name: CustomElementCollection.cs
// Allowed snippet tags range: [51 - 70].

//<Snippet51>
using System;
using System.Configuration;
using System.Collections;

namespace Samples.AspNet
{
    public class UrlsCollection : ConfigurationElementCollection
    {
        //<Snippet52>
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
        //</Snippet52>

        //<Snippet53>
        public override 
            ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return 

                    ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }
        //</Snippet53>

        //<Snippet54>
        protected override 
            ConfigurationElement CreateNewElement()
        {
            return new UrlConfigElement();
        }
        //</Snippet54>


        //<Snippet55>
        protected override 
            ConfigurationElement CreateNewElement(
            string elementName)
        {
            return new UrlConfigElement(elementName);
        }
        //</Snippet55>


        //<Snippet56>
        protected override Object 
            GetElementKey(ConfigurationElement element)
        {
            return ((UrlConfigElement)element).Name;
        }
        //</Snippet56>


        // <Snippet57>
        public new string AddElementName
        {
            get
            { return base.AddElementName; }

            set
            { base.AddElementName = value; }

        }
        // </Snippet57>

        // <Snippet58>
        public new string ClearElementName
        {
            get
            { return base.ClearElementName; }

            set
            { base.ClearElementName = value; }

        }
        // </Snippet58>

        // <Snippet59>
        public new string RemoveElementName
        {
            get
            { return base.RemoveElementName; }
        }
        // </Snippet59>

        //<Snippet60>
        public new int Count
        {
            get { return base.Count; }
        }
        //</Snippet60>


        //<Snippet61>
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
        //</Snippet61>

        //<Snippet62>
        new public UrlConfigElement this[string Name]
        {
            get
            {
                return (UrlConfigElement)BaseGet(Name);
            }
        }
        //</Snippet62>

        //<Snippet63>
        public int IndexOf(UrlConfigElement url)
        {
            return BaseIndexOf(url);
        }
        //</Snippet63>

        //<Snippet64>
        public void Add(UrlConfigElement url)
        {
            BaseAdd(url);
            // Add custom code here.
        }
        //</Snippet64>

        //<Snippet65>
        protected override void 
            BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
            // Add custom code here.
        }
        //</Snippet65>        

        //<Snippet66>
        public void Remove(UrlConfigElement url)
        {
            if (BaseIndexOf(url) >= 0)
                BaseRemove(url.Name);
        }
        //</Snippet66>

        //<Snippet67>
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }
        //</Snippet67>

        //<Snippet68>
        public void Remove(string name)
        {
            BaseRemove(name);
        }
        //</Snippet68>

        //<Snippet69>
        public void Clear()
        {
            BaseClear();
            // Add custom code here.
        }
        //</Snippet69>
    }
}
//</Snippet51>

