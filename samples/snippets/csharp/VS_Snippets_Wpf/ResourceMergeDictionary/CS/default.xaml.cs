using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Markup;
using System.Windows.Automation;

namespace SDKSamples
{
    public partial class ResourceMerge
    {
        ResourceDictionary _rd;
        string _rdFileName = "myresourcedictionary3.xaml";

        ResourceDictionary CreateOrLoadRD()
        {
            FileInfo fi = new FileInfo(_rdFileName);
            if (!fi.Exists)
            {
                ResourceDictionary rd = new ResourceDictionary();
                root.Resources.MergedDictionaries.Add(rd);
                FileStream fs = new FileStream(_rdFileName, FileMode.Create);
                XamlWriter.Save(rd, fs);
                fs.Close();
                return rd;
            }
            else {
                FileStream fs = new FileStream(_rdFileName, FileMode.Open);
                ResourceDictionary rd = (ResourceDictionary)XamlReader.Load(fs);
                root.Resources.MergedDictionaries.Add(rd);
                fs.Close();
                return rd;
            }
        }
        void ChangeRD(ResourceDictionary rd, string newKey, object newValue)
        {
            if (!rd.Contains(newKey))
            {
                rd.Add(newKey, newValue);
                SaveChange();
            }
        }
        void SaveChange()
        {
            FileStream fs = new FileStream(_rdFileName, FileMode.Open);
            XamlWriter.Save(_rd, fs);
            fs.Close();
        }
        void NewD(object sender, RoutedEventArgs e)
        {
            _rd = CreateOrLoadRD();
        }
        void Add2NewD(object sender, RoutedEventArgs e)
        {
            ChangeRD(_rd, "BodyBrush", new SolidColorBrush(Colors.Green));
        }
    }
}
