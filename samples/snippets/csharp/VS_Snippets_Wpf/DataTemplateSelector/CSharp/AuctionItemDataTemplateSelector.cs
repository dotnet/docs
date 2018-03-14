//<SnippetDataTemplateSelector>
using System.Windows;
using System.Windows.Controls;

namespace SDKSample
{
    public class AuctionItemDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate 
            SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is AuctionItem)
            {
                AuctionItem auctionItem = item as AuctionItem;
                Window window = Application.Current.MainWindow;

                switch (auctionItem.SpecialFeatures)
                {
                    case SpecialFeatures.None:
                        return 
                            element.FindResource("AuctionItem_None") 
                            as DataTemplate;
                    case SpecialFeatures.Color:
                        return 
                            element.FindResource("AuctionItem_Color") 
                            as DataTemplate;
                }
            }

            return null;
        }
    }


}
//</SnippetDataTemplateSelector>
