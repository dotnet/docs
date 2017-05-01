using System.Windows;
using System.Collections;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SDKSample {
    public partial class DPClearValue {
//<SnippetIterateLocalValuesAndClear>        
        void RestoreDefaultProperties(object sender, RoutedEventArgs e)
        {
            UIElementCollection uic = Sandbox.Children;
            foreach (Shape uie in uic)
            {
                LocalValueEnumerator locallySetProperties = uie.GetLocalValueEnumerator();
                while (locallySetProperties.MoveNext())
                {
                    DependencyProperty propertyToClear = locallySetProperties.Current.Property;
                    if (!propertyToClear.ReadOnly) { uie.ClearValue(propertyToClear); }
                }
            }
        }
//</SnippetIterateLocalValuesAndClear>
        void MakeEverythingRed(object sender, RoutedEventArgs e)
        {
            UIElementCollection uic = Sandbox.Children;
            foreach (Shape uie in uic) {uie.Fill = new SolidColorBrush(Colors.Red);}
        }
    }
}