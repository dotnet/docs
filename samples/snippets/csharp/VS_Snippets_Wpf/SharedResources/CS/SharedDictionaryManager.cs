using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ElementResourcesCustomControlLibrary
{
    //<Snippet3>
    internal static class SharedDictionaryManager
    {
        internal static ResourceDictionary SharedDictionary
        {
            get
            {
                if (_sharedDictionary == null)
                {
                    System.Uri resourceLocater =
                        new System.Uri("/ElementResourcesCustomControlLibrary;component/Dictionary1.xaml",
                                        System.UriKind.Relative);

                    _sharedDictionary =
                        (ResourceDictionary)Application.LoadComponent(resourceLocater);
                }

                return _sharedDictionary;
            }
        }

        private static ResourceDictionary _sharedDictionary;
    }
    //</Snippet3>
}
